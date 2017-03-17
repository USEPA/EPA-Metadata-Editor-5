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
using System.Windows;
using System.ComponentModel;
using ESRI.ArcGIS.Metadata.Editor.Pages;
using System.Windows.Navigation;
using System.Diagnostics;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for CI_Citation.xaml
    /// </summary>
    public partial class CI_Citation : EditorPage, INotifyPropertyChanged
    {

        public static readonly DependencyProperty SupressPartiesProperty = DependencyProperty.Register(
           "SupressParties",
           typeof(Boolean),
           typeof(CI_Citation));

        public static readonly DependencyProperty SupressOnlineResourceProperty = DependencyProperty.Register(
           "SupressOnlineResource",
           typeof(Boolean),
           typeof(CI_Citation));

        public Boolean SupressParties
        {
            get { return (Boolean)this.GetValue(SupressPartiesProperty); }
            set { this.SetValue(SupressPartiesProperty, value); }
        }

        public Boolean SupressOnlineResource
        {
            get { return (Boolean)this.GetValue(SupressOnlineResourceProperty); }
            set { this.SetValue(SupressOnlineResourceProperty, value); }
        }

        public CI_Citation()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

    }
}