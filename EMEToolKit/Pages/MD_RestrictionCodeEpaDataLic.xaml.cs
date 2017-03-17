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

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for MD_RestrictionCodeEpaDataLic.xaml
    /// </summary>
    public partial class MD_RestrictionCodeEpaDataLic : EditorPage
    {
        public MD_RestrictionCodeEpaDataLic()
        {
            InitializeComponent();
        }

        private void lblRestrictCd_Loaded(object sender, RoutedEventArgs e)
        {
            tbkRestrictCd.Text = "009";
            tbkRestrictName.Text = "Unrestricted License";
            tbkRestrictUrl.Text = "https://edg.epa.gov/EPA_Data_License.html";
        }
    }
}