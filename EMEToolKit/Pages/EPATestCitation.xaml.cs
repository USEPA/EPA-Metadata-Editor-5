using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ESRI.ArcGIS.Metadata.Editor.Pages;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for EPATestCitation.xaml
    /// </summary>
    /// public partial class EPATestCitation : EditorPage

    public partial class EPATestCitation : EditorPage
    {
        private List<string> _listThemeK = new List<string>();

        public EPATestCitation()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            get { return "EME Test Citation"; }
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

        private void tbxMDEpaThemeK_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void chbxEpaThemekey_Checked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            //_listThemeK.Remove(xmlCheckBox.InnerText);
            //ListBox liBox = (ListBox)lbxDataIdInfo;
            //foreach (var lbItem in liBox.Items)
            //{
            //    var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
            //    var lbChildren = AllChildren(lbCont);
            //    var lbName = "tbxMetadataEpaK";
            //    var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
            //    lbCtrl.Text = "";

            //    foreach (string s in _listThemeK)
            //    {
            //        lbCtrl.Text += s + System.Environment.NewLine;
            //        lbCtrl.Focus();
            //        cbx.Focus();
            //    }
            //    lbCtrl.Focus();
            //}
        }

        private void chbxEpaThemekey_Unchecked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            //_listThemeK.Remove(xmlCheckBox.InnerText);
            //ListBox liBox = (ListBox)lbxDataIdInfo;
            //foreach (var lbItem in liBox.Items)
            //{
            //    var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
            //    var lbChildren = AllChildren(lbCont);
            //    var lbName = "tbxMetadataEpaK";
            //    var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
            //    lbCtrl.Text = "";

            //    foreach (string s in _listThemeK)
            //    {
            //        lbCtrl.Text += s + System.Environment.NewLine;
            //        lbCtrl.Focus();
            //        cbx.Focus();
            //    }
            //    lbCtrl.Focus();
            //}
        }

        private void btnLoadMDThemeK_Click(object sender, RoutedEventArgs e)
        {
            List<string> listMdEpaK = new List<string>();

            //Existing metadata keywords
            ListBox lbxExist = (ListBox)lbxDataIdInfo;
            if (lbxExist.HasItems)
            {
                foreach (var lbxExistItem in lbxExist.Items)
                {
                    var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
                    var lbxExistChildren = AllChildren(lbxExistCont);
                    var lbxExistName = "tbxMetadataEpaK";
                    var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
                    string ExistingKey = (string)lbxExistCtrl.Text;
                    listMdEpaK.Add(ExistingKey.Trim());
                }
            }

            listMdEpaK = listMdEpaK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            listMdEpaK.Sort();

            //EPA Checkbox List from: EPA Metadata Edtior 4x\Eme4xSystemFiles\EMEdb\KeywordsEPA.xml
            ListBox liBox = (ListBox)lbxDataIdInfo;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaThemekey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
                string searchKeyword = xmlTest.InnerText.Trim();

                if (listMdEpaK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

                {
                    liBoxCtrl.IsChecked = true;
                }
                else
                {
                    liBoxCtrl.IsChecked = false;
                }
            }
        }

        private void btnLoadDefaultThemeK_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxDataIdInfo;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaThemekey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
                if (xmlTest.NextSibling.InnerText.Contains("true"))
                { liBoxCtrl.IsChecked = true; }
                else
                { liBoxCtrl.IsChecked = false; }
            }
        }

        private void btnClearThemeK_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxDataIdInfo;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaThemekey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                liBoxCtrl.IsChecked = false;
            }
        }

        private void tbxMDEpaPlaceK_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void chbxEpaPlacekey_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chbxEpaPlacekey_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoadMDPlaceK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoadDefaultPlaceK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClearPlaceK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbxMDEpaUserK_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void chbxEpaUserkey_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chbxEpaUserkey_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoadMDUserK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoadDefaultUserK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClearUserK_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
