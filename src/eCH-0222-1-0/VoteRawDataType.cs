// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0222_1_0;

[Serializable]
[JsonObject("reportingBodyType")]
[XmlRoot(ElementName = "reportingBodyType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0222/1")]
public class VoteRawDataType
{
    private string _voteIdentification;
    private VoteBallotRawData[] _ballotRawData;

    [XmlElement(ElementName = "voteIdentification", DataType = "token", Order = 1)]
    public string VoteIdentification { get => _voteIdentification; set => _voteIdentification = value; }

    [XmlElement("ballotRawData", Order = 2)]
    public VoteBallotRawData[] BallotRawData { get => _ballotRawData; set => _ballotRawData = value; }
}
