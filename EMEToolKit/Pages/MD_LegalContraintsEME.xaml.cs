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
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using ESRI.ArcGIS.Metadata.Editor.Pages;
using System.Diagnostics;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for MD_LegalConstraintsEME.xaml
    /// </summary>
    public partial class MD_LegalConstraintsEME : EditorPage
    {
        public MD_LegalConstraintsEME()
        {
            InitializeComponent();
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

        private void btnAddSORN_Click(object sender, RoutedEventArgs e)
        {
            //tbxConstsUserNote.Text = cboEpaSecUseNote.Text;
            //tbxConstsUserNote.Focus();

            ListBox liBox = (ListBox)lbxLegalConstsUseLimit;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "tbxUseLimit";
                var liBoxCtrl = (TextBox)liBoxChildren.First(c => c.Name == liBoxName);
                liBoxCtrl.Text = "FederalRegister.gov System of Records Notice";
                liBoxCtrl.Focus();
            }
            tbxChangeFocus.Focus();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void btnAddEpaDL_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxLegalConstsUseLimit;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "tbxUseLimit";
                var liBoxCtrl = (TextBox)liBoxChildren.First(c => c.Name == liBoxName);
                liBoxCtrl.Text = "EPA Public Domain License";
                liBoxCtrl.Focus();
            }
            tbxChangeFocus.Focus();
        }

        private void AddToLocalSoRN(object sender, RoutedEventArgs e)
        {
            //add othConsts xml node
            btnAddToLocalSoRN.Tag = "Other";
            AddRecordByTagToLocal(sender, e);

            //add useLimit xml node
            btnAddToLocalSoRN.Tag = "UseLimit";
            AddRecordByTagToLocal(sender, e);

            //update useLimit content
            tbxUseLimitType.Focus();
            tbxUseLimitType.Text = "FederalRegister.gov System of Records Notice";
            tbxChangeFocus.Focus();
        }

        private void AddToLocalDataLic(object sender, RoutedEventArgs e)
        {
            //add othConsts xml node
            btnAddToLocalDataLic.Tag = "Other";
            AddRecordByTagToLocal(sender, e);
            
            //add useLimit xml node
            btnAddToLocalDataLic.Tag = "UseLimit";
            AddRecordByTagToLocal(sender, e);

            //update useLimit content
            tbxUseLimitType.Focus();
            tbxUseLimitType.Text = "EPA Public Domain License";
            tbxChangeFocus.Focus();
        }
    }
}
