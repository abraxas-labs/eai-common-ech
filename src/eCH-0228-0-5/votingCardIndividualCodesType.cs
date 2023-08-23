// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

namespace eCH_0228;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public partial class votingCardIndividualCodesType
{

    private namedCodeType[] individualContestCodesField;

    private voteType[] voteField;

    private votingCardIndividualCodesTypeElectionGroupBallot[] electionGroupBallotField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("individualContestCodes")]
    public namedCodeType[] individualContestCodes
    {
        get { return this.individualContestCodesField; }
        set { this.individualContestCodesField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("vote")]
    public voteType[] vote
    {
        get { return this.voteField; }
        set { this.voteField = value; }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("electionGroupBallot")]
    public votingCardIndividualCodesTypeElectionGroupBallot[] electionGroupBallot
    {
        get { return this.electionGroupBallotField; }
        set { this.electionGroupBallotField = value; }
    }
}
