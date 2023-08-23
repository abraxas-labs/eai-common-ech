// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

[XmlRoot(ElementName = "extension", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ExtensionType
{
    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension", Order = 1)]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
