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
public partial class electionInformationTypeCandidate
{
    private string candidateIdentificationField;
    private CandidateTextInformation candidateTextinformationField;
    private electionInformationTypeCandidateCandidateReference[] candidateField;

    [System.Xml.Serialization.XmlElementAttribute("candidateIdentification")]
    public string CandidateIdentification
    {
        get { return this.candidateIdentificationField; }
        set { this.candidateIdentificationField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("candidateTextinformation")]
    public CandidateTextInformation CandidateTextinformation
    {
        get { return this.candidateTextinformationField; }
        set { this.candidateTextinformationField = value; }
    }

    [System.Xml.Serialization.XmlArrayItemAttribute("candidateReference",
        typeof(electionInformationTypeCandidateCandidateReference), IsNullable = false)]
    public electionInformationTypeCandidateCandidateReference[] candidateReference
    {
        get { return this.candidateField; }
        set { this.candidateField = value; }
    }
}
