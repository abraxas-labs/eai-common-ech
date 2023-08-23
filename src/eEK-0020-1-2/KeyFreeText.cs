// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_2;

[Serializable]
[JsonObject("keyFreeText")]
[XmlRoot(ElementName = "keyFreeText", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class KeyFreeText : FieldValueChecker<KeyFreeText>
{
    private string _key;
    private FreeText _text;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public KeyFreeText()
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
    [JsonProperty("text")]
    [XmlElement(ElementName = "text")]
    public FreeText Text
    {
        get => _text;
        set => CheckAndSetValue(ref _text, value);
    }
}
