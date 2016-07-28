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
        private ArrayList myDataList = null;
        string currentItemText;
        int currentItemIndex;

        public EPATestPage()
        {
            InitializeComponent();
        }

        public override string SidebarLabel
        {
            get {return Properties.Resources.LBL_TEST_SIDEBAR;}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get data from somewhere and fill in my local ArrayList
            myDataList = LoadListBoxData();
            // Bind ArrayList with the ListBox
            LeftListBox.ItemsSource = myDataList;
        }

        private ArrayList LoadListBoxData()
        {
            ArrayList itemsList = new ArrayList();
            itemsList.Add("Agriculture");
            itemsList.Add("Air");
            itemsList.Add("Biology");
            itemsList.Add("Cleanup");
            itemsList.Add("Ufology");
            return itemsList;
        }

        private void chbKeyword_Checked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            CheckBox cbx = (CheckBox)sender;
            currentItemText = cbx.Content.ToString();
            RightListBox.Items.Add(currentItemText);
            // Need to loop through the items?
            //testTBox.Text = RightListBox.Items.ToString();
            testTBox.Text += currentItemText+System.Environment.NewLine;

            // Refresh data binding
            ApplyDataBinding();
        }


        private void chbKeyword_Unchecked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            CheckBox cbx = (CheckBox)sender;
            currentItemText = cbx.Content.ToString()+ System.Environment.NewLine;
            //RightListBox.Items.Remove(currentItemText);
            string s = testTBox.Text;
            s.Replace(currentItemText, "");
            testTBox.Text = "";
            //testTBox.Text = s;
            
            // Refresh data binding
            ApplyDataBinding();
        }

        private void chbKeyword001_Checked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = chbKeyword001.Content.ToString();

            RightListBox.Items.Add(currentItemText);

            // Refresh data binding
            ApplyDataBinding();
        }
        private void chbKeyword001_Unchecked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = chbKeyword001.Content.ToString();

            RightListBox.Items.Remove(currentItemText);

            // Refresh data binding
            ApplyDataBinding();
        }

        private void chbKeyword002_Checked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = chbKeyword002.Content.ToString();

            RightListBox.Items.Add(currentItemText);

            // Refresh data binding
            ApplyDataBinding();
        }
        private void chbKeyword002_Unchecked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = chbKeyword002.Content.ToString();

            RightListBox.Items.Remove(currentItemText);

            // Refresh data binding
            ApplyDataBinding();
        }

        private void chbKeyword003_Checked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = chbKeyword003.Content.ToString();

            RightListBox.Items.Add(currentItemText);

            // Refresh data binding
            ApplyDataBinding();
        }
        private void chbKeyword003_Unchecked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = chbKeyword003.Content.ToString();

            RightListBox.Items.Remove(currentItemText);

            // Refresh data binding
            ApplyDataBinding();
        }

        private void chbKeyword004_Checked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = chbKeyword004.Content.ToString();

            RightListBox.Items.Add(currentItemText);

            // Refresh data binding
            ApplyDataBinding();
        }
        private void chbKeyword004_Unchecked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = chbKeyword004.Content.ToString();

            RightListBox.Items.Remove(currentItemText);

            // Refresh data binding
            ApplyDataBinding();
        }

        private void chbKeyword005_Checked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = chbKeyword005.Content.ToString();

            RightListBox.Items.Add(currentItemText);

            // Refresh data binding
            ApplyDataBinding();
        }
        private void chbKeyword005_Unchecked(object sender, RoutedEventArgs e)
        {
            // Find the right item and it's value and index
            currentItemText = chbKeyword005.Content.ToString();

            RightListBox.Items.Remove(currentItemText);

            // Refresh data binding
            ApplyDataBinding();
        }

        /// <summary>
        /// Refreshes data binding
        /// </summary>
        private void ApplyDataBinding()
        {
            LeftListBox.ItemsSource = null;
            // Bind ArrayList with the ListBox
            LeftListBox.ItemsSource = myDataList;
        }

    }
}