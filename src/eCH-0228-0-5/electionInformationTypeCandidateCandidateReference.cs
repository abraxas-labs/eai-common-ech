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
public partial class electionInformationTypeCandidateCandidateReference
{
    private string candidateReferenceField;
    private string occurencesField;
    private CandidateTextInformation candidateTextOnPositionField;
    private namedCodeType[] individualCandidateVerificationCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("candidateReference")]
    public string CandidateReference
    {
        get { return this.candidateReferenceField; }
        set { this.candidateReferenceField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
    public string Occurences
    {
        get { return this.occurencesField; }
        set { this.occurencesField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "candidateTextOnPosition")]
    public CandidateTextInformation CandidateTextOnPosition
    {
        get { return this.candidateTextOnPositionField; }
        set { this.candidateTextOnPositionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("individualCandidateVerificationCode")]
    public namedCodeType[] individualCandidateVerificationCode
    {
        get { return this.individualCandidateVerificationCodeField; }
        set { this.individualCandidateVerificationCodeField = value; }
    }
}
