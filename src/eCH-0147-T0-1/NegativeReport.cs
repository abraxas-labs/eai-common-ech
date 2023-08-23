// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0039_2_0;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("negativeReport")]
[XmlType("negativeReportType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class NegativeReport : FieldValueChecker<NegativeReport>
{
    private Error[] _errors;

    [FieldRequired]
    [JsonProperty("errors")]
    [XmlArray("errors")]
    [XmlArrayItem("error", IsNullable = false)]
    public Error[] Errors
    {
        get => _errors;
        set => CheckAndSetValue(ref _errors, value);
    }

    [JsonProperty("comments")]
    [XmlArray("comments")]
    [XmlArrayItem("comment", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Comment[] Comments { get; set; }

    [JsonProperty("applicationCustom")]
    [XmlElement("applicationCustom")]
    public ApplicationCustom ApplicationCustom { get; set; }
}
