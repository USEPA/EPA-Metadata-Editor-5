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
﻿using System;
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

using ESRI.ArcGIS.Metadata.Editor; using ESRI.ArcGIS.Metadata.Editor.Pages; namespace EPAMetadataEditor.Pages
{
  /// <summary>
  /// Interaction logic for PartyPickerControl.xaml
  /// </summary>
  public partial class PartyPickerControl : EditorPage
  {
    public string ContainerElement { get; set; }

    public PartyPickerControl()
    {
      InitializeComponent();
    }

    public void LoadList(object sender, EventArgs e)
    {
      XmlDocument _contactsDoc = new XmlDocument();
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
