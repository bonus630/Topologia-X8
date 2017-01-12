using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

using c = Corel.Interop.VGCore;

namespace br.corp.bonus630.layerControl
{
    
    public class GridLayer : StackPanel
    {
        private c.Application corelApp;
        BitmapResources bitmapsResources;
        GridLayerEventController gridController;
        
        //<StackPanel HorizontalAlignment="Left"  Margin="0,16,0,0" VerticalAlignment="Top" MinWidth="225" Orientation="Vertical"  >

        //                </StackPanel>
        public GridLayer(c.Application app)
        {
            this.corelApp = app;
            this.bitmapsResources = new BitmapResources();
            this.gridController = new GridLayerEventController(app);
           
            this.gridController.LayerListGet += gridController_LayerListGet;
        }

        public void DeleteLayer()
        {
            try
            {
                corelApp.ActiveLayer.Delete();
            }
            catch { }
        }
        public void CreateLayer()
        {
            try
            {
                Corel.Interop.VGCore.Layer layer = corelApp.ActiveDocument.ActivePage.CreateLayer("Nova Camada");
                layer.Activate();
            }
            catch { }
        }

        void gridController_LayerListGet(GridLayerEventArgs e)
        {
            
            if (e.EventType == GridLayerEventType.List)
            {
                this.Children.Clear();
                
                for (int i = 0; i < e.LayerList.Count; i++)
                {
                    GridLayerItem grid = new GridLayerItem(e.LayerList[i], bitmapsResources, false);

                    this.Children.Add(grid);
                    if(i!=e.LayerList.Count-1)
                        this.Children.Add(new Separator());
                }
                (this.Children[0] as GridLayerItem).GridLayerActive(corelApp.ActiveLayer);
                
            }
            if (e.EventType == GridLayerEventType.Add)
            {
                if (this.Children[this.Children.Count - 1].GetType() == typeof(GridLayerItem)) 
                    this.Children.Add(new Separator());
                GridLayerItem grid = new GridLayerItem(e.LayerList[0], bitmapsResources, false);

                this.Children.Add(grid);
                grid.GridLayerActive(e.LayerList[0]);
                
                
            }
            if (e.EventType == GridLayerEventType.Change)
            {
                 for (int i = 0; i < this.Children.Count; i++)
                 {
                     if (this.Children[i].GetType() == typeof(GridLayerItem))
                     {
                         
                         if ((this.Children[i] as GridLayerItem).GridCheckLayer(e.LayerList[0]))
                             (this.Children[i] as GridLayerItem).GridLayerActive(true);
                         else
                             (this.Children[i] as GridLayerItem).GridLayerActive(false);
                     }

                 }
                
            }
           
        }

  
    }
}
