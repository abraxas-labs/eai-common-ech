// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0155_4_0;
using eCH_0222_1_0;

namespace eCH_0110_4_0;

[Serializable]
[XmlRoot(ElementName = "eventResultDelivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0110/4")]
public class EventResultDelivery
{
    private ExtensionType _extension;
    private RawDataType _rawData;
    private ContestType _contestInformation;
    private ReportingBodyType _reportingBody;

    [XmlElement("reportingBody", Order = 1)]
    public ReportingBodyType ReportingBody { get => _reportingBody; set => _reportingBody = value; }

    [XmlElement("contestInformation", Order = 2)]
    public ContestType ContestInformation { get => _contestInformation; set => _contestInformation = value; }

    [XmlElement("countingCircleResults", Order = 3)]
    public CountingCircleResultsType[] CountingCircleResults { get; set; }

    [XmlElement("rawData", Order = 4)]
    public eCH_0222_1_0.RawDataType RawData { get => _rawData; set => _rawData = value; }

    [XmlElement("extension", Order = 5)]
    public ExtensionType Extension { get => _extension; set => _extension = value; }
}
