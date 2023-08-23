// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0147_T0_1;

[Serializable]
[JsonObject("object")]
[XmlType("objectType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public class Object : FieldValueChecker<Object>
{
    private object _applicationCustom;

    [FieldRequired]
    [JsonProperty("applicationCustom")]
    [XmlElement("applicationCustom")]
    public object ApplicationCustom
    {
        get => _applicationCustom;
        set => CheckAndSetValue(ref _applicationCustom, value);
    }
}
