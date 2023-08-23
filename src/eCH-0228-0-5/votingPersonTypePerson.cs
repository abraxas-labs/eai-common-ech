// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class votingPersonTypePerson
{

    private object itemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("foreigner", typeof(foreignerType))]
    [System.Xml.Serialization.XmlElementAttribute("swiss", typeof(swissDomesticType))]
    [System.Xml.Serialization.XmlElementAttribute("swissAbroad", typeof(swissAbroadType))]
    public object Item
    {
        get { return this.itemField; }
        set { this.itemField = value; }
    }
}
