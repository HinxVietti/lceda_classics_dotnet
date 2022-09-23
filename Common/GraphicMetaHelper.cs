
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using _LC_Classis_dotnetf.Common;
using _LC_Classis_dotnetf.Meta;
using System.Linq;

public class GraphicMetaHelper
{

    private static bool init_started = false;
    private static bool init_finished = false;
    private static Dictionary<string, Type> _lcmeta_ts = new Dictionary<string, Type>();

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



    public static lcMeta CreateFromString(string content)
    {
        if (!init_finished)
            throw new Exception("GraphicMetaHelper Not Ready yet.");


        string[] keys = Regex.Split(content, lcSeparator.SP);
        string key = keys[0];
        if (_lcmeta_ts.ContainsKey(key))
        {
            var t = _lcmeta_ts[key];
            return Activator.CreateInstance(t, new object[] { keys }) as lcMeta;
        }
        return new lcUnknow(content);
        //switch (key)
        //{
        //    case lcArc.cmdK:
        //        return new lcArc(keys);
        //    case lcCircle.cmdK:
        //        return new lcCircle(keys);
        //    case lcPad.cmdK:
        //        return new lcPad(keys);
        //    case lcRect.cmdK:
        //        return new lcRect(keys);
        //    case lcText.cmdK:
        //        return new lcText(keys);
        //    case lcTrack.cmdK:
        //        return new lcTrack(keys);
        //    case lcSvgNode.cmdK:
        //        return new lcSvgNode(keys);
        //    default:
        //        return new lcUnknow(content);
        //}

    }
}
