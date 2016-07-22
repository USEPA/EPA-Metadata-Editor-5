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
using System.ComponentModel;
using System.Xml;

using ESRI.ArcGIS.Metadata.Editor; using ESRI.ArcGIS.Metadata.Editor.Pages; namespace EPAMetadataEditor.Pages
{
  /// <summary>
  /// Interaction logic for EX_GeographicDescription.xaml
  /// </summary>
  public partial class EX_GeographicDescription : EditorPage, INotifyPropertyChanged
  {
    public EX_GeographicDescription()
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

        StringBuilder sb = new StringBuilder();
        foreach (XmlNode root in data)
        {
          // west
          XmlNode node = root.SelectSingleNode("GeoDesc/geoId/identCode");
          if (null != node && 0 < node.InnerText.Length)
          {
            sb.Append(node.InnerText);
          }

          break;
        }

        if (0 < sb.Length)
          return ESRI.ArcGIS.Metadata.Editor.Properties.Resources.LBL_EXTENTS_GEODESC + sb.ToString().Substring(0, 30) + "...";
        else
          return String.Empty; // ESRI.ArcGIS.Metadata.Editor.Properties.Resources.LBL_EXTENTS_GEODESC_EMPTY;
      }
      set
      {
        // NOOP
      }
    }
  }
}
