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
using System.Xml;

using ESRI.ArcGIS.Metadata.Editor;
using ESRI.ArcGIS.Metadata.Editor.Pages;
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
            XmlDocument _contactsEpa = new XmlDocument();

            string filePathEsri = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\ArcGIS\\Descriptions\\";
            string filePathEpa = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Innovate! Inc\\EPA Metadata Edtior 4x\\Eme4xSystemFiles\\EMEdb\\";

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
            //_contactsEsri.Save(filePathEsri + "contactsEsri.xml");

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
            //_contactsEpa.Save(filePathEsri + "contactsEpa.xml");

            // new document
            XmlDocument clone = new XmlDocument();
            XmlNode contactsNode = clone.CreateElement("contacts");
            clone.AppendChild(contactsNode);

            // write back out the contacts marked saved
            var listEsri = _contactsEsri.SelectNodes("//contact[editorSave='True']");
            var listEpa = _contactsEpa.SelectNodes("//contact");
            StringBuilder sb = new StringBuilder();
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
                    e2.InnerText = "emedb";
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

            var list = Utils.GenerateContactsList(_contactsDoc, this.DataContext);

            foreach (XmlNode node in list)
            {
                // get ONE good name for display
                //var nameNode = node.SelectSingleNode("rpIndName | rpOrgName | rpPosName");
                //var nameString = "unknown";
                //if (null != nameNode && 0 < nameNode.InnerText.Length) {
                //  nameString = nameNode.InnerText;
                //}

                var nameString = Utils.ExtractResponsiblePartyLabel(node, ESRI.ArcGIS.Metadata.Editor.Properties.Resources.LBL_CI_PARTY_ADD_FORMAT);

                // create new node for display in the list control
                var newNode = _contactsDoc.CreateElement("displayName");
                newNode.InnerText = nameString;
                node.AppendChild(newNode);
            }

            // return list
            PartyList.ItemsSource = list;

            _contactsEsri.Save(filePathEsri + "contacts.xml");

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
