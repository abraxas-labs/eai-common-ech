// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class electionInformationTypeWriteInCodes
{

    private string positionField;

    private string individualWriteInVerificationCodeField;

    private electionInformationTypeWriteInCodesWriteInCodeDesignation[] writeInCodeDesignationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
    public string position
    {
        get { return this.positionField; }
        set { this.positionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string individualWriteInVerificationCode
    {
        get { return this.individualWriteInVerificationCodeField; }
        set { this.individualWriteInVerificationCodeField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("writeInCodeDesignation")]
    public electionInformationTypeWriteInCodesWriteInCodeDesignation[] writeInCodeDesignation
    {
        get { return this.writeInCodeDesignationField; }
        set { this.writeInCodeDesignationField = value; }
    }
}
