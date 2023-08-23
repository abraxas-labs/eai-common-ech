// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eEK_0020_1_3;

[Serializable]
[JsonObject("grdmCode")]
[XmlRoot(ElementName = "grdmCode", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class GrdmCodeClass : FieldValueChecker<GrdmCodeClass>
{
    private GrdmCodeTypeType _grdmCodeType;
    private GrdmCodeType _grdmCode;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public GrdmCodeClass()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    [FieldRequired]
    [JsonProperty("grdmCodeType", Required = Required.Always)]
    [XmlElement(ElementName = "grdmCodeType")]
    public GrdmCodeTypeType GrdmCodeType
    {
        get => _grdmCodeType;
        set => CheckAndSetValue(ref _grdmCodeType, value);
    }

    [JsonProperty("grdmCode")]
    [XmlElement(ElementName = "grdmCode")]
    public GrdmCodeType GrdmCode
    {
        get => _grdmCode;
        set => CheckAndSetValue(ref _grdmCode, value);
    }
}
