using System;
using System.Text;
using Corel.Interop.VGCore;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;



namespace br.corp.bonus630.layerControl
{
    class GridLayerItem : System.Windows.Controls.Canvas
    {
        public Layer CorelLayer { get; set; }
        private System.Windows.Controls.Image visibled, printed, editabled, selectebled;
        private TextBox label;
        private BitmapResources bitmaps;
        private bool scalable = false;
        private ToolTip tooltip;

        public GridLayerItem(Layer corelLayer, BitmapResources bitmaps, bool scalable): base()
        {
            this.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255,255,255,255));
           
            tooltip = new ToolTip();
            tooltip.StaysOpen = false;
            this.scalable = scalable;
            this.CorelLayer = corelLayer;
            this.bitmaps = bitmaps;
            this.Height = 25;
            label = new TextBox();
            Canvas.SetLeft(label, 82);

            label.Text = this.CorelLayer.Name;
            label.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 100, 100));
          
            label.SetValue(Border.BorderBrushProperty, null);
            label.KeyUp += label_KeyUp;
            label.MouseUp += label_MouseUp;
            label.LostFocus += label_LostFocus;

            visibled = new System.Windows.Controls.Image();
            visibled.Width = 20;
            visibled.Height = 20;
            Canvas.SetLeft(visibled, 0);
            Canvas.SetTop(visibled, 2);
            visibled.Source = bitmaps.VisibleEnable;
            visibled.MouseUp += visibled_MouseUp;
           

            printed = new System.Windows.Controls.Image();
            printed.Width = 20;
            printed.Source = bitmaps.PrintEnable;
            Canvas.SetLeft(printed, 20);
            Canvas.SetTop(printed, 2);
            printed.MouseUp += printed_MouseUp;
           

            editabled = new System.Windows.Controls.Image();
            editabled.Width = 20;
            editabled.Source = bitmaps.EditableEnable;
            Canvas.SetLeft(editabled, 40);
            Canvas.SetTop(editabled, 2);
            editabled.MouseUp += editabled_MouseUp;
          


            selectebled = new System.Windows.Controls.Image();
            selectebled.Width = 20;
            selectebled.Source = bitmaps.SelectionEnable;
            Canvas.SetLeft(selectebled, 60);
            Canvas.SetTop(selectebled, 2);
           
           selectebled.MouseUp += selectebled_MouseUp;
        

            Label l = new Label();
            l.Content = "oi";

            if (scalable)
            {
                Canvas.SetLeft(l, 80);
                Canvas.SetTop(l, 2);
            }

            this.Children.Add(visibled);
            this.Children.Add(label);
            this.Children.Add(printed);
            this.Children.Add(editabled);
            this.Children.Add(selectebled);
            this.GridLayerChange(corelLayer);
          

        }

        void label_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.CorelLayer.Name = label.Text;
            this.CorelLayer.Activate();
            e.Handled = false;
        }

        

        protected override void OnMouseUp(System.Windows.Input.MouseButtonEventArgs e)
        {
            this.CorelLayer.Activate();
            this.GridLayerActive(true);
            //System.Windows.Point mousePosition = e.GetPosition(this);

            //if (mousePosition.X > 60 && mousePosition.X < 80 && mousePosition.Y > 2 && mousePosition.Y < 22)
            //{
            //    foreach (Shape shape in this.CorelLayer.Shapes)
            //    {
            //        shape.AddToSelection();
            //    }
                
            //}
            //else if (mousePosition.X > 0 && mousePosition.X < 20 && mousePosition.Y > 2 && mousePosition.Y < 22)
            //{

            //}
            //else if (mousePosition.X > 20 && mousePosition.X < 40 && mousePosition.Y > 2 && mousePosition.Y < 22)
            //{

            //}
            //else if (mousePosition.X > 40 && mousePosition.X < 60 && mousePosition.Y > 2 && mousePosition.Y < 22)
            //{

            //}
           
          
            Debug.WriteLine("E source-" + e.Source.ToString());
            Debug.WriteLine("E originalsource-" + e.OriginalSource.ToString());
           // Debug.WriteLine("sender-" + sender.ToString());
        }
       
       
        public void GridLayerChange(Layer corelLayer)
        {
            if (corelLayer.Visible)
                visibled.Source = bitmaps.VisibleEnable;
            else
                visibled.Source = bitmaps.VisibleDisable;
            if (corelLayer.Printable)
                printed.Source = bitmaps.PrintEnable;
            else
                printed.Source = bitmaps.PrintDisable;
            if (corelLayer.Editable)
            {
                editabled.Source = bitmaps.EditableEnable;
            }
            else
            {
                editabled.Source = bitmaps.EditableDisable;
            }
            if (corelLayer.Editable && corelLayer.Visible)
            {
                selectebled.IsEnabled = true;
                selectebled.Source = bitmaps.SelectionEnable;
            }
            else
            {
                selectebled.IsEnabled = false;
                selectebled.Source = bitmaps.SelectionDisable;
            }
            label.Text = corelLayer.Name;
            this.CorelLayer.Activate();
        }
      //  protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
        //{
        
        //    Debug.WriteLine("mouse out");
        //    base.OnMouseLeave(e);
        //    tooltip.IsOpen = false;
        //    //e.Handled = true;

        //}
        //protected override void OnMouseMove(System.Windows.Input.MouseEventArgs e)
        //{

        //    //base.OnMouseMove(e);
        //    System.Windows.Point mousePosition = e.GetPosition(this);

        //    if (mousePosition.X > 60 && mousePosition.X < 80 && mousePosition.Y > 2 && mousePosition.Y < 22)
        //    {
        //        Debug.WriteLine("mouse move X-" + mousePosition.X.ToString() + " Y-" + mousePosition.Y.ToString());
        //        tooltip.Content = "Adiciona para seleção";
        //        if (!tooltip.IsOpen)
        //            tooltip.IsOpen = true;

        //        // tooltip.Visibility = System.Windows.Visibility.Visible;
        //        // Canvas.SetLeft(tooltip,mousePosition.X + 10);
        //        // Canvas.SetTop(tooltip, mousePosition.Y + 10);
        //    }
        //    else if (mousePosition.X > 0 && mousePosition.X < 20 && mousePosition.Y > 2 && mousePosition.Y < 22)
        //    {
        //        tooltip.Content = "Visible";
        //        if (!tooltip.IsOpen)
        //            tooltip.IsOpen = true;
        //    }
        //    else if (mousePosition.X > 20 && mousePosition.X < 40 && mousePosition.Y > 2 && mousePosition.Y < 22)
        //    {
        //        tooltip.Content = "imprimir";
        //        if (!tooltip.IsOpen)
        //            tooltip.IsOpen = true;
        //    }
        //    else if (mousePosition.X > 40 && mousePosition.X < 60 && mousePosition.Y > 2 && mousePosition.Y < 22)
        //    {
        //        tooltip.Content = "Editar";
        //        if (!tooltip.IsOpen)
        //            tooltip.IsOpen = true;
        //    }
        //    else
        //        tooltip.IsOpen = false;
        //    e.Handled = true;
        //}
        public bool GridCheckLayer(Layer corelLayer)
        {
            if (corelLayer.Equals(this.CorelLayer))
                return true;
            else
                return false;
        }

        

        void label_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            label.IsEnabled = true;
            e.Handled = true;
        }

        void label_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                this.CorelLayer.Name = label.Text;
                
            }
            e.Handled = true;
        }

        void printed_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.CorelLayer.Printable = !this.CorelLayer.Printable;
            GridLayerChange(this.CorelLayer);
            e.Handled = true;
        }

        void visibled_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.CorelLayer.Visible = !this.CorelLayer.Visible;
            GridLayerChange(this.CorelLayer);
            e.Handled = true;
        }

        void editabled_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.CorelLayer.Editable = !this.CorelLayer.Editable;
            GridLayerChange(this.CorelLayer);
            e.Handled = true;
        }

        void selectebled_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
          
            foreach (Shape shape in this.CorelLayer.Shapes)
            {
                shape.AddToSelection();
            }
            this.CorelLayer.Activate();
            e.Handled = true;
        }


        internal void GridLayerActive(bool p)
        {
            if (p)
            {
                label.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 100, 100));
                CorelLayer.Activate();
            }
            else
                label.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
        }
        internal void GridLayerActive(Layer corelLayerActive)
        {
            foreach (object item in (this.Parent as StackPanel).Children)
            {
                if (item.GetType() == typeof(GridLayerItem))
                {
                     GridLayerItem grid = item as GridLayerItem;
                    grid.GridLayerActive(grid.GridCheckLayer(corelLayerActive));
                   
                 
                }
            }
        }
       
    }
}
