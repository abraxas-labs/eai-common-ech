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
public partial class voteType
{

    private string voteIdentificationField;

    private VoteDescriptionInformationType voteDescriptionInformationField;

    private voteTypeBallot[] ballotField;

    private namedCodeType[] individualVoteVerificationCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("voteIdentification", DataType = "token")]
    public string VoteIdentification
    {
        get { return this.voteIdentificationField; }
        set { this.voteIdentificationField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("voteDescription")]
    public VoteDescriptionInformationType VoteDescription
    {
        get { return this.voteDescriptionInformationField; }
        set { this.voteDescriptionInformationField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ballot")]
    public voteTypeBallot[] ballot
    {
        get { return this.ballotField; }
        set { this.ballotField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("individualVoteVerificationCode")]
    public namedCodeType[] individualVoteVerificationCode
    {
        get { return this.individualVoteVerificationCodeField; }
        set { this.individualVoteVerificationCodeField = value; }
    }
}
