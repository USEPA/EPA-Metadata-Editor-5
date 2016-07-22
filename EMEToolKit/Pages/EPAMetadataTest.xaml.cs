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
using ESRI.ArcGIS.Metadata.Editor.Pages;
using System.Data;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for EPAMetadataTest.xaml
    /// </summary>
    public partial class EPAMetadataTest : EditorPage
    {
        public EPAMetadataTest()
        {
            InitializeComponent();
        }
        public override string SidebarLabel
        {
            get
            {
                return Properties.Resources.LBL_EME_SIDEBAR;
            }
        }
    }
}