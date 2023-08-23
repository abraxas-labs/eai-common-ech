// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class votingPlaceInformationType
{

    private string votingPlaceIdentificationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string votingPlaceIdentification
    {
        get { return this.votingPlaceIdentificationField; }
        set { this.votingPlaceIdentificationField = value; }
    }
}
