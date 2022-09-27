using _LC_Classis_dotnetf.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


internal static class InternalcHelper
{

    internal static string AddToVector2(this string str, float x, float y)
    {
        var args = str.Split(',');
        args[0] = args[0].Add(x);
        args[1] = args[1].Add(y);
        return $"{args[0]},{args[1]}";
    }

    internal static string svgNodeToSvg(this string json)
    {
        var node = LitJson.JsonMapper.ToObject<lcSvgNode.lcSvgNode_jrev>(json);

        return string.Empty;
    }

    internal static string pointsAddOffsetXY_Path(this string path, float x, float y)
    {
        Func<string, float[]> converter = str =>
        {
            string[] numstrs = str.Split(' ');
            float[] res = new float[numstrs.Length];
            for (int i = 0; i < numstrs.Length; i++)
            {
                if (float.TryParse(numstrs[i], out float _v))
                {
                    res[i] = _v;
                }
                //res[i] = (float.Parse(numstrs[i]));
            }
            return res;
        };

        float[] points = converter(path);
        for (int i = 0; i < points.Length; i++)
        {
            int cmd = i % 3;
            switch (cmd)
            {
                case 1:
                    points[i] = points[i] + x;
                    break;
                case 2:
                    points[i] = points[i] + y;
                    break;
                default:
                    break;
            }
        }

        StringBuilder sb = new StringBuilder();
        sb.Append(points[0].ToString("0.0000"));
        for (int i = 1; i < points.Length; i++)
        {
            sb.Append(' ');
            sb.Append(points[i].ToString("0.0000"));
        }
        return sb.ToString();
    }

    internal static string pointsAddOffsetXY(this string path, float x, float y)
    {
        Func<string, float[]> converter = str =>
        {
            string[] numstrs = str.Split(' ');
            float[] res = new float[numstrs.Length];
            for (int i = 0; i < numstrs.Length; i++)
            {
                res[i] = (float.Parse(numstrs[i]));
            }
            return res;
        };

        float[] points = converter(path);
        for (int i = 0; i < points.Length; i++)
        {
            bool addx = i % 2 == 0;
            if (addx)
                points[i] = points[i] + x;
            else
                points[i] = points[i] + y;
        }

        StringBuilder sb = new StringBuilder();
        sb.Append(points[0].ToString("0.0000"));
        for (int i = 1; i < points.Length; i++)
        {
            sb.Append(' ');
            sb.Append(points[i].ToString("0.0000"));
        }
        return sb.ToString();
    }


    internal static string Add(this string str, float value)
    {
        float v = float.Parse(str);
        v += value;
        return v.ToString("0.0000");
    }
}

