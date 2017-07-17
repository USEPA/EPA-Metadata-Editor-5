using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml;

namespace EMEdbManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _pathEmeDb = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Innovate! Inc\\EME Toolkit\\EMEdb\\";
        private XmlDocument _emeConfig = new XmlDocument();

        public MainWindow()
        {
            InitializeComponent();
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            XmlRecord_ThemeKeyEpa.Source = new Uri(_pathEmeDb + "KeywordsEPA.xml");
            XmlRecord_ThemeKeyUser.Source = new Uri(_pathEmeDb + "KeywordsUser.xml");
            XmlRecord_ThemeKeyPlace.Source = new Uri(_pathEmeDb + "KeywordsPlace.xml");
            XmlRecord_SystemofRecords.Source = new Uri(_pathEmeDb + "SystemofRecords.xml");
            XmlRecord_SystemofRecords.XPath = "/emeData/SystemOfRecord[SysRcrdName[(text())]]";
            XmlRecord_SecConsts.Source = new Uri(_pathEmeDb + "SecurityConstraints.xml");
            XmlRecord_emeConfig.Source = new Uri(_pathEmeDb + "emeConfig.xml");
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void lbxThemekeyEpa_loaded(object sender, RoutedEventArgs e)
        {
            lblKwEPACount.Content = "( " + lbxThemekeyEpa.Items.Count.ToString() + " )";
        }

        private void lbxThemekeyUser_loaded(object sender, RoutedEventArgs e)
        {
            lblKwUserCount.Content = "( " + lbxThemekeyUser.Items.Count.ToString() + " )";
        }
        private void lbxThemekeyPlace_loaded(object sender, RoutedEventArgs e)
        {
            lblKwPlaceCount.Content = "( " + lbxThemekeyPlace.Items.Count.ToString() + " )";
        }

        private void lbxSystemofRecords_loaded(object sender, RoutedEventArgs e)
        {
            lblSoRCount.Content = "( " + lbxSystemofRecords.Items.Count.ToString() + " )";
        }

        private void lbxSecConsts_loaded(object sender, RoutedEventArgs e)
        {
            lblSecConstsCount.Content = "( " + lbxSecConsts.Items.Count.ToString() + " )";
        }

        private void lbxConfig_loaded(object sender, RoutedEventArgs e)
        {
            _emeConfig.Load(_pathEmeDb + "emeConfig.xml");
            TimeSpan emeSyncAge = (DateTime.Now) - (DateTime.Parse(_emeConfig.SelectSingleNode("//emeControl/date").InnerText));
            bool dbExpired = emeSyncAge > (new TimeSpan(0, 12, 0, 0));
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

        private void btnSaveThemekeyPlace_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_ThemeKeyPlace.Source.LocalPath;
            XmlRecord_ThemeKeyPlace.Document.Save(source);
        }

        private void btnSaveThemekeyUser_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_ThemeKeyUser.Source.LocalPath;
            XmlRecord_ThemeKeyUser.Document.Save(source);
        }

        private void btnSaveEmeConfig_Click(object sender, RoutedEventArgs e)
        {
            string source = XmlRecord_emeConfig.Source.LocalPath;
            XmlRecord_emeConfig.Document.Save(source);
        }

        private void btnAddThemekeyEpa_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_ThemeKeyEpa.Document;
            XmlElement epaElement = doc.CreateElement("KeywordsEPA");
            XmlElement xmlEleThesaName = doc.CreateElement("themekt");
            XmlElement xmlEleKeyword = doc.CreateElement("themekey");
            XmlElement xmlEleDefault = doc.CreateElement("default");
            xmlEleThesaName.InnerText = "EPA GIS Keyword Thesaurus";
            xmlEleKeyword.InnerText = "New Keyword";
            xmlEleDefault.InnerText = "False";

            epaElement.AppendChild(xmlEleThesaName);
            epaElement.AppendChild(xmlEleKeyword);
            epaElement.AppendChild(xmlEleDefault);
            doc.DocumentElement.InsertAfter(epaElement, doc.DocumentElement.LastChild);
            lbxThemekeyEpa.SelectedIndex = lbxThemekeyEpa.Items.Count - 1;

        }

        private void btnAddThemekeyUser_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_ThemeKeyUser.Document;
            XmlElement userElement = doc.CreateElement("KeywordsUser");
            XmlElement xmlEleThesaName = doc.CreateElement("themekt");
            XmlElement xmlEleKeyword = doc.CreateElement("themekey");
            XmlElement xmlEleDefault = doc.CreateElement("default");
            xmlEleThesaName.InnerText = "User";
            xmlEleKeyword.InnerText = "New Keyword";
            xmlEleDefault.InnerText = "False";

            userElement.AppendChild(xmlEleThesaName);
            userElement.AppendChild(xmlEleKeyword);
            userElement.AppendChild(xmlEleDefault);
            doc.DocumentElement.InsertAfter(userElement, doc.DocumentElement.LastChild);
            lbxThemekeyUser.SelectedIndex = lbxThemekeyUser.Items.Count - 1;
        }

        private void btnAddThemekeyPlace_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_ThemeKeyPlace.Document;
            XmlElement placeElement = doc.CreateElement("KeywordsPlace");
            XmlElement xmlEleThesaName = doc.CreateElement("placekt");
            XmlElement xmlEleKeyword = doc.CreateElement("placekey");
            XmlElement xmlEleDefault = doc.CreateElement("default");
            xmlEleKeyword.InnerText = "New Keyword";
            xmlEleDefault.InnerText = "False";

            placeElement.AppendChild(xmlEleThesaName);
            placeElement.AppendChild(xmlEleKeyword);
            placeElement.AppendChild(xmlEleDefault);
            doc.DocumentElement.InsertAfter(placeElement, doc.DocumentElement.LastChild);
            lbxThemekeyPlace.SelectedIndex = lbxThemekeyPlace.Items.Count - 1;
        }

        private void btnAddSecConsts_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_SecConsts.Document;
            XmlElement xmlEleSecCnst = doc.CreateElement("SecurityConstraints");
            XmlElement xmlEleSecNote = doc.CreateElement("usenote");
            XmlElement xmlEleSecClass = doc.CreateElement("constsclass");
            xmlEleSecNote.InnerText = "EPA Category: ";
            xmlEleSecClass.InnerText = "non-public";

            xmlEleSecCnst.AppendChild(xmlEleSecNote);
            xmlEleSecCnst.AppendChild(xmlEleSecClass);
            doc.DocumentElement.InsertAfter(xmlEleSecCnst, doc.DocumentElement.LastChild);
            lbxSecConsts.SelectedIndex = lbxSecConsts.Items.Count - 1;
        }

        private void btnAddSOR_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_SecConsts.Document;
            XmlElement xmlEleSOR = doc.CreateElement("SystemOfRecord");
            XmlElement xmlEleSORname = doc.CreateElement("SysRcrdName");
            XmlElement xmlEleSORurl = doc.CreateElement("SysRcrdUrl");
            xmlEleSORname.InnerText = "New System of Record";

            xmlEleSOR.AppendChild(xmlEleSORname);
            xmlEleSOR.AppendChild(xmlEleSORurl);
            doc.DocumentElement.InsertAfter(xmlEleSOR, doc.DocumentElement.LastChild);
            lbxSystemofRecords.SelectedIndex = lbxSystemofRecords.Items.Count - 1;
        }

        private void btnDeletePlaceKeyword_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_ThemeKeyPlace.Document;
            string source = XmlRecord_ThemeKeyPlace.Source.LocalPath;
            XmlNode themek = doc.SelectSingleNode("/emeData/KeywordsPlace[placekey[text()='" + tbKeywordPlace.Text + "']]");

            themek.ParentNode.RemoveChild(themek);
            XmlRecord_ThemeKeyPlace.Document.Save(source);
        }

        private void btnDeleteEpaKeyword_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_ThemeKeyEpa.Document;
            string source = XmlRecord_ThemeKeyEpa.Source.LocalPath;
            XmlNode themek = doc.SelectSingleNode("/emeData/KeywordsEPA[themekey[text()='" + tbKeywordEpa.Text + "']]");

            themek.ParentNode.RemoveChild(themek);
            XmlRecord_ThemeKeyEpa.Document.Save(source);
        }

        private void btnDeleteUserKeyword_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_ThemeKeyUser.Document;
            string source = XmlRecord_ThemeKeyUser.Source.LocalPath;
            XmlNode themek = doc.SelectSingleNode("/emeData/KeywordsUser[themekey[text()='" + tbKeywordUser.Text + "']]");

            themek.ParentNode.RemoveChild(themek);
            XmlRecord_ThemeKeyUser.Document.Save(source);
        }

        private void btnDeleteSecConsts_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = XmlRecord_SecConsts.Document;
            string source = XmlRecord_SecConsts.Source.LocalPath;
            XmlNode sconst = doc.SelectSingleNode("/emeData/SecurityConstraints[usenote[text()='" + tbUseNote.Text + "']]");

            sconst.ParentNode.RemoveChild(sconst);
            XmlRecord_SecConsts.Document.Save(source);
        }

        private void btnDefaultConfig_Click(object sender, RoutedEventArgs e)
        {
            string dOrg = "U.S. Environmental Protection Agency";
            string dContacts = "EPA Directory";
            string dUrl = "https://edg.epa.gov/EME/contacts.xml";
            string dDate = "2010-06-27T12:00:00-07:00";

            XmlDocument doc = XmlRecord_emeConfig.Document;
            string source = XmlRecord_emeConfig.Source.LocalPath;

            XmlNode eOrg = doc.SelectSingleNode("//emeControl[controlName[contains(. , 'Organization')]]/param");
            XmlNode eDir = doc.SelectSingleNode("//emeControl[controlName[contains(. , 'Contacts Manager')]]/param");
            XmlNode eUrl = doc.SelectSingleNode("//emeControl[controlName[contains(. , 'Contacts Manager')]]/url");
            XmlNode eDate = doc.SelectSingleNode("//emeControl[controlName[contains(. , 'Contacts Manager')]]/date");

            eOrg.InnerText = dOrg;
            eDir.InnerText = dContacts;
            eUrl.InnerText = dUrl;
            eDate.InnerText = dDate;

            XmlRecord_emeConfig.Document.Save(source);
        }
    }
}
