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
    /// Interaction logic for KeywordsEME.xaml
    /// </summary>
    public partial class KeywordsEME : EditorPage
    {
        private int _countThemeK;
        private int _countEpaThemeK;
        private int _countEpaPlaceK;
        private int _countEpaUserK;
        private string _labelEpaThemeK;

        public KeywordsEME()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            get { return ESRI.ArcGIS.Metadata.Editor.Properties.Resources.CFG_LBL_KEYWORDS; }
            //get { return "TEST: Topics & Keywords"; }
        }

        public List<Control> AllChildren(DependencyObject parent)
        {
            var _List = new List<Control> { };
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is Control)
                    _List.Add(_Child as Control);
                _List.AddRange(AllChildren(_Child));
            }
            return _List;
        }

        private void lbxKeywordEditorPage_Loaded(object sender, RoutedEventArgs e)
        {
            //ListBox liBox = (ListBox)lbxKeywordEditorPage;
            //foreach (var lbItem in liBox.Items)
            //{
            //    var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
            //    var lbChildren = AllChildren(lbCont);
            //    var lbName = "tbxMDEpaThemeK";
            //    var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
            //    lbCtrl.Text = "";
            //}
            //_labelEpaThemeK = _countEpaThemeK.ToString();
        }
    }
}