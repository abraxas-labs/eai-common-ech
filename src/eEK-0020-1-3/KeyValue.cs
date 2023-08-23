// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_3;

[Serializable]
[JsonObject("keyValue")]
[XmlRoot(ElementName = "keyValue", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class KeyValue : FieldValueChecker<KeyValue>
{
    private string _key;
    private string _value;
    private string _validFrom;
    private string _validTo;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public KeyValue()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [JsonProperty("key")]
    [XmlElement(ElementName = "key")]
    public string Key
    {
        get => _key;
        set => CheckAndSetValue(ref _key, value);
    }

    [FieldRequired]
    [JsonProperty("value")]
    [XmlElement(ElementName = "value")]
    public string Value
    {
        get => _value;
        set => CheckAndSetValue(ref _value, value);
    }

    [JsonProperty("eCHValue")]
    [XmlElement(ElementName = "eCHValue")]
    public string EChValue { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool EChValueSpecified => !string.IsNullOrWhiteSpace(EChValue);

    [FieldRequired]
    [JsonProperty("validFrom")]
    [XmlElement(ElementName = "validFrom")]
    public string ValidFrom
    {
        get => _validFrom;
        set => CheckAndSetValue(ref _validFrom, value);
    }

    [FieldRequired]
    [JsonProperty("validTo")]
    [XmlElement(ElementName = "validTo")]
    public string ValidTo
    {
        get => _validTo;
        set => CheckAndSetValue(ref _validTo, value);
    }
}
