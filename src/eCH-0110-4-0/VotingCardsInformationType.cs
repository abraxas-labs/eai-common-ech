// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "votingCardsInformationType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class VotingCardsInformationType
{
    private VotingCardsResultDetailType[] _subTotalInfo;

    [XmlElement("receivedValidVotingCards", Order = 1)]
    public VotingCard[] ReceivedValidVotingCards { get; set; }

    [XmlElement("receivedInvalidVotingCards", Order = 2)]
    public VotingCard[] ReceivedInvalidVotingCards { get; set; }

    [XmlElement(ElementName = "countOfReceivedValidVotingCardsTotal", Order = 3)]
    public int CountOfReceivedValidVotingCardsTotal { get; set; }

    [XmlElement(ElementName = "countOfReceivedInvalidVotingCardsTotal", Order = 4)]
    public int CountOfReceivedInvalidVotingCardsTotal { get; set; }

    [XmlElement("subTotalInfo", Order = 5)]
    public VotingCardsResultDetailType[] SubTotalInfo { get => _subTotalInfo; set => _subTotalInfo = value; }
}
