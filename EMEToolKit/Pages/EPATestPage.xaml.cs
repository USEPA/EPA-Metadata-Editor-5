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
using System.Collections;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for EPATestPage.xaml
    /// </summary>
    public partial class EPATestPage : EditorPage
    {
        string currentItemText;
        string currentItemTextNewLine;

        public EPATestPage()
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

        public override string SidebarLabel
        {
            get { return Properties.Resources.LBL_TEST_SIDEBAR; }
        }

        private void chbKeyword_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            currentItemText = cbx.Content.ToString() + System.Environment.NewLine;

            tbxEpaThemeK.Text += currentItemText;

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

        private void chbKeyword_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            currentItemText = cbx.Content.ToString() + System.Environment.NewLine;

            tbxEpaThemeK.Text = tbxEpaThemeK.Text.Replace(currentItemText, "");

            var liBox = lbxMDEpaThemeK as ListBox;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaThemeK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = tbxEpaThemeK.Text.Replace(currentItemText, "");
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
        private void chbxXMLPlace_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            string xmlStr = "";
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
            xmlStr = xmlCheckBox.InnerText;

            currentItemText = xmlStr;
            currentItemTextNewLine = xmlStr + System.Environment.NewLine;

            tbxEPAPlaceK.Text += currentItemTextNewLine;

            List<string> strList = tbxEPAPlaceK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            strList.Sort();
            strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            tbxEPAPlaceK.Text = "";
            foreach (string s in strList)
            {
                tbxEPAPlaceK.Text += s + System.Environment.NewLine;
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

            tbxEPAPlaceK.Text = tbxEPAPlaceK.Text.Replace(currentItemTextNewLine, "");

            var liBox = lbxMDEpaPlaceK as ListBox;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaPlaceK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = tbxEPAPlaceK.Text.Replace(currentItemTextNewLine, "");
            }
        }

        private void lbxEpaThemeK_Loaded(object sender, RoutedEventArgs e)
        {
            //List<string> strList = tbxEpaThemeK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            //strList.Sort();
            //strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //tbxEpaThemeK.Text = "";
            //foreach (string s in strList)
            //{
            //    tbxEpaThemeK.Text += s + System.Environment.NewLine;
            //}

            var liBox = lbxMDEpaThemeK as ListBox;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxMDEpaPlaceK";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);

                testEpaThemeK.Text = lbCtrl.Text + System.Environment.NewLine;
                //lbCtrl.Text = "";
                //foreach (string s in strList)
                //{
                //    lbCtrl.Text += s + System.Environment.NewLine;
                //}
            }
        }
    }
}