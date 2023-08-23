// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_3;

[Serializable]
[JsonObject("text")]
[XmlRoot(ElementName = "text", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class TextClass : FieldValueChecker<TextClass>
{
    private string _languageCode;
    private string _text;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public TextClass()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [FieldMinMaxLength(5, 5)]
    [JsonProperty("languageCode", Required = Required.Always)]
    [XmlElement(ElementName = "languageCode")]
    public string LanguageCode
    {
        get => _languageCode;
        set => CheckAndSetValue(ref _languageCode, value);
    }

    [FieldRequired]
    [JsonProperty("text", Required = Required.Always)]
    [XmlElement(ElementName = "text")]
    public string Text
    {
        get => _text;
        set => CheckAndSetValue(ref _text, value);
    }
}
