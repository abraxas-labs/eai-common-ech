// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Trennungsart.
/// </summary>
[XmlType(TypeName = "separationType", Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public enum Separation
{
    /// <summary>
    /// 1 - freiwillig getrennt.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Freiwillig = 1,

    /// <summary>
    /// 2 - gerichtlich getrennt.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Gerichtlich = 2
}
