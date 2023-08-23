// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_3;

[Serializable]
[JsonObject("srdmCodeTypeType")]
[XmlRoot(ElementName = "srdmCodeTypeType", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class SrdmCodeTypeType : FieldValueChecker<SrdmCodeTypeType>
{
    private string _codeTypeId;
    private List<TextClass> _codeTypeText;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public SrdmCodeTypeType()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [JsonProperty("codeTypeId", Required = Required.Always)]
    [XmlElement(ElementName = "codeTypeId")]
    public string CodeTypeId
    {
        get => _codeTypeId;
        set => CheckAndSetValue(ref _codeTypeId, value);
    }

    [FieldRequired]
    [JsonProperty("codeTypeText", Required = Required.Always)]
    [XmlElement(ElementName = "codeTypeText")]
    public List<TextClass> CodeTypeText
    {
        get => _codeTypeText;
        set => CheckAndSetValue(ref _codeTypeText, value);
    }
}
