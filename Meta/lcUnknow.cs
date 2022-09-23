using _LC_Classis_dotnetf.Common;
using System.Text.RegularExpressions;


namespace _LC_Classis_dotnetf.Meta
{
    public class lcUnknow : lcMeta
    {
        public readonly string Origin;

        public lcUnknow(string content) : this(Regex.Split(content, lcSeparator.SP))
        {
            Origin = content;
        }

        public lcUnknow(string[] args) : base(args)
        {

        }
    }
}