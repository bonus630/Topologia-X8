using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.corp.bonus630.layerControl
{
    
    public class GridLayerEventController
    {
        private Corel.Interop.VGCore.Application corelApp;
        public delegate void LayerListEventHandler(GridLayerEventArgs e);
        private object eventLock = new object();
        private LayerListEventHandler layerListHandler;
       // private List<Corel.Interop.VGCore.Layer> prevLayerList;
        public GridLayerEventController(Corel.Interop.VGCore.Application app)
        {
            this.corelApp = app;
        }

        public event LayerListEventHandler LayerListGet
        {
            add
            {
                lock(eventLock)
                {
                    layerListHandler -= value;
                    unRegisterLayerEvents();
                    layerListHandler += value;
                    foreach (Corel.Interop.VGCore.Document doc in corelApp.Documents)
                    {
                        registerLayerEvents(doc);
                    }
                    corelApp.DocumentOpen += corelApp_DocumentOpen;
                    corelApp.DocumentNew += corelApp_DocumentNew;
                    corelApp.WindowActivate += corelApp_WindowActivate;
                }
            }
            remove 
            { 
                lock(eventLock)
                {
                    layerListHandler -= value;
                    unRegisterLayerEvents();
                }
            }
        }

        private void corelApp_WindowActivate(Corel.Interop.VGCore.Document Doc, Corel.Interop.VGCore.Window Window)
        {
            List<Corel.Interop.VGCore.Layer> layerList = new List<Corel.Interop.VGCore.Layer>();
            for (int i = 1; i <= corelApp.ActiveDocument.ActivePage.Layers.Count; i++)
            {
                layerList.Add(corelApp.ActiveDocument.ActivePage.Layers[i]);
            }
            eventDispacher(layerList,GridLayerEventType.List);
        }

        private void corelApp_DocumentNew(Corel.Interop.VGCore.Document Doc, bool FromTemplate, string Template, bool IncludeGraphics)
        {
            registerLayerEvents(Doc);
        }

        private void corelApp_DocumentOpen(Corel.Interop.VGCore.Document Doc, string FileName)
        {
            registerLayerEvents(Doc);
        }

        private void registerLayerEvents(Corel.Interop.VGCore.Document Doc)
        {
            Doc.LayerChange += Doc_LayerChange;
            Doc.LayerCreate += Doc_LayerCreate;
            Doc.LayerDelete += Doc_LayerDelete;
            Doc.LayerActivate += Doc_LayerActivate;
        }
        private void unRegisterLayerEvents()
        {
            try
            {
                foreach (Corel.Interop.VGCore.Document Doc in corelApp.Documents)
                {
                    Doc.LayerChange -= Doc_LayerChange;
                    Doc.LayerCreate -= Doc_LayerCreate;
                    Doc.LayerDelete -= Doc_LayerDelete;
                    Doc.LayerActivate -= Doc_LayerActivate;
                }
                corelApp.DocumentOpen -= corelApp_DocumentOpen;
                corelApp.DocumentNew -= corelApp_DocumentNew;
                corelApp.WindowActivate -= corelApp_WindowActivate;
            }
            catch { }
        }

        private void Doc_LayerActivate(Corel.Interop.VGCore.Layer Layer)
        {
            eventDispacher(new List<Corel.Interop.VGCore.Layer> { Layer },GridLayerEventType.Change);
        }

        private void Doc_LayerDelete(int Count)
        {
            List<Corel.Interop.VGCore.Layer> layerList = new List<Corel.Interop.VGCore.Layer>();
            for (int i = 1; i <= corelApp.ActiveDocument.ActivePage.Layers.Count; i++)
            {
                layerList.Add(corelApp.ActiveDocument.ActivePage.Layers[i]);
            }
            eventDispacher(layerList,GridLayerEventType.List);
        }

        private void Doc_LayerCreate(Corel.Interop.VGCore.Layer Layer)
        {
            eventDispacher(new List<Corel.Interop.VGCore.Layer> { Layer },GridLayerEventType.Add);
        }

        private void Doc_LayerChange(Corel.Interop.VGCore.Layer Layer)
        {
            eventDispacher(new List<Corel.Interop.VGCore.Layer> { Layer },GridLayerEventType.Change);
        }

        private void eventDispacher(List<Corel.Interop.VGCore.Layer> layerList,GridLayerEventType type)
        {
            if (layerListHandler != null)
                layerListHandler(new GridLayerEventArgs(layerList,type));
        }


    }
}
