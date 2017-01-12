using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace br.corp.bonus630.layerControl
{
    public class GridLayerEventArgs : EventArgs
    {
        private List<Corel.Interop.VGCore.Layer> layerList;
        private GridLayerEventType type;
        public List<Corel.Interop.VGCore.Layer> LayerList { get{return this.layerList;} set{layerList = value;} }

        public GridLayerEventType EventType { get { return this.type; } set { this.type = value; } }
        public GridLayerEventArgs(List<Corel.Interop.VGCore.Layer> layerList,GridLayerEventType type)
        {
            this.layerList = layerList.OrderBy(r=>r.Index).ToList();
            
            this.type = type;
        }
    }
}
