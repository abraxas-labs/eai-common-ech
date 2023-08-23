// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_2;

[Serializable]
[JsonObject("additionalInfo")]
[XmlRoot(ElementName = "additionalInfo", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class AdditionalInfo : FieldValueChecker<AdditionalInfo>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public AdditionalInfo()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [JsonProperty("grdmCode")]
    [XmlElement(ElementName = "grdmCode")]
    public GrdmCodeClass GrdmCode { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GrdmCodeSpecified => GrdmCode != null;

    [JsonProperty("text")]
    [XmlElement(ElementName = "text")]
    public List<KeyFreeText> Text { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool TextSpecified => Text != null && Text.Any();
}
