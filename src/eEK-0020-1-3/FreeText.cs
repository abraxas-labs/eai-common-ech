// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_3;

[Serializable]
[JsonObject("freeText")]
[XmlRoot(ElementName = "freeText", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class FreeText : FieldValueChecker<FreeText>
{
    private string _value;
    private TextClass _text;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public FreeText()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [JsonProperty("value")]
    [XmlElement(ElementName = "value")]
    public string Value
    {
        get => _value;
        set => CheckAndSetValue(ref _value, value);
    }

    [JsonProperty("text")]
    [XmlElement(ElementName = "text")]
    public TextClass Text
    {
        get => _text;
        set => CheckAndSetValue(ref _text, value);
    }

    [JsonProperty("eCHValue")]
    [XmlElement(ElementName = "eCHValue")]
    public string ECHValue { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ECHValueSpecified => !string.IsNullOrWhiteSpace(ECHValue);
}
