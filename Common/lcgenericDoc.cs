
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _LC_Classis_dotnetf.Common
{
    //如果好用，请收藏地址，帮忙分享。
    public class C_para
    {

    }

    public class Head
    {
        public string docType { get; set; }
        public string editorVersion { get; set; }
        public bool newgId { get; set; }
        public C_para c_para { get; set; }
        public int x { get; set; }
        public double y { get; set; }
        public bool hasIdFlag { get; set; }
    }

    public class BBox
    {
        public int x { get; set; }
        public double y { get; set; }
        public double width { get; set; }
        public double height { get; set; }
    }

    public class Preference
    {
        public string hideFootprints { get; set; }
        public string hideNets { get; set; }
    }

    public class DRCRULE_Profile
    {
        public int trackWidth { get; set; }
        public double clearance { get; set; }
        public double viaHoleDiameter { get; set; }
        public double viaHoleD { get; set; }
    }

    public class DRCRULE
    {
        public DRCRULE_Profile @Default { get; set; }
        public bool isRealtime { get; set; }
        public bool isDrcOnRoutingOrPlaceVia { get; set; }
        public bool checkObjectToCopperarea { get; set; }
        public bool showDRCRangeLine { get; set; }
    }

    public class NetColors
    {
    }

    public class lcgenericDoc
    {
        public Head head { get; set; }
        public string canvas { get; set; }
        public List<string> shape { get; set; }
        public List<string> layers { get; set; }
        public List<string> objects { get; set; }
        public BBox BBox { get; set; }
        public Preference preference { get; set; }
        public DRCRULE DRCRULE { get; set; }
        public NetColors netColors { get; set; }
    }

}