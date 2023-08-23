// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using eCH_0155_4_0;

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public class ContestDataType
{

    private namedCodeType[] eVotingContestCodesField;
    private object itemField;
    private urlType[] eVotingUrlInfoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("eVotingContestCodes")]
    public namedCodeType[] eVotingContestCodes
    {
        get { return this.eVotingContestCodesField; }
        set { this.eVotingContestCodesField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("eVotingUrlInfo")]
    public urlType[] eVotingUrlInfo
    {
        get { return this.eVotingUrlInfoField; }
        set { this.eVotingUrlInfoField = value; }
    }



    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("contest", typeof(ContestType))]
    [System.Xml.Serialization.XmlElementAttribute("contestIdentification", typeof(string))]
    public object Item
    {
        get { return this.itemField; }
        set { this.itemField = value; }
    }
}
