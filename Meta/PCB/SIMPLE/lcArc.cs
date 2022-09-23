
using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;

namespace _LC_Classis_dotnetf.Meta
{
    public class lcArc : lcMeta
    {
        public const string cmdK = "ARC";//图元标识符，ARC
        public string strokeWidth;//线宽
        public string layerid;//所属层
        public string net;//网络
        public string d;//路径数据
        public string c_helper_dots;//辅助线路径数据
        public string gId;//元素id
        public string locked;//是否锁定

        public lcArc(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcArc(string[] args) : base(args)
        {
            this.strokeWidth = args[1];
            this.layerid = args[2];
            this.net = args[3];
            this.d = args[4];
            this.c_helper_dots = args[5];
            this.gId = args[6];
            if (args.Length > 7)
                this.locked = args[7];
        }
        public static lcArc Demo()
        {
            string sample = "ARC~1~1~~M 4108.3572 3265.4999 A 53.7587 53.7587 0 1 0 4130.4018 3353.4528~~gge16~0";
            return new lcArc(sample);
        }
    }
}