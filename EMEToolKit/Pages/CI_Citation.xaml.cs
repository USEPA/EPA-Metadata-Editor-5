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
using System.ComponentModel;

using ESRI.ArcGIS.Metadata.Editor; using ESRI.ArcGIS.Metadata.Editor.Pages; namespace EPAMetadataEditor.Pages
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
            ListBox liBox = (ListBox)lbxCitation;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "tbxResTitle";
                var liBoxCtrl = (TextBox)liBoxChildren.First(c => c.Name == liBoxName);
                liBoxCtrl.Text = "EPA GIS Keyword Thesaurus";
                liBoxCtrl.Focus();
            }
        }

        private void btnThesanameUser_Click(object sender, RoutedEventArgs e)
        {
            ListBox liBox = (ListBox)lbxCitation;
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                var liBoxName = "tbxResTitle";
                var liBoxCtrl = (TextBox)liBoxChildren.First(c => c.Name == liBoxName);
                liBoxCtrl.Text = "User";
                liBoxCtrl.Focus();
            }
        }
    }
}
