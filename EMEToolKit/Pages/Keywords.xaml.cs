using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ESRI.ArcGIS.Metadata.Editor.Pages;
using System.Windows.Media;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for Keywords.xaml
    /// </summary>
    public partial class Keywords : EditorPage
    {
        string currentItemText;
        string currentItemTextNewLine;

        public Keywords()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            //get { return "ListView Test"; }
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

        private void chbxXMLPlace_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            string xmlStr = "";
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
            xmlStr = xmlCheckBox.InnerText;

            currentItemText = xmlStr;
            currentItemTextNewLine = xmlStr + System.Environment.NewLine;

            tbxEpaPlaceK.Text += currentItemTextNewLine;

            List<string> strList = tbxEpaPlaceK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            strList.Sort();
            strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            tbxEpaPlaceK.Text = "";
            foreach (string s in strList)
            {
                tbxEpaPlaceK.Text += s + System.Environment.NewLine;
            }

            var liBox = lbxMDEpaPlaceK as ListBox;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaPlaceK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";
                foreach (string s in strList)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                }
            }
        }

        private void chbxXMLPlace_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            string xmlStr = "";
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
            xmlStr = xmlCheckBox.InnerText;

            currentItemText = xmlStr;
            currentItemTextNewLine = xmlStr + System.Environment.NewLine;

            tbxEpaPlaceK.Text = tbxEpaPlaceK.Text.Replace(currentItemTextNewLine, "");

            var liBox = lbxMDEpaPlaceK as ListBox;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaPlaceK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = tbxEpaPlaceK.Text.Replace(currentItemTextNewLine, "");
            }
        }

        private void chbxXMLkey_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            string xmlStr = "";
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
            xmlStr = xmlCheckBox.InnerText;

            currentItemText = xmlStr;
            currentItemTextNewLine = xmlStr + System.Environment.NewLine;

            tbxEpaThemeK.Text += currentItemTextNewLine;

            List<string> strList = tbxEpaThemeK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            strList.Sort();
            strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            tbxEpaThemeK.Text = "";
            foreach (string s in strList)
            {
                tbxEpaThemeK.Text += s + System.Environment.NewLine;
            }

            var liBox = lbxMDEpaThemeK as ListBox;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaThemeK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";
                foreach (string s in strList)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                }
            }
        }

        private void chbxXMLkey_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            string xmlStr = "";
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
            xmlStr = xmlCheckBox.InnerText;

            currentItemText = xmlStr;
            currentItemTextNewLine = xmlStr + System.Environment.NewLine;

            tbxEpaThemeK.Text = tbxEpaThemeK.Text.Replace(currentItemTextNewLine, "");

            var liBox = lbxMDEpaThemeK as ListBox;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaThemeK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = tbxEpaThemeK.Text.Replace(currentItemTextNewLine, "");
            }
        }

        private void lbxMDEpaThemeK_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> MDKeywords = new List<string>();
            var lbxExist = lbxMDEpaThemeK as ListBox;
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

            var liBox = lbxEpaThemeK as ListBox;
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

        private void lbxMDEpaPlaceK_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> MDKeywords = new List<string>();
            var lbxExist = lbxMDEpaPlaceK as ListBox;
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

            var liBox = lbxEpaPlaceK as ListBox;
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
        //// >>> END <<<
        //////{
        //////    string currentItemText;
        //////    string currentItemTextNewLine;
        //////    private ListBox lbxMDEpaThemeK;
        //////    private TextBox tbxEpaThemeK;

        //////    public Keywords()
        //////    {
        //////        InitializeComponent();
        //////    }

        //////    public override string SidebarLabel
        //////    {
        //////        get { return ESRI.ArcGIS.Metadata.Editor.Properties.Resources.CFG_LBL_KEYWORDS; }
        //////    }

        //////    public List<Control> AllChildren(DependencyObject parent)
        //////    {
        //////        var _List = new List<Control> { };
        //////        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        //////        {
        //////            var _Child = VisualTreeHelper.GetChild(parent, i);
        //////            if (_Child is Control)
        //////                _List.Add(_Child as Control);
        //////            _List.AddRange(AllChildren(_Child));
        //////        }
        //////        return _List;
        //////    }

        //////    private void chbxXMLkey_Checked(object sender, RoutedEventArgs e)
        //////    {
        //////        CheckBox cbx = (CheckBox)sender;
        //////        string xmlStr = "";
        //////        System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //////        xmlStr = xmlCheckBox.InnerText;

        //////        currentItemText = xmlStr;
        //////        currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //////        tbxEpaThemeK.Text += currentItemTextNewLine;

        //////        List<string> strList = tbxEpaThemeK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        //////        strList.Sort();
        //////        strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
        //////        tbxEpaThemeK.Text = "";
        //////        foreach (string s in strList)
        //////        {
        //////            tbxEpaThemeK.Text += s + System.Environment.NewLine;
        //////        }

        //////        var liBox = lbxMDEpaThemeK as ListBox;
        //////        foreach (var lbItem in liBox.Items)
        //////        {
        //////            var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //////            var lbChildren = AllChildren(lbCont);
        //////            var lbName = "tbxMDEpaThemeK";
        //////            var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //////            lbCtrl.Text = "";
        //////            foreach (string s in strList)
        //////            {
        //////                lbCtrl.Text += s + System.Environment.NewLine;
        //////            }
        //////        }
        //////    }

        //////    private void chbxXMLkey_Unchecked(object sender, RoutedEventArgs e)
        //////    {
        //////        CheckBox cbx = (CheckBox)sender;
        //////        string xmlStr = "";
        //////        System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
        //////        xmlStr = xmlCheckBox.InnerText;

        //////        currentItemText = xmlStr;
        //////        currentItemTextNewLine = xmlStr + System.Environment.NewLine;

        //////        tbxEpaThemeK.Text = tbxEpaThemeK.Text.Replace(currentItemTextNewLine, "");

        //////        var liBox = lbxMDEpaThemeK as ListBox;
        //////        foreach (var lbItem in liBox.Items)
        //////        {
        //////            var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
        //////            var lbChildren = AllChildren(lbCont);
        //////            var lbName = "tbxMDEpaThemeK";
        //////            var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
        //////            lbCtrl.Text = tbxEpaThemeK.Text.Replace(currentItemTextNewLine, "");
        //////        }
        //////    }
    }
}