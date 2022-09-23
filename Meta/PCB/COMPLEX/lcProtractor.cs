using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;

namespace _LC_Classis_dotnetf.Meta
{
    class lcProtractor : lcMeta
    {
        public const string cmdK = "PROTRACTOR";//：图元标识符，PROTRACTOR
        public string layerid;//：所属层
        public string d;//：路径数据
        public string strokeWidth;//：线宽
        public string gId;//：元素id
        public string fontSize;//：文字大小
        public string precision;//：精度
        public string locked;//：是否锁定

        public lcProtractor(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcProtractor(string[] args) : base(args)
        {
            this.layerid = args[1];
            this.d = args[2];
            this.strokeWidth = args[3];
            this.gId = args[4];
            this.fontSize = args[5];
            this.precision = args[6];
            this.locked = args[7];
        }

        public static lcProtractor Demo()
        {
            string sample = "PROTRACTOR~12~M4051.5 3328 L4051.5 3299.4825M4051.5 3328...... L4069.39 3309.77 ~0.4~gge22~4.5~0~0";
            return new lcProtractor(sample);
        }
    }
}
