using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;


namespace _LC_Classis_dotnetf.Meta
{
    class lcVia : lcMeta
    {
        public const string cmdK = "VIA";//：图元标识符，VIA

        public string x;//：横坐标
        public string y;//：纵坐标
        public string diameter;//：过孔直径
        public string net;//：网络
        public string holeR;//：过孔内径
        public string gId;//：元素id
        public string locked;//：是否锁定


        public lcVia(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcVia(string[] args) : base(args)
        {
            this.x = args[1];
            this.y = args[2];
            this.diameter = args[3];
            this.net = args[4];
            this.holeR = args[5];
            this.gId = args[6];
            this.locked = args[7];
        }

        public static lcVia Demo()
        {
            string sample = "VIA~4030~3308.5~2.4~~0.6~gge11~0";
            return new lcVia(sample);
        }

    }
}
