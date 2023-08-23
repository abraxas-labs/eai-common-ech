// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0010_6_0;

[XmlType(TypeName = "mrMrsType", Namespace = "http://www.ech.ch/xmlns/eCH-0010/6")]
public enum MrMrsType
{
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Frau = 1,

    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Herr = 2,

    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Fräulein = 3
}
