using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;

namespace _LC_Classis_dotnetf.Meta
{
    class lcHole : lcMeta
    {
        public const string cmdK = "HOLE";//：图元标识符，HOLE
        public string x;//：横坐标
        public string y;//：纵坐标
        public string holeR;//：孔直径
        public string gId;//：元素id
        public string locked;//：是否锁定

        public lcHole(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcHole(string[] args) : base(args)
        {
            this.x = args[1];
            this.y = args[2];
            this.holeR = args[3];
            this.gId = args[4];
            this.locked = args[5];
        }

        public static lcHole Demo()
        {
            string sample = "HOLE~4041.5~3309~4~gge15~0";
            return new lcHole(sample);
        }


        public override void AddOffset(float x, float y)
        {
            this.x = this.x.Add(x);
            this.y = this.y.Add(y);
        }
    }
}
