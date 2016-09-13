using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Metadata.Editor.Pages;


namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for EPA_ThemeKeys.xaml
    /// </summary>
    public partial class EPA_ThemeKeys : EditorPage
    {
        private List<string> _listThemeK = new List<string>();

        public EPA_ThemeKeys()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            get { return "TEST: EPA themeKeys"; }
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

        private void chbxEpaThemekey_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Add(xmlCheckBox.InnerText);
            _listThemeK.Sort();
            _listThemeK = _listThemeK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            tbxMetadataEpaK.Text = "";

            foreach (string s in _listThemeK)
            {
                tbxMetadataEpaK.Text += s + System.Environment.NewLine;
                tbxMetadataEpaK.Focus();
            }
            tbxMetadataEpaK.Focus();
        }

        private void chbxEpaThemekey_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            System.Xml.XmlElement xmlCheckBox = (System.Xml.XmlElement)cbx.Content;

            _listThemeK.Remove(xmlCheckBox.InnerText);
            tbxMetadataEpaK.Text = "";

            foreach (string s in _listThemeK)
            {
                tbxMetadataEpaK.Text += s + System.Environment.NewLine;
                tbxMetadataEpaK.Focus();
            }
            tbxMetadataEpaK.Focus();
        }

        private void btnLoadMDThemeK_Click(object sender, RoutedEventArgs e)
        {
            List<string> listMdEpaK = new List<string>();

            //Existing metadata keywords
            if (tbxMetadataEpaK.Text.Length > 0)
            {
                string[] strMDEpaK = tbxMetadataEpaK.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in strMDEpaK)
                {
                    listMdEpaK.Add(s.Trim());
                }
                listMdEpaK = listMdEpaK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                listMdEpaK.Sort();
            }

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

        private void EditorPage_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("EPA Keyword EditorPage - EditorPage.Load event");
        }

        private void lbxEpaThemeK_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("EPA Keyword Checkboxes - lbxEpaThemeK.Load event");
        }

        private void tbxMetadataEpaK_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("EPA Keyword Metadata - tbxMetadataEpaK.Load event");
            List<string> listMdEpaK = new List<string>();

            //Existing metadata keywords
            if (tbxMetadataEpaK.Text.Length > 0)
            {
                string[] strMDEpaK = tbxMetadataEpaK.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in strMDEpaK)
                {
                    listMdEpaK.Add(s.Trim());
                }
                listMdEpaK = listMdEpaK.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
                listMdEpaK.Sort();
            }

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
        }
    }
}
