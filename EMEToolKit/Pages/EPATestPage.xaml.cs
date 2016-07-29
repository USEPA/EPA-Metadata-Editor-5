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
            CheckBox cbx = (CheckBox)sender;
            currentItemTextB = cbx.Content.ToString() + System.Environment.NewLine;

            KeywordTextBox.Text += currentItemTextB;

            List<string> strList = KeywordTextBox.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            strList.Sort();
            strList = strList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            KeywordTextBox.Text = "";
            foreach (string s in strList)
            {
                KeywordTextBox.Text += s + System.Environment.NewLine;
            }

            var liBox = lbKeywordsEPA as ListBox;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxKeywords";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = "";
                foreach (string s in strList)
                {
                    lbCtrl.Text += s + System.Environment.NewLine;
                }
                // lbCtrl.CaretIndex = lbCtrl.Text.Length;
                // lbCtrl.SetValue(IsFocusedProperty, true);
            }
            // lbKeywordsEPA.SetValue(IsFocusedProperty, true);
        }

        private void chbKeyword_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            currentItemTextB = cbx.Content.ToString() + System.Environment.NewLine;

            KeywordTextBox.Text = KeywordTextBox.Text.Replace(currentItemTextB, "");

            var liBox = lbKeywordsEPA as ListBox;
            foreach (var lbItem in liBox.Items)
            {
                var lbCont = liBox.ItemContainerGenerator.ContainerFromItem(lbItem);
                var lbChildren = AllChildren(lbCont);
                var lbName = "tbxKeywords";
                var lbCtrl = (TextBox)lbChildren.First(c => c.Name == lbName);
                lbCtrl.Text = KeywordTextBox.Text.Replace(currentItemTextB, "");
                // lbCtrl.CaretIndex = lbCtrl.Text.Length;
                // lbCtrl.SetValue(IsFocusedProperty, true);
            }
            // lbKeywordsEPA.SetValue(IsFocusedProperty, true);
        }

    }
}