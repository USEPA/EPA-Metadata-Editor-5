using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ESRI.ArcGIS.Metadata.Editor.Pages;
using System.Windows.Media;
using System.Windows.Data;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for Keywords.xaml
    /// </summary>
    public partial class Keywords : EditorPage
    {
        private List<string> _listThemeK = new List<string>();
        private List<string> _listPlaceK = new List<string>();
        private List<string> _listUserK = new List<string>();

        public Keywords()
        {
            InitializeComponent();
            //MessageBox.Show("Test");
        }

        public override string SidebarLabel
        {
            //get { return ESRI.ArcGIS.Metadata.Editor.Properties.Resources.CFG_LBL_KEYWORDS; }
            get { return "TEST: Topics & Keywords"; }
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

        private void keywordsEpa_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> listMdEpaK = new List<string>();

            //Existing metadata keywords
            ListBox lbxExist = (ListBox)lbxMetadataEpaK;
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
            ListBox liBox = (ListBox)lbxEpaThemeK;
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
            #region // This logic for TextBox Metadata
            //List<string> listMdEpaK = new List<string>();
            //if (tbxMetadataEpaK.Text.Length > 0)
            //{
            //    string[] strMDEpaK = tbxMetadataEpaK.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //    foreach (string s in strMDEpaK)
            //    {
            //        listMdEpaK.Add(s.Trim());
            //    }
            //    listMdEpaK = listMdEpaK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //    listMdEpaK.Sort();
            //}

            //ListBox liBox = (ListBox)lbxEpaThemeK;
            //foreach (var liBoxItem in liBox.Items)
            //{
            //    var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
            //    var liBoxChildren = AllChildren(liBoxCont);
            //    var liBoxName = "chbxEpaThemekey";
            //    var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
            //    System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
            //    string searchKeyword = xmlTest.InnerText.Trim();

            //    if (listMdEpaK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

            //    {
            //        liBoxCtrl.IsChecked = true;
            //    }
            //    else
            //    {
            //        liBoxCtrl.IsChecked = false;
            //    }
            //}
            #endregion
        }

        //private void testUser_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> listMdUserK = new List<string>();
        //    string[] strMDUserK = testMetadataUserK.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        //    foreach (string s in strMDUserK)
        //    {
        //        listMdUserK.Add(s.Trim());
        //    }
        //    listMdUserK = listMdUserK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    listMdUserK.Sort();

        //    ListBox liBox = (ListBox)lbxEpaUserK;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaThemekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        string searchKeyword = xmlTest.InnerText.Trim();

        //        if (listMdUserK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

        //        {
        //            liBoxCtrl.IsChecked = true;
        //        }
        //        else
        //        {
        //            liBoxCtrl.IsChecked = false;
        //        }
        //    }
        //}

        //private void keywordsPlace_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> listMdPlaceK = new List<string>();
        //    string[] strMDPlaceK = tbxMetadataPlaceK.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        //    foreach (string s in strMDPlaceK)
        //    {
        //        listMdPlaceK.Add(s.Trim());
        //    }
        //    listMdPlaceK = listMdPlaceK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    listMdPlaceK.Sort();

        //    ListBox liBox = (ListBox)lbxEpaPlaceK;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaPlacekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        string searchKeyword = xmlTest.InnerText.Trim();

        //        if (listMdPlaceK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

        //        {
        //            liBoxCtrl.IsChecked = true;
        //        }
        //        else
        //        {
        //            liBoxCtrl.IsChecked = false;
        //        }
        //    }
        //}

        //private void keywordsUser_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> listMdUserK = new List<string>();
        //    string[] strMDUserK = tbxMetadataUserK.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        //    foreach (string s in strMDUserK)
        //    {
        //        listMdUserK.Add(s.Trim());
        //    }
        //    listMdUserK = listMdUserK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    listMdUserK.Sort();

        //    ListBox liBox = (ListBox)lbxEpaUserK;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaUserkey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        string searchKeyword = xmlTest.InnerText.Trim();

        //        if (listMdUserK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

        //        {
        //            liBoxCtrl.IsChecked = true;
        //        }
        //        else
        //        {
        //            liBoxCtrl.IsChecked = false;
        //        }
        //    }
        //}



        //private void lbxEpaTK_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> listMdEpaK = new List<string>();

        //    //Existing metadata keywords
        //    ListBox lbxExist = (ListBox)lbxMetadataEpaK;
        //    if (lbxExist.HasItems)
        //    {
        //        foreach (var lbxExistItem in lbxExist.Items)
        //        {
        //            var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
        //            var lbxExistChildren = AllChildren(lbxExistCont);
        //            var lbxExistName = "tbxMetadataEpaK";
        //            var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
        //            string ExistingKey = (string)lbxExistCtrl.Text;
        //            listMdEpaK.Add(ExistingKey.Trim());
        //        }
        //    }

        //    listMdEpaK = listMdEpaK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    listMdEpaK.Sort();

        //    //EPA Checkbox List from: EPA Metadata Edtior 4x\Eme4xSystemFiles\EMEdb\KeywordsEPA.xml
        //    ListBox liBox = (ListBox)lbxEpaThemeK;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaThemekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        string searchKeyword = xmlTest.InnerText.Trim();

        //        if (listMdEpaK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

        //        {
        //            liBoxCtrl.IsChecked = true;
        //        }
        //        else
        //        {
        //            liBoxCtrl.IsChecked = false;
        //        }
        //    }
        //}

        private void keywordsPlace_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> listMdPlaceK = new List<string>();

            //Existing metadata keywords
            ListBox lbxExist = (ListBox)lbxMetadataPlaceK;
            if (lbxExist.HasItems)
            {
                foreach (var lbxExistItem in lbxExist.Items)
                {
                    var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
                    var lbxExistChildren = AllChildren(lbxExistCont);
                    var lbxExistName = "tbxMetadataPlaceK";
                    var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
                    string ExistingKey = (string)lbxExistCtrl.Text;
                    listMdPlaceK.Add(ExistingKey.Trim());
                }
            }

            listMdPlaceK = listMdPlaceK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            listMdPlaceK.Sort();

            //Place Keyword List from: EPA Metadata Edtior 4x\Eme4xSystemFiles\EMEdb\KeywordsPlace.xml
            ListBox liBox = (ListBox)lbxEpaPlaceK;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaPlacekey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
                string searchKeyword = xmlTest.InnerText.Trim();

                if (listMdPlaceK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

                {
                    liBoxCtrl.IsChecked = true;
                }
                else
                {
                    liBoxCtrl.IsChecked = false;
                }
            }
        }

        private void keywordsUser_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> listMdUserK = new List<string>();

            //Existing metadata keywords
            ListBox lbxExist = (ListBox)lbxMetadataUserK;
            if (lbxExist.HasItems)
            {
                foreach (var lbxExistItem in lbxExist.Items)
                {
                    var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
                    var lbxExistChildren = AllChildren(lbxExistCont);
                    var lbxExistName = "tbxMetadataUserK";
                    var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
                    string ExistingKey = (string)lbxExistCtrl.Text;
                    listMdUserK.Add(ExistingKey.Trim());
                }
            }

            listMdUserK = listMdUserK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            listMdUserK.Sort();

            //User Keyword List from: EPA Metadata Edtior 4x\Eme4xSystemFiles\EMEdb\KeywordsUser.xml
            ListBox liBox = (ListBox)lbxEpaUserK;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxUserKey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
                string searchKeyword = xmlTest.InnerText.Trim();

                if (listMdUserK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

                {
                    liBoxCtrl.IsChecked = true;
                }
                else
                {
                    liBoxCtrl.IsChecked = false;
                }
            }
            topOfPage.Focus();
        }

        private void chbxEpaKey_Checked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            //_listThemeK.Add(xmlCheckBox.InnerText);
            //_listThemeK.Sort();
            //_listThemeK = _listThemeK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //tbxMetadataEpaK.Text = "";

            //foreach (string s in _listThemeK)
            //{
            //    tbxMetadataEpaK.Text += s + System.Environment.NewLine;
            //    tbxMetadataEpaK.Focus();
            //}
            //tbxMetadataEpaK.Focus();

            #region //Use this code if Metadata Exists in ListBox
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Add(xmlCheckBox.InnerText);
            _listThemeK.Sort();
            _listThemeK = _listThemeK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

            ListBox liBox = (ListBox)lbxMetadataEpaK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMetadataEpaK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";

                foreach (string s in _listThemeK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                }
            }
            #endregion
        }
        private void chbxEpaKey_Unchecked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            //_listThemeK.Remove(xmlCheckBox.InnerText);
            //tbxMetadataEpaK.Text = "";

            //foreach (string s in _listThemeK)
            //{
            //    tbxMetadataEpaK.Text += s + System.Environment.NewLine;
            //    tbxMetadataEpaK.Focus();
            //}
            //tbxMetadataEpaK.Focus();

            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Remove(xmlCheckBox.InnerText);
            ListBox liBox = (ListBox)lbxMetadataEpaK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMetadataEpaK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";

                foreach (string s in _listThemeK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                    cbx.Focus();
                }
                lbCtrl.Focus();
            }
        }

        private void chbxPlaceKey_Checked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            //_listPlaceK.Add(xmlCheckBox.InnerText);
            //_listPlaceK.Sort();
            //_listPlaceK = _listPlaceK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //tbxMetadataPlaceK.Text = "";

            //foreach (string s in _listPlaceK)
            //{
            //    tbxMetadataPlaceK.Text += s + System.Environment.NewLine;
            //    tbxMetadataPlaceK.Focus();
            //}
            //tbxMetadataPlaceK.Focus();

            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listPlaceK.Add(xmlCheckBox.InnerText);
            _listPlaceK.Sort();
            _listPlaceK = _listPlaceK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

            ListBox liBox = (ListBox)lbxMetadataPlaceK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMetadataPlaceK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";
                foreach (string s in _listPlaceK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                }
            }
        }
        private void chbxPlaceKey_Unchecked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            //_listPlaceK.Remove(xmlCheckBox.InnerText);
            //tbxMetadataPlaceK.Text = "";

            //foreach (string s in _listPlaceK)
            //{
            //    tbxMetadataPlaceK.Text += s + System.Environment.NewLine;
            //    tbxMetadataPlaceK.Focus();
            //}
            //tbxMetadataPlaceK.Focus();

            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listPlaceK.Remove(xmlCheckBox.InnerText);
            ListBox liBox = (ListBox)lbxMetadataPlaceK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMetadataPlaceK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";

                foreach (string s in _listPlaceK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                    cbx.Focus();
                }
                lbCtrl.Focus();
            }
        }

        private void chbxUserKey_Checked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            //_listUserK.Add(xmlCheckBox.InnerText);
            //_listUserK.Sort();
            //_listUserK = _listUserK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //tbxMetadataUserK.Text = "";

            //foreach (string s in _listUserK)
            //{
            //    tbxMetadataUserK.Text += s + System.Environment.NewLine;
            //    tbxMetadataUserK.Focus();
            //}
            //tbxMetadataUserK.Focus();

            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listUserK.Add(xmlCheckBox.InnerText);
            _listUserK.Sort();
            _listUserK = _listUserK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

            ListBox liBox = (ListBox)lbxMetadataUserK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMetadataUserK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";
                foreach (string s in _listUserK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                }
            }
        }
        private void chbxUserKey_Unchecked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            //_listUserK.Remove(xmlCheckBox.InnerText);
            //tbxMetadataUserK.Text = "";

            //foreach (string s in _listUserK)
            //{
            //    tbxMetadataUserK.Text += s + System.Environment.NewLine;
            //    tbxMetadataUserK.Focus();
            //}
            //tbxMetadataUserK.Focus();

            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listUserK.Remove(xmlCheckBox.InnerText);
            ListBox liBox = (ListBox)lbxMetadataUserK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMetadataUserK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";

                foreach (string s in _listUserK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                    cbx.Focus();
                }
                lbCtrl.Focus();
            }
        }

        private void btnLoadDefaultThemeK_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxEpaThemeK;
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
            ListBox liBox = (ListBox)lbxEpaThemeK;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaThemekey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                liBoxCtrl.IsChecked = false;
            }
        }

        private void btnLoadDefaultPlaceK_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxEpaPlaceK;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaPlacekey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
                if (xmlTest.NextSibling.InnerText.Contains("true"))
                { liBoxCtrl.IsChecked = true; }
                else
                { liBoxCtrl.IsChecked = false; }
            }
        }
        private void btnClearPlaceK_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxEpaPlaceK;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaPlacekey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                liBoxCtrl.IsChecked = false;
            }
        }

        private void btnLoadDefaultUserK_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnClearUserK_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxEpaUserK;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxUserKey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                liBoxCtrl.IsChecked = false;
            }
        }

        //// >>> END <<<

        //private void chbxPlaceKey_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cbx = (CheckBox)sender;
        //    string xmlStr = "";
        //    System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //    xmlStr = xmlCheckBox.InnerText;

        //    currentItemText = xmlStr;
        //    currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //    tbxEpaPlaceK.Text += currentItemTextNewLine;

        //    List<string> strList = tbxEpaPlaceK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        //    strList.Sort();
        //    strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    tbxEpaPlaceK.Text = "";
        //    foreach (string s in strList)
        //    {
        //        tbxEpaPlaceK.Text += s + System.Environment.NewLine;
        //    }

        //    var liBox = lbxMetadataPlaceK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMetadataPlaceK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = "";
        //        foreach (string s in strList)
        //        {
        //            lbCtrl.Text += s + System.Environment.NewLine;
        //        }
        //    }
        //}

        //private void chbxPlaceKey_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cbx = (CheckBox)sender;
        //    string xmlStr = "";
        //    System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //    xmlStr = xmlCheckBox.InnerText;

        //    currentItemText = xmlStr;
        //    currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //    tbxEpaPlaceK.Text = tbxEpaPlaceK.Text.Replace(currentItemTextNewLine, "");

        //    var liBox = lbxMetadataPlaceK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMetadataPlaceK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = tbxEpaPlaceK.Text.Replace(currentItemTextNewLine, "");
        //    }
        //}

        //private void chbxEpaKey_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cbx = (CheckBox)sender;
        //    string xmlStr = "";
        //    System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //    xmlStr = xmlCheckBox.InnerText;

        //    currentItemText = xmlStr;
        //    currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //    tbxEpaThemeK.Text += currentItemTextNewLine;

        //    List<string> strList = tbxEpaThemeK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        //    strList.Sort();
        //    strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    tbxEpaThemeK.Text = "";
        //    foreach (string s in strList)
        //    {
        //        tbxEpaThemeK.Text += s + System.Environment.NewLine;
        //    }

        //    var liBox = lbxMetadataEpaK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMetadataEpaK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = "";
        //        foreach (string s in strList)
        //        {
        //            lbCtrl.Text += s + System.Environment.NewLine;
        //        }
        //    }
        //}

        //private void chbxEpaKey_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cbx = (CheckBox)sender;
        //    string xmlStr = "";
        //    System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //    xmlStr = xmlCheckBox.InnerText;

        //    currentItemText = xmlStr;
        //    currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //    tbxEpaThemeK.Text = tbxEpaThemeK.Text.Replace(currentItemTextNewLine, "");

        //    var liBox = lbxMetadataEpaK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMetadataEpaK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = tbxEpaThemeK.Text.Replace(currentItemTextNewLine, "");
        //    }
        //}

        //private void lbxMetadataEpaK_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> listMdEpaK = new List<string>();
        //    var lbxExist = lbxMetadataEpaK as ListBox;
        //    foreach (var lbxExistItem in lbxExist.Items)
        //    {
        //        var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
        //        var lbxExistChildren = AllChildren(lbxExistCont);
        //        var lbxExistName = "tbxMetadataEpaK";
        //        var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
        //        string ExistingKey = (string)lbxExistCtrl.Text;
        //        listMdEpaK.Add(ExistingKey.Trim());
        //    }
        //    listMdEpaK = listMdEpaK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    listMdEpaK.Sort();

        //    var liBox = lbxEpaThemeK as ListBox;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaThemekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        string searchKeyword = xmlTest.InnerText.Trim();

        //        if (listMdEpaK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

        //        {
        //            liBoxCtrl.IsChecked = true;
        //        }
        //        else
        //        {
        //            liBoxCtrl.IsChecked = false;
        //        }
        //    }
        //}

        //private void lbxMetadataPlaceK_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> listMdPlaceK = new List<string>();
        //    var lbxExist = lbxMetadataPlaceK as ListBox;
        //    foreach (var lbxExistItem in lbxExist.Items)
        //    {
        //        var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
        //        var lbxExistChildren = AllChildren(lbxExistCont);
        //        var lbxExistName = "tbxMetadataPlaceK";
        //        var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
        //        string ExistingKey = (string)lbxExistCtrl.Text;
        //        listMdPlaceK.Add(ExistingKey.Trim());
        //    }
        //    listMdPlaceK = listMdPlaceK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    listMdPlaceK.Sort();

        //    var liBox = lbxEpaPlaceK as ListBox;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaPlacekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        string searchKeyword = xmlTest.InnerText.Trim();

        //        if (listMdPlaceK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

        //        {
        //            liBoxCtrl.IsChecked = true;
        //        }
        //        else
        //        {
        //            liBoxCtrl.IsChecked = false;
        //        }
        //    }
        //}

        //private void btnLoadDefaultThemeK_Click(object sender, RoutedEventArgs e)
        //{
        //    var liBox = lbxEpaThemeK as ListBox;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaThemekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        if (xmlTest.NextSibling.InnerText.Contains("true"))
        //        { liBoxCtrl.IsChecked = true; }
        //        else
        //        { liBoxCtrl.IsChecked = false; }
        //    }
        //}
        //private void btnClearThemeK_Click(object sender, RoutedEventArgs e)
        //{
        //    var liBox = lbxEpaThemeK as ListBox;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaThemekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        liBoxCtrl.IsChecked = false;
        //    }
        //}

        //private void btnLoadDefaultPlaceK_Click(object sender, RoutedEventArgs e)
        //{
        //    var liBox = lbxEpaPlaceK as ListBox;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaPlacekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        if (xmlTest.NextSibling.InnerText.Contains("true"))
        //        { liBoxCtrl.IsChecked = true; }
        //        else
        //        { liBoxCtrl.IsChecked = false; }
        //    }
        //}
        //private void btnClearPlaceK_Click(object sender, RoutedEventArgs e)
        //{
        //    var liBox = lbxEpaPlaceK as ListBox;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaPlacekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        liBoxCtrl.IsChecked = false;
        //    }
        //}

        //private void chbxUserKey_Checked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cbx = (CheckBox)sender;
        //    string xmlStr = "";
        //    System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //    xmlStr = xmlCheckBox.InnerText;

        //    currentItemText = xmlStr;
        //    currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //    tbxEpaUserK.Text += currentItemTextNewLine;

        //    List<string> strList = tbxEpaUserK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        //    strList.Sort();
        //    strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    tbxEpaUserK.Text = "";
        //    foreach (string s in strList)
        //    {
        //        tbxEpaUserK.Text += s + System.Environment.NewLine;
        //    }

        //    var liBox = lbxMetadataUserK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMetadataUserK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = "";
        //        foreach (string s in strList)
        //        {
        //            lbCtrl.Text += s + System.Environment.NewLine;
        //        }
        //    }
        //}

        //private void chbxUserKey_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cbx = (CheckBox)sender;
        //    string xmlStr = "";
        //    System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //    xmlStr = xmlCheckBox.InnerText;

        //    currentItemText = xmlStr;
        //    currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //    tbxEpaUserK.Text = tbxEpaUserK.Text.Replace(currentItemTextNewLine, "");

        //    var liBox = lbxMetadataUserK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMetadataUserK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = tbxEpaUserK.Text.Replace(currentItemTextNewLine, "");
        //    }
        //}

        //private void lbxEpaUserK_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> listMdUserK = new List<string>();
        //    var lbxExist = lbxMetadataUserK as ListBox;
        //    foreach (var lbxExistItem in lbxExist.Items)
        //    {
        //        var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
        //        var lbxExistChildren = AllChildren(lbxExistCont);
        //        var lbxExistName = "tbxMetadataUserK";
        //        var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
        //        string ExistingKey = (string)lbxExistCtrl.Text;
        //        listMdUserK.Add(ExistingKey.Trim());
        //    }
        //    listMdUserK = listMdUserK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    listMdUserK.Sort();

        //    var liBox = lbxEpaUserK as ListBox;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxUserKey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        string searchKeyword = xmlTest.InnerText.Trim();

        //        if (listMdUserK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

        //        {
        //            liBoxCtrl.IsChecked = true;
        //        }
        //        else
        //        {
        //            liBoxCtrl.IsChecked = false;
        //        }
        //    }
    }
}