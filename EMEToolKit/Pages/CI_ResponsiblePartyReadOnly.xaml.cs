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
  /// Interaction logic for CI_ResponsibleParty.xaml
  /// </summary>
  public partial class CI_ResponsiblePartyReadOnly : EditorPage, INotifyPropertyChanged
  {
    public CI_ResponsiblePartyReadOnly()
    {
      InitializeComponent();
    }

    public override string DefaultValue
    {
      get
      {
        return Utils.ExtractResponsiblePartyLabel(this, ESRI.ArcGIS.Metadata.Editor.Properties.Resources.LBL_CI_PARTY_READONLY_FORMAT);
      }

      set
      {
        // NOOP
      }
    }

        private void EditorPage_Loaded(object sender, RoutedEventArgs e)
        {
            FillXml();
            if (this.IsVisible == true)
            {
                //var dataContextXml = Utils.GetXmlDataContext(this.DataContext);
                //lblContactsFileLocation.Content = Utils.GetContactsFileLocation();
                //lblThisDataContextStr.Content = this.DataContext.ToString();
                //lblThisDataContext.Content = this.DataContext;
                //lblGetDataContext.Content = dataContextXml;
            }
        }
    }
}
