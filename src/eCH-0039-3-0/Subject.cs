// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0039_3_0;

[Serializable]
[JsonObject("subject")]
[XmlType(TypeName = "subjectType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/3")]
public class Subject
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public Subject()
    {
        Xmlns.Add("eCH-0039", "http://www.ech.ch/xmlns/eCH-0039/3");
    }

    [JsonProperty("lang")]
    [XmlAttribute(AttributeName = "lang", Form = System.Xml.Schema.XmlSchemaForm.Qualified, DataType = "language")]
    public string Lang { get; set; }

    [JsonProperty("value")]
    [XmlText]
    public string Value { get; set; }
}
