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

using System.Windows.Controls;
using System.ComponentModel;
using ESRI.ArcGIS.Metadata.Editor;
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages

{
    /// <summary>
    /// Interaction logic for CI_ResponsiblePartyPub.xaml
    /// </summary>
    public partial class CI_ResponsiblePartyPoC : EditorPage, INotifyPropertyChanged
    {
        public CI_ResponsiblePartyPoC()
        {
            InitializeComponent();
        }

        public override string DefaultValue
        {
            get
            {
                return Utils.ExtractResponsiblePartyLabel(this, ESRI.ArcGIS.Metadata.Editor.Properties.Resources.LBL_CI_PARTY_FORMAT);
            }

            set
            {
                // NOOP
            }
        }
    }
}
