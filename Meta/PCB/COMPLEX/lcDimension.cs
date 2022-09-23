using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;

namespace _LC_Classis_dotnetf.Meta
{
    public class lcDimension : lcMeta
    {
        public const string cmdK = "DIMENSION";//图元标识符，DIMENSION
        public string layerid;          //所属层
        public string d;                //路径数据
        public string gId;              //元素id
        public string fontSize;         //尺寸高度
        public string locked;           //是否锁定
        public string measuring_type;   //尺寸类型
        public string font_width;       //尺寸宽度


        public lcDimension(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcDimension(string[] args) : base(args)
        {
            layerid = args[1];
            d = args[2];
            gId = args[3];
            fontSize = args[4];
            locked = args[5];
            measuring_type = args[6];
            font_width = args[7];
        }

        public static lcDimension Demo()
        {
            string sample = "DIMENSION~12~M4015.9632,3321.9632L4038.4632,3299.4632M......M 4035.5 3296.5 4045.5342 3306.5342~gge21~~0~straight~0.4";
            return new lcDimension(sample);
        }
    }
}