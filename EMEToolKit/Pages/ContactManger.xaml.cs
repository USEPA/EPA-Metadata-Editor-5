/*
COPYRIGHT 1995-2012 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States and applicable international
laws, treaties, and conventions.
 
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts and Legal Services Department
380 New York Street
Redlands, California, 92373
USA
 
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

using ESRI.ArcGIS.Metadata.Editor.Properties;
using System.Xml;
using System.Security.Cryptography;

using ESRI.ArcGIS.Metadata.Editor;
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for ContactManger.xaml
    /// </summary>
    public partial class ContactManager : EditorPage
    {
        private XmlDocument _contactsDoc = null;
        private XmlDocument _contactsEsri = null;
        private XmlDocument _contactsEpa = null;
        public string partySource = null;
        public ContactManager()
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

        /// <summary>
        /// unload form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        override public void CommitChanges()
        {
            if (null == _contactsDoc)
                return;

            // new document
            XmlDocument clone = new XmlDocument();
            XmlNode contactsNode = clone.CreateElement("contacts");
            clone.AppendChild(contactsNode);

            // write back out the contacts marked saved
            var list = _contactsDoc.SelectNodes("//contact[(editorSave='True') and not(editorSource='emedb')]");
            StringBuilder sb = new StringBuilder();

            foreach (XmlNode child in list)
            {
                // remove elements
                //
                XmlNode e = child.SelectSingleNode("editorSource");
                if (null != e)
                {
                    child.RemoveChild(e);
                }

                e = child.SelectSingleNode("editorDigest");
                if (null != e)
                {
                    child.RemoveChild(e);
                }

                // remove role
                //
                e = child.SelectSingleNode("role");
                if (null != e)
                {
                    child.RemoveChild(e);
                }

                // save back unique key
                string digest = Utils.GeneratePartyKey(child);
                sb.Append("<contact>");
                sb.Append("<editorSource>external</editorSource>");
                sb.Append("<editorDigest>");
                sb.Append(digest);
                sb.Append("</editorDigest>");
                sb.Append(child.InnerXml);
                sb.Append("</contact>");
            }

            // append to clone
            contactsNode.InnerXml = sb.ToString();

            // save to file
            string file = Utils.GetContactsFileLocation();
            clone.Save(file);
        }


        public void UncheckBox(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (null == cb)
                return;
            Nullable<bool> check = cb.IsChecked;

            XmlNode tagNode = cb.Tag as XmlNode;
            if (null == tagNode)
                return;

            if (false == check && "external".Equals(tagNode.InnerText))
            {
                //string message = ESRI.ArcGIS.Metadata.Editor.Properties.Resources.MSGBOX_SAVE_MSG;
                //string caption = ESRI.ArcGIS.Metadata.Editor.Properties.Resources.MSGBOX_SAVE_CAPTION;
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;

                // show dialog
                MessageBoxResult result = MessageBox.Show(ESRI.ArcGIS.Metadata.Editor.Properties.Resources.LBL_CM_Confirm, ESRI.ArcGIS.Metadata.Editor.Properties.Resources.LBL_CM_ConfirmTitle, button, icon);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        // NOOP
                        break;
                    //DoSave();
                    //break;
                    case MessageBoxResult.No:
                        cb.IsChecked = true;
                        break;
                        //DoCancel();
                        //break;
                }
            }
        }

        /// <summary>
        /// load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoadContacts(object sender, RoutedEventArgs e)
        {
            _contactsDoc = new XmlDocument();
            _contactsEsri = new XmlDocument();
            _contactsEpa = new XmlDocument();
            string filePathEsri = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\ArcGIS\\Descriptions\\";
            string filePathEpa = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Innovate! Inc\\EPA Metadata Edtior 4x\\Eme4xSystemFiles\\EMEdb\\";

            //_contactsEsri.PreserveWhitespace = true;
            try { _contactsEsri.Load(filePathEsri + "contacts.xml"); }
            catch (System.IO.FileNotFoundException)
            {
                _contactsEsri.LoadXml(
                "<contacts> \n" +
                "  <contact> \n" +
                "    <editorSource></editorSource> \n" +
                "    <editorDigest></editorDigest> \n" +
                "    <rpIndName></rpIndName> \n" +
                "    <rpOrgName></rpOrgName> \n" +
                "    <rpPosName></rpPosName> \n" +
                "    <editorSave></editorSave> \n" +
                "    <rpCntInfo></rpCntInfo> \n" +
                "  </contact> \n" +
                "</contacts>");
            }
            //_contactsEsri.Save(filePathEsri + "contactManEsri.xml");

            //_contactsEpa.PreserveWhitespace = true;
            try { _contactsEpa.Load(filePathEpa + "contacts.xml"); }
            catch (System.IO.FileNotFoundException)
            {
                _contactsEpa.LoadXml(
                "<contacts> \n" +
                "  <contact> \n" +
                "    <editorSource></editorSource> \n" +
                "    <editorDigest></editorDigest> \n" +
                "    <rpIndName></rpIndName> \n" +
                "    <rpOrgName></rpOrgName> \n" +
                "    <rpPosName></rpPosName> \n" +
                "    <editorSave></editorSave> \n" +
                "    <rpCntInfo></rpCntInfo> \n" +
                "  </contact> \n" +
                "</contacts>");
            }
            //_contactsEpa.Save(filePathEsri + "contactManEpa.xml");

            // new document
            XmlDocument cloneMerge = new XmlDocument();
            XmlNode contactsNodeMerge = cloneMerge.CreateElement("contacts");
            cloneMerge.AppendChild(contactsNodeMerge);

            // write back out the contacts marked saved
            var listEsri = _contactsEsri.SelectNodes("//contact");
            var listEpa = _contactsEpa.SelectNodes("//contact");
            StringBuilder sb2 = new StringBuilder();
            foreach (XmlNode child in listEsri)
            {
                // remove editorSource
                XmlNode e1 = child.SelectSingleNode("editorSource");
                if (null != e1)
                {
                    e1.InnerText = "external";
                }

                e1 = child.SelectSingleNode("editorDigest");
                if (null != e1)
                {
                    string digest = Utils.GeneratePartyKey(child);
                    e1.InnerText = digest;
                }

                // save back localuser editorSource
                sb2.Append("<contact>");
                sb2.Append(child.InnerXml);
                sb2.Append("</contact>");
            }
            foreach (XmlNode child in listEpa)
            {
                // remove editorSource
                XmlNode e2 = child.SelectSingleNode("editorSource");
                if (null != e2)
                {
                    e2.InnerText = "EPA Contact";
                }

                e2 = child.SelectSingleNode("editorDigest");
                if (null != e2)
                {
                    string digest = Utils.GeneratePartyKey(child);
                    e2.InnerText = digest;
                }

                e2 = child.SelectSingleNode("editorSave");
                if (null != e2)
                {
                    e2.InnerText = "True";
                }

                // save back epa editorSource
                sb2.Append("<contact>");
                sb2.Append(child.InnerXml);
                sb2.Append("</contact>");
            }

            // append to clone
            contactsNodeMerge.InnerXml = sb2.ToString();

            // save to file
            //cloneMerge.Save(Utils.GetContactsFileLocation());
            //cloneMerge.Save(filePathEsri + "contactsCbo.xml");
            cloneMerge.Save(filePathEsri + "contacts.xml");

            // generate contact list
            contactsListBox.ItemsSource = Utils.GenerateContactsList(_contactsDoc, this.DataContext);

            _contactsDoc.Save(filePathEsri + "contactsDoc.xml");
            _contactsEsri.Save(filePathEsri + "contacts.xml");

            // come find me later...
            Utils.GetMetadataEditorControl(this).AddCommitPage(this);
        }

        #region ISidebarLabel Members

        /// <summary>
        /// get the sidebar label
        /// </summary>
        override public string SidebarLabel
        {
            get { return ESRI.ArcGIS.Metadata.Editor.Properties.Resources.CFG_LBL_CONTACT_MGR; }
        }

        #endregion

        private void contactsListBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (contactsListBox.IsVisible == true)
            {
                partySource = "ListBox Visible";
            }
        }
    }
}