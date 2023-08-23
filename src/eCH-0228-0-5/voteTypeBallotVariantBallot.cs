// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class voteTypeBallotVariantBallot
{

    private voteTypeBallotVariantBallotQuestionInformation[] questionInformationField;

    private voteTypeBallotVariantBallotTieBreakInformation[] tieBreakInformationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("questionInformation")]
    public voteTypeBallotVariantBallotQuestionInformation[] questionInformation
    {
        get { return this.questionInformationField; }
        set { this.questionInformationField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("tieBreakInformation")]
    public voteTypeBallotVariantBallotTieBreakInformation[] tieBreakInformation
    {
        get { return this.tieBreakInformationField; }
        set { this.tieBreakInformationField = value; }
    }
}
