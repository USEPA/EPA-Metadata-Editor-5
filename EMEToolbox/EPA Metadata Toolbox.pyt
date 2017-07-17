import arcpy


class Toolbox(object):
    def __init__(self):
        """Define the toolbox (the name of the toolbox is the name of the
        .pyt file)."""
        self.label = "EPA Metadata Toolbox"
        self.alias = ""

        # List of tool classes associated with this toolbox
        self.tools = [upgradeTool,cleanupTool,exportISOTool,saveTemplate,mergeTemplate,importTool]


class upgradeTool(object):
    def __init__(self):
        """Define the tool (tool name is the name of the class)."""
        self.label = "EPA Upgrade FGDC to ArcGIS"
        self.description = "This tool creates a copy of the existing FGDC CSDGM metadata, performs the standard upgrade to ArcGIS Metadata, then adds several extra cleanup steps including copying legacy UUIDs to the ISO-Compliant element and cleaning up all legacy elements. This tool is not recommended for records that have already been upgraded to ArcGIS Metadata."
        self.canRunInBackground = False

    def getParameterInfo(self):
        """Define parameter definitions"""
            # Second parameter
        param0 = arcpy.Parameter(
            displayName="Source Metadata",
            name="sourcemetadata",
            datatype="DEType",
            parameterType="Required",
            direction="Input")

        # Third parameter
        param1 = arcpy.Parameter(
            displayName="Output Metadata",
            name="out_metadata",
            datatype="DEFile",
            parameterType="Required",
            direction="Output")

        params = [param0, param1]
        return params

    def isLicensed(self):
        """Set whether tool is licensed to execute."""
        return True

    def updateParameters(self, parameters):
        """Modify the values and properties of parameters before internal
        validation is performed.  This method is called whenever a parameter
        has been changed."""
        if parameters[1].valueAsText:
            fileExtension = parameters[1].valueAsText[-4:].lower()
            if fileExtension != ".xml":
                parameters[1].value = parameters[1].valueAsText + ".xml"
        return

    def updateMessages(self, parameters):
        """Modify the messages created by internal validation for each tool
        parameter.  This method is called after internal validation."""
        return

    def execute(self, parameters, messages):
        try:
            """The source code of the tool."""
            Source_Metadata = parameters[0].valueAsText
            Output_Metadata = parameters[1].valueAsText

            # Local variables:
            # Esri-provided standard stylesheet for copying metadata.
            exact_copy_of_xslt = arcpy.GetInstallInfo()['InstallDir'] + "Metadata\\Stylesheets\\gpTools\exact Copy Of.xslt"
            Copy_to_be_upgraded = "%scratchworkspace%\\metadatatoupgrade.xml"
            EPAUpgradeCleanup_xslt = "EPAUpgradeCleanup.xslt"

            messages.addMessage("Making a temporary copy of the existing metadata to upgrade...")
            # Process: Copy Metadata for Upgrade
            arcpy.XSLTransform_conversion(Source_Metadata, exact_copy_of_xslt, Copy_to_be_upgraded, "")

            messages.addMessage("Upgrading the metadata...")
            # Process: Upgrade Metadata
            Upgraded_Metadata = arcpy.UpgradeMetadata_conversion(Copy_to_be_upgraded, "FGDC_TO_ARCGIS")

            messages.addMessage("Preserving the UUID and cleaning up legacy elements...")
            # Process: EPA Cleanup
            arcpy.XSLTransform_conversion(Upgraded_Metadata, EPAUpgradeCleanup_xslt, Output_Metadata, "")

            messages.addMessage("Process complete - please review the output carefully before importing or harvesting.")
        except:
            # Cycle through Geoprocessing tool specific errors
            for msg in range(0, arcpy.GetMessageCount()):
                if arcpy.GetSeverity(msg) == 2:
                    arcpy.AddReturnMessage(msg)
        finally:
            # Regardless of errors, clean up intermediate products.
            arcpy.Delete_management(Copy_to_be_upgraded)
        return

class cleanupTool(object):
    def __init__(self):
        """Define the tool (tool name is the name of the class)."""
        self.label = "EPA Cleanup ArcGIS Record"
        self.description = "This tool performs several extra cleanup steps including copying legacy UUIDs to the ISO-Compliant element and cleaning up all legacy elements. This tool is recommended for records that have already been upgraded to ArcGIS Metadata."
        self.canRunInBackground = False

    def getParameterInfo(self):
        """Define parameter definitions"""
            # Second parameter
        param0 = arcpy.Parameter(
            displayName="Source Metadata",
            name="sourcemetadata",
            datatype="DEType",
            parameterType="Required",
            direction="Input")

        # Third parameter
        param1 = arcpy.Parameter(
            displayName="Output Metadata",
            name="out_metadata",
            datatype="DEFile",
            parameterType="Required",
            direction="Output")

        params = [param0, param1]
        return params

    def isLicensed(self):
        """Set whether tool is licensed to execute."""
        return True

    def updateParameters(self, parameters):
        """Modify the values and properties of parameters before internal
        validation is performed.  This method is called whenever a parameter
        has been changed."""
        if parameters[1].valueAsText:
            fileExtension = parameters[1].valueAsText[-4:].lower()
            if fileExtension != ".xml":
                parameters[1].value = parameters[1].valueAsText + ".xml"
        return

    def updateMessages(self, parameters):
        """Modify the messages created by internal validation for each tool
        parameter.  This method is called after internal validation."""
        return

    def execute(self, parameters, messages):
        try:
            """The source code of the tool."""
            Source_Metadata = parameters[0].valueAsText
            Output_Metadata = parameters[1].valueAsText

            # Local variables:
            EPAUpgradeCleanup_xslt = "EPAUpgradeCleanup.xslt"

            messages.addMessage("Preserving the UUID and cleaning up legacy elements...")
            # Process: EPA Cleanup
            arcpy.XSLTransform_conversion(Source_Metadata, EPAUpgradeCleanup_xslt, Output_Metadata, "")

            messages.addMessage("Process complete - please review the output carefully before importing or harvesting.")
        except:
            # Cycle through Geoprocessing tool specific errors
            for msg in range(0, arcpy.GetMessageCount()):
                if arcpy.GetSeverity(msg) == 2:
                    arcpy.AddReturnMessage(msg)
        finally:
            # Regardless of errors, clean up intermediate products.
            pass
        return

class exportISOTool(object):
    def __init__(self):
        """Define the tool (tool name is the name of the class)."""
        self.label = "Export ArcGIS Metadata to ISO"
        self.description = "This tool streamlines exporting ArcGIS metadata to compliant ISO 19115. It is equivalent to using the Export Metadata tool with ArcGIS2ISO19139 as the translator."
        self.canRunInBackground = False

    def getParameterInfo(self):
        """Define parameter definitions"""
            # Second parameter
        param0 = arcpy.Parameter(
            displayName="Source Metadata",
            name="sourcemetadata",
            datatype="DEType",
            parameterType="Required",
            direction="Input")

        # Third parameter
        param1 = arcpy.Parameter(
            displayName="Output Metadata",
            name="out_metadata",
            datatype="DEFile",
            parameterType="Required",
            direction="Output")

        params = [param0, param1]
        return params

    def isLicensed(self):
        """Set whether tool is licensed to execute."""
        return True

    def updateParameters(self, parameters):
        """Modify the values and properties of parameters before internal
        validation is performed.  This method is called whenever a parameter
        has been changed."""
        if parameters[1].valueAsText:
            fileExtension = parameters[1].valueAsText[-4:].lower()
            if fileExtension != ".xml":
                parameters[1].value = parameters[1].valueAsText + ".xml"
        return

    def updateMessages(self, parameters):
        """Modify the messages created by internal validation for each tool
        parameter.  This method is called after internal validation."""
        return

    def execute(self, parameters, messages):
        try:
            """The source code of the tool."""
            Source_Metadata = parameters[0].valueAsText
            Output_Metadata = parameters[1].valueAsText

            # Local variables:
            translator = arcpy.GetInstallInfo()['InstallDir'] + "Metadata\\Translator\\ArcGIS2ISO19139.xml"

            # Process: Export Metadata
            arcpy.ExportMetadata_conversion(Source_Metadata, translator, Output_Metadata)

            messages.addMessage("Process complete - please review the output carefully..")
        except:
            # Cycle through Geoprocessing tool specific errors
            for msg in range(0, arcpy.GetMessageCount()):
                if arcpy.GetSeverity(msg) == 2:
                    arcpy.AddReturnMessage(msg)
        finally:
            # Regardless of errors, clean up intermediate products.
            pass
        return

class saveTemplate(object):
    def __init__(self):
        """Define the tool (tool name is the name of the class)."""
        self.label = "Save record as metadata template"
        self.description = "This tool saves a metadata record as a reusable template by excluding those elements which must be unique in every metadata record, such as title, abstract, unique identifier, etc, leaving those elements that are common across many records."
        self.canRunInBackground = False

    def getParameterInfo(self):
        """Define parameter definitions"""
        param0 = arcpy.Parameter(
            displayName="Source Metadata",
            name="sourcemetadata",
            datatype="DEType",
            parameterType="Required",
            direction="Input")

        param1 = arcpy.Parameter(
            displayName="Output Metadata",
            name="out_metadata",
            datatype="DEFile",
            parameterType="Required",
            direction="Output")

        params = [param0, param1]
        return params

    def isLicensed(self):
        """Set whether tool is licensed to execute."""
        return True

    def updateParameters(self, parameters):
        """Modify the values and properties of parameters before internal
        validation is performed.  This method is called whenever a parameter
        has been changed."""
        if parameters[1].valueAsText:
            fileExtension = parameters[1].valueAsText[-4:].lower()
            if fileExtension != ".xml":
                parameters[1].value = parameters[1].valueAsText + ".xml"
        return

    def updateMessages(self, parameters):
        """Modify the messages created by internal validation for each tool
        parameter.  This method is called after internal validation."""
        return

    def execute(self, parameters, messages):
        try:
            """The source code of the tool."""
            Source_Metadata = parameters[0].valueAsText
            Output_Metadata = parameters[1].valueAsText

            # Local variables:
            saveTemplate_xslt = "saveTemplate.xslt"

            # Process: EPA Cleanup
            arcpy.XSLTransform_conversion(Source_Metadata, saveTemplate_xslt, Output_Metadata, "")

            messages.addMessage("Process complete - please review the output carefully before reusing as a template.")
        except:
            # Cycle through Geoprocessing tool specific errors
            for msg in range(0, arcpy.GetMessageCount()):
                if arcpy.GetSeverity(msg) == 2:
                    arcpy.AddReturnMessage(msg)
        finally:
            # Regardless of errors, clean up intermediate products.
            pass
        return

class mergeTemplate(object):
    def __init__(self):
        """Define the tool (tool name is the name of the class)."""
        self.label = "Merge a selected metadata record with a saved template"
        self.description = "This tool merges a selected metadata record with elements from a saved template record. Elements from the template record will overwrite their equivalents in the selected record, but by design it will exclude those elements which must be unique in every metadata record, such as title, abstract, unique identifier, etc, replacing only those elements that are common across many records. Still, caution is urged when using this tool."
        self.canRunInBackground = False

    def getParameterInfo(self):
        """Define parameter definitions"""
        param0 = arcpy.Parameter(
            displayName="Source Metadata",
            name="sourcemetadata",
            datatype="DEType",
            parameterType="Required",
            direction="Input")

        param1 = arcpy.Parameter(
            displayName="Template Metadata",
            name="template_metadata",
            datatype="DEFile",
            parameterType="Required",
            direction="Input")

        param2 = arcpy.Parameter(
            displayName="Output Metadata",
            name="out_metadata",
            datatype="DEFile",
            parameterType="Required",
            direction="Output")

        params = [param0, param1, param2]
        return params

    def isLicensed(self):
        """Set whether tool is licensed to execute."""
        return True

    def updateParameters(self, parameters):
        """Modify the values and properties of parameters before internal
        validation is performed.  This method is called whenever a parameter
        has been changed."""
        if parameters[2].valueAsText:
            fileExtension = parameters[2].valueAsText[-4:].lower()
            if fileExtension != ".xml":
                parameters[2].value = parameters[2].valueAsText + ".xml"
        return

    def updateMessages(self, parameters):
        """Modify the messages created by internal validation for each tool
        parameter.  This method is called after internal validation."""
        return

    def execute(self, parameters, messages):
        try:
            """The source code of the tool."""
            Source_Metadata = parameters[0].valueAsText
            Template_Metadata = parameters[1].valueAsText
            Output_Metadata = parameters[2].valueAsText

            # Local variables:
            mergeTemplate_xslt = "mergeTemplate.xslt"

            # Process: EPA Cleanup
            arcpy.XSLTransform_conversion(Source_Metadata, mergeTemplate_xslt, Output_Metadata, "Template_Metadata")

            messages.addMessage("Process complete - please review the output carefully.")
        except:
            # Cycle through Geoprocessing tool specific errors
            for msg in range(0, arcpy.GetMessageCount()):
                if arcpy.GetSeverity(msg) == 2:
                    arcpy.AddReturnMessage(msg)
        finally:
            # Regardless of errors, clean up intermediate products.
            pass
        return

class importTool(object):
    def __init__(self):
        """Define the tool (tool name is the name of the class)."""
        self.label = "EPA Import ArcGIS Record"
        self.description = "It is not unusual for the default Esri tools to merge and preserve legacy metadata sections when performing a standard import. This tool first purges all metadata from the target (usually a feature class), then performs a clean import of the source. It does not perform the EPA upgrade or cleanup function, but rather is intended to supplement those tools and allow for a clean import of the output from those tools into a feature class."
        self.canRunInBackground = False

    def getParameterInfo(self):
        """Define parameter definitions"""
            # Second parameter
        param0 = arcpy.Parameter(
            displayName="Source Metadata",
            name="sourcemetadata",
            datatype="DEType",
            parameterType="Required",
            direction="Input")

        # Third parameter
        param1 = arcpy.Parameter(
            displayName="Target Metadata",
            name="out_metadata",
            datatype="DEType",
            parameterType="Required",
            direction="Input")

        params = [param0, param1]
        return params

    def isLicensed(self):
        """Set whether tool is licensed to execute."""
        return True

    def updateParameters(self, parameters):
        """Modify the values and properties of parameters before internal
        validation is performed.  This method is called whenever a parameter
        has been changed."""
        return

    def updateMessages(self, parameters):
        """Modify the messages created by internal validation for each tool
        parameter.  This method is called after internal validation."""
        return

    def execute(self, parameters, messages):
        try:
            """The source code of the tool."""
            Source_Metadata = parameters[0].valueAsText
            Target_Metadata = parameters[1].valueAsText

            # Local variables:
            blankDoc = "blankdoc.xml"

            messages.addMessage("Performing complete purge of existing metadata")
            # Process: Purge
            arcpy.MetadataImporter_conversion(blankDoc, Target_Metadata)
            messages.addMessage("Importing new metadata")
            # Process: Import
            arcpy.MetadataImporter_conversion(Source_Metadata, Target_Metadata)

            messages.addMessage("Process complete - please review the output carefully.")
        except:
            # Cycle through Geoprocessing tool specific errors
            for msg in range(0, arcpy.GetMessageCount()):
                if arcpy.GetSeverity(msg) == 2:
                    arcpy.AddReturnMessage(msg)
        finally:
            # Regardless of errors, clean up intermediate products.
            pass
        return
