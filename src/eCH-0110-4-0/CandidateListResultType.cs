// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "candidateListResultType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class CandidateListResultType
{
    private string _listIdentification;
    private ResultDetailType _countOfvotesFromUnchangedBallots;
    private ResultDetailType _countOfvotesFromChangedBallots;

    [XmlElement(ElementName = "listIdentification", DataType = "token", Order = 1)]
    public string ListIdentification { get => _listIdentification; set => _listIdentification = value; }

    [XmlElement("countOfvotesFromUnchangedBallots", Order = 2)]
    public ResultDetailType CountOfvotesFromUnchangedBallots { get => _countOfvotesFromUnchangedBallots; set => _countOfvotesFromUnchangedBallots = value; }

    [XmlElement("countOfvotesFromChangedBallots", Order = 3)]
    public ResultDetailType CountOfvotesFromChangedBallots { get => _countOfvotesFromChangedBallots; set => _countOfvotesFromChangedBallots = value; }
}
