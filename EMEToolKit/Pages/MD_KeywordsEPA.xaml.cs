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
    /// Interaction logic for MD_KeywordsEPA.xaml
    /// </summary>
    public partial class MD_KeywordsEPA : EditorPage
    {
        private List<string> _listThemeK = new List<string>();

        public MD_KeywordsEPA()
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

        private void keywordTest()
        {
            //string[] strMDKeywords = tbxMDEpaThemeK.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (string s in strMDKeywords)
            //{
            //    _listThemeK.Add(s.Trim());
            //}
            //_listThemeK = _listThemeK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //_listThemeK.Sort();

            //ListBox liBox = (ListBox)lbxEpaThemeK;
            //foreach (var liBoxItem in liBox.Items)
            //{
            //    var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
            //    var liBoxChildren = AllChildren(liBoxCont);
            //    var liBoxName = "chbxEpaThemekey";
            //    var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
            //    System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
            //    string searchKeyword = xmlTest.InnerText.Trim();

            //    if (_listThemeK.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

            //    {
            //        liBoxCtrl.IsChecked = true;
            //    }
            //    else
            //    {
            //        liBoxCtrl.IsChecked = false;
            //    }
            //}
        }

        private void lbxEpaThemeK_Loaded(object sender, RoutedEventArgs e)
        {
            //List<string> MDKeywords = new List<string>();
            //if (tbxMDEpaThemeK.Text.Any())
            //{
            //    string[] strMDKeywords = tbxMDEpaThemeK.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //    foreach (string s in strMDKeywords)
            //    {
            //        MDKeywords.Add(s.Trim());
            //    }
            //}

            //MDKeywords = MDKeywords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //MDKeywords.Sort();

            //ListBox liBox = (ListBox)lbxEpaThemeK;
            //foreach (var liBoxItem in liBox.Items)
            //{
            //    var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
            //    var liBoxChildren = AllChildren(liBoxCont);
            //    var liBoxName = "chbxEpaThemekey";
            //    var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
            //    System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
            //    string searchKeyword = xmlTest.InnerText.Trim();

            //    if (MDKeywords.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

            //    {
            //        liBoxCtrl.IsChecked = true;
            //    }
            //    else
            //    {
            //        liBoxCtrl.IsChecked = false;
            //    }
            //}
        }

        private void chbxEpaThemekey_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Add(xmlCheckBox.InnerText);
            _listThemeK.Sort();
            _listThemeK = _listThemeK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            tbxMDEpaThemeK.Text = "";

            foreach (string s in _listThemeK)
            {
                tbxMDEpaThemeK.Text += s + System.Environment.NewLine;
                tbxMDEpaThemeK.Focus();
            }
            tbxMDEpaThemeK.Focus();
        }

        private void chbxEpaThemekey_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Remove(xmlCheckBox.InnerText);
            tbxMDEpaThemeK.Text = "";

            foreach (string s in _listThemeK)
            {
                tbxMDEpaThemeK.Text += s + System.Environment.NewLine;
                tbxMDEpaThemeK.Focus();
            }
            tbxMDEpaThemeK.Focus();
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

        private void MD_KeywordsEPA_Loaded(object sender, RoutedEventArgs e)
        {
            FillXml();

            //List<string> MDKeywords = new List<string>();
            //string[] strMDKeywords = tbxMDEpaThemeK.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (string s in strMDKeywords)
            //{
            //    MDKeywords.Add(s.Trim());
            //}
            //MDKeywords = MDKeywords.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //MDKeywords.Sort();

            //ListBox liBox = (ListBox)lbxEpaThemeK;
            //foreach (var liBoxItem in liBox.Items)
            //{
            //    var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
            //    var liBoxChildren = AllChildren(liBoxCont);
            //    var liBoxName = "chbxEpaThemekey";
            //    var liBoxCtrl = (CheckBox)liBoxChildren.First(c => c.Name == liBoxName);
            //    System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)liBoxCtrl.Content;
            //    string searchKeyword = xmlTest.InnerText.Trim();

            //    if (MDKeywords.Exists(s => s.Contains(xmlTest.InnerText.Trim())))

            //    {
            //        liBoxCtrl.IsChecked = true;
            //    }
            //    else
            //    {
            //        liBoxCtrl.IsChecked = false;
            //    }
            //}
        }

        private void btnLoadMDThemeK_Click(object sender, RoutedEventArgs e)
        {
            List<string> MDKeywords = new List<string>();
            if (tbxMDEpaThemeK.Text.Any())
            {
                string[] strMDKeywords = tbxMDEpaThemeK.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in strMDKeywords)
                {
                    MDKeywords.Add(s.Trim());
                }
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
    }
}