// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using eCH_0155_4_0;

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class voteTypeBallot
{
    private string ballotIdentificationField;

    private int ballotPositionField;

    private BallotDescriptionInformation ballotDescriptionField;

    private BallotDescriptionInformation ballotBroupField;

    private object itemField;

    private object extensionField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ballotIdentification", DataType = "token")]
    public string BallotIdentification
    {
        get { return this.ballotIdentificationField; }
        set { this.ballotIdentificationField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("ballotPosition", DataType = "positiveInteger")]
    public int BallotPosition
    {
        get { return this.ballotPositionField; }
        set { this.ballotPositionField = value; }
    }


    [System.Xml.Serialization.XmlElementAttribute("ballotDescription")]
    public BallotDescriptionInformation BallotDescription
    {
        get { return this.ballotDescriptionField; }
        set { this.ballotDescriptionField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("ballotGroup")]
    public BallotDescriptionInformation BallotGroup
    {
        get { return this.ballotBroupField; }
        set { this.ballotBroupField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("standardBallot", typeof(voteTypeBallotStandardBallot))]
    [System.Xml.Serialization.XmlElementAttribute("variantBallot", typeof(voteTypeBallotVariantBallot))]
    public object Item
    {
        get { return this.itemField; }
        set { this.itemField = value; }
    }

    [System.Xml.Serialization.XmlElementAttribute("extension")]
    public object Extension
    {
        get { return this.extensionField; }
        set { this.extensionField = value; }
    }
}
