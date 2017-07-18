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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Xml;
using System.Collections;

using ESRI.ArcGIS.Metadata.Editor;
using ESRI.ArcGIS.Metadata.Editor.Pages;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;

namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for ItemInfo.xaml
    /// </summary>
    public partial class ItemInfo : EditorPage
    {
        private Image _thumbnailImage = null;
        private bool _isDefault = false;
        private List<string> _listThemeK = new List<string>();

        public ItemInfo()
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

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        public override string SidebarLabel
        {
            get { return ESRI.ArcGIS.Metadata.Editor.Properties.Resources.CFG_LBL_ITEMINFO; }
        }

        public void DeleteThumbnail(object sender, EventArgs e)
        {
            UseDefaultImage();
        }

        public void UpdateThumbnail(object sender, EventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".png"; // Default file extension
            dlg.Filter = "Image Files(*.PNG;*.JPG;*.BMP;*.GIF)|*.PNG;*.JPG;*.BMP;*.GIF|All files (*.*)|*.*";

            Nullable<bool> result = dlg.ShowDialog();
            if (true == result)
            {
                if (null != dlg.FileName && 0 < dlg.FileName.Length && File.Exists(dlg.FileName))
                {
                    // loadimage
                    try
                    {
                        // fetch via URL
                        Uri imageUri = new Uri(dlg.FileName);
                        BitmapDecoder bmd = BitmapDecoder.Create(imageUri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

                        // reset width
                        ThumbnailImage.Width = double.NaN;

                        // set the source
                        _thumbnailImage.Source = bmd.Frames[0];
                        _isDefault = false;
                    }
                    catch (Exception) { /* noop */ }
                }
            }
        }

        private void CreateThumbnailNode()
        {

            object context = Utils.GetDataContext(this);
            IEnumerable nodes = Utils.GetXmlDataContext(context);
            if (null != nodes)
            {
                foreach (XmlNode node in nodes)
                {

                    XmlDataProvider provider = Resources["ThumbnailXml"] as XmlDataProvider;
                    XmlNode owner = (null == node.OwnerDocument) ? node : node.OwnerDocument;
                    Utils.CopyElements(owner, provider.Document.FirstChild, true, false);

                    break; // paranoid
                }
            }
        }

        private XmlNode GetBinaryThumbnailNode(object sender, bool is_empty_ok)
        {
            object context = Utils.GetDataContext(sender);
            IEnumerable nodes = Utils.GetXmlDataContext(context);

            if (null != nodes)
            {
                foreach (XmlNode node in nodes)
                {
                    // fetch base64 image
                    //  <Binary><Thumbnail><Data EsriPropertyType="Picture">... 
                    XmlNode dataNode = node.SelectSingleNode("/metadata/Binary/Thumbnail/Data[@EsriPropertyType=\"Picture\"] | /metadata/Binary/Thumbnail/Data[@EsriPropertyType=\"PictureX\"]");
                    if (null != dataNode && (is_empty_ok || 0 < dataNode.InnerText.Trim().Length))
                        return dataNode;
                }
            }

            return null;
        }

        private void CleanThumbnailNodes(bool cleanAll)
        {
            object context = Utils.GetDataContext(this);
            IEnumerable nodes = Utils.GetXmlDataContext(context);

            if (null != nodes)
            {
                foreach (XmlNode node in nodes)
                {
                    // fetch base64 image
                    //  <Binary><Thumbnail><Data EsriPropertyType="Picture">... 
                    XmlNode dataNode = node.SelectSingleNode("/metadata/Binary/Thumbnail/Data[@EsriPropertyType=\"Picture\"]");
                    if (null != dataNode)
                        dataNode.ParentNode.RemoveChild(dataNode);

                    if (cleanAll)
                    {
                        dataNode = node.SelectSingleNode("/metadata/Binary/Thumbnail/Data[@EsriPropertyType=\"PictureX\"]");
                        if (null != dataNode)
                            dataNode.ParentNode.RemoveChild(dataNode);
                    }
                }
            }
        }

        private void UpdateThumbnail()
        {
            // fetch base64 image
            //  <Binary><Thumbnail><Data EsriPropertyType="Picture">... 
            XmlNode base64imageNode = GetBinaryThumbnailNode(this, false);
            if (null != base64imageNode)
            {
                try
                {
                    // get base64 data and convert
                    string base64 = base64imageNode.InnerText;
                    byte[] base64bytes = System.Convert.FromBase64String(base64);

                    MemoryStream ms = new MemoryStream(base64bytes);
                    BitmapDecoder bmd = BitmapDecoder.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.None);

                    // reset width
                    ThumbnailImage.Width = double.NaN;

                    if (null != _thumbnailImage)
                    {
                        _thumbnailImage.Source = bmd.Frames[0];
                        _isDefault = false;
                    }
                }
                catch (Exception ex)
                {
                    /* noop */
                }
            }
            else
            {
                // NO THUMBNAIL
                UseDefaultImage();
            }
        }

        private void UseDefaultImage()
        {
            var obj = this.Resources["EmptyImage"];
            if (null != obj)
            {
                BitmapImage emptyImage = obj as BitmapImage;
                _thumbnailImage.Source = emptyImage;
                ThumbnailImage.Width = 32;
            }
            else
            {
                _thumbnailImage.Source = null;
            }

            // now using default
            _isDefault = true;
        }

        override public void CommitChanges()
        {

            if (null == _thumbnailImage.Source || _isDefault)
            {
                CleanThumbnailNodes(true);
                return;
            }

            JpegBitmapEncoder jbe = new JpegBitmapEncoder();
            jbe.Frames.Add(BitmapFrame.Create(_thumbnailImage.Source as BitmapSource));

            MemoryStream ms = new MemoryStream();
            jbe.Save(ms);

            string base64 = System.Convert.ToBase64String(ms.ToArray(), Base64FormattingOptions.InsertLineBreaks);

            // clean nodes
            CleanThumbnailNodes(false);

            // get the insert node
            XmlNode base64imageNode = GetBinaryThumbnailNode(this, true);
            if (null == base64imageNode)
                CreateThumbnailNode();

            // try again:
            base64imageNode = GetBinaryThumbnailNode(this, true);

            if (null != base64imageNode)
            {
                base64imageNode.InnerText = base64;
            }
        }

        public void LoadedThumbnailImage(object sender, RoutedEventArgs e)
        {

            // add me, so I can be called later
            Utils.GetMetadataEditorControl(this).AddCommitPage(this);

            _thumbnailImage = sender as Image;
            UpdateThumbnail();
        }

        private void tbxMdDateSt_Loaded(object sender, RoutedEventArgs e)
        {
            //tbxMdDateSt.Text = DateTime.Now.ToString("yyyyMMdd");
            tbxMdDateSt.Text = DateTime.Now.ToString("yyyy-MM-dd");
            tbxMdDateSt.Focus();
            tbxTopOfPage.Focus();
        }

        private void btnDelSearchTags_Click(object sender, RoutedEventArgs e)
        {
            if (lbxItemDesc.IsVisible == true)
            {
                ListBox liBox = (ListBox)lbxItemDesc;
                foreach (var liBoxItem in liBox.Items)
                {
                    var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                    var liBoxChildren = AllChildren(liBoxCont);
                    var liBoxName = "tbxSearchTags";
                    var liBoxCtrl = (TextBox)liBoxChildren.First(c => c.Name == liBoxName);
                    //Add logic to copy to clipboard
                    List<string> listSearchTag = new List<string>();
                    if (liBoxCtrl.Text.Any())
                    {
                        string[] strsearchTag = liBoxCtrl.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in strsearchTag)
                        {
                            listSearchTag.Add(s.Trim());
                        }
                    }
                    listSearchTag = listSearchTag.Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();
                    listSearchTag.Sort();
                    //clear TextBox
                    liBoxCtrl.Text = "";
                    liBoxCtrl.Focus();
                    tbxTopOfPage.Focus();
                }
            }
        }
    }

}