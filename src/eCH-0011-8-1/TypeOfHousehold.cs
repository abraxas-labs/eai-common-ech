// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Haushaltsart.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0011/8")]
public enum TypeOfHousehold
{
    /// <summary>
    /// 1 = Privathaushalt.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Privathaushalt = 1,

    /// <summary>
    /// 2 = Kollektivhaushalt.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Kollektivhaushalt = 2,

    /// <summary>
    /// 3 = Sammelhaushalt.
    /// </summary>
    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Sammelhaushalt = 3,

    /// <summary>
    /// 0 = Haushaltsart noch nicht zugeteilt.
    /// </summary>
    [EnumMember(Value = "0")]
    [XmlEnum("0")]
    NichtZugeteilt = 0
}
