// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0045_3_0;

[XmlType("http://www.ech.ch/xmlns/eCH-0045/3")]
public enum Language
{
    [EnumMember(Value = "de")][XmlEnum("de")] German,

    [EnumMember(Value = "fr")][XmlEnum("fr")] French,

    [EnumMember(Value = "it")][XmlEnum("it")] Italian,

    [EnumMember(Value = "rm")][XmlEnum("rm")] Romansh,
}
