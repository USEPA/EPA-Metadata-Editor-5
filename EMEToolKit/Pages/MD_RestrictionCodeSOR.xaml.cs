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

using ESRI.ArcGIS.Metadata.Editor;
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for MD_RestrictionCodeSOR.xaml
    /// </summary>
    public partial class MD_RestrictionCodeSOR : EditorPage
    {
        public MD_RestrictionCodeSOR()
        {
            InitializeComponent();
        }

        //public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        //{
        //    if (depObj != null)
        //    {
        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //        {
        //            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
        //            if (child != null && child is T)
        //            {
        //                yield return (T)child;
        //            }

        //            foreach (T childOfChild in FindVisualChildren<T>(child))
        //            {
        //                yield return childOfChild;
        //            }
        //        }
        //    }
        //}

        //public static childItem FindVisualChild<childItem>(DependencyObject obj)
        //    where childItem : DependencyObject
        //{
        //    foreach (childItem child in FindVisualChildren<childItem>(obj))
        //    {
        //        return child;
        //    }
        //    return null;
        //}

        //private void cboRestrictCd_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    ComboBox cbo = (ComboBox)sender;
        //    ContentPresenter contentPresenter = FindVisualChild<ContentPresenter>(cbo);
        //    DataTemplate dTemplate = contentPresenter.ContentTemplate;
        //    TextBlock textClassLbl = (TextBlock)dTemplate.FindName("tbkClassLabel", contentPresenter);
        //    if (textClassLbl != null)
        //    {
        //        tbkRestrictCd.Text = "012";
        //        tbkRestrictName.Text = textClassLbl.Text;
        //    }
        //}

        //private void cboRestrictCd_Loaded(object sender, RoutedEventArgs e)
        //{
        //    PostProcessComboBoxValues(sender, e);
        //    cboRestrictCd.SelectedValue = "012";
        //    tbkRestrictName.Text = "Privacy";
        //}

        private void lblRestrictCd_Loaded(object sender, RoutedEventArgs e)
        {
            tbkRestrictCd.Text = "012";
            tbkRestrictName.Text = "Privacy";
        }
    }
}
