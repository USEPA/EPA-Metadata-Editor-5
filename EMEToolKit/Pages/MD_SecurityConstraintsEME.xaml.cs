/*
COPYRIGHT 1995-2009 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States.
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts Dept
380 New York Street
Redlands, California, USA 92373
email: contracts@esri.com
*/

using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Navigation;
using ESRI.ArcGIS.Metadata.Editor.Pages;
using System.Diagnostics;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for MD_SecurityConstraintsEME.xaml
    /// </summary>
    public partial class MD_SecurityConstraintsEME : EditorPage
    {
        private string _pathEmeDb = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Innovate! Inc\\EME Toolkit\\EMEdb\\";

        public MD_SecurityConstraintsEME()
        {
            InitializeComponent();
        }

        private void EditorPage_Loaded(object sender, RoutedEventArgs e)
        {
            FillXml();

            var xmldp = (XmlDataProvider)this.Resources["EPAData"];
            string dbname = "SecurityConstraints.xml";
            xmldp.Source = new Uri(_pathEmeDb + dbname);
        }

        private void cboEpaSecUseNote_LostFocus(object sender, RoutedEventArgs e)
        {
            tbxConstsUserNote.Text = cboEpaSecUseNote.Text;
            tbxConstsUserNote.Focus();
        }

        private void cboEpaSecUseNote_Loaded(object sender, RoutedEventArgs e)
        {
            if (cboEpaSecUseNote.IsVisible == true)
            {
                if (tbxConstsUserNote.Text.Any())
                {
                    cboEpaSecUseNote.Text = tbxConstsUserNote.Text;
                }
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

    }
}