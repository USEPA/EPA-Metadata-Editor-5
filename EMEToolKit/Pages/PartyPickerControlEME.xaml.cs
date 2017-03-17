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
using System.Xml;

using ESRI.ArcGIS.Metadata.Editor;
using ESRI.ArcGIS.Metadata.Editor.Pages;
using System.Net;
using System.IO;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for PartyPickerControlEME.xaml
    /// </summary>
    public partial class PartyPickerControlEME : EditorPage
    {
        public string ContainerElement { get; set; }

        public PartyPickerControlEME()
        {
            InitializeComponent();
        }

        public void LoadList(object sender, EventArgs e)
        {
            XmlDocument _contactsDoc = new XmlDocument();
            XmlDocument _contactsEsri = new XmlDocument();
            XmlDocument _contactsBAK = new XmlDocument();
            XmlDocument _contactsEpa = new XmlDocument();
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
                // myerror.Message;
                {
                    MessageBoxResult result = MessageBox.Show(weberror.Message + "\n" + "EME contacts will be loaded from local cache.", "EME 5.0 Web Request", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

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
            _contactsBAK.Save(filePathEsri + "contacts.bak");
            
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

            // new document
            XmlDocument clone = new XmlDocument();
            XmlNode contactsNode = clone.CreateElement("contacts");
            clone.AppendChild(contactsNode);

            // Combine local contacts.xml with EPA contacts
            var listEsri = _contactsEsri.SelectNodes("//contact[editorSave='True']");
            var listEpa = _contactsEpa.SelectNodes("//contact");
            StringBuilder sb = new StringBuilder();
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
                sb.Append("<contact>");
                sb.Append(child.InnerXml);
                sb.Append("</contact>");
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
                    e2.InnerText = "True";
                }

                // save back epa editorSource
                sb.Append("<contact>");
                sb.Append(child.InnerXml);
                sb.Append("</contact>");
            }

            // append to clone
            contactsNode.InnerXml = sb.ToString();

            // save to file
            clone.Save(Utils.GetContactsFileLocation());

            // create display name for combobox
            var list = Utils.GenerateContactsList(_contactsDoc, this.DataContext);
            //_contactsDoc.Save(filePathEme + "contactsDoc.xml");

            //XDocument doc = XDocument.Load(filePathEme + "contactsDoc.xml");
            //XElement dealsParent = doc.Element("contacts");
            //dealsParent.ReplaceNodes(dealsParent.Nodes().Cast<XElement>().OrderByDescending(element => element.Element("displayName").Value));
            //doc.Save(filePathEme + "contactsSort.xml");

            //XPathDocument myXPathDoc = new XPathDocument(filePathEme + "contactsDoc.xml");
            //XslCompiledTransform myXslTrans = new XslCompiledTransform();
            //myXslTrans.Load(filePathEme + "myStyleSheet.xslt");
            //XmlTextWriter myWriter = new XmlTextWriter(filePathEme + "contactsResult.xml", null);
            //myXslTrans.Transform(myXPathDoc, null, myWriter);

            foreach (XmlNode node in list)
            {
                // get ONE good name for display
                //var nameNode = node.SelectSingleNode("rpIndName | rpOrgName | rpPosName");
                //var nameString = "unknown";
                //if (null != nameNode && 0 < nameNode.InnerText.Length)
                //{
                //    nameString = nameNode.InnerText + " test";
                //}

                string nameString = "unknown";
                string sourceString = "From Metadata Record";
                var nameString1 = Utils.ExtractResponsiblePartyLabel(node, ESRI.ArcGIS.Metadata.Editor.Properties.Resources.LBL_CI_PARTY_ADD_FORMAT);
                var sourceNode = node.SelectSingleNode("editorSource");

                if (null != sourceNode && 0 < sourceNode.InnerText.Length)
                {
                    sourceString = sourceNode.InnerText;
                    nameString = "[" + sourceString + "]   " + nameString1;
                }
                else
                {
                    nameString = "[" + sourceString + "]   " + nameString1;
                }              

                // create new node for display in the list control
                var newNode = _contactsDoc.CreateElement("displayName");
                newNode.InnerText = nameString;
                node.AppendChild(newNode);
            }

            // return list
            PartyList.ItemsSource = list;
            
            // Restore contacts.xml to original state
            _contactsBAK.Save(Utils.GetContactsFileLocation());

            // LoadList complete and contacts.xml restored successfully. Safe to delete BAK file.
            if (File.Exists(filePathEsri + "contacts.bak"))
            {
                File.Delete(filePathEsri + "contacts.bak");
            }

        }

        public void LoadParty(object sender, EventArgs e)
        {
            // new xml to be inserted
            XmlNode selectedNode = PartyList.SelectedItem as XmlNode;
            if (null == selectedNode)
                return; // nothing selected

            string newXml = selectedNode.InnerXml;

            // get the context node
            var dataContextXml = Utils.GetXmlDataContext(this.DataContext);
            if (null == dataContextXml)
                return;

            XmlNode contextNode = null;
            foreach (XmlNode node in dataContextXml)
            {
                contextNode = node;
                break;
            }

            // add new xml to a container element, then add the container to the datacontext node
            if (null != newXml && 0 < newXml.Length && null != ContainerElement && 0 < ContainerElement.Length)
            {

                // create container node
                var containerNode = contextNode.OwnerDocument.CreateElement(ContainerElement);
                containerNode.InnerXml = newXml;

                // add to data context
                contextNode.AppendChild(containerNode);
            }
        }
    }
}
