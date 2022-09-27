
using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;

namespace _LC_Classis_dotnetf.Meta
{
    public class lcSolidregion : lcMeta
    {
        public const string cmdK = "SOLIDREGION";//图元标识符，SOLIDREGION
        public string layerid;//所属层
        public string net;//网络
        public string pathStr;//路径数据
        public string type;//类型
        public string gId;//元素id
        public string teardrop;//泪滴
        public string targetPad;//目标焊盘
        public string targetWire;//目标导线
        public string locked;//是否锁定



        public lcSolidregion(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcSolidregion(string[] args) : base(args)
        {
            this.layerid = args[1];
            this.net = args[2];
            this.pathStr = args[3];
            this.type = args[4];
            this.gId = args[5];
            this.teardrop = args[6];
            this.targetPad = args[7];
            this.targetWire = args[8];
            this.locked = args[9];
        }

        public static lcSolidregion Demo()
        {
            string sample = "SOLIDREGION~1~~M 4012 3300.5 L 4012 3317.5 L 4019.5 3325 L 4034 3325 L 4040 3319 L 4040 3308 L 4031 3299 L4019.5,3299 L4018.5,3298 Z~solid~gge20~~~~0";
            return new lcSolidregion(sample);
        }

        public override void AddOffset(float x, float y)
        {
            this.pathStr = this.pathStr.pointsAddOffsetXY_Path(x, y);
        }
    }
}