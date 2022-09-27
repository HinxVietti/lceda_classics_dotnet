
using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;
using _LC_COM = _LC_Classis_dotnetf.Meta.lcCircle;

namespace _LC_Classis_dotnetf.Meta
{
    public class lcCircle : lcMeta
    {
        public const string cmdK = "CIRCLE";//图元标识符，CIRCLE
        public string cx;//圆心x坐标
        public string cy;//圆心y坐标
        public string r;//半径
        public string strokeWidth;//线宽
        public string layerid;//所属层
        public string gId;//元素id
        public string locked;//是否锁定
        public string net;//网络
        public string transformarc;//由圆转换的两个半圆的id信息

        public lcCircle(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcCircle(string[] args) : base(args)
        {
            this.cx = args[1];
            this.cy = args[2];
            this.r = args[3];
            this.strokeWidth = args[4];
            this.layerid = args[5];
            this.gId = args[6];
            this.locked = args[7];
            this.net = args[8];
            this.transformarc = args[9];
        }

        public static _LC_COM Demo()
        {
            string sample = "CIRCLE~4193.5~3148~45.6426~1~1~gge5~0~~circle_gge8,circle_gge9";
            return new _LC_COM(sample);
        }

        public override void AddOffset(float x, float y)
        {
            float xx = float.Parse(this.cx);
            float yy = float.Parse(this.cy);
            xx += x;
            yy += y;

            this.cx = xx.ToString("0.000");
            this.cy = yy.ToString("0.000");
        }
    }
}