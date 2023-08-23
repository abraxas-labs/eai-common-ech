// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "votingCardsResultDetailType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class VotingCardsResultDetailType
{
    [XmlElement(ElementName = "countOfReceivedVotingCards", DataType = "nonNegativeInteger", Order = 1)]
    public string CountOfReceivedVotingCards { get; set; }

    [XmlElement("voterType", Order = 2)]
    public VoterType VoterType { get; set; }

    [XmlIgnore]
    public bool VoterTypeSpecified { get; set; }

    [XmlElement("allowsEvoting", Order = 3)]
    public bool AllowsEvoting { get; set; }

    [XmlIgnore]
    public bool AllowsEvotingSpecified { get; set; }

    [XmlElement("valid", Order = 4)]
    public bool Valid { get; set; }

    [XmlIgnore]
    public bool ValidSpecified { get; set; }

    [XmlElement("channel", Order = 5)]
    public VotingChannel channel { get; set; }

    [XmlIgnore]
    public bool ChannelSpecified { get; set; }
}
