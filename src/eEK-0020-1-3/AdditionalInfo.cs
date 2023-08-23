// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_3;

[Serializable]
[JsonObject("additionalInfo")]
[XmlRoot(ElementName = "additionalInfo", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class AdditionalInfo : FieldValueChecker<AdditionalInfo>
{
    private string _groupCodeId;
    private string _groupName;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public AdditionalInfo()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [JsonProperty("groupCodeId")]
    [XmlElement(ElementName = "groupCodeId")]
    public string GroupCodeId
    {
        get => _groupCodeId;
        set => CheckAndSetValue(ref _groupCodeId, value);
    }

    [JsonProperty("groupName")]
    [XmlElement(ElementName = "groupName")]
    public string GroupName
    {
        get => _groupName;
        set => CheckAndSetValue(ref _groupName, value);
    }

    [JsonProperty("text")]
    [XmlElement(ElementName = "text")]
    public List<KeyFreeText> Text { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool TextSpecified => Text != null && Text.Any();

    [JsonProperty("grdmCode")]
    [XmlElement(ElementName = "grdmCode")]
    public List<GrdmCodeClass> GrdmCode { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GrdmCodeSpecified => GrdmCode != null && GrdmCode.Any();

    [JsonProperty("srdmCode")]
    [XmlElement(ElementName = "srdmCode")]
    public List<SrdmCodeClass> SrdmCode { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SrdmCodeSpecified => SrdmCode != null && SrdmCode.Any();

    [JsonProperty("additionalInfos")]
    [XmlElement(ElementName = "additionalInfos")]
    public List<AdditionalInfo> AdditionalInfos { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AdditionalInfosSpecified => AdditionalInfos != null && AdditionalInfos.Any();

    [JsonProperty("additionalData")]
    [XmlElement(ElementName = "additionalData")]
    public object AdditionalData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool AdditionalDataSpecified => AdditionalData != null;
}
