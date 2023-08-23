// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0222_1_0;

[Serializable]
[JsonObject("ballotRawData")]
[XmlRoot(ElementName = "ballotRawData", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0222/1")]
public class ElectionBallotRawData
{
    private ElectionListRawData _listRawData;
    private ElectionBallotPosition[] _ballotPosition;
    private bool _isUnchangedBallot;
    private bool _isUnchangedBallotSpecified;

    [XmlElement("listRawData", Order = 1)]
    public ElectionListRawData ListRawData { get => _listRawData; set => _listRawData = value; }

    [XmlElement("ballotPosition", Order = 2)]
    public ElectionBallotPosition[] BallotPosition { get => _ballotPosition; set => _ballotPosition = value; }

    [XmlElement("isUnchangedBallot", Order = 3)]
    public bool IsUnchangedBallot { get => _isUnchangedBallot; set => _isUnchangedBallot = value; }

    [XmlIgnore]
    public bool IsUnchangedBallotSpecified { get => _isUnchangedBallotSpecified; set => _isUnchangedBallotSpecified = value; }
}
