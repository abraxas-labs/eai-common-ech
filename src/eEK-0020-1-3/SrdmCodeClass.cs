// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_3;

[Serializable]
[JsonObject("srdmCode")]
[XmlRoot(ElementName = "srdmCode", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class SrdmCodeClass : FieldValueChecker<SrdmCodeClass>
{
    private SrdmCodeTypeType _srdmCodeType;
    private SrdmCodeType _srdmCode;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public SrdmCodeClass()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [JsonProperty("srdmCodeType", Required = Required.Always)]
    [XmlElement(ElementName = "srdmCodeType")]
    public SrdmCodeTypeType SrdmCodeType
    {
        get => _srdmCodeType;
        set => CheckAndSetValue(ref _srdmCodeType, value);
    }

    [JsonProperty("srdmCode")]
    [XmlElement(ElementName = "srdmCode")]
    public SrdmCodeType SrdmCode
    {
        get => _srdmCode;
        set => CheckAndSetValue(ref _srdmCode, value);
    }
}
