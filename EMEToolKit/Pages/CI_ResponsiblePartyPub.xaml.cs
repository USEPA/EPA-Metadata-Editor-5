﻿/*
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

using ESRI.ArcGIS.Metadata.Editor;
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for CI_ResponsiblePartyPub.xaml
    /// </summary>
    public partial class CI_ResponsiblePartyPub : EditorPage, INotifyPropertyChanged
    {
        public CI_ResponsiblePartyPub()
        {
            InitializeComponent();
        }

        public override string DefaultValue
        {
            get
            {
                return Utils.ExtractResponsiblePartyLabel(this, ESRI.ArcGIS.Metadata.Editor.Properties.Resources.LBL_CI_PARTY_FORMAT);
            }

            set
            {
                // NOOP
            }
        }
    }
}
