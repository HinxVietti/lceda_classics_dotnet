using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace _LC_Classis_dotnetf.Common
{
    public class lcFootprint : lcMeta
    {
        public const string cmdK = "LIB";
        public string x;//横坐标
        public string y;//纵坐标
        public string c_para;//自定义属性
        public string rotation;//旋转角度
        public string importFlag;//eagle导入标记
        public string gId;//元素id
        public string puuid;//绑定的pcb封装uuid
        public string uuid;//器件的uuid
        public string locked;//是否锁定
        public string bind_pcb_id;//绑定的pcb封装的id（弃用）
        public string convert_to_pcb;//是否更新到pcb
        public string add_into_bom;//是否加入bom表单

        public List<lcMeta> lcmetas = new List<lcMeta>();

        public lcFootprint(string body) : this(Regex.Split(body, lcSeparator.SP))
        { }

        public lcFootprint(string[] args) : base(args)
        {
            this.x = args[1];
            this.y = args[2];
            this.c_para = args[3];
            this.rotation = args[4];
            this.importFlag = args[5];
            this.gId = args[6];
            this.puuid = args[7];
            this.uuid = args[8];
            this.locked = args[9];
            this.bind_pcb_id = args[10];
            if (args.Length > 11)
                this.convert_to_pcb = args[11];
            if (args.Length > 12)
                this.add_into_bom = args[12];
        }


        public static lcFootprint CreateFromString(string str)
        {
            string content = str.Replace(lcSeparator.NEWLINE, System.Environment.NewLine);
            TextReader reader = new StringReader(content);
            var p1 = reader.ReadLine();
            lcFootprint lib = new lcFootprint(p1);
            string line = string.Empty;
            int count = 0;
            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                count++;
                var meta = GraphicMetaHelper.CreateFromString(line);
                if (!object.ReferenceEquals(meta, null))
                    lib.lcmetas.Add(meta);
            }
            return lib;

        }
    }
}