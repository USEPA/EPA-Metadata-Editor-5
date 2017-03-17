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
  /// Interaction logic for MD_Identifier.xaml
  /// </summary>
  public partial class MD_Identifier : EditorPage
  {
    public MD_Identifier()
    {
      InitializeComponent();
    }

    public override string DefaultValue
    {
      get
      {
        IEnumerable<XmlNode> data = GetXmlDataContext();
        if (null == data)
          return String.Empty;

        foreach (XmlNode root in data)
        {
          // Person
          XmlNode node = root.SelectSingleNode("identCode");
          if (null != node && 0 < node.InnerText.Length)
          {
            return node.InnerText;
          }

          break;
        }

        return String.Empty; // ESRI.ArcGIS.Metadata.Editor.Properties.Resources.LBL_IDENTIFIER_EMPTY;
      }
      set
      {
        // NOOP
      }
    }
  }
}
