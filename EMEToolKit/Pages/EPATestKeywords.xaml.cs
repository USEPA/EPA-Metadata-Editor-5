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
    /// Interaction logic for EPATestKeywords.xaml
    /// </summary>
    public partial class EPATestKeywords : EditorPage
    {
        string currentItemText;
        string currentItemTextNewLine;

        public EPATestKeywords()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            get { return "ListBox Test"; }
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
        //END
    }
}
