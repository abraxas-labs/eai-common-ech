// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0222_1_0;

[Serializable]
[JsonObject("rawDataType")]
[XmlRoot(ElementName = "rawDataType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0222/1")]
public class RawDataType
{
    private string _contestIdentification;
    private CountingCircleRawData[] _countingCircleRawData;

    [XmlElement(ElementName = "contestIdentification", DataType = "token", Order = 1)]
    public string ContestIdentification { get => _contestIdentification; set => _contestIdentification = value; }

    [XmlElement("countingCircleRawData", Order = 2)]
    public CountingCircleRawData[] CountingCircleRawData { get => _countingCircleRawData; set => _countingCircleRawData = value; }
}
