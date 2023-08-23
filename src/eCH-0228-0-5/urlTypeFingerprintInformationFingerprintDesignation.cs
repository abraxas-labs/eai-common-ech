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
public partial class urlTypeFingerprintInformationFingerprintDesignation
{

    private LanguageType languageField;
    private string fingerprintDesignationTextField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("language")]
    public LanguageType language
    {
        get { return this.languageField; }
        set { this.languageField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string fingerprintDesignationText
    {
        get { return this.fingerprintDesignationTextField; }
        set { this.fingerprintDesignationTextField = value; }
    }
}
