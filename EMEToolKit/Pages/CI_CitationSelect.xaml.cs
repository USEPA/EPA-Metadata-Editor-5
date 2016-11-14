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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for CI_CitationSelect.xaml
    /// </summary>
    public partial class CI_CitationSelect : EditorPage, INotifyPropertyChanged
    {

        public static readonly DependencyProperty SupressPartiesProperty = DependencyProperty.Register(
           "SupressParties",
           typeof(Boolean),
           typeof(CI_CitationSelect));

        public static readonly DependencyProperty SupressOnlineResourceProperty = DependencyProperty.Register(
           "SupressOnlineResource",
           typeof(Boolean),
           typeof(CI_CitationSelect));

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

        public CI_CitationSelect()
        {
            InitializeComponent();
        }

        public List<Control> AllChildren(DependencyObject parent)
        {
            var _List = new List<Control> { };
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is Control)
                    _List.Add(_Child as Control);
                _List.AddRange(AllChildren(_Child));
            }
            return _List;
        }

        private void btnThesanameEPA_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = lbxCitation;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var thesTitle = "tbxResTitle";
                var altName = "tbxAltTitle";
                var tbxResTitle = (TextBox)liBoxChildren.First(c => c.Name == thesTitle);
                var tbxAltTitle = (TextBox)liBoxChildren.First(c => c.Name == altName);
                tbxResTitle.Text = "EPA GIS Keyword Thesaurus";
                tbxResTitle.Focus();
                tbxAltTitle.Focus();
            }
        }

        private void btnThesanameUser_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = lbxCitation;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var thesTitle = "tbxResTitle";
                var altName = "tbxAltTitle";
                var tbxResTitle = (TextBox)liBoxChildren.First(c => c.Name == thesTitle);
                var tbxAltTitle = (TextBox)liBoxChildren.First(c => c.Name == altName);
                tbxResTitle.Text = "User";
                tbxResTitle.Focus();
                tbxAltTitle.Focus();
            }
        }

        private void btnThesanameNew_Click(object sender, RoutedEventArgs e)
        {
            Style style = (Style) this.FindResource("EditorTextBoxStyle");
            ListBox liBox = lbxCitation;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var thesTitle = "tbxResTitle";
                var altName = "tbxAltTitle";
                var tbxResTitle = (TextBox)liBoxChildren.First(c => c.Name == thesTitle);
                var tbxAltTitle = (TextBox)liBoxChildren.First(c => c.Name == altName);
                tbxResTitle.Style = style;
                tbxResTitle.Focus();
                //tbxAltTitle.Focus();
            }
        }

        private void btnThesanameCode_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = lbxCitation;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var thesTitle = "tbxResTitle";
                var altName = "tbxAltTitle";
                var tbxResTitle = (TextBox)liBoxChildren.First(c => c.Name == thesTitle);
                var tbxAltTitle = (TextBox)liBoxChildren.First(c => c.Name == altName);
                tbxResTitle.Text = "Federal Program Inventory";
                tbxResTitle.Focus();
                tbxAltTitle.Focus();
            }
        }
    }
}