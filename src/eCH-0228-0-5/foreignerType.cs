// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using eCH_0007_6_0;

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class foreignerType
{

    private foreignerPersonType foreignerPersonField;

    private SwissMunicipality municipalityField;

    /// <remarks/>
    public foreignerPersonType foreignerPerson
    {
        get { return this.foreignerPersonField; }
        set { this.foreignerPersonField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("municipality")]
    public SwissMunicipality Municipality
    {
        get { return this.municipalityField; }
        set { this.municipalityField = value; }
    }
}
