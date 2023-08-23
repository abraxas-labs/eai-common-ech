// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_3;

[Serializable]
[JsonObject("keyTypeList")]
[XmlRoot(ElementName = "keyTypeList", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class KeyTypeList : FieldValueChecker<KeyTypeList>
{
    private List<KeyClass> _keyType;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public KeyTypeList()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [JsonProperty("keyType")]
    [XmlElement(ElementName = "keyType")]
    public List<KeyClass> KeyType
    {
        get => _keyType;
        set => CheckAndSetValue(ref _keyType, value);
    }
}
