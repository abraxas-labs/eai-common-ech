// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using eCH_0155_4_0;

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class electionInformationType
{

    private ElectionType electionField;

    private electionInformationTypeCandidate[] candidateField;

    private electionInformationTypeList[] listField;

    private electionInformationTypeEmptyPositionCodes[] emptyPositionCodesField;

    private electionInformationTypeWriteInCodes[] writeInCodesField;

    private namedCodeType[] individualElectionVerificationCodeField;

    /// <remarks/>
    public ElectionType election
    {
        get { return this.electionField; }
        set { this.electionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("candidate", typeof(electionInformationTypeCandidate),
        IsNullable = false)]
    public electionInformationTypeCandidate[] candidate
    {
        get { return this.candidateField; }
        set { this.candidateField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("list")]
    public electionInformationTypeList[] list
    {
        get { return this.listField; }
        set { this.listField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("emptyPositionCodes")]
    public electionInformationTypeEmptyPositionCodes[] emptyPositionCodes
    {
        get { return this.emptyPositionCodesField; }
        set { this.emptyPositionCodesField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("writeInCodes")]
    public electionInformationTypeWriteInCodes[] writeInCodes
    {
        get { return this.writeInCodesField; }
        set { this.writeInCodesField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("individualElectionVerificationCode")]
    public namedCodeType[] individualElectionVerificationCode
    {
        get { return this.individualElectionVerificationCodeField; }
        set { this.individualElectionVerificationCodeField = value; }
    }
}
