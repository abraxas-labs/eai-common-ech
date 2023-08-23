// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class electionInformationTypeEmptyPositionCodes
{

    private string positionField;

    private string individualEmptyPositionVerificationCodeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
    public string position
    {
        get { return this.positionField; }
        set { this.positionField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "token")]
    public string individualEmptyPositionVerificationCode
    {
        get { return this.individualEmptyPositionVerificationCodeField; }
        set { this.individualEmptyPositionVerificationCodeField = value; }
    }
}
