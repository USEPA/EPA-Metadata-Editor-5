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
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

using ESRI.ArcGIS.Metadata.Editor;
using ESRI.ArcGIS.Metadata.Editor.Pages;
using System.Net;
using System.IO;

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
        private XmlDocument _contactsBAK = null;
        public string partySource = null;
        public ContactManager()
        {
            InitializeComponent();
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
            //var list = _contactsDoc.SelectNodes("//contact[(editorSave='True') and not(editorSource='EPA Directory')]");
            var list = _contactsDoc.SelectNodes("//contact[editorSave='True']");
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
                sb.Append("<editorSource>My Contacts</editorSource>");
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

            if (false == check && "My Contacts".Equals(tagNode.InnerText))
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
            _contactsBAK = new XmlDocument();
            XmlDocument _contactsWEB = new XmlDocument();

            string filePathEsri = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\ArcGIS\\Descriptions\\";
            string filePathEme = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Innovate! Inc\\EME Toolkit\\EMEdb\\";

            // Check to see if contacts.bak exists.
            // contacts.bak is created during LoadList. If LoadList crashes contacts.xml will be left with bad data.
            // replace contacts.xml with contacts.bak
            if (File.Exists(filePathEsri + "contacts.bak"))
            {
                File.Delete(filePathEsri + "contacts.xml");
                File.Copy(filePathEsri + "contacts.bak", filePathEsri + "contacts.xml");
                File.Delete(filePathEsri + "contacts.bak");
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://edg.epa.gov/EME/contacts.xml");
            request.Timeout = 15000;
            request.Method = "HEAD"; //test URL without downloading the content
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode.ToString() == "OK")
                    {
                        //MessageBoxResult webResponse = MessageBox.Show("EME contacts loaded from https://edg.epa.gov/EME/contacts.xml", "EME 5.0 Web Request", MessageBoxButton.OK, MessageBoxImage.Information);
                        try { _contactsWEB.Load("https://edg.epa.gov/EME/contacts.xml"); }
                        catch (System.IO.FileNotFoundException)
                        {
                            _contactsWEB.LoadXml(
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
                        _contactsWEB.Save(filePathEme + "contacts.xml");
                    }
                    else
                    {
                        MessageBoxResult webResponse = MessageBox.Show("Error loading contacts from https://edg.epa.gov/EME/contacts.xml." + "\n" + "EME contacts will be loaded from local cache.", "EME 5.0 Web Request", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception weberror)
            {
                {
                    MessageBoxResult result = MessageBox.Show(weberror.Message + "\n" + "EME contacts will be loaded from local cache.", "EME 5.0 Web Request", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            try { _contactsBAK.Load(filePathEsri + "contacts.xml"); }
            catch (System.IO.FileNotFoundException)
            {
                _contactsBAK.LoadXml(
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
            // save backup of user contacts.xml
            _contactsBAK.Save(filePathEsri + "contacts.bak");
            
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
            try { _contactsEpa.Load(filePathEme + "contacts.xml"); }
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

            // Populate contacts list with local contacts.xml and EPA Directorys
            var listEsri = _contactsEsri.SelectNodes("//contact");
            var listEpa = _contactsEpa.SelectNodes("//contact");
            StringBuilder sb2 = new StringBuilder();
            foreach (XmlNode child in listEsri)
            {
                // remove editorSource
                XmlNode e1 = child.SelectSingleNode("editorSource");
                if (null != e1)
                {
                    e1.InnerText = "My Contacts";
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
                    e2.InnerText = "EPA Directory";
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
                    e2.InnerText = "False";
                }

                // save back epa editorSource
                sb2.Append("<contact>");
                sb2.Append(child.InnerXml);
                sb2.Append("</contact>");
            }

            // append to clone
            contactsNodeMerge.InnerXml = sb2.ToString();

            // save to file
            cloneMerge.Save(Utils.GetContactsFileLocation());


            // generate contact list
            contactsListBox.ItemsSource = Utils.GenerateContactsList(_contactsDoc, this.DataContext);

            // restore contacts.xml to original state
            _contactsBAK.Save(Utils.GetContactsFileLocation());

            // contacts.xml restored successfully. It is now safe to delete BAK file.
            if (File.Exists(filePathEsri + "contacts.bak"))
            {
                File.Delete(filePathEsri + "contacts.bak");
            }

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