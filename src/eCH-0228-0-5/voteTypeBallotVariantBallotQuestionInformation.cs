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
public partial class voteTypeBallotVariantBallotQuestionInformation
{
    private string questionIdentificationField;

    private int? ballotQuestionNumberField;

    private int? questionPosition;

    private answerOptionType[] questionInformationField;

    private BallotQuestion ballotQuestionField;

    [System.Xml.Serialization.XmlElementAttribute("questionIdentification", DataType = "token")]
    public string QuestionIdentification
    {
        get { return this.questionIdentificationField; }
        set { this.questionIdentificationField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("ballotQuestionNumber", DataType = "positiveInteger")]
    public int? BallotQuestionNumber
    {
        get { return this.ballotQuestionNumberField; }
        set { this.ballotQuestionNumberField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("questionPosition", DataType = "positiveInteger")]
    public int? QuestionPosition
    {
        get { return this.questionPosition; }
        set { this.questionPosition = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("ballotQuestion")]
    public BallotQuestion BallotQuestion
    {
        get { return this.ballotQuestionField; }
        set { this.ballotQuestionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("answerOption", IsNullable = false)]
    public answerOptionType[] questionInformation
    {
        get { return this.questionInformationField; }
        set { this.questionInformationField = value; }
    }
}
