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

        //string b = "/metadata/dataIdInfo/themeKeys[thesaName/resTitle[contains(. , 'User')]]";
        //ListBox lbxMDEpaThemeK = new ListBox();
        //lbxMDEpaThemeK.SetBinding(ListBox.ItemsSourceProperty, b );

        public Keywords()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            get { return ESRI.ArcGIS.Metadata.Editor.Properties.Resources.CFG_LBL_KEYWORDS; }
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

        private void lbxEpaTK_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> MDKeywords = new List<string>();
            ListBox lbxExist = (ListBox)lbxMDEpaThemeK;
            foreach (var lbxExistItem in lbxExist.Items)
            {
                var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
                var lbxExistChildren = AllChildren(lbxExistCont);
                var lbxExistName = "tbxMDEpaThemeK";
                var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
                string ExistingKey = (string)lbxExistCtrl.Text;
                MDKeywords.Add(ExistingKey.Trim());
            }
            MDKeywords = MDKeywords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            MDKeywords.Sort();

            ListBox liBox = (ListBox)lbxEpaThemeK;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaThemekey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
                string searchKeyword = xmlTest.InnerText.Trim();

                if (MDKeywords.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

                {
                    liBoxCtrl.IsChecked = true;
                }
                else
                {
                    liBoxCtrl.IsChecked = false;
                }
            }
        }

        private void lbxPlaceK_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> MDKeywords = new List<string>();
            ListBox lbxExist = (ListBox)lbxMDEpaPlaceK;
            foreach (var lbxExistItem in lbxExist.Items)
            {
                var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
                var lbxExistChildren = AllChildren(lbxExistCont);
                var lbxExistName = "tbxMDEpaPlaceK";
                var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
                string ExistingKey = (string)lbxExistCtrl.Text;
                MDKeywords.Add(ExistingKey.Trim());
            }
            MDKeywords = MDKeywords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            MDKeywords.Sort();

            ListBox liBox = (ListBox)lbxEpaPlaceK;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaPlacekey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
                string searchKeyword = xmlTest.InnerText.Trim();

                if (MDKeywords.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

                {
                    liBoxCtrl.IsChecked = true;
                }
                else
                {
                    liBoxCtrl.IsChecked = false;
                }
            }
        }

        private void lbxUserK_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> MDKeywords = new List<string>();
            ListBox lbxExist = (ListBox)lbxMDUserThemeK;
            foreach (var lbxExistItem in lbxExist.Items)
            {
                var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
                var lbxExistChildren = AllChildren(lbxExistCont);
                var lbxExistName = "tbxMDUserThemeK";
                var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
                string ExistingKey = (string)lbxExistCtrl.Text;
                MDKeywords.Add(ExistingKey.Trim());
            }
            MDKeywords = MDKeywords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            MDKeywords.Sort();

            ListBox liBox = (ListBox)lbxEpaUserK;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaUserkey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
                string searchKeyword = xmlTest.InnerText.Trim();

                if (MDKeywords.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

                {
                    liBoxCtrl.IsChecked = true;
                }
                else
                {
                    liBoxCtrl.IsChecked = false;
                }
            }
            testFocus.Focus();
        }

        private void chbxXMLkey_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Add(xmlCheckBox.InnerText);
            _listThemeK.Sort();
            _listThemeK = _listThemeK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

            ListBox liBox = (ListBox)lbxMDEpaThemeK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaThemeK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";

                foreach (string s in _listThemeK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                }
            }
        }

        private void chbxXMLkey_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Remove(xmlCheckBox.InnerText);
            ListBox liBox = (ListBox)lbxMDEpaThemeK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaThemeK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";

                foreach (string s in _listThemeK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                    cbx.Focus();
                }
            }
        }

        private void chbxXMLPlace_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listPlaceK.Add(xmlCheckBox.InnerText);
            _listPlaceK.Sort();
            _listPlaceK = _listPlaceK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

            ListBox liBox = (ListBox)lbxMDEpaPlaceK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaPlaceK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";
                foreach (string s in _listPlaceK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                    cbx.Focus();
                }
            }
        }

        private void chbxXMLPlace_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listPlaceK.Remove(xmlCheckBox.InnerText);
            ListBox liBox = (ListBox)lbxMDEpaPlaceK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaPlaceK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";

                foreach (string s in _listPlaceK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                    cbx.Focus();
                }
            }
        }

        private void chbxEpaUserkey_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listUserK.Add(xmlCheckBox.InnerText);
            _listUserK.Sort();
            _listUserK = _listUserK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

            ListBox liBox = (ListBox)lbxMDUserThemeK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDUserThemeK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";
                foreach (string s in _listUserK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                    cbx.Focus();
                }
            }
        }

        private void chbxEpaUserkey_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listUserK.Remove(xmlCheckBox.InnerText);
            ListBox liBox = (ListBox)lbxMDUserThemeK;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDUserThemeK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";

                foreach (string s in _listUserK)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                    lbCtrl.Focus();
                    cbx.Focus();
                }
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

        private void btnClearUserK_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxEpaUserK;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "chbxEpaUserkey";
                var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
                liBoxCtrl.IsChecked = false;
            }
        }

        private void btnLoadDefaultUserK_Click(object sender, RoutedEventArgs e)
        {

        }
        //// >>> END <<<

        //private void chbxXMLPlace_Checked(object sender, RoutedEventArgs e)
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

        //    var liBox = lbxMDEpaPlaceK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMDEpaPlaceK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = "";
        //        foreach (string s in strList)
        //        {
        //            lbCtrl.Text += s + System.Environment.NewLine;
        //        }
        //    }
        //}

        //private void chbxXMLPlace_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cbx = (CheckBox)sender;
        //    string xmlStr = "";
        //    System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //    xmlStr = xmlCheckBox.InnerText;

        //    currentItemText = xmlStr;
        //    currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //    tbxEpaPlaceK.Text = tbxEpaPlaceK.Text.Replace(currentItemTextNewLine, "");

        //    var liBox = lbxMDEpaPlaceK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMDEpaPlaceK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = tbxEpaPlaceK.Text.Replace(currentItemTextNewLine, "");
        //    }
        //}

        //private void chbxXMLkey_Checked(object sender, RoutedEventArgs e)
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

        //    var liBox = lbxMDEpaThemeK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMDEpaThemeK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = "";
        //        foreach (string s in strList)
        //        {
        //            lbCtrl.Text += s + System.Environment.NewLine;
        //        }
        //    }
        //}

        //private void chbxXMLkey_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cbx = (CheckBox)sender;
        //    string xmlStr = "";
        //    System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //    xmlStr = xmlCheckBox.InnerText;

        //    currentItemText = xmlStr;
        //    currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //    tbxEpaThemeK.Text = tbxEpaThemeK.Text.Replace(currentItemTextNewLine, "");

        //    var liBox = lbxMDEpaThemeK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMDEpaThemeK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = tbxEpaThemeK.Text.Replace(currentItemTextNewLine, "");
        //    }
        //}

        //private void lbxMDEpaThemeK_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> MDKeywords = new List<string>();
        //    var lbxExist = lbxMDEpaThemeK as ListBox;
        //    foreach (var lbxExistItem in lbxExist.Items)
        //    {
        //        var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
        //        var lbxExistChildren = AllChildren(lbxExistCont);
        //        var lbxExistName = "tbxMDEpaThemeK";
        //        var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
        //        string ExistingKey = (string)lbxExistCtrl.Text;
        //        MDKeywords.Add(ExistingKey.Trim());
        //    }
        //    MDKeywords = MDKeywords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    MDKeywords.Sort();

        //    var liBox = lbxEpaThemeK as ListBox;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaThemekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        string searchKeyword = xmlTest.InnerText.Trim();

        //        if (MDKeywords.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

        //        {
        //            liBoxCtrl.IsChecked = true;
        //        }
        //        else
        //        {
        //            liBoxCtrl.IsChecked = false;
        //        }
        //    }
        //}

        //private void lbxMDEpaPlaceK_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> MDKeywords = new List<string>();
        //    var lbxExist = lbxMDEpaPlaceK as ListBox;
        //    foreach (var lbxExistItem in lbxExist.Items)
        //    {
        //        var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
        //        var lbxExistChildren = AllChildren(lbxExistCont);
        //        var lbxExistName = "tbxMDEpaPlaceK";
        //        var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
        //        string ExistingKey = (string)lbxExistCtrl.Text;
        //        MDKeywords.Add(ExistingKey.Trim());
        //    }
        //    MDKeywords = MDKeywords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    MDKeywords.Sort();

        //    var liBox = lbxEpaPlaceK as ListBox;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaPlacekey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        string searchKeyword = xmlTest.InnerText.Trim();

        //        if (MDKeywords.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

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

        //private void chbxEpaUserkey_Checked(object sender, RoutedEventArgs e)
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

        //    var liBox = lbxMDUserThemeK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMDUserThemeK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = "";
        //        foreach (string s in strList)
        //        {
        //            lbCtrl.Text += s + System.Environment.NewLine;
        //        }
        //    }
        //}

        //private void chbxEpaUserkey_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    CheckBox cbx = (CheckBox)sender;
        //    string xmlStr = "";
        //    System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //    xmlStr = xmlCheckBox.InnerText;

        //    currentItemText = xmlStr;
        //    currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //    tbxEpaUserK.Text = tbxEpaUserK.Text.Replace(currentItemTextNewLine, "");

        //    var liBox = lbxMDUserThemeK as ListBox;
        //    foreach (var lbItem in liBox.Items)
        //    {
        //        var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //        var lbChildren = AllChildren(lbCont);
        //        var lbName = "tbxMDUserThemeK";
        //        var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //        lbCtrl.Text = tbxEpaUserK.Text.Replace(currentItemTextNewLine, "");
        //    }
        //}

        //private void lbxEpaUserK_Loaded(object sender, RoutedEventArgs e)
        //{
        //    List<string> MDKeywords = new List<string>();
        //    var lbxExist = lbxMDUserThemeK as ListBox;
        //    foreach (var lbxExistItem in lbxExist.Items)
        //    {
        //        var lbxExistCont = lbxExist.ItemContainerGenerator.ContainerFromItem(lbxExistItem);
        //        var lbxExistChildren = AllChildren(lbxExistCont);
        //        var lbxExistName = "tbxMDUserThemeK";
        //        var lbxExistCtrl = (TextBox)lbxExistChildren.First(c => c.Name == lbxExistName);
        //        string ExistingKey = (string)lbxExistCtrl.Text;
        //        MDKeywords.Add(ExistingKey.Trim());
        //    }
        //    MDKeywords = MDKeywords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //    MDKeywords.Sort();

        //    var liBox = lbxEpaUserK as ListBox;
        //    foreach (var liBoxItem in liBox.Items)
        //    {
        //        var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
        //        var liBoxChildren = AllChildren(liBoxCont);
        //        var liBoxName = "chbxEpaUserkey";
        //        var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
        //        System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
        //        string searchKeyword = xmlTest.InnerText.Trim();

        //        if (MDKeywords.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

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