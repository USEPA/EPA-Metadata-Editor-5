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
        string currentItemTextB;

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
            // Find the right item and it's value and index
            CheckBox cbx = (CheckBox)sender;
            currentItemText = cbx.Content.ToString();
            currentItemTextB = cbx.Content.ToString() + System.Environment.NewLine;
            KeywordListBox.Items.Add(currentItemText);

            var _ListBox = lbKeywordsEPA as ListBox;
            foreach (var _ListboxItem in _ListBox.Items)
            {
                var _Container = _ListBox.ItemContainerGenerator.ContainerFromItem(_ListboxItem);
                var _Children = AllChildren(_Container);
                var _Name = "tbxKeywords";
                var _Control = (TextBox)_Children.First(c => c.Name == _Name);
                _Control.Text += currentItemTextB;
            }



            KeywordTextBox.Text += currentItemTextB;

            // Refresh data binding
            // ApplyDataBinding();
        }

        private void chbKeyword_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            currentItemText = cbx.Content.ToString();
            KeywordListBox.Items.Remove(currentItemText);

            currentItemTextB = cbx.Content.ToString() + System.Environment.NewLine;
            string s = KeywordTextBox.Text;

            //string sr = s.Replace(currentItemTextB, "");
            //KeywordTextBox.Text = sr;
            KeywordTextBox.Text = s.Replace(currentItemTextB, "");

            var _ListBox = lbKeywordsEPA as ListBox;
            foreach (var _ListboxItem in _ListBox.Items)
            {
                var _Container = _ListBox.ItemContainerGenerator.ContainerFromItem(_ListboxItem);
                var _Children = AllChildren(_Container);
                var _Name = "tbxKeywords";
                var _Control = (TextBox)_Children.First(c => c.Name == _Name);
                _Control.Text = s.Replace(currentItemTextB, "");
            }

            // Refresh data binding
            // ApplyDataBinding();            
        }

        /// <summary>
        /// Refreshes data binding
        /// </summary>
        //private void ApplyDataBinding()
        //{
        //    lbKeywordsEPA.ItemsSource = null;
        //
        //    lbKeywordsEPA.ItemsSource = "{Binding XPath=/metadata/dataIdInfo/themeKeys}";
        //}
}
}