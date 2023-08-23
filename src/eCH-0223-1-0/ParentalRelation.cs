// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0223_1_0;

[Serializable]
[JsonObject("parentalRelation")]
[XmlType(TypeName = "parentalRelationType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class ParentalRelation
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public ParentalRelation()
    {
        Xmlns.Add("eCH-0223", "http://www.ech.ch/xmlns/eCH-0223/1");
    }

    [JsonProperty("father")]
    [XmlElement(ElementName = "father")]
    public PersonIdentificationLight Father { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool FatherSpecified => Father != null;

    [JsonProperty("mother")]
    [XmlElement(ElementName = "mother")]
    public PersonIdentificationLight Mother { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MotherSpecified => Mother != null;
}
