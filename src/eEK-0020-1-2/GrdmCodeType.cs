// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_2;

[Serializable]
[JsonObject("grdmCodeType")]
[XmlRoot(ElementName = "grdmCodeType", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class GrdmCodeType : FieldValueChecker<GrdmCodeType>
{
    private string _codeId;
    private List<TextClass> _codeText;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public GrdmCodeType()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [JsonProperty("codeId")]
    [XmlElement(ElementName = "codeId")]
    public string CodeId
    {
        get => _codeId;
        set => CheckAndSetValue(ref _codeId, value);
    }

    [FieldRequired]
    [JsonProperty("codeText")]
    [XmlElement(ElementName = "codeText")]
    public List<TextClass> CodeText
    {
        get => _codeText;
        set => CheckAndSetValue(ref _codeText, value);
    }

    [JsonProperty("codeECH")]
    [XmlElement(ElementName = "codeECH")]
    public string CodeECH { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CodeECHSpecified => !string.IsNullOrWhiteSpace(CodeECH);
}
