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

using System.Windows.Navigation;
using ESRI.ArcGIS.Metadata.Editor.Pages;
using System.Diagnostics;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for SpatialRepresentation.xaml
    /// </summary>
    public partial class SpatialRepresentation : EditorPage
    {
        public SpatialRepresentation()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            get { return ESRI.ArcGIS.Metadata.Editor.Properties.Resources.CFG_LBL_SPATIALREPRESENTATION; }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}