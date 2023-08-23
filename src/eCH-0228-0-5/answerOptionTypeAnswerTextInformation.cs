// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using eCH_0045_4_0;

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class answerOptionTypeAnswerTextInformation
{
    private LanguageType languageField;
    private string answerTextShortField;

    private string answerTextField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("language")]
    public LanguageType Language
    {
        get { return this.languageField; }
        set { this.languageField = value; }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string answerTextShort
    {
        get { return this.answerTextShortField; }
        set { this.answerTextShortField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string answerText
    {
        get { return this.answerTextField; }
        set { this.answerTextField = value; }
    }
}
