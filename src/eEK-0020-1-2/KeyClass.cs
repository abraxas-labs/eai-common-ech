// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_2;

[Serializable]
[JsonObject("key")]
[XmlRoot(ElementName = "key", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class KeyClass : FieldValueChecker<KeyClass>
{
    private KeyValue _key;
    private List<KeyValue> _values;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public KeyClass()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [JsonProperty("key")]
    [XmlElement(ElementName = "key")]
    public KeyValue Key
    {
        get => _key;
        set => CheckAndSetValue(ref _key, value);
    }

    [FieldRequired]
    [JsonProperty("values")]
    [XmlElement(ElementName = "values")]
    public List<KeyValue> Values
    {
        get => _values;
        set => CheckAndSetValue(ref _values, value);
    }
}
