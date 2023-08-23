// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class answerOptionType
{
    private string answerIdentificationField;

    private string answerSequenceNumberField;

    private answerOptionTypeAnswerTextInformation[] answerTextInformationField;

    private string individualVoteVerificationCodeField;


    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("answerIdentification", DataType = "token")]
    public string AnswerIdentification
    {
        get { return this.answerIdentificationField; }
        set { this.answerIdentificationField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
    public string answerSequenceNumber
    {
        get { return this.answerSequenceNumberField; }
        set { this.answerSequenceNumberField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("answerTextInformation")]
    public answerOptionTypeAnswerTextInformation[] answerTextInformation
    {
        get { return this.answerTextInformationField; }
        set { this.answerTextInformationField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string individualVoteVerificationCode
    {
        get { return this.individualVoteVerificationCodeField; }
        set { this.individualVoteVerificationCodeField = value; }
    }
}
