using _LC_Classis_dotnetf.Common;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace _LC_Classis_dotnetf.Meta
{
    class lcSheet : lcMeta
    {
        public const string cmdK = "SHEET";

        public string x;//：横坐标
        public string y;//：纵坐标
        public string locked;//：是否锁定
        public string layerid;//：所属层
        public string gId;//：元素id

        public List<lcMeta> lcmetas = new List<lcMeta>();

        public lcSheet(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcSheet(string[] args) : base(args)
        {
            this.x = args[1];
            this.y = args[2];
            this.locked = args[3];
            this.layerid = args[4];
            this.gId = args[5];
        }


        public static lcSheet CreateFromString(string str)
        {
            string content = str.Replace(lcSeparator.NEWLINE, System.Environment.NewLine);
            TextReader reader = new StringReader(content);
            var p1 = reader.ReadLine();
            lcSheet lib = new lcSheet(p1);
            string line = string.Empty;
            int count = 0;
            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                count++;
                var meta = GraphicMetaHelper.CreateFromString(line);
                if (!object.ReferenceEquals(meta, null))
                    lib.lcmetas.Add(meta);
            }
           
            return lib;

        }

        public override void AddOffset(float x, float y)
        {
            this.x = this.x.Add(x);
            this.y = this.y.Add(y);
        }
    }
}
