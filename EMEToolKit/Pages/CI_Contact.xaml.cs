/*
COPYRIGHT 1995-2009 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States.
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts Dept
380 New York Street
Redlands, California, USA 92373
email: contracts@esri.com
*/

using System;
using System.Collections.Generic;
using System.Collections;
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
using System.ComponentModel;
using System.Globalization;
using ESRI.ArcGIS.Metadata.Editor.Validation;

using ESRI.ArcGIS.Metadata.Editor; using ESRI.ArcGIS.Metadata.Editor.Pages; namespace EPAMetadataEditor.Pages
{
  /// <summary>
  /// Interaction logic for Contact.xaml
  /// </summary>
  public partial class CI_Contact : EditorPage
  {

    public CI_Contact()
    {
      InitializeComponent();
    }

    public override string DefaultValue
    {
      get
      {
        IEnumerable<XmlNode> data = GetXmlDataContext();
        if (null == data)
          return null;

        foreach (XmlNode root in data)
        {
          // URL
          //XmlNode node = root.SelectSingleNode("cntOnlineRes/linkage");
          //if (null != node && 0 < node.InnerText.Length)
          //{
          //    return node.InnerText;
          //}

          // EMAIL
          XmlNode node = root.SelectSingleNode("cntAddress/eMailAdd");
          if (null != node && 0 < node.InnerText.Length)
          {
            return node.InnerText;
          }

          // ADDRESS
          string address = "";
          node = root.SelectSingleNode("cntAddress/delPoint");
          if (null != node && 0 < node.InnerText.Length)
          {
            address += node.InnerText;
            address += " ";
          }
          node = root.SelectSingleNode("cntAddress/city");
          if (null != node && 0 < node.InnerText.Length)
          {
            address += node.InnerText;
            address += ", ";
          }
          node = root.SelectSingleNode("cntAddress/adminArea");
          if (null != node && 0 < node.InnerText.Length)
          {
            address += node.InnerText;
            //address += " ";
          }

          if (0 < address.Length)
            return address;

          break;
        }

        return null;
      }
      set
      {
        // DO NOTHING
      }
    }
  }
}
