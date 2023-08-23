// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using eCH_0155_4_0;

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class votingCardIndividualCodesTypeElectionGroupBallot
{

    private electionInformationType[] electionInformationField;

    private namedCodeType[] individualElectionGroupVerificationCodesField;
    private string electionGroupIdentificationField;
    private int electionGroupPositionField;
    private ElectionGroupDescriptionType electionGroupDescriptionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("electionGroupIdentification")]
    public string ElectionGroupIdentification
    {
        get { return this.electionGroupIdentificationField; }
        set { this.electionGroupIdentificationField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("electionGroupDescription")]
    public ElectionGroupDescriptionType electionGroupDescription
    {
        get { return this.electionGroupDescriptionField; }
        set { this.electionGroupDescriptionField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
    [System.Xml.Serialization.XmlElementAttribute("electionGroupPosition")]
    public int ElectionGroupPosition
    {
        get { return this.electionGroupPositionField; }
        set { this.electionGroupPositionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("electionInformation")]
    public electionInformationType[] electionInformation
    {
        get { return this.electionInformationField; }
        set { this.electionInformationField = value; }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("individualElectionGroupVerificationCodes")]
    public namedCodeType[] individualElectionGroupVerificationCodes
    {
        get { return this.individualElectionGroupVerificationCodesField; }
        set { this.individualElectionGroupVerificationCodesField = value; }
    }
}
