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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ESRI.ArcGIS.Metadata.Editor;
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for CI_OnlineResourceEME.xaml
    /// </summary>
    public partial class CI_OnlineResourceEME : EditorPage
    {
        private string _pathEmeDb = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Innovate! Inc\\EME Toolkit\\EMEdb\\";

        public CI_OnlineResourceEME()
        {
            InitializeComponent();
        }

        private void CI_OnlineResourceEME_Loaded(object sender, RoutedEventArgs e)
        {
            FillXml();

            var xmldp = (XmlDataProvider)this.Resources["EPAData"];
            string dbname = "OnlineProtocol.xml";
            xmldp.Source = new Uri(_pathEmeDb + dbname);
        }

        private void cboOrProtocol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboOrProtocol_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void cboOrProtocol_LostMouseCapture(object sender, MouseEventArgs e)
        {

        }
    }
}