// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using eCH_0007_6_0;
using eCH_0008_3_0;

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class swissAbroadType
{

    private swissPersonType swissAbroadPersonField;

    private Country residenceCountryField;

    private object itemField;

    /// <remarks/>
    public swissPersonType swissAbroadPerson
    {
        get { return this.swissAbroadPersonField; }
        set { this.swissAbroadPersonField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("residenceCountry")]
    public Country ResidenceCountry
    {
        get { return this.residenceCountryField; }
        set { this.residenceCountryField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("municipality", typeof(SwissMunicipality))]
    [System.Xml.Serialization.XmlElementAttribute("canton", typeof(CantonAbbreviation))]
    public object Item
    {
        get { return this.itemField; }
        set { this.itemField = value; }
    }
}
