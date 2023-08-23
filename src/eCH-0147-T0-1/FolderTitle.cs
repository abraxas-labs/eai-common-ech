// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("folderTitle")]
[XmlType("folderTitleType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class FolderTitle
{
    [JsonProperty("lang")]
    [XmlAttribute("lang", Form = XmlSchemaForm.Qualified, Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", DataType = "language")]
    public string Lang { get; set; }

    [JsonProperty("value")]
    [XmlText(DataType = "token")]
    public string Value { get; set; }
}
