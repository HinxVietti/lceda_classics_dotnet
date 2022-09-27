using _LC_Classis_dotnetf.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace _LC_Classis_dotnetf.Meta
{
    public class lcSvgNode : lcMeta
    {
        public const string cmdK = "SVGNODE";
        public string json;

        public lcSvgNode(string content) : this(Regex.Split(content, lcSeparator.SP)) { }

        public lcSvgNode(string[] args) : base(args)
        {
            json = args[1];
        }

        public static lcSvgNode Demo()
        {
            string sample = "SVGNODE~{\"gId\":\"gge65\",\"nodeName\":\"path\",\"nodeType\":1,\"layerid\":\"1\",\"attrs\":{\"d\":\"M 4002.49 2996.53 L 4001.2451 2998.03 L 3999.3676 2998.03 L 3997.49 2998.03 L 3997.49 2999.471 C 3997.49 3000.2635 3997.9693 3001.2082 3998.5551 3001.5703 L 3999.6203 3002.2286 L 3997.8946 3004.1354 L 3996.1689 3006.0423 L 3996.8233 3006.6967 L 3997.4777 3007.3511 L 3999.3405 3005.6653 L 4001.2032 3003.9795 L 4002.4599 3005.4938 L 4003.7166 3007.008 L 4004.6033 3006.46 C 4005.091 3006.1586 4005.49 3005.1083 4005.49 3004.126 L 4005.49 3002.34 L 4007.4981 3000.5227 L 4009.5062 2998.7054 L 4007.8431 2996.8677 C 4005.8255 2994.6383 4004.1478 2994.5324 4002.49 2996.53\",\"id\":\"gge65\",\"stroke\":\"none\",\"layerid\":\"1\"}}";
            return new lcSvgNode(sample);
        }

        public override void AddOffset(float x, float y)
        {
            var obj = LitJson.JsonMapper.ToObject<lcSvgNode_jrev>(this.json);
            string path = obj.childNodes[0].attrs.points;

            obj.childNodes[0].attrs.points = path.pointsAddOffsetXY(x, y);
            string json = LitJson.JsonMapper.ToJson(obj);
            this.json = json;
        }


        #region jsondata

        public class Attrs
        {
            /// <summary>
            /// 
            /// </summary>
            public string c_width { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string c_height { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string c_rotation { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string z { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string c_origin { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string uuid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string c_etype { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string layerid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string transform { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
        }

        public class Attrs_cNode
        {
            /// <summary>
            /// 
            /// </summary>
            public string fill { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string c_shapetype { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string points { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
        }

        public class ChildNodesItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string gId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string nodeName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int nodeType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Attrs_cNode attrs { get; set; }
        }

        public class lcSvgNode_jrev
        {
            /// <summary>
            /// 
            /// </summary>
            public string gId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string nodeName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int nodeType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string layerid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Attrs attrs { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<ChildNodesItem> childNodes { get; set; }
        }

        #endregion
    }
}