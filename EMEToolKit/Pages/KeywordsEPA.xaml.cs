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
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for KeywordsEPA.xaml
    /// </summary>
    public partial class KeywordsEPA : EditorPage
    {
        public KeywordsEPA()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            get { return Properties.Resources.LBL_ESRI_KEYWORDS; }
        }
    }
}
