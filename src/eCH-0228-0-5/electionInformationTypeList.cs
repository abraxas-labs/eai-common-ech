// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using eCH_0155_4_0;
using ListDescriptionInformation = eCH_0155_4_0.ListDescriptionInformation;

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class electionInformationTypeList
{
    private string listIdentificationField;
    private string listIndentureNumberField;
    private ListDescriptionInformation listDescriptionInformationField;
    private bool isEmptyListField;
    private int listOrderOfPrecedenceField;
    private ListUnionDescriptionType listUnionBallotTextField;
    private namedCodeType[] individualListVerificationCodesField;

    private electionInformationTypeListCandidatePosition[] candidatePositionField;


    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("listIdentification")]
    public string ListIdentification
    {
        get { return this.listIdentificationField; }
        set { this.listIdentificationField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("listIndentureNumber", DataType = "token")]
    public string ListIndentureNumber
    {
        get { return this.listIndentureNumberField; }
        set { this.listIndentureNumberField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("listDescription")]
    public ListDescriptionInformation ListDescriptionInformation
    {
        get { return this.listDescriptionInformationField; }
        set { this.listDescriptionInformationField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("isEmptyList")]
    public bool IsEmptyList
    {
        get { return this.isEmptyListField; }
        set { this.isEmptyListField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("listOrderOfPrecedence", DataType = "positiveInteger")]
    public int ListOrderOfPrecedence
    {
        get { return this.listOrderOfPrecedenceField; }
        set { this.listOrderOfPrecedenceField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("listUnionBallotText")]
    public ListUnionDescriptionType ListUnionBallotText
    {
        get { return this.listUnionBallotTextField; }
        set { this.listUnionBallotTextField = value; }
    }



    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("individualListVerificationCodes")]
    public namedCodeType[] individualListVerificationCodes
    {
        get { return this.individualListVerificationCodesField; }
        set { this.individualListVerificationCodesField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("candidatePosition")]
    public electionInformationTypeListCandidatePosition[] candidatePosition
    {
        get { return this.candidatePositionField; }
        set { this.candidatePositionField = value; }
    }
}
