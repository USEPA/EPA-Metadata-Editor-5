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

namespace EMEdbManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            XmlRecord_ThemeKeyEpa.Source = new Uri("C:\\Users\\Innovate\\AppData\\Roaming\\Innovate! Inc\\EPA Metadata Edtior 4x\\Eme4xSystemFiles\\EMEdb\\KeywordsEPA.xml");
            //XmlRecord_ThemeKeyUser.Source = new Uri("C:\\Users\\Innovate\\AppData\\Roaming\\Innovate! Inc\\EPA Metadata Edtior 4x\\Eme4xSystemFiles\\EMEdb\\KeywordsUser.xml");
            //XmlRecord_PlaceKey.Source = new Uri("C:\\Users\\Innovate\\AppData\\Roaming\\Innovate! Inc\\EPA Metadata Edtior 4x\\Eme4xSystemFiles\\EMEdb\\KeywordsPlace.xml");
            XmlRecord_SystemofRecords.Source = new Uri("C:\\Users\\Innovate\\AppData\\Roaming\\Innovate! Inc\\EPA Metadata Edtior 4x\\Eme4xSystemFiles\\EMEdb\\SystemofRecords.xml");
            XmlRecord_SecConsts.Source = new Uri("C:\\Users\\Innovate\\AppData\\Roaming\\Innovate! Inc\\EPA Metadata Edtior 4x\\Eme4xSystemFiles\\EMEdb\\SecurityConstraints.xml");
            // C:\Users\Innovate\AppData\Roaming\Innovate! Inc\EPA Metadata Edtior 4x\Eme4xSystemFiles\EMEdb\
            //labelXMLPath.Content = KeywordData.Source.LocalPath;
        }

        private void lbxThemekeyEpa_loaded(object sender, RoutedEventArgs e)
        {
            lblKwEPACount.Content = lbxThemekeyEpa.Items.Count.ToString();
        }

        private void lbxSystemofRecords_loaded(object sender, RoutedEventArgs e)
        {
            lblSoRCount.Content = lbxSystemofRecords.Items.Count.ToString();
        }

        private void lbxSecConsts_loaded(object sender, RoutedEventArgs e)
        {
            lblSecConstsCount.Content = lbxSecConsts.Items.Count.ToString();
        }

        private void btnSaveThemekeyEpa_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_ThemeKeyEpa.Source.LocalPath;
            XmlRecord_ThemeKeyEpa.Document.Save(source);
        }

        private void btnSaveSOR_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_SystemofRecords.Source.LocalPath;
            XmlRecord_SystemofRecords.Document.Save(source);
        }

        private void btnSaveSecConsts_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_SecConsts.Source.LocalPath;
            XmlRecord_SecConsts.Document.Save(source);
        }
    }
}
