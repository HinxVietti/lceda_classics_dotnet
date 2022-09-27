using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;

namespace _LC_Classis_dotnetf.Meta
{
    public class lcTrack : lcMeta
    {
        public const string cmdK = "TRACK";//图元标识符，TRACK

        public string strokeWidth;// 线宽
        public string layerid;//所属层
        public string net;//网络
        public string pointArr;//坐标点数据
        public string gId;//元素id
        public string locked;//是否锁定

        public lcTrack(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcTrack(string[] args) : base(args)
        {
            this.strokeWidth = args[1];
            this.layerid = args[2];
            this.net = args[3];
            this.pointArr = args[4];
            this.gId = args[5];
            if (args.Length > 6)
                this.locked = args[6];
        }

        public static lcTrack Demo()
        {
            string sample = "TRACK~1~1~~4055.5 3348 4055.5 3346 4131.5 3270 4096 3270~gge5~0";
            return new lcTrack(sample);
        }

        public override void AddOffset(float x, float y)
        {
            this.pointArr = pointArr.pointsAddOffsetXY(x,y);
        }
    }
}