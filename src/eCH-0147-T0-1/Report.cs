// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("report")]
[XmlType("reportType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class Report : FieldValueChecker<Report>
{
    [XmlElement("negativeReport", typeof(NegativeReport))]
    [XmlElement("positiveReport", typeof(PositiveReport))]
    public object Item { get; set; }
}
