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

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for MD_RestrictionCode.xaml
    /// </summary>
    public partial class MD_RestrictionCode : EditorPage
    {
        public MD_RestrictionCode()
        {
            InitializeComponent();
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }
            return null;
        }

        private void cboRestrictCd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            ContentPresenter contentPresenter = FindVisualChild<ContentPresenter>(cbo);
            DataTemplate dTemplate = contentPresenter.ContentTemplate;
            TextBlock textClassLbl = (TextBlock)dTemplate.FindName("tbkClassLabel", contentPresenter);
            if (textClassLbl != null)
            {
                tbkRestrictName.Text = textClassLbl.Text;
            }
        }

        private void cboRestrictCd_LostFocus(object sender, RoutedEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            ContentPresenter contentPresenter = FindVisualChild<ContentPresenter>(cbo);
            DataTemplate dTemplate = contentPresenter.ContentTemplate;
            TextBlock textClassLbl = (TextBlock)dTemplate.FindName("tbkClassLabel", contentPresenter);
            if (textClassLbl != null)
            {
                tbkRestrictName.Text = textClassLbl.Text;
            }
        }

        private void cboRestrictCd_LostMouseCapture(object sender, MouseEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            ContentPresenter contentPresenter = FindVisualChild<ContentPresenter>(cbo);
            DataTemplate dTemplate = contentPresenter.ContentTemplate;
            TextBlock textClassLbl = (TextBlock)dTemplate.FindName("tbkClassLabel", contentPresenter);
            if (textClassLbl != null)
            {
                tbkRestrictName.Text = textClassLbl.Text;
            }
        }
    }
}
