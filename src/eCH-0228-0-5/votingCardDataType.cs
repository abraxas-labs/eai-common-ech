// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using eCH_0010_5_1;
using eCH_0044_4_1;
using eCH_0045_4_0;

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class votingCardDataType
{

    private string votingCardSequenceNumberField;

    private string frankingAreaField;

    private object itemField;

    private OrganisationMailAddress votingPlaceInformationField;

    private votingCardIndividualCodesType votingCardIndividualCodesField;

    private OrganisationMailAddress votingCardReturnAddressField;
    private namedCodeType[] individualLogisticCodeField;

    private object extensionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string votingCardSequenceNumber
    {
        get { return this.votingCardSequenceNumberField; }
        set { this.votingCardSequenceNumberField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string frankingArea
    {
        get { return this.frankingAreaField; }
        set { this.frankingAreaField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("personIdentification", typeof(PersonIdentification))]
    [System.Xml.Serialization.XmlElementAttribute("votingPerson", typeof(VotingPersonType))]
    public object Item
    {
        get { return this.itemField; }
        set { this.itemField = value; }
    }

    /// <remarks/>
    public OrganisationMailAddress votingPlaceInformation
    {
        get { return this.votingPlaceInformationField; }
        set { this.votingPlaceInformationField = value; }
    }

    /// <remarks/>
    public votingCardIndividualCodesType votingCardIndividualCodes
    {
        get { return this.votingCardIndividualCodesField; }
        set { this.votingCardIndividualCodesField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("votingCardReturnAddress")]
    public OrganisationMailAddress VotingCardReturnAddress
    {
        get { return this.votingCardReturnAddressField; }
        set { this.votingCardReturnAddressField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("individualLogisticCode")]
    public namedCodeType[] individualLogisticCode
    {
        get { return this.individualLogisticCodeField; }
        set { this.individualLogisticCodeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("extension")]
    public object Extension
    {
        get { return this.extensionField; }
        set { this.extensionField = value; }
    }
}
