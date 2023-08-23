// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "listResultsType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class ListResultsType
{
    private ListInformationType _listInformation;
    private ResultDetailType _countOfChangedBallots;
    private ResultDetailType _countOfUnchangedBallots;
    private ResultDetailType _countOfCandidateVotes;
    private ResultDetailType _countOfAdditionalVotes;
    private ResultDetailType _countOfPartyVotes;

    [XmlElement("listInformation", Order = 1)]
    public ListInformationType ListInformation { get => _listInformation; set => _listInformation = value; }

    [XmlElement("countOfChangedBallots", Order = 2)]
    public ResultDetailType CountOfChangedBallots { get => _countOfChangedBallots; set => _countOfChangedBallots = value; }

    [XmlElement("countOfUnchangedBallots", Order = 3)]
    public ResultDetailType CountOfUnchangedBallots { get => _countOfUnchangedBallots; set => _countOfUnchangedBallots = value; }

    [XmlElement("countOfCandidateVotes", Order = 4)]
    public ResultDetailType CountOfCandidateVotes { get => _countOfCandidateVotes; set => _countOfCandidateVotes = value; }

    [XmlElement("countOfAdditionalVotes", Order = 5)]
    public ResultDetailType CountOfAdditionalVotes { get => _countOfAdditionalVotes; set => _countOfAdditionalVotes = value; }

    [XmlElement("countOfPartyVotes", Order = 6)]
    public ResultDetailType CountOfPartyVotes { get => _countOfPartyVotes; set => _countOfPartyVotes = value; }
}
