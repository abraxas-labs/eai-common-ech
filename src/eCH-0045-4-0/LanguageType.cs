// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace eCH_0045_4_0;

[XmlType("http://www.ech.ch/xmlns/eCH-0045/4")]
[JsonConverter(typeof(StringEnumConverter))]
public enum LanguageType
{
    [EnumMember(Value = "de")]
    [XmlEnum("de")]
    de,

    [EnumMember(Value = "fr")]
    [XmlEnum("fr")]
    fr,

    [EnumMember(Value = "it")]
    [XmlEnum("it")]
    it,

    [EnumMember(Value = "rm")]
    [XmlEnum("rm")]
    rm,
}
