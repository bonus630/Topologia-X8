using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace br.corp.bonus630.layerControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LayerControl : UserControl
    {
        private GridLayer gridLayer;
        
        public LayerControl(Corel.Interop.VGCore.Application app)
        {
            InitializeComponent();
            gridLayer = new GridLayer(app);
            this.box_layers.Content = gridLayer;
            BitmapResources bitmapsResources = new BitmapResources();
            btn_new_layer.Source = bitmapsResources.newLayer;
            btn_delete_layer.Source = bitmapsResources.deleteLayer;
        }

        private void btn_delete_layer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            gridLayer.DeleteLayer();
            // Doc_LayerDelete(1);
        }

        private void btn_new_layer_MouseUp(object sender, MouseButtonEventArgs e)
        {
            gridLayer.CreateLayer();
            //Doc_LayerActivate(layer);
        }
    }
}
