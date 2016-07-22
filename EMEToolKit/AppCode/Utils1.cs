using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace EPAMetadataEditor.AppCode
{
    public static class Utils1
    {
        //global static utilities
        public static DataSet emeDataSet;
        public static DataSet emeDataSetEditor;
        public static string[] dataTableNames;
        public static System.Diagnostics.Process globalHelpProc = new System.Diagnostics.Process();

        public static string EmeUserAppDataFolder
        {
            get
            {
                return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\Innovate! Inc\\EPA Metadata Edtior 4x\\";
            }
            //get { return Path.GetDirectoryName(Assembly.GetCallingAssembly().Location); }
        }
        public static string EmeInstallFolder
        {
            get { return Path.GetDirectoryName(Assembly.GetCallingAssembly().Location); }
        }

        public static void setEmeDataSets()
        {
            try
            {
                //Check that directory exists.  If not, try to copy for the specific user from the CallingAssembly Location                

                if (!Directory.Exists(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb"))
                {
                    string sourceDirPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) + "\\Eme4xSystemFiles\\EMEdb";
                    //MessageBox.Show(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location));
                    //MessageBox.Show(sourceDirPath);
                    DirectoryCopy(sourceDirPath, EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb", true);

                }

                emeDataSet = new DataSet();
                emeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
                //emeDataSet.ReadXml(Directory.GetCurrentDirectory() + "\\Eme4xSystemFiles\\EMEdb\\Publisher.xml");            
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\Publisher.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\OnlineLinkage.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\KeywordsEPA.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\KeywordsISO.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\KeywordsUser.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\KeywordsPlace.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\Contact_Information.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\BoundingBox.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\Citation.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\DistributionLiability.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\ProgramCode.xml");
                emeDataSet.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\SystemofRecords.xml");
                emeDataSet.DataSetName = "emeData";

                emeDataSetEditor = emeDataSet;
                //new DataSet();
                //emeDataSetEditor = 

                //use for databinding to drop list
                //dataTableNames = new string[]{"Publisher", "OnlineLinkage", "KeywordsEPA", "KeywordsISO",
                //"KeywordsUser","KeywordsPlace","Contact_Information", "BoundingBox", "Citation", "DistributionLiability", "ProgramCode"};
                dataTableNames = new string[]{"Contact_Information", "BoundingBox", "KeywordsEPA", "KeywordsISO",
                "KeywordsUser","KeywordsPlace"};
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Loading Data Files!"
                    + System.Environment.NewLine
                    + "Please confirm the following directory is installed: "
                    + EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static DataSet codeListValuesDataSet;
        public static void setCodeListValues()
        {
            codeListValuesDataSet = new DataSet("codeLists");

            string codelistPath = @"C:\DEV\EMEMetadataToolKit\EMEToolKit\Codelists\Codelists_ArcGIS.xml";

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(codelistPath);
            XmlNodeList codelistNodes = xdoc.SelectNodes("//codelist");

            foreach (XmlNode xnode in codelistNodes)
            {
                //create a table and name after each codelist
                string codelistName = (xnode.Attributes["id"] != null) ? xnode.Attributes["id"].Value : "noName";

                DataTable codelistDT = new DataTable(codelistName);
                codelistDT.Columns.Add("codeListName", typeof(string));
                codelistDT.Columns.Add("cLsource", typeof(string));
                codelistDT.Columns.Add("xmlns", typeof(string));
                codelistDT.Columns.Add("cValue", typeof(string));
                codelistDT.Columns.Add("cSource", typeof(string));
                codelistDT.Columns.Add("cStdValue", typeof(string));
                codelistDT.Columns.Add("cDisplayValue", typeof(string));


                //Get each CL Value
                XmlNodeList codelistvalues = xnode.SelectNodes("./code");
                foreach (XmlNode codeNode in codelistvalues)
                {

                    string clsource = (xnode.Attributes["source"] != null) ? xnode.Attributes["source"].Value.ToString() : "";
                    string xmlns = (xnode.Attributes["xmlns"] != null) ? xnode.Attributes["xmlns"].Value.ToString() : "";
                    string cValue = (codeNode.Attributes["value"] != null) ? codeNode.Attributes["value"].Value.ToString() : "";
                    string cSource = (codeNode.Attributes["source"] != null) ? codeNode.Attributes["source"].Value.ToString() : "";
                    //XmlNode testnode = codeNode.Attributes["stdvalue"];
                    string cStdValue = (codeNode.Attributes["stdvalue"] != null) ? codeNode.Attributes["stdvalue"].Value.ToString() : "";
                    string cDisplayValue = (codeNode.InnerText != null) ? codeNode.InnerText.ToString() : "";
                    codelistDT.Rows.Add(codelistName, clsource, xmlns, cValue, cSource, cStdValue, cDisplayValue);

                }
                codeListValuesDataSet.Tables.Add(codelistDT);
            }
            string tablecount = codeListValuesDataSet.Tables.Count.ToString();


            //codeListValues.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;


        }

        public static DataSet emeSettingsDataset;
        public static void setEmeSettingsDataset()
        {
            try
            {
                emeSettingsDataset = new DataSet();
                emeSettingsDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
                //emeSettingsDataset.ReadXml(Directory.GetCurrentDirectory() + "\\Eme4xSystemFiles\\EMEdb\\emeSettings.xml");
                emeSettingsDataset.ReadXml(EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb\\emeSettings.xml");
                emeSettingsDataset.DataSetName = "emeSettings";
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Loading Data Files!"
                    + System.Environment.NewLine
                    + "Please confirm the following directory is installed: "
                    + EmeUserAppDataFolder + "\\Eme4xSystemFiles\\EMEdb", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
