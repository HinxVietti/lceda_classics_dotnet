using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;


namespace _LC_Classis_dotnetf.Meta
{
    class lcCopperarea : lcMeta
    {

        public const string cmdK = "COPPERAREA";//：图元标识符，COPPERAREA
        public string strokeWidth;//：线宽
        public string layerid;//：所属层
        public string net;//：网络
        public string pathStr;//：路径数据
        public string clearanceWidth;//：间距
        public string fillStyle;//：填充样式
        public string gId;//：元素id
        public string thermal;//：焊盘连接方式（发散 | 直连）
        public string keepIsland;//：是否保留孤岛
        public string compressData;//：铺铜压缩数据
        public string locked;//：是否锁定
        public string name;//：名称
        public string order;//：顺序
        public string gridTrackWidth;//：网格线宽
        public string gridClearance;//：网格间距
        public string toBoardOutline;//：到边框间距
        public string fabricationImprove;//：是否制造优化
        public string spoke_width;//：发散线宽

        public lcCopperarea(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcCopperarea(string[] args) : base(args)
        {
            this.strokeWidth = args[1];
            this.layerid = args[2];
            this.net = args[3];
            this.pathStr = args[4];
            this.clearanceWidth = args[5];
            this.fillStyle = args[6];
            this.gId = args[7];
            this.thermal = args[8];
            this.keepIsland = args[9];
            this.compressData = args[10];
            this.locked = args[11];
            this.name = args[12];
            this.order = args[13];
            this.gridTrackWidth = args[14];
            this.gridClearance = args[15];
            this.toBoardOutline = args[16];
            this.fabricationImprove = args[17];
            this.spoke_width = args[18];
            //this.strokeWidth = args[19];
        }

        public static lcCopperarea Demo()
        {
            string sample = "COPPERAREA~1~1~GND~M 4055 3023.5 L 4055 3060.5 L 4060 3065.5 L 4108.5 3065.5 L 4115.5 3058.5 L4115.5,3025 L4114,3023.5 Z~1~solid~gge83~spoke~none~~0~~1~1~1~1~yes~0";
            return new lcCopperarea(sample);
        }
        public override void AddOffset(float x, float y)
        {
            this.pathStr = this.pathStr.pointsAddOffsetXY_Path(x,y);
        }
    }
}
