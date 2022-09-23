using _LC_Classis_dotnetf.Common;
using System.IO;
using System.Text.RegularExpressions;


namespace _LC_Classis_dotnetf.Meta
{
    class lcPlaneZone : lcMeta
    {
        public const string cmdK_IG = "PLANEZONE";//：图元标识符，PLANEZONE
        public string layerid;//：所属层
        public string net;//：网络
        public string fillStyle;//：填充类型
        public string gId;//：元素id

        public string gId_p;//：路径元素id
        public string pathStr;//：路径数据

        public lcPlaneZone(string content, string part2) : this(
            Regex.Split(content, lcSeparator.SP),
            Regex.Split(part2, lcSeparator.SP))
        { }

        public lcPlaneZone(string[] args, string[] args2) : base(args)
        {
            this.layerid = args[1];
            this.net = args[2];
            this.fillStyle = args[3];
            this.gId = args[4];

            this.gId_p = args2[0];
            this.pathStr = args2[1];
        }

        public static lcPlaneZone CreateFromString(string sample)
        {
            var content = sample.Replace(lcSeparator.NEWLINE, System.Environment.NewLine);
            //TextReader reader = new StringReader(content);
            //string line = string.Empty;
            string[] parts = Regex.Split(content, System.Environment.NewLine);
            return new lcPlaneZone(parts[0], parts[1]);
        }

        public static lcPlaneZone Demo()
        {
            string sample = "PLANEZONE~21~GND~solid~planeL21B0#@$planeL21B0I0~M4342.5,3232 4342.5,3169 4420.5,3169 4420.5,3232zM4375.6222,3223.2077 4375.6314,3223.2077 4376.0759,3223.2015 4376.0852,3223.2012 4376.5294,3223.1869z";
            return CreateFromString(sample);
        }

    }
}
