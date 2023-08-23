// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Auflösungsgrund.
/// </summary>
[XmlType(TypeName = "partnerShipAbolitionType", Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public enum PartnerShipAbolitionType
{
    /// <summary>
    /// 1 – Gerichtlich aufgelöste Partnerschaft.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Grund1 = 1,

    /// <summary>
    /// 2 – Ungültigerklärung.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Grund2 = 2,

    /// <summary>
    /// 3 – Durch Verschollenerklärung.
    /// </summary>
    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Grund3 = 3,

    /// <summary>
    /// 4 – Durch Tod aufgelöste Partnerschaft.
    /// </summary>
    [EnumMember(Value = "4")]
    [XmlEnum("4")]
    Grund4 = 4,

    /// <summary>
    /// 9 – Unbekannt / Andere Gründe.
    /// </summary>
    [EnumMember(Value = "9")]
    [XmlEnum("9")]
    Grund9 = 9
}
