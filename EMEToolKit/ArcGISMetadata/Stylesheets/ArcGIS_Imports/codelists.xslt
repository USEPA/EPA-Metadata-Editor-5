<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:res="http://www.esri.com/metadata/res/" xmlns:gmd="http://www.isotc211.org/2005/gmd" >

<!-- An XSLT template for displaying metadata in ArcGIS that is stored in the ArcGIS metadata format.

     Copyright (c) 2009-2013, Environmental Systems Research Institute, Inc. All rights reserved.
	
     Revision History: Created 3/19/2009 avienneau
-->


<!-- templates for handling ISO 19115 code lists -->

<xsl:template name="CI_DateTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idCreation/></xsl:when>
		<xsl:when test="$code = '002'"><res:idPub/></xsl:when>
		<xsl:when test="$code = '003'"><res:idRev/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="CI_OnLineFunctionCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idDownload/></xsl:when>
		<xsl:when test="$code = '002'"><res:idInfo/></xsl:when>
		<xsl:when test="$code = '003'"><res:idOfflineAccess/></xsl:when>
		<xsl:when test="$code = '004'"><res:idOrder/></xsl:when>
		<xsl:when test="$code = '005'"><res:idSearch/></xsl:when>
		<xsl:when test="$code = '006'"><res:idUpload/></xsl:when>
		<xsl:when test="$code = '007'"><res:idWebService/></xsl:when>
		<xsl:when test="$code = '008'"><res:idEmailService/></xsl:when>
		<xsl:when test="$code = '009'"><res:idBrowsing/></xsl:when>
		<xsl:when test="$code = '010'"><res:idFileAccess/></xsl:when>
		<xsl:when test="$code = '011'"><res:idWebMapService/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="CI_PresentationFormCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idDigitalDoc/></xsl:when>
		<xsl:when test="$code = '002'"><res:idHardcopyDoc/></xsl:when>
		<xsl:when test="$code = '003'"><res:idDigitalImg/></xsl:when>
		<xsl:when test="$code = '004'"><res:idHardcopyImg/></xsl:when>
		<xsl:when test="$code = '005'"><res:idDigitalMap/></xsl:when>
		<xsl:when test="$code = '006'"><res:idHardcopyMap/></xsl:when>
		<xsl:when test="$code = '007'"><res:idDigitalModel/></xsl:when>
		<xsl:when test="$code = '008'"><res:idHardcopyModel/></xsl:when>
		<xsl:when test="$code = '009'"><res:idDigitalProfile/></xsl:when>
		<xsl:when test="$code = '010'"><res:idHardcopyProfile/></xsl:when>
		<xsl:when test="$code = '011'"><res:idDigitalTable/></xsl:when>
		<xsl:when test="$code = '012'"><res:idHardcopyTable/></xsl:when>
		<xsl:when test="$code = '013'"><res:idDigitalVid/></xsl:when>
		<xsl:when test="$code = '014'"><res:idHardcopyVid/></xsl:when>
		<xsl:when test="$code = '015'"><res:idDigitalAudio/></xsl:when>
		<xsl:when test="$code = '016'"><res:idHardcopyAudio/></xsl:when>
		<xsl:when test="$code = '017'"><res:idDigitalMultiMed/></xsl:when>
		<xsl:when test="$code = '018'"><res:idHardcopyMultiMed/></xsl:when>
		<xsl:when test="$code = '019'"><res:idDigitalDiagram/></xsl:when>
		<xsl:when test="$code = '020'"><res:idHardcopyDiagram/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="CI_RoleCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idResProv/></xsl:when>
		<xsl:when test="$code = '002'"><res:idCustodian/></xsl:when>
		<xsl:when test="$code = '003'"><res:idOwner/></xsl:when>
		<xsl:when test="$code = '004'"><res:idUser/></xsl:when>
		<xsl:when test="$code = '005'"><res:idDistrib_codelists/></xsl:when>
		<xsl:when test="$code = '006'"><res:idOrigin/></xsl:when>
		<xsl:when test="$code = '007'"><res:idPtContact/></xsl:when>
		<xsl:when test="$code = '008'"><res:idPrincipalInvestigator/></xsl:when>
		<xsl:when test="$code = '009'"><res:idProcessor/></xsl:when>
		<xsl:when test="$code = '010'"><res:idPublisher_codelists/></xsl:when>
		<xsl:when test="$code = '011'"><res:idAuthor/></xsl:when>
		<xsl:when test="$code = '012'"><res:idCollaborator/></xsl:when>
		<xsl:when test="$code = '013'"><res:idEditor/></xsl:when>
		<xsl:when test="$code = '014'"><res:idMediator/></xsl:when>
		<xsl:when test="$code = '015'"><res:idRightsHolder/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="DQ_EvaluationMethodTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idDirectInternal/></xsl:when>
		<xsl:when test="$code = '002'"><res:idDirectExternal/></xsl:when>
		<xsl:when test="$code = '003'"><res:idIndirect/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="DS_AssociationTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idCrossRef_codelists/></xsl:when>
		<xsl:when test="$code = '002'"><res:idLargerWorkCitation_codelists/></xsl:when>
		<xsl:when test="$code = '003'"><res:idPartSeamlessDb/></xsl:when>
		<xsl:when test="$code = '004'"><res:idSrc/></xsl:when>
		<xsl:when test="$code = '005'"><res:idStereoMate/></xsl:when>
		<xsl:when test="$code = '006'"><res:idIsComposedOf/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="DS_InitiativeTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idCampaign/></xsl:when>
		<xsl:when test="$code = '002'"><res:idColl/></xsl:when>
		<xsl:when test="$code = '003'"><res:idEx/></xsl:when>
		<xsl:when test="$code = '004'"><res:idExperiment/></xsl:when>
		<xsl:when test="$code = '005'"><res:idInvestigation/></xsl:when>
		<xsl:when test="$code = '006'"><res:idMission/></xsl:when>
		<xsl:when test="$code = '007'"><res:idSensor/></xsl:when>
		<xsl:when test="$code = '008'"><res:idOperation/></xsl:when>
		<xsl:when test="$code = '009'"><res:idPlatform/></xsl:when>
		<xsl:when test="$code = '010'"><res:idProc/></xsl:when>
		<xsl:when test="$code = '011'"><res:idProg/></xsl:when>
		<xsl:when test="$code = '012'"><res:idProj/></xsl:when>
		<xsl:when test="$code = '013'"><res:idStudy/></xsl:when>
		<xsl:when test="$code = '014'"><res:idTask/></xsl:when>
		<xsl:when test="$code = '015'"><res:idTrial/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_CellGeometryCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idPt/></xsl:when>
		<xsl:when test="$code = '002'"><res:idArea/></xsl:when>
		<xsl:when test="$code = '003'"><res:idVoxel/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_CharSetCd">
	<xsl:param name="code" />
    <xsl:choose>
        <xsl:when test="$code = '001'"><res:idUCS2/></xsl:when>
        <xsl:when test="$code = '002'"><res:idUCS4/></xsl:when>
        <xsl:when test="$code = '003'"><res:idUTF7/></xsl:when>
        <xsl:when test="$code = '004'"><res:idUTF8/></xsl:when>
        <xsl:when test="$code = '005'"><res:idUTF16/></xsl:when>
        <xsl:when test="$code = '006'"><res:id8859p1/></xsl:when>
        <xsl:when test="$code = '007'"><res:id8859p2/></xsl:when>
        <xsl:when test="$code = '008'"><res:id8859p3/></xsl:when>
        <xsl:when test="$code = '009'"><res:id8859p4/></xsl:when>
        <xsl:when test="$code = '010'"><res:id8859p5/></xsl:when>
        <xsl:when test="$code = '011'"><res:id8859p6/></xsl:when>
        <xsl:when test="$code = '012'"><res:id8859p7/></xsl:when>
        <xsl:when test="$code = '013'"><res:id8859p8/></xsl:when>
        <xsl:when test="$code = '014'"><res:id8859p9/></xsl:when>
        <xsl:when test="$code = '015'"><res:id8859p10/></xsl:when>
        <xsl:when test="$code = '016'"><res:id8859p11/></xsl:when>
        <xsl:when test="$code = '017'"><res:idReservedFutureUse/></xsl:when>
        <xsl:when test="$code = '018'"><res:id8859p13/></xsl:when>
        <xsl:when test="$code = '019'"><res:id8859p14/></xsl:when>
        <xsl:when test="$code = '020'"><res:id8859p15/></xsl:when>
        <xsl:when test="$code = '021'"><res:id8859p16/></xsl:when>
        <xsl:when test="$code = '022'"><res:idJIS/></xsl:when>
        <xsl:when test="$code = '023'"><res:idShiftJIS/></xsl:when>
        <xsl:when test="$code = '024'"><res:idEUCJP/></xsl:when>
        <xsl:when test="$code = '025'"><res:idUSASCII/></xsl:when>
        <xsl:when test="$code = '026'"><res:idebcdic/></xsl:when>
        <xsl:when test="$code = '027'"><res:idEUCKR/></xsl:when>
        <xsl:when test="$code = '028'"><res:idBIG5/></xsl:when>
        <xsl:when test="$code = '029'"><res:idGB2312/></xsl:when>
        <xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
    </xsl:choose>
</xsl:template>

<xsl:template name="MD_ClassificationCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idUnclass/></xsl:when>
		<xsl:when test="$code = '002'"><res:idRestr/></xsl:when>
		<xsl:when test="$code = '003'"><res:idConfid/></xsl:when>
		<xsl:when test="$code = '004'"><res:idSecret/></xsl:when>
		<xsl:when test="$code = '005'"><res:idTopSecret/></xsl:when>
		<xsl:when test="$code = '006'"><res:idSensitive/></xsl:when>
		<xsl:when test="$code = '007'"><res:idForOfficialUseOnly/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_CoverageContentTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idImg/></xsl:when>
		<xsl:when test="$code = '002'"><res:idThematicClass/></xsl:when>
		<xsl:when test="$code = '003'"><res:idPhysMeas/></xsl:when>
		<xsl:when test="$code = '101'">EPA Predicted Surface</xsl:when>
		<xsl:when test="$code = '201'">EPA Test Custom Codelists XML File</xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="EPA_Keywords">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'">Agriculture</xsl:when>
		<xsl:when test="$code = '002'">Air</xsl:when>
		<xsl:when test="$code = '003'">Biology</xsl:when>
		<xsl:when test="$code = '004'">Cleanup</xsl:when>
		<xsl:when test="$code = '005'">Climate</xsl:when>
		<xsl:when test="$code = '006'">Compliance</xsl:when>
		<xsl:when test="$code = '007'">Conservation</xsl:when>
		<xsl:when test="$code = '008'">Contaminant</xsl:when>
		<xsl:when test="$code = '009'">Disaster</xsl:when>
		<xsl:when test="$code = '010'">Drinking Water</xsl:when>
		<xsl:when test="$code = '011'">Ecology</xsl:when>
		<xsl:when test="$code = '012'">Ecosystem</xsl:when>
		<xsl:when test="$code = '013'">Emergency</xsl:when>
		<xsl:when test="$code = '014'">Energy</xsl:when>
		<xsl:when test="$code = '015'">Environment</xsl:when>
		<xsl:when test="$code = '016'">Estuary</xsl:when>
		<xsl:when test="$code = '017'">Exposure</xsl:when>
		<xsl:when test="$code = '018'">Facilities</xsl:when>
		<xsl:when test="$code = '019'">Ground Water</xsl:when>
		<xsl:when test="$code = '020'">Hazards</xsl:when>
		<xsl:when test="$code = '021'">Health</xsl:when>
		<xsl:when test="$code = '022'">Human</xsl:when>
		<xsl:when test="$code = '023'">Impact</xsl:when>
		<xsl:when test="$code = '024'">Indicator</xsl:when>
		<xsl:when test="$code = '025'">Indoor Air</xsl:when>
		<xsl:when test="$code = '026'">Inspections</xsl:when>
		<xsl:when test="$code = '027'">Land</xsl:when>
		<xsl:when test="$code = '028'">Management</xsl:when>
		<xsl:when test="$code = '029'">Marine</xsl:when>
		<xsl:when test="$code = '030'">Modeling</xsl:when>
		<xsl:when test="$code = '031'">Monitoring</xsl:when>
		<xsl:when test="$code = '032'">Natural Resources</xsl:when>
		<xsl:when test="$code = '033'">Permits</xsl:when>
		<xsl:when test="$code = '034'">Pesticides</xsl:when>
		<xsl:when test="$code = '035'">Quality</xsl:when>
		<xsl:when test="$code = '036'">Radiation</xsl:when>
		<xsl:when test="$code = '037'">Recreation</xsl:when>
		<xsl:when test="$code = '038'">Regulatory</xsl:when>
		<xsl:when test="$code = '039'">Remediation</xsl:when>
		<xsl:when test="$code = '040'">Response</xsl:when>
		<xsl:when test="$code = '041'">Risk</xsl:when>
		<xsl:when test="$code = '042'">Sites</xsl:when>
		<xsl:when test="$code = '043'">Spills</xsl:when>
		<xsl:when test="$code = '044'">Surface Water</xsl:when>
		<xsl:when test="$code = '045'">Toxics</xsl:when>
		<xsl:when test="$code = '046'">Transportation</xsl:when>
		<xsl:when test="$code = '047'">Waste</xsl:when>
		<xsl:when test="$code = '048'">Water</xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
  </xsl:choose>
</xsl:template>

<xsl:template name="MD_DatatypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idClass/></xsl:when>
		<xsl:when test="$code = '002'"><res:idCodelist/></xsl:when>
		<xsl:when test="$code = '003'"><res:idEnum/></xsl:when>
		<xsl:when test="$code = '004'"><res:idCodelistElem/></xsl:when>
		<xsl:when test="$code = '005'"><res:idAbstractClass/></xsl:when>
		<xsl:when test="$code = '006'"><res:idAggregateClass/></xsl:when>
		<xsl:when test="$code = '007'"><res:idSpecClass/></xsl:when>
		<xsl:when test="$code = '008'"><res:idDatatypeClass/></xsl:when>
		<xsl:when test="$code = '009'"><res:idInterfaceClass/></xsl:when>
		<xsl:when test="$code = '010'"><res:idUnionClass/></xsl:when>
		<xsl:when test="$code = '011'"><res:idMetaClass/></xsl:when>
		<xsl:when test="$code = '012'"><res:idTypeClass/></xsl:when>
		<xsl:when test="$code = '013'"><res:idCharString/></xsl:when>
		<xsl:when test="$code = '014'"><res:idInt/></xsl:when>
		<xsl:when test="$code = '015'"><res:idAssoc/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_DimensionNameTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idRowYaxis/></xsl:when>
		<xsl:when test="$code = '002'"><res:idColXaxis/></xsl:when>
		<xsl:when test="$code = '003'"><res:idVertZaxis/></xsl:when>
		<xsl:when test="$code = '004'"><res:idTrack/></xsl:when>
		<xsl:when test="$code = '005'"><res:idCrossTrack/></xsl:when>
		<xsl:when test="$code = '006'"><res:idSensorScanLine/></xsl:when>
		<xsl:when test="$code = '007'"><res:idSampleAlongScanLine/></xsl:when>
		<xsl:when test="$code = '008'"><res:idTimeDur/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_GeometricObjectTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idComplex/></xsl:when>
		<xsl:when test="$code = '002'"><res:idComposite/></xsl:when>
		<xsl:when test="$code = '003'"><res:idCurve/></xsl:when>
		<xsl:when test="$code = '004'"><res:idPoint/></xsl:when>
		<xsl:when test="$code = '005'"><res:idSolid/></xsl:when>
		<xsl:when test="$code = '006'"><res:idSurface/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_ImagingConditionCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idBlurredImg/></xsl:when>
		<xsl:when test="$code = '002'"><res:idCloud/></xsl:when>
		<xsl:when test="$code = '003'"><res:idDegradingObliquity/></xsl:when>
		<xsl:when test="$code = '004'"><res:idFog/></xsl:when>
		<xsl:when test="$code = '005'"><res:idHeavySmokeDust/></xsl:when>
		<xsl:when test="$code = '006'"><res:idNight/></xsl:when>
		<xsl:when test="$code = '007'"><res:idRain/></xsl:when>
		<xsl:when test="$code = '008'"><res:idSemidark/></xsl:when>
		<xsl:when test="$code = '009'"><res:idShadow/></xsl:when>
		<xsl:when test="$code = '010'"><res:idSnow/></xsl:when>
		<xsl:when test="$code = '011'"><res:idTerrainMask/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_KeywordTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idDiscipline/></xsl:when>
		<xsl:when test="$code = '002'"><res:idPlace_codelists/></xsl:when>
		<xsl:when test="$code = '003'"><res:idStratum_codelists/></xsl:when>
		<xsl:when test="$code = '004'"><res:idTemporal_codelists/></xsl:when>
		<xsl:when test="$code = '005'"><res:idTheme_codelists/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_MaintenanceFrequencyCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idCont/></xsl:when>
		<xsl:when test="$code = '002'"><res:idDaily/></xsl:when>
		<xsl:when test="$code = '003'"><res:idWeekly/></xsl:when>
		<xsl:when test="$code = '004'"><res:idFortnightly/></xsl:when>
		<xsl:when test="$code = '005'"><res:idMonthly/></xsl:when>
		<xsl:when test="$code = '006'"><res:idQuarterly/></xsl:when>
		<xsl:when test="$code = '007'"><res:idBiannually/></xsl:when>
		<xsl:when test="$code = '008'"><res:idAnnually/></xsl:when>
		<xsl:when test="$code = '009'"><res:idAsNeeded/></xsl:when>
		<xsl:when test="$code = '010'"><res:idIrregular/></xsl:when>
		<xsl:when test="$code = '011'"><res:idNotPlanned/></xsl:when>
		<xsl:when test="$code = '012'"><res:idUnkn/></xsl:when>
		<xsl:when test="$code = '013'"><res:idSemiMonthly/></xsl:when>
		<xsl:when test="$code = '998'"><res:idUnkn/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_MediumFormatCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idCpio/></xsl:when>
		<xsl:when test="$code = '002'"><res:idTar/></xsl:when>
		<xsl:when test="$code = '003'"><res:idHighSierraFileSys/></xsl:when>
		<xsl:when test="$code = '004'"><res:idIso9660Cdrom/></xsl:when>
		<xsl:when test="$code = '005'"><res:idIso9660RockRidgeUnix/></xsl:when>
		<xsl:when test="$code = '006'"><res:idIso9660AppleHfs/></xsl:when>
		<xsl:when test="$code = '007'"><res:idUDF/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_MediumNameCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idCdrom/></xsl:when>
		<xsl:when test="$code = '002'"><res:idDvd/></xsl:when>
		<xsl:when test="$code = '003'"><res:idDvdrom/></xsl:when>
		<xsl:when test="$code = '004'"><res:id3.5InFDD/></xsl:when>
		<xsl:when test="$code = '005'"><res:id5.25InFDD/></xsl:when>
		<xsl:when test="$code = '006'"><res:id7TrackTape/></xsl:when>
		<xsl:when test="$code = '007'"><res:id9TrackTape/></xsl:when>
		<xsl:when test="$code = '008'"><res:id3480CartridgeTape/></xsl:when>
		<xsl:when test="$code = '009'"><res:id3490CartridgeTape/></xsl:when>
		<xsl:when test="$code = '010'"><res:id3580CartridgeTape/></xsl:when>
		<xsl:when test="$code = '011'"><res:id4mmCartridgeTape/></xsl:when>
		<xsl:when test="$code = '012'"><res:id8mmCartridgeTape/></xsl:when>
		<xsl:when test="$code = '013'"><res:id0.25InCartridgeTape/></xsl:when>
		<xsl:when test="$code = '014'"><res:idDigitalLinearTape/></xsl:when>
		<xsl:when test="$code = '015'"><res:idOnlineLink/></xsl:when>
		<xsl:when test="$code = '016'"><res:idSatLink/></xsl:when>
		<xsl:when test="$code = '017'"><res:idTelephoneLink/></xsl:when>
		<xsl:when test="$code = '018'"><res:idHardcopy/></xsl:when>
		<xsl:when test="$code = '019'"><res:idHardcopyDiazoPolyester08/></xsl:when>
		<xsl:when test="$code = '020'"><res:idHardcopyCardMicrofilm/></xsl:when>
		<xsl:when test="$code = '021'"><res:idHardcopyMicrofilm240/></xsl:when>
		<xsl:when test="$code = '022'"><res:idHardcopyMicrofilm35/></xsl:when>
		<xsl:when test="$code = '023'"><res:idHardcopyMicrofilm70/></xsl:when>
		<xsl:when test="$code = '024'"><res:idHardcopyMicrofilmGeneral/></xsl:when>
		<xsl:when test="$code = '025'"><res:idHardcopyMicrofilmMicrofiche/></xsl:when>
		<xsl:when test="$code = '026'"><res:idHardcopyNegativePhoto/></xsl:when>
		<xsl:when test="$code = '027'"><res:idHardcopyPaper/></xsl:when>
		<xsl:when test="$code = '028'"><res:idHardcopyDiazo/></xsl:when>
		<xsl:when test="$code = '029'"><res:idHardcopyPhoto/></xsl:when>
		<xsl:when test="$code = '030'"><res:idHardcopyTracedPaper/></xsl:when>
		<xsl:when test="$code = '031'"><res:idHardDisk/></xsl:when>
		<xsl:when test="$code = '032'"><res:idUSBFlashDrive/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<!-- enumeration -->
<xsl:template name="MD_ObligationCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idMandatory/></xsl:when>
		<xsl:when test="$code = '002'"><res:idOptional/></xsl:when>
		<xsl:when test="$code = '003'"><res:idConditional/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<!-- enumeration -->
<xsl:template name="MD_PixelOrientationCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idCenter/></xsl:when>
		<xsl:when test="$code = '002'"><res:idLowerLeft/></xsl:when>
		<xsl:when test="$code = '003'"><res:idLowerRight/></xsl:when>
		<xsl:when test="$code = '004'"><res:idUpperRight/></xsl:when>
		<xsl:when test="$code = '005'"><res:idUpperLeft/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_ProgressCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idCompleted/></xsl:when>
		<xsl:when test="$code = '002'"><res:idHistArchive/></xsl:when>
		<xsl:when test="$code = '003'"><res:idObsolete/></xsl:when>
		<xsl:when test="$code = '004'"><res:idOngoing/></xsl:when>
		<xsl:when test="$code = '005'"><res:idPlanned/></xsl:when>
		<xsl:when test="$code = '006'"><res:idReqd/></xsl:when>
		<xsl:when test="$code = '007'"><res:idUnderDev/></xsl:when>
		<xsl:when test="$code = '008'"><res:idProposed/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_RestrictionCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idCopyright/></xsl:when>
		<xsl:when test="$code = '002'"><res:idPatent/></xsl:when>
		<xsl:when test="$code = '003'"><res:idPatentPending/></xsl:when>
		<xsl:when test="$code = '004'"><res:idTrademark/></xsl:when>
		<xsl:when test="$code = '005'"><res:idLicense/></xsl:when>
		<xsl:when test="$code = '006'"><res:idIntellectualPropRights/></xsl:when>
		<xsl:when test="$code = '007'"><res:idRestr_codelists/></xsl:when>
		<xsl:when test="$code = '008'"><res:idOtherRestr/></xsl:when>
		<xsl:when test="$code = '009'"><res:idLicenseUnrestricted/></xsl:when>
		<xsl:when test="$code = '010'"><res:idLicenseEndUser/></xsl:when>
		<xsl:when test="$code = '011'"><res:idLicenseDistributor/></xsl:when>
		<xsl:when test="$code = '012'"><res:idPrivacy/></xsl:when>
		<xsl:when test="$code = '013'"><res:idStatutory/></xsl:when>
		<xsl:when test="$code = '014'"><res:idConfidential/></xsl:when>
		<xsl:when test="$code = '015'"><res:idSensitivity/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_ScopeCode">
	<xsl:param name="code" />
    <xsl:choose>
        <xsl:when test="$code = '001'"><res:idAttrib_codelists/></xsl:when>
        <xsl:when test="$code = '002'"><res:idAttribType/></xsl:when>
        <xsl:when test="$code = '003'"><res:idCollHw/></xsl:when>
        <xsl:when test="$code = '004'"><res:idCollSession/></xsl:when>
        <xsl:when test="$code = '005'"><res:idDataset/></xsl:when>
        <xsl:when test="$code = '006'"><res:idSeries_codelists/></xsl:when>
        <xsl:when test="$code = '007'"><res:idNongeoDataset/></xsl:when>
        <xsl:when test="$code = '008'"><res:idDimGrp/></xsl:when>
        <xsl:when test="$code = '009'"><res:idFeature/></xsl:when>
        <xsl:when test="$code = '010'"><res:idFeatureType/></xsl:when>
        <xsl:when test="$code = '011'"><res:idPropType/></xsl:when>
        <xsl:when test="$code = '012'"><res:idFieldSession/></xsl:when>
        <xsl:when test="$code = '013'"><res:idSw/></xsl:when>
        <xsl:when test="$code = '014'"><res:idService/></xsl:when>
        <xsl:when test="$code = '015'"><res:idModel/></xsl:when>
        <xsl:when test="$code = '016'"><res:idTile/></xsl:when>
        <xsl:when test="$code = '017'"><res:idInitiative/></xsl:when>
        <xsl:when test="$code = '018'"><res:idStereomate_scope/></xsl:when>
        <xsl:when test="$code = '019'"><res:idSensor_scope/></xsl:when>
        <xsl:when test="$code = '020'"><res:idPlatformSeries/></xsl:when>
        <xsl:when test="$code = '021'"><res:idSensorSeries/></xsl:when>
        <xsl:when test="$code = '022'"><res:idProductionSeries/></xsl:when>
        <xsl:when test="$code = '023'"><res:idTransferAggregate/></xsl:when>
        <xsl:when test="$code = '024'"><res:idOtherAggregate/></xsl:when>
        <xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
    </xsl:choose>
</xsl:template>

<xsl:template name="MD_SpatialRepresentationTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idVec/></xsl:when>
		<xsl:when test="$code = '002'"><res:idGrid/></xsl:when>
		<xsl:when test="$code = '003'"><res:idTextTable/></xsl:when>
		<xsl:when test="$code = '004'"><res:idTin/></xsl:when>
		<xsl:when test="$code = '005'"><res:idStereoModel/></xsl:when>
		<xsl:when test="$code = '006'"><res:idVid/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<!-- enumeration -->
<xsl:template name="MD_TopicCategoryCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idFarming/></xsl:when>
		<xsl:when test="$code = '002'"><res:idBiota/></xsl:when>
		<xsl:when test="$code = '003'"><res:idBounds/></xsl:when>
		<xsl:when test="$code = '004'"><res:idCMA/></xsl:when>
		<xsl:when test="$code = '005'"><res:idEcon/></xsl:when>
		<xsl:when test="$code = '006'"><res:idElev/></xsl:when>
		<xsl:when test="$code = '007'"><res:idEnv/></xsl:when>
		<xsl:when test="$code = '008'"><res:idGSI/></xsl:when>
		<xsl:when test="$code = '009'"><res:idHealth/></xsl:when>
		<xsl:when test="$code = '010'"><res:idImageryBMEC/></xsl:when>
		<xsl:when test="$code = '011'"><res:idIntelMil/></xsl:when>
		<xsl:when test="$code = '012'"><res:idInlandwaters/></xsl:when>
		<xsl:when test="$code = '013'"><res:idLocation/></xsl:when>
		<xsl:when test="$code = '014'"><res:idOceans/></xsl:when>
		<xsl:when test="$code = '015'"><res:idPlancadastre/></xsl:when>
		<xsl:when test="$code = '016'"><res:idSociety/></xsl:when>
		<xsl:when test="$code = '017'"><res:idStructure/></xsl:when>
		<xsl:when test="$code = '018'"><res:idTransportation/></xsl:when>
		<xsl:when test="$code = '019'"><res:idUtilsComm/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="MD_TopologyLevelCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idGeoOnly/></xsl:when>
		<xsl:when test="$code = '002'"><res:idTopo1d/></xsl:when>
		<xsl:when test="$code = '003'"><res:idPlanarGraph/></xsl:when>
		<xsl:when test="$code = '004'"><res:idFullPlanarGraph/></xsl:when>
		<xsl:when test="$code = '005'"><res:idSurfaceGraph/></xsl:when>
		<xsl:when test="$code = '006'"><res:idFullSurfaceGraph/></xsl:when>
		<xsl:when test="$code = '007'"><res:idTopo3d/></xsl:when>
		<xsl:when test="$code = '008'"><res:idFullTopo3d/></xsl:when>
		<xsl:when test="$code = '009'"><res:idAbstract_codelists/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<!-- ArcGIS code lists -->

<xsl:template name="ArcIMS_ContentTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idLiveDataMaps/></xsl:when>
		<xsl:when test="$code = '002'"><res:idDlData/></xsl:when>
		<xsl:when test="$code = '003'"><res:idOfflineData/></xsl:when>
		<xsl:when test="$code = '004'"><res:idStaticMapImages/></xsl:when>
		<xsl:when test="$code = '005'"><res:idOtherDocs/></xsl:when>
		<xsl:when test="$code = '006'"><res:idApps/></xsl:when>
		<xsl:when test="$code = '007'"><res:idGeoSvcs/></xsl:when>
		<xsl:when test="$code = '008'"><res:idClearinghouses/></xsl:when>
		<xsl:when test="$code = '009'"><res:idMapFiles/></xsl:when>
		<xsl:when test="$code = '010'"><res:idGeoActivities/></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
   </xsl:choose>
</xsl:template>

<xsl:template name="GeometryTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = 0"><res:idGeomNull /></xsl:when>
		<xsl:when test="$code = 1"><res:idGeomPt /></xsl:when>
		<xsl:when test="$code = 2"><res:idGeomMultipt /></xsl:when>
		<xsl:when test="$code = 3"><res:idGeomPolyln /></xsl:when>
		<xsl:when test="$code = 4"><res:idGeomPolygn /></xsl:when>
		<xsl:when test="$code = 5"><res:idGeomEnv /></xsl:when>
		<xsl:when test="$code = 6"><res:idGeomPath /></xsl:when>
		<xsl:when test="$code = 7"><res:idGeomAny /></xsl:when>
		<xsl:when test="$code = 9"><res:idGeomMultiptch /></xsl:when>
		<xsl:when test="$code = 11"><res:idGeomRing /></xsl:when>
		<xsl:when test="$code = 13"><res:idGeomLine /></xsl:when>
		<xsl:when test="$code = 14"><res:idGeomCircArc /></xsl:when>
		<xsl:when test="$code = 15"><res:idGeomBez /></xsl:when>
		<xsl:when test="$code = 16"><res:idGeomEllArc /></xsl:when>
		<xsl:when test="$code = 17"><res:idGeomBag /></xsl:when>
		<xsl:when test="$code = 18"><res:idGeomTriStr /></xsl:when>
		<xsl:when test="$code = 19"><res:idGeomTriFan /></xsl:when>
		<xsl:when test="$code = 20"><res:idGeomRay /></xsl:when>
		<xsl:when test="$code = 21"><res:idGeomSph /></xsl:when>
		<xsl:when test="$code = 22"><res:idGeomTri /></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
   </xsl:choose>
</xsl:template>

<xsl:template name="DataQuality_ReportTypeCode">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = 'DQCompComm'"><res:DQCompComm/></xsl:when>
		<xsl:when test="$code = 'DQCompOm'"><res:DQCompOm/></xsl:when>
		<xsl:when test="$code = 'DQConcConsis'"><res:DQConcConsis/></xsl:when>
		<xsl:when test="$code = 'DQDomConsis'"><res:DQDomConsis/></xsl:when>
		<xsl:when test="$code = 'DQFormConsis'"><res:DQFormConsis/></xsl:when>
		<xsl:when test="$code = 'DQTopConsis'"><res:DQTopConsis/></xsl:when>
		<xsl:when test="$code = 'DQAbsExtPosAcc'"><res:DQAbsExtPosAcc/></xsl:when>
		<xsl:when test="$code = 'DQGridDataPosAcc'"><res:DQGridDataPosAcc/></xsl:when>
		<xsl:when test="$code = 'DQRelIntPosAcc'"><res:DQRelIntPosAcc/></xsl:when>
		<xsl:when test="$code = 'DQAccTimeMeas'"><res:DQAccTimeMeas/></xsl:when>
		<xsl:when test="$code = 'DQTempConsis'"><res:DQTempConsis/></xsl:when>
		<xsl:when test="$code = 'DQTempValid'"><res:DQTempValid/></xsl:when>
		<xsl:when test="$code = 'DQThemClassCor'"><res:DQThemClassCor/></xsl:when>
		<xsl:when test="$code = 'DQNonQuanAttAcc'"><res:DQNonQuanAttAcc/></xsl:when>
		<xsl:when test="$code = 'DQQuanAttAcc'"><res:DQQuanAttAcc/></xsl:when>
		<xsl:otherwise><res:DQOtherwise /></xsl:otherwise>
   </xsl:choose>
</xsl:template>

<!-- other ISO code lists -->

<!-- language codes from ISO 639 -->
<xsl:template name="ISO639_LanguageCode">
	<xsl:param name="code" />
    <xsl:choose>
        <xsl:when test="string-length($code) = 2">
			<xsl:call-template name="lang639_2letter">
				<xsl:with-param name="code" select="$code" />
			</xsl:call-template>
        </xsl:when>
        <xsl:when test="string-length($code) = 3">
			<xsl:call-template name="lang639_3letter">
				<xsl:with-param name="code" select="$code" />
			</xsl:call-template>
        </xsl:when>
        <xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
    </xsl:choose>
</xsl:template>

<!-- country codes from ISO 3166 -->
<xsl:template name="ISO3166_CountryCode">
	<xsl:param name="code" />
    <xsl:choose>
        <xsl:when test="string-length($code) = 2">
			<xsl:call-template name="cntry3166_2letter">
				<xsl:with-param name="code" select="$code" />
			</xsl:call-template>
        </xsl:when>
        <xsl:when test="string-length($code) = 3">
			<xsl:call-template name="cntry3166_3letter">
				<xsl:with-param name="code" select="$code" />
			</xsl:call-template>
        </xsl:when>
        <xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
    </xsl:choose>
</xsl:template>

<!-- codes from ISO 19119 -->

<xsl:template name="SV_CouplTypCd">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idCouplLoose /></xsl:when>
		<xsl:when test="$code = '002'"><res:idCouplMixed /></xsl:when>
		<xsl:when test="$code = '003'"><res:idCouplTight /></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="SV_DCPList">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idDcpXml /></xsl:when>
		<xsl:when test="$code = '002'"><res:idDcpCorba /></xsl:when>
		<xsl:when test="$code = '003'"><res:idDcpJava /></xsl:when>
		<xsl:when test="$code = '004'"><res:idDcpCom /></xsl:when>
		<xsl:when test="$code = '005'"><res:idDcpSql /></xsl:when>
		<xsl:when test="$code = '006'"><res:idDcpWebSvc /></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

<xsl:template name="SV_ParamDirCd">
	<xsl:param name="code" />
	<xsl:choose>
		<xsl:when test="$code = '001'"><res:idDirIn /></xsl:when>
		<xsl:when test="$code = '002'"><res:idDirOut /></xsl:when>
		<xsl:when test="$code = '003'"><res:idDirInOut /></xsl:when>
		<xsl:otherwise><xsl:value-of select="$code"/></xsl:otherwise>
	</xsl:choose>
</xsl:template>

</xsl:stylesheet>