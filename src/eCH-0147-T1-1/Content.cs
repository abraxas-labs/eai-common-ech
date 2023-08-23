// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0147_T0_1;
using Newtonsoft.Json;

namespace eCH_0147_T1_1;

[Serializable]
[JsonObject("content")]
[XmlType("contentType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T1/1")]
public class Content : FieldValueChecker<Content>
{
    [JsonProperty("directive")]
    [XmlElement("directive", Form = XmlSchemaForm.Unqualified)]
    public Directive Directive { get; set; }

    [JsonProperty("dossiers")]
    [XmlArray("dossiers", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("dossier", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1", IsNullable = false)]
    public Dossier[] Dossiers { get; set; }

    [JsonProperty("documents")]
    [XmlArray("documents", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("document", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1", IsNullable = false)]
    public Document[] Documents { get; set; }

    [JsonProperty("addresses")]
    [XmlArray("addresses", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem(ElementName = "address", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1", IsNullable = false)]
    public Address[] Addresses { get; set; }
}
