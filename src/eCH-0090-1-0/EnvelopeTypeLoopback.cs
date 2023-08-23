// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0090_1_0;

public class EnvelopeTypeLoopback
{
    [JsonProperty("authorise")]
    [XmlAttribute(AttributeName = "authorise")]
    public bool Authorise { get; set; }
}
