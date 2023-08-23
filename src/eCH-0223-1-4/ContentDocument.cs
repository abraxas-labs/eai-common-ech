// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0039_3_0;
using Newtonsoft.Json;

namespace eCH_0223_1_4;

[Serializable]
[JsonObject("contentDocument")]
[XmlType(TypeName = "contentDocumentType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class ContentDocument : Document
{
    public ContentDocument()
    {
        Xmlns.Add("eCH-0223", "http://www.ech.ch/xmlns/eCH-0223/1");
    }

    [JsonProperty("originalCreationDate")]
    [XmlElement(DataType = "dateTime", ElementName = "originalCreationDate")]
    public DateTime OriginalCreationDate { get; set; }
}
