// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using eCH_0010_5_1;
using Newtonsoft.Json;

namespace eEK_0020_1_3;

[Serializable]
[JsonObject("extension")]
[XmlType(TypeName = "extensionType", Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
[XmlRoot(ElementName = "extension", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class Extension
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public Extension()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [JsonProperty("residencePaper")]
    [XmlElement(ElementName = "residencePaper")]
    public ResidencePaper ResidencePaper { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidencePaperSpecified => ResidencePaper != null;

    [JsonProperty("decision")]
    [XmlElement(ElementName = "decision")]
    public List<Decision> Decisions { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DecisionsSpecified => Decisions != null && Decisions.Any();

    [JsonProperty("residenceAddress")]
    [XmlElement(ElementName = "residenceAddress")]
    public AddressInformation ResidenceAddress { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidenceAddressSpecified => ResidenceAddress != null;

    [JsonProperty("additionalInfos")]
    [XmlElement(ElementName = "additionalInfos")]
    public List<AdditionalInfo> AdditionalInfos { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AdditionalInfosSpecified => AdditionalInfos != null && AdditionalInfos.Any();
}
