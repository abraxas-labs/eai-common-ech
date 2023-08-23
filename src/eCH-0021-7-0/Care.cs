// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angabe ob die Eltern die elterliche Sorge besitzen.
/// </summary>
[XmlType(TypeName = "careType", Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public enum Care
{
    /// <summary>
    /// 0 = keine elterliche Sorge oder nicht abgeklärt.
    /// </summary>
    [EnumMember(Value = "0")]
    [XmlEnum("0")]
    Sorge0 = 0,

    /// <summary>
    /// 1 = elterliche Sorge.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Sorge1 = 1,

    /// <summary>
    /// 2 = gemeinsame elterliche Sorge.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Sorge2 = 2,

    /// <summary>
    /// 3 = alleinige elterliche Sorge.
    /// </summary>
    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Sorge3 = 3
}
