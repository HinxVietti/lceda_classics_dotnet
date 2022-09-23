using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _LC_Classis_dotnetf.Common
{
    public class lcLayer
    {
        public string layerid;//：层的id标识
        public string name;//：层名称
        public string color;//：层颜色
        public string visible;//：层是否可见
        public string active;//：是否为当前激活层
        public string config;//：是否配置当前层
        public string transparency;//：层透明度
        public string type;//：层类型（内电层 | 信号层），内层专有配置


        public lcLayer(string content)
        {
            string[] args = System.Text.RegularExpressions.Regex.Split(content, lcSeparator.SP);

            layerid = args[0];
            name = args[1];
            color = args[2];
            visible = args[3];
            active = args[4];
            config = args[5];
            transparency = args[6];
            if (args.Length > 7)
                type = args[7];
        }

    }
}
