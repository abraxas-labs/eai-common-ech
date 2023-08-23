// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0147_T0_1;
using Newtonsoft.Json;

namespace eCH_0147_T1_1;

[Serializable]
[JsonObject("eventReport")]
[XmlType("eventReportType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
[XmlRoot("eventReport", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T1/1", IsNullable = false)]
public class EventReport : FieldValueChecker<EventReport>
{
    private ReportHeader _reportHeader;
    private Report _report;

    [FieldRequired]
    [JsonProperty("reportHeader")]
    [XmlElement("reportHeader")]
    public ReportHeader ReportHeader
    {
        get => _reportHeader;
        set => CheckAndSetValue(ref _reportHeader, value);
    }

    [FieldRequired]
    [JsonProperty("report")]
    [XmlElement("report")]
    public Report Report
    {
        get => _report;
        set => CheckAndSetValue(ref _report, value);
    }
}
