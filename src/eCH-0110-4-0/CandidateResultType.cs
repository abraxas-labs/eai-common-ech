// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "candidateResultType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class CandidateResultType
{
    private object _item;
    private CandidateListResultType[] _listResults;
    private string _countOfVotesTotal;

    [XmlElement("candidateInformation", typeof(CandidateInformationType), Order = 1)]
    [XmlElement("writeIn", typeof(string), DataType = "token", Order = 1)]
    public object Item { get => _item; set => _item = value; }

    [XmlElement("listResults", Order = 2)]
    public CandidateListResultType[] ListResults { get => _listResults; set => _listResults = value; }

    [XmlElement(ElementName = "countOfVotesTotal", DataType = "nonNegativeInteger", Order = 3)]
    public string CountOfVotesTotal { get => _countOfVotesTotal; set => _countOfVotesTotal = value; }
}
