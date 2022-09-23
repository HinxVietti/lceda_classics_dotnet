using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _LC_Classis_dotnetf.Common;

namespace _LC_Classis_dotnetf
{
    public class Lcproj
    {
        public Head head { get; set; }
        public lcCanvas_PCB canvas { get; set; }
        public List<lcMeta> shape { get; set; }
        public List<lcLayer> layers { get; set; }
        public List<string> objects { get; set; }
        public BBox BBox { get; set; }
        public Preference preference { get; set; }
        public DRCRULE DRCRULE { get; set; }
        public NetColors netColors { get; set; }

        public Lcproj(lcgenericDoc doc)
        {
            this.head = doc.head;
            this.canvas = new lcCanvas_PCB(doc.canvas);
            this.shape = new List<lcMeta>();
            foreach (var shapedes in doc.shape)
                shape.Add(GraphicMetaHelper.CreateFromString(shapedes));
            this.layers = new List<lcLayer>();
            foreach (var layerdes in doc.layers)
                layers.Add(new lcLayer(layerdes));
            this.objects = new List<string>(doc.objects);
            this.BBox = doc.BBox;
            this.preference = doc.preference;
            this.DRCRULE = doc.DRCRULE;
            this.netColors = doc.netColors;

        }
    }

}
