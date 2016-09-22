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
    /// Interaction logic for EPATestPage.xaml
    /// </summary>
    /// public partial class EPATestPage : EditorPage

    public partial class EPATestPage : EditorPage
    {
        //string currentItemTextNewLine;
        private List<string> _listThemeK = new List<string>();
        private List<string> _listPlaceK = new List<string>();
        private List<string> _listUserK = new List<string>();

        //string b = "/metadata/dataIdInfo/themeKeys[thesaName/resTitle[contains(. , 'User')]]";
        //ListBox lbxMDEpaThemeK = new ListBox();
        //lbxMDEpaThemeK.SetBinding(ListBox.ItemsSourceProperty, b );

        public EPATestPage()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            get { return "EME Test Page"; }
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

                if (MDKeywords.Exists(s => s.Equals(xmlTest.InnerText.Trim())))

                {
                    liBoxCtrl.IsChecked = true;
                }
                else
                {
                    liBoxCtrl.IsChecked = false;
                }
            }
        }

        private void testEpa_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> MDKeywords = new List<string>();

            //<ListBox.ItemsSource>
            //    <Binding XPath = "/metadata/dataIdInfo/themeKeys[thesaName/resTitle[contains(. , 'EPA GIS Keyword Thesaurus')]]" />
            //</ListBox.ItemsSource>
            //<TextBox x:Name="tbxMDEpaThemeK" Text="{e:MetadataBinding XPath=bag}"/>

            // Is it possible to replace lbxMDEpaThemeK with direct binding to XML
            // If so try to use: 
            //                  string source = EPAData.Source.LocalPath;
            //                  EPAData.Document.Save(source);
            //                  add code to get/set the Source property of the XmlDataProvider
            //                  XmlDataProvider x:Key="XmlRecord"
            //                  I believe this is populated using ESRI.ArcGIS.Metadata.Editor.Utils.FillXml

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

                //System.Xml.XmlElement xmlKeyword = (System.Xml.XmlElement)lbChildren.First(c => c.Name == lbName).FindName("chbxEpaThemekey");
                //foreach (string s in _listUserK)
                //{
                //    lbCtrl.Text += s + " " + xmlKeyword.BaseURI + "test" + System.Environment.NewLine;
                //    lbCtrl.Focus();
                //}

                if (MDKeywords.Exists(s => s.Equals(xmlTest.InnerText.Trim())))

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

                if (MDKeywords.Exists(s => s.Equals(xmlTest.InnerText.Trim())))

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

                if (MDKeywords.Exists(s => s.Equals(xmlTest.InnerText.Trim())))

                {
                    liBoxCtrl.IsChecked = true;
                }
                else
                {
                    liBoxCtrl.IsChecked = false;
                }
                testFocus.Focus();
            }
        }
        
        private void chbxXMLkey_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Add(xmlCheckBox.InnerText);
            _listThemeK.Sort();
            _listThemeK = _listThemeK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            
            //List<string> strList = _listThemeK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            //strList.Sort();
            //strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //_listThemeK.Text = "";
            //foreach (string s in strList)
            //{
            //    _listThemeK.Text += s + System.Environment.NewLine;
            //}

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
            //currentItemTextNewLine = xmlCheckBox.InnerText + System.Environment.NewLine;
            //_listThemeK.Text = _listThemeK.Text.Replace(currentItemTextNewLine, "");

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
                }
            }
            //ListBox liBox = (ListBox)lbxMDEpaThemeK;
            //foreach (var lbItem in liBox.Items)
            //{
            //    var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
            //    var lbChildren = AllChildren(lbCont);
            //    var lbName = "tbxMDEpaThemeK";
            //    var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
            //    lbCtrl.Text = lbCtrl.Text.Replace(currentItemTextNewLine, "");
            //}
        }

        private void chbxXMLPlace_Checked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
            //_listPlaceK.Text += xmlCheckBox.InnerText + System.Environment.NewLine;

            //List<string> strList = _listPlaceK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            //strList.Sort();
            //strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //_listPlaceK.Text = "";
            //foreach (string s in strList)
            //{
            //    _listPlaceK.Text += s + System.Environment.NewLine;
            //}
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
                }
            }
        }

        private void chbxXMLPlace_Unchecked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
            //currentItemTextNewLine = xmlCheckBox.InnerText + System.Environment.NewLine;
            //_listPlaceK.Text = _listPlaceK.Text.Replace(currentItemTextNewLine, "");

            //ListBox liBox = (ListBox)lbxMDEpaPlaceK;
            //foreach (var lbItem in liBox.Items)
            //{
            //    var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
            //    var lbChildren = AllChildren(lbCont);
            //    var lbName = "tbxMDEpaPlaceK";
            //    var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
            //    lbCtrl.Text = lbCtrl.Text.Replace(currentItemTextNewLine, "");
            //}
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
                }
            }
        }

        private void chbxEpaUserkey_Checked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
            //_listUserK.Text += xmlCheckBox.InnerText + System.Environment.NewLine;

            //List<string> strList = _listUserK.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            //strList.Sort();
            //strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            //_listUserK.Text = "";
            //foreach (string s in strList)
            //{
            //    _listUserK.Text += s + System.Environment.NewLine;
            //}

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
                }
            }
        }

        private void chbxEpaUserkey_Unchecked(object sender, RoutedEventArgs e)
        {
            //CheckBox cbx = (CheckBox)sender;
            //System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;
            //currentItemTextNewLine = xmlCheckBox.InnerText + System.Environment.NewLine;

            //ListBox liBox = (ListBox)lbxMDUserThemeK;
            //foreach (var lbItem in liBox.Items)
            //{
            //    var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
            //    var lbChildren = AllChildren(lbCont);
            //    var lbName = "tbxMDUserThemeK";
            //    var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
            //    lbCtrl.Text = lbCtrl.Text.Replace(currentItemTextNewLine, "");
            //}
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

        private void labelXMLPath_Loaded(object sender, RoutedEventArgs e)
        {
            //labelXMLPath.Content = TryFindResource(XmlTestData);
        }
        //// >>> END <<<
    }
}