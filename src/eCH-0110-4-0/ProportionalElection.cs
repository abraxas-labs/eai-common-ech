// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0110_4_0;

[Serializable]
public class ProportionalElection
{
    private ResultDetailType _countOfChangedBallotsWithPartyAffiliation;
    private ResultDetailType _countOfChangedBallotsWithoutPartyAffiliation;
    private ResultDetailType _countOfEmptyVotesOfChangedBallotsWithoutPartyAffiliation;
    private ListResultsType[] _list;
    private CandidateResultType[] _candidate;

    [XmlElement("countOfChangedBallotsWithPartyAffiliation", Order = 1)]
    public ResultDetailType CountOfChangedBallotsWithPartyAffiliation { get => _countOfChangedBallotsWithPartyAffiliation; set => _countOfChangedBallotsWithPartyAffiliation = value; }

    [XmlElement("countOfChangedBallotsWithoutPartyAffiliation", Order = 2)]
    public ResultDetailType CountOfChangedBallotsWithoutPartyAffiliation { get => _countOfChangedBallotsWithoutPartyAffiliation; set => _countOfChangedBallotsWithoutPartyAffiliation = value; }

    [XmlElement("countOfEmptyVotesOfChangedBallotsWithoutPartyAffiliation", Order = 3)]
    public ResultDetailType CountOfEmptyVotesOfChangedBallotsWithoutPartyAffiliation { get => _countOfEmptyVotesOfChangedBallotsWithoutPartyAffiliation; set => _countOfEmptyVotesOfChangedBallotsWithoutPartyAffiliation = value; }

    [XmlElement("list", Order = 4)]
    public ListResultsType[] List { get => _list; set => _list = value; }

    [XmlElement("candidate", Order = 5)]
    public CandidateResultType[] Candidate { get => _candidate; set => _candidate = value; }
}
