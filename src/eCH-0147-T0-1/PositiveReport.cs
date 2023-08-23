// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0039_2_0;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("positiveReport")]
[XmlType("positiveReportType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class PositiveReport : FieldValueChecker<PositiveReport>
{
    [JsonProperty("comments")]
    [XmlArray("comments")]
    [XmlArrayItem("comment", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Comment[] Comments { get; set; }

    [JsonProperty("applicationCustom")]
    [XmlElement("applicationCustom")]
    public ApplicationCustom ApplicationCustom { get; set; }
}
