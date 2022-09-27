
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using _LC_Classis_dotnetf.Common;
using _LC_Classis_dotnetf.Meta;
using System.Linq;
using System.Text;
using System.Reflection;


public delegate lcMeta lcMetaStringConstructor(string content);

public class GraphicMetaHelper
{

    private static bool init_started = false;
    private static bool init_finished = false;
    private static Dictionary<string, lcMetaStringConstructor> _lcmeta_tc = new Dictionary<string, lcMetaStringConstructor>();
    private static Dictionary<string, Type> _lcmeta_ts = new Dictionary<string, Type>();
    private static Dictionary<string, lcTypeBuilder> _lcmeta_bds = new Dictionary<string, lcTypeBuilder>();

    static GraphicMetaHelper()
    {
        Init();
    }

    public static void Init()
    {
        if (init_finished)
            return;
        if (init_started)
            return;
        init_started = true;

        //_lcmeta_bds.Add();
        _lcmeta_tc.Add("lcFootprint", lcFootprint.CreateFromString);
        _lcmeta_bds.Add(typeof(lcCanvas_PCB).Name, new lcCanvasTypeBuilder(typeof(lcCanvas_PCB)));
        _lcmeta_bds.Add(typeof(lcCanvas_SCH).Name, new lcCanvasTypeBuilder(typeof(lcCanvas_SCH)));
        _lcmeta_bds.Add(typeof(lcLayer).Name, new lcTypeBuilder(typeof(lcLayer)));
        var tmeta = typeof(lcMeta);
        var typies = tmeta.Assembly.GetTypes().Where(t => tmeta.IsAssignableFrom(t));
        string fieldName = "cmdK";
        foreach (var t in typies)
        {
            var fs = t.GetFields().Where(f => string.Equals(f.Name, fieldName)).ToArray();
            if (fs.Length > 0)
            {
                var cmdKeyField = fs[0];
                try
                {
                    object key = cmdKeyField.GetValue(null);
                    _lcmeta_ts.Add(key.ToString(), t);
                    _lcmeta_bds.Add(t.Name, new lcMetaTypeBuilder(t));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Err reg type ***{t.Name} \n{e}");
                }
            }
        }


        init_finished = true;
        init_started = false;
    }

    internal static string ConvertToString(lcLayer layer)
    {
        return _lcmeta_bds["lcLayer"].ConvertToString(layer);
    }


    #region debug

    [_LC_Classis_dotnetf.Attributes.ldDebugFeature]
    public static List<string> ListFeatures()
    {
        List<string> res = new List<string>();
        foreach (var kvp in _lcmeta_ts)
            res.Add($"{kvp.Value.Name} = {kvp.Key}");
        return res;
    }

    [_LC_Classis_dotnetf.Attributes.ldDebugFeature]
    public static List<string> ListIgnoreFreatures()
    {
        List<string> res = new List<string>();
        var tmeta = typeof(lcMeta);
        var typies = tmeta.Assembly.GetTypes().Where(t => tmeta.IsAssignableFrom(t));
        string fieldName_IGNORE = "cmdK_IG";
        foreach (var t in typies)
        {
            var fs = t.GetFields().Where(f => string.Equals(f.Name, fieldName_IGNORE)).ToArray();
            if (fs.Length > 0)
            {
                var cmdKeyField = fs[0];
                try
                {
                    object key = cmdKeyField.GetValue(null);
                    res.Add($"_ignore {t.Name} = {key}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Err reg type ***{t.Name} \n{e}");
                }
            }
        }
        return res;
    }

    #endregion

    public static string ConvertToString(lcCanvas_PCB meta)
    {
        return _lcmeta_bds["lcCanvas_PCB"].ConvertToString(meta);
    }
    public static string ConvertToString(lcMeta meta)
    {
        var type = meta.GetType();
        var builder = _lcmeta_bds[type.Name];
        return builder.ConvertToString(meta);
    }


    public static lcMeta CreateFromString(string content)
    {
        if (!init_finished)
            throw new Exception("GraphicMetaHelper Not Ready yet.");


        string[] keys = Regex.Split(content, lcSeparator.SP);
        string key = keys[0];
        if (_lcmeta_ts.ContainsKey(key))
        {
            var t = _lcmeta_ts[key];
            if (_lcmeta_tc.ContainsKey(t.Name))
                return _lcmeta_tc[t.Name].Invoke(content);
            //return Activator.CreateInstance(t, new object[] { keys }) as lcMeta;
            return Activator.CreateInstance(t, new object[] { keys }) as lcMeta;
        }
        return new lcUnknow(content);
    }

    class lcTypeBuilder
    {
        internal Type type;
        public readonly string type_Name;
        internal readonly FieldInfo[] _Fields;

        public lcTypeBuilder(Type t, FieldInfo[] fss)
        {
            this.type = t;
            this.type_Name = t.Name;
            this._Fields = fss;
        }

        public lcTypeBuilder(Type t)
        {
            this.type = t;
            this.type_Name = t.Name;

            var fields = t.GetFields();
            int length = fields.Length;
            List<FieldInfo> finfos = new List<FieldInfo>();
            for (int i = 0; i < length; i++)
            {
                var field = fields[i];
                if (field.IsLiteral || field.IsInitOnly)
                    continue;
                else
                {
                    finfos.Add(field);
                }
            }
            var last = finfos[finfos.Count - 1];
            if (last.Name == "cmdKey")
            {
                finfos.RemoveAt(finfos.Count - 1);
                finfos.Insert(0, last);
            }

            this._Fields = finfos.ToArray();
        }

        public virtual string ConvertToString(object meta)
        {
            var t = meta.GetType();
            if (string.Equals(this.type.Name, t.Name))
            {
                StringBuilder sb = new StringBuilder();
                int length = _Fields.Length;
                for (int i = 0; i < length; i++)
                {
                    var field = _Fields[i];
                    if (field.FieldType.Name == "String")
                    {
                        sb.Append(field.GetValue(meta));
                        if (i + 1 < length)
                            sb.Append(lcSeparator.SP);
                    }
                    //else if (field.FieldType.Name == "List`1")
                    //{
                    //    var metas = field.GetValue(meta) as List<lcMeta>;
                    //    foreach (var childMeta in metas)
                    //    {
                    //        sb.Append(lcSeparator.NEWLINE);
                    //        sb.Append(GraphicMetaHelper.ConvertToString(childMeta));
                    //    }
                    //    //Console.WriteLine($"--{metas.Count}");
                    //}
                }
                return sb.ToString();
            }
            throw new Exception();
        }

    }

    class lcCanvasTypeBuilder : lcTypeBuilder
    {
        public lcCanvasTypeBuilder(Type t) : base(t)
        {

        }

        public override string ConvertToString(object meta)
        {
            return $"CA~{base.ConvertToString(meta)}";
        }
    }


    class lcMetaTypeBuilder : lcTypeBuilder
    {
        public lcMetaTypeBuilder(Type t) : base(t) { }


        public override string ConvertToString(object meta)
        {
            var t = meta.GetType();
            if (string.Equals(this.type.Name, t.Name))
            {
                StringBuilder sb = new StringBuilder();
                int length = _Fields.Length;
                for (int i = 0; i < length; i++)
                {
                    var field = _Fields[i];
                    if (field.FieldType.Name == "String")
                    {
                        sb.Append(field.GetValue(meta));
                        if (i + 1 < length)
                            sb.Append(lcSeparator.SP);
                    }
                    else if (field.FieldType.Name == "List`1")
                    {
                        var metas = field.GetValue(meta) as List<lcMeta>;
                        foreach (var childMeta in metas)
                        {
                            sb.Append(lcSeparator.NEWLINE);
                            sb.Append(GraphicMetaHelper.ConvertToString(childMeta));
                        }
                        //Console.WriteLine($"--{metas.Count}");
                    }
                }
                return sb.ToString();
            }
            throw new Exception();
        }


    }
}
