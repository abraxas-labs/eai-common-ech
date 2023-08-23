// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

[XmlRoot(ElementName = "extension", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class ExtensionType
{
    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
