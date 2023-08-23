// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class electionInformationTypeListCandidatePosition
{

    private int positionOnListField;

    private string candidateReferenceOnPositionField;

    private string candidateIdentificationField;

    private int occurencesField;

    private string checkingNumberField;

    private namedCodeType[] individualCandidateVerificationCodeField;

    [System.Xml.Serialization.XmlElementAttribute("positionOnList", DataType = "positiveInteger")]
    public int PositionOnList
    {
        get { return this.positionOnListField; }
        set { this.positionOnListField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("candidateReferenceOnPosition", DataType = "token")]
    public string CandidateReferenceOnPosition
    {
        get { return this.candidateReferenceOnPositionField; }
        set { this.candidateReferenceOnPositionField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("candidateIdentification", DataType = "token")]
    public string CandidateIdentification
    {
        get { return this.candidateIdentificationField; }
        set { this.candidateIdentificationField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
    public int occurences
    {
        get { return this.occurencesField; }
        set { this.occurencesField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string checkingNumber
    {
        get { return this.checkingNumberField; }
        set { this.checkingNumberField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("individualCandidateVerificationCode")]
    public namedCodeType[] individualCandidateVerificationCode
    {
        get { return this.individualCandidateVerificationCodeField; }
        set { this.individualCandidateVerificationCodeField = value; }
    }
}
