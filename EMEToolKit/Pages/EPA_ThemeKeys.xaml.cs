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


namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for EPA_ThemeKeys.xaml
    /// </summary>
    public partial class EPA_ThemeKeys : EditorPage
    {
        public EPA_ThemeKeys()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            get { return "TEST EPA themeKeys"; }
        }

        private void chbxEpaThemekey_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chbxEpaThemekey_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoadMDThemeK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoadDefaultThemeK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClearThemeK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditorPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
