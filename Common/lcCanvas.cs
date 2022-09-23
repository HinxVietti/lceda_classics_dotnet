using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _LC_Classis_dotnetf.Common
{
    public class lcCanvas_SCH
    {
        public const string 固定标识 = "CA";//：'CA'
        public string viewWidth;//：svg元素的width属性值，zoom越大该值越大。（旧版本使用）
        public string viewHeight;//：svg元素的height属性值，zoom越大该值越大。（旧版本使用）
        public string backGround;//：背景色
        public string gridVisible;//：网格是否可见
        public string gridColor;//：网格颜色
        public string gridSize;//：网格尺寸
        public string canvasWidth;//：逻辑上的画布宽，即svg viewBox里的宽，不随zoom改变（旧版本使用）
        public string canvasHeight;//：逻辑上的画布高，即svg viewBox里的高，不随zoom改变（旧版本使用）
        public string gridStyle;//：网格样式
        public string snapSize;//：吸附的栅格尺寸
        public string unit;//：单位
        public string altSnapSize;//：alt键吸附尺寸
        public string originX;//：画布原点横坐标
        public string originY;//：画布原点纵坐标

        public lcCanvas_SCH(string content)
        {
            string[] args = System.Text.RegularExpressions.Regex.Split(content, lcSeparator.SP);
            this.viewWidth = args[1];
            this.viewHeight = args[2];
            this.backGround = args[3];
            this.gridVisible = args[4];
            this.gridColor = args[5];
            this.gridSize = args[6];
            this.canvasWidth = args[7];
            this.canvasHeight = args[8];
            this.gridStyle = args[9];
            this.snapSize = args[10];
            this.unit = args[11];
            this.altSnapSize = args[12];
            this.originX = args[13];
            this.originY = args[14];
        }
    }

    public class lcCanvas_PCB
    {
        public const string 固定标识 = "CA";//：'CA'
        public string viewWidth;//：svg元素的width属性值，zoom越大该值越大。（旧版本使用）
        public string viewHeight;//：svg元素的height属性值，zoom越大该值越大。（旧版本使用）
        public string backGround;//：背景色
        public string gridVisible;//：网格是否可见
        public string gridColor;//：网格颜色
        public string gridSize;//：网格尺寸
        public string canvasWidth;//：逻辑上的画布宽，即svg viewBox里的宽，不随zoom改变（旧版本使用）
        public string canvasHeight;//：逻辑上的画布高，即svg viewBox里的高，不随zoom改变（旧版本使用）
        public string gridStyle;//：网格样式
        public string snapSize;//：吸附的栅格尺寸
        public string unit;//：单位
        public string routingWidth;//：线宽
        public string routingAngle;//：拐角角度
        public string copperAreaDisplay;//：铺铜区是否可见
        public string altSnapSize;//：alt键吸附尺寸
        public string originX;//：画布原点横坐标
        public string originY;//：画布原点纵坐标
        public string routeConflict;//：布线冲突（忽略 | 环绕 | 阻挡）
        public string removeLoop;//：是否移除回路


        public lcCanvas_PCB(string content)
        {
            string[] args = System.Text.RegularExpressions.Regex.Split(content, lcSeparator.SP);

            this.viewWidth = args[1];
            this.viewHeight = args[2];
            this.backGround = args[3];
            this.gridVisible = args[4];
            this.gridColor = args[5];
            this.gridSize = args[6];
            this.canvasWidth = args[7];
            this.canvasHeight = args[8];
            this.gridStyle = args[9];
            this.snapSize = args[10];
            this.unit = args[11];
            this.routingWidth = args[12];
            this.routingAngle = args[13];
            this.copperAreaDisplay = args[14];
            this.altSnapSize = args[15];
            this.originX = args[16];
            this.originY = args[17];
            this.routeConflict = args[18];
            this.removeLoop = args[19];
        }
    }
}
