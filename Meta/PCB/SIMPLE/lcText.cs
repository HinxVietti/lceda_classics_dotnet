
using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;

namespace _LC_Classis_dotnetf.Meta
{
    public class lcText : lcMeta
    {
        public const string cmdK = "TEXT";//图元标识符，TEXT

        public string type;//文本标记，可选值：L(普通文本) | N(器件名称) | P(器件编号) | PK(封装名)
        public string x;//横坐标   //弃用，参考pathStr
        public string y;//纵坐标   //弃用，参考pathStr
        public string strokeWidth;// 线宽
        public string rotation;//旋转角度    //弃用，参考pathStr
        public string mirror;//是否镜像      //弃用，参考pathStr
        public string layerid;//所属层
        public string net;//网络
        public string fontSize;//文字大小
        public string text;//文本值        //弃用，参考pathStr
        public string pathStr;//路径数据
        public string display;//是否显示
        public string gId;//元素id
        public string fontFamily;//字体
        public string locked;//是否锁定
        public string c_etype;//c_etype属性值（c_etype是自定义的用于细分图元类型的属性）

        public lcText(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcText(string[] args) : base(args)
        {
            this.type = args[1];
            this.x = args[2];
            this.y = args[3];
            this.strokeWidth = args[4];
            this.rotation = args[5];
            this.mirror = args[6];
            this.layerid = args[7];
            this.net = args[8];
            this.fontSize = args[9];
            this.text = args[10];
            this.pathStr = args[11];
            this.display = args[12];
            this.gId = args[13];
            this.fontFamily = args[14];
            this.locked = args[15];
            this.c_etype = args[16];
        }


        public static lcText Demo()
        {
            string sample = "TEXT~L~4081~3306.5~0.8~0~0~1~~8~TEXT~M 4083.55 3298.44 L 4083.55 3306.07 M 4081 3298.44 L 4086.09 3298.44 M 4088.49 3298.44 L 4088.49 3306.07 M 4088.49 3298.44 L 4093.22 3298.44 M 4088.49 3302.07 L 4091.4 3302.07 M 4088.49 3306.07 L 4093.22 3306.07 M 4095.62 3298.44 L 4100.71 3306.07 M 4100.71 3298.44 L 4095.62 3306.07 M 4105.65 3298.44 L 4105.65 3306.07 M 4103.11 3298.44 L 4108.2 3298.44~~gge13~~0~pinpart";
            return new lcText(sample);
        }

        public override void AddOffset(float x, float y)
        {
            this.x = this.x.Add(x);
            this.y = this.y.Add(y);
            //pathStr = pathStr.pointsAddOffsetXY_Path(x, y);
        }
    }
}