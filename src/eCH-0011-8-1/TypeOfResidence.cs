// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Art des Meldeverhältnisses.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0011/8")]
public enum TypeOfResidence
{
    /// <summary>
    /// Hauptwohnsitz - hasMainResidence.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Hauptwohnsitz = 1,

    /// <summary>
    /// Nebenwohnsitz – hasSecondaryResidence.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Nebenwohnsitz = 2,

    /// <summary>
    /// Weder Haupt- noch Nebenwohnsitz – hasOtherResidence.
    /// </summary>
    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Andere = 3
}
