
using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;


namespace _LC_Classis_dotnetf.Meta
{
    public class lcRect : lcMeta
    {
        public const string cmdK = "RECT";//图元标识符，RECT
        public string x;//横坐标
        public string y;//纵坐标
        public string width;//宽度
        public string height;//高度
        public string layerid;//所属层
        public string gId;//元素id
        public string locked;//是否锁定
        public string strokeWidth;//线宽
        public string fill;//填充颜色
        public string transform;//偏移数据
        public string net;//网络
        public string c_etype;//c_etype属性值（自定义的用于细分图元类型的属性）

        public lcRect(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcRect(string[] args) : base(args)
        {
            this.x = args[1];
            this.y = args[2];
            this.width = args[3];
            this.height = args[4];
            this.layerid = args[5];
            this.gId = args[6];
            this.locked = args[7];
            this.strokeWidth = args[8];
            this.fill = args[9];
            this.transform = args[10];
            this.net = args[11];
            this.c_etype = args[12];
        }


        public static lcRect Demo()
        {
            return new lcRect("RECT~4065.5~3293.25~63~45.5~1~gge6~0~0~~~~");
        }

        public override void AddOffset(float x, float y)
        {
            this.x = this.x.Add(x);
            this.y = this.y.Add(y);
        }
    }
}