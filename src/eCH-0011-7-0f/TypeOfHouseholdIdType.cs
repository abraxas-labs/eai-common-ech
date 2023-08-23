// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0011_7_0f;

[XmlType(TypeName = "mrMrsType", Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public enum TypeOfHouseholdIdType
{
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Privathaushalt = 1,

    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Kollektivhaushalt = 2,

    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Sammelhaushalt = 3,

    [EnumMember(Value = "0")]
    [XmlEnum("0")]
    HaushaltsartNochNichtZugeteilt = 0
}
