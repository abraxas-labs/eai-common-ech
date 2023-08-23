// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class urlType
{

    private string eVotingURLField;

    private urlTypeFingerprintInformation[] fingerprintInformationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string eVotingURL
    {
        get { return this.eVotingURLField; }
        set { this.eVotingURLField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("fingerprintInformation")]
    public urlTypeFingerprintInformation[] fingerprintInformation
    {
        get { return this.fingerprintInformationField; }
        set { this.fingerprintInformationField = value; }
    }
}
