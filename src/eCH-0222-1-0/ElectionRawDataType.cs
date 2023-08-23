// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0222_1_0;

[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "electionRawDataType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0222/1")]
public class ElectionRawDataType
{
    [XmlElement(ElementName = "electionIdentification", DataType = "token", Order = 1)]
    public string ElectionIdentification { get; set; }

    [XmlElement("ballotRawData", Order = 2)]
    public ElectionBallotRawData[] BallotRawData { get; set; }
}
