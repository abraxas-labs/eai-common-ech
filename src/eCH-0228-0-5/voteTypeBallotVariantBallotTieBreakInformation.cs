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
public partial class voteTypeBallotVariantBallotTieBreakInformation
{
    private string questionIdentificationField;

    private int? tieBreakQuestionNumberField;

    private int? questionPosition;

    private answerOptionType[] questionInformationField;

    private TieBreakQuestion tieBreakQuestionField;

    [System.Xml.Serialization.XmlElementAttribute("questionIdentification", DataType = "token")]
    public string QuestionIdentification
    {
        get { return this.questionIdentificationField; }
        set { this.questionIdentificationField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("tieBreakQuestionNumber", DataType = "positiveInteger")]
    public int? TieBreakQuestionNumber
    {
        get { return this.tieBreakQuestionNumberField; }
        set { this.tieBreakQuestionNumberField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("questionPosition", DataType = "positiveInteger")]
    public int? QuestionPosition
    {
        get { return this.questionPosition; }
        set { this.questionPosition = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("tieBreakQuestion")]
    public TieBreakQuestion BallotQuestion
    {
        get { return this.tieBreakQuestionField; }
        set { this.tieBreakQuestionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("answerOption", IsNullable = false)]
    public answerOptionType[] questionInformation
    {
        get { return this.questionInformationField; }
        set { this.questionInformationField = value; }
    }
}
