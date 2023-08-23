// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;
using Newtonsoft.Json;

namespace eCH_0222_1_0;

[Serializable]
[JsonObject("eventRawDataDelivery")]
[XmlRoot(ElementName = "eventRawDataDelivery", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0222/1")]
public class EventRawDataDelivery
{
    private ReportingBodyType _reportingBody;
    private RawDataType _rawData;
    private ExtensionType _extension;

    [XmlElement("reportingBody", Order = 1)]
    public ReportingBodyType ReportingBody { get => _reportingBody; set => _reportingBody = value; }

    [XmlElement("rawData", Order = 2)]
    public RawDataType RawData { get => _rawData; set => _rawData = value; }

    [XmlElement("extension", Order = 3)]
    public ExtensionType Extension { get => _extension; set => _extension = value; }
}
