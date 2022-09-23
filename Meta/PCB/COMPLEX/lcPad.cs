
using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;

namespace _LC_Classis_dotnetf.Meta
{
    public class lcPad : lcMeta
    {
        public const string cmdK = "PAD";//图元标识符，PAD
        public string shape;//焊盘形状
        public string x;//横坐标
        public string y;//纵坐标
        public string width;//宽度
        public string height;//高度
        public string layerid;//所属层
        public string net;//网络
        public string number;//编号
        public string holeR;//孔直径
        public string pointArr;//坐标点数据
        public string rotation;//旋转角度
        public string gId;//元素id
        public string holeLength;//孔长度
        public string slotPointArr;//孔的坐标点数据
        public string plated;//是否金属化
        public string locked;//是否锁定
        public string pasteexpansion;//助焊扩展
        public string solderexpansion;//阻焊扩展
        public string holeCenter;//孔中心坐标
        public lcPad(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcPad(string[] args) : base(args)
        {
            this.shape = args[1];
            this.x = args[2];
            this.y = args[3];
            this.width = args[4];
            this.height = args[5];
            this.layerid = args[6];
            this.net = args[7];
            this.number = args[8];
            this.holeR = args[9];
            this.pointArr = args[10];
            this.rotation = args[11];
            this.gId = args[12];
            this.holeLength = args[13];
            this.slotPointArr = args[14];
            this.plated = args[15];
            this.locked = args[16];
            this.pasteexpansion = args[17];
            this.solderexpansion = args[18];
            this.holeCenter = args[19];
        }
        public static lcPad Demo()
        {
            string sample = "PAD~ELLIPSE~4020~3308.5~6~6~11~~1~1.8~~0~gge5~0~~Y~0~~~4020,3308.5";
            return new lcPad(sample);
        }
    }
}