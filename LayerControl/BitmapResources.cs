﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace br.corp.bonus630.layerControl
{
    public class BitmapResources
    {
        public BitmapSource VisibleEnable
        {
            get
            {
                return genereteBitmapSource(layerControl.Properties.Resources.visibleEnable);
            }
           
        }

        public BitmapSource VisibleDisable
        {
            get
            {
                return genereteBitmapSource(layerControl.Properties.Resources.visibleDisable);
            }
           
        }
        public BitmapSource SelectionEnable
        {
            get
            {
                return genereteBitmapSource(layerControl.Properties.Resources.selection);
            }
            
        }
        public BitmapSource SelectionDisable
        {
            get
            {
                return genereteBitmapSource(layerControl.Properties.Resources.selectionDisable);
            }

        }
        public BitmapSource PrintEnable
        {
            get
            {
                return genereteBitmapSource(layerControl.Properties.Resources.printEnable);
            }
            
        }
        public BitmapSource PrintDisable
        {
            get
            {
                return genereteBitmapSource(layerControl.Properties.Resources.printDisable);
            }
            
        }
        public BitmapSource EditableEnable
        {
            get
            {
                return genereteBitmapSource(layerControl.Properties.Resources.editableEnable);
            }
            
        }
        public BitmapSource EditableDisable
        {
            get
            {
                return genereteBitmapSource(layerControl.Properties.Resources.editableDisable);
            }
            
        }
      
    
     
        public BitmapSource newLayer
        {
            get 
            {
                return genereteBitmapSource(layerControl.Properties.Resources.newLayer);
            }
        }
        public BitmapSource deleteLayer
        {
            get
            {
                return genereteBitmapSource(layerControl.Properties.Resources.deleteLayer);
            }
        }
        private BitmapSource genereteBitmapSource(System.Drawing.Bitmap resource)
        {
            var image = resource;
            var bitmap = new System.Drawing.Bitmap(image);
            var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),
                                                                                  IntPtr.Zero,
                                                                                  Int32Rect.Empty,
                                                                                  BitmapSizeOptions.FromEmptyOptions()
                  );

            bitmap.Dispose();
            return bitmapSource;
        }

      
    }
}
