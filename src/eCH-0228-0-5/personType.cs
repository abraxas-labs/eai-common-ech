// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using eCH_0044_4_1;
using eCH_0045_4_0;

namespace eCH_0228;

/// <remarks/>
[System.Xml.Serialization.XmlIncludeAttribute(typeof(foreignerPersonType))]
[System.Xml.Serialization.XmlIncludeAttribute(typeof(swissPersonType))]
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class personType
{

    private PersonIdentification personIdentificationField;

    private string callNameField;

    private string allianceNameField;

    private LanguageType languageOfCorrespondanceField;

    private object extensionField;

    /// <remarks/>
    public PersonIdentification personIdentification
    {
        get { return this.personIdentificationField; }
        set { this.personIdentificationField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("callName", DataType = "token")]
    public string CallName
    {
        get { return this.callNameField; }
        set { this.callNameField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("allianceName", DataType = "token")]
    public string AllianceName
    {
        get { return this.allianceNameField; }
        set { this.allianceNameField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("languageOfCorrespondance")]
    public LanguageType LanguageOfCorrespondance
    {
        get { return this.languageOfCorrespondanceField; }
        set { this.languageOfCorrespondanceField = value; }
    }

    /// <remarks/>
    public object extension
    {
        get { return this.extensionField; }
        set { this.extensionField = value; }
    }
}
