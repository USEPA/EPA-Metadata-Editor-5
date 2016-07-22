using System;
using System.Windows;
using System.Collections.Generic;
using ESRI.ArcGIS.Metadata.Editor.Pages;
using EPAMetadataEditor.AppCode;
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
