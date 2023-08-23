// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0006_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Ausländerkategorien (eCH-0006)
/// Der inhabitantControlType enthält die Liste der Codes mit den Basiskategorien inkl. der Regelung.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0006/2")]
public enum InhabitantControl
{
    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0102.
    /// </summary>
    [EnumMember(Value = "0102")]
    [XmlEnum("0102")]
    Kategorie0102,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0201.
    /// </summary>
    [EnumMember(Value = "0201")]
    [XmlEnum("0201")]
    Kategorie0201,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0202.
    /// </summary>
    [EnumMember(Value = "0202")]
    [XmlEnum("0202")]
    Kategorie0202,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0301.
    /// </summary>
    [EnumMember(Value = "0301")]
    [XmlEnum("0301")]
    Kategorie0301,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0302.
    /// </summary>
    [EnumMember(Value = "0302")]
    [XmlEnum("0302")]
    Kategorie0302,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0401.
    /// </summary>
    [EnumMember(Value = "0401")]
    [XmlEnum("0401")]
    Kategorie0401,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0402.
    /// </summary>
    [EnumMember(Value = "0402")]
    [XmlEnum("0402")]
    Kategorie0402,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0503.
    /// </summary>
    [EnumMember(Value = "0503")]
    [XmlEnum("0503")]
    Kategorie0503,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0601.
    /// </summary>
    [EnumMember(Value = "0601")]
    [XmlEnum("0601")]
    Kategorie0601,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0602.
    /// </summary>
    [EnumMember(Value = "0602")]
    [XmlEnum("0602")]
    Kategorie0602,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0701.
    /// </summary>
    [EnumMember(Value = "0701")]
    [XmlEnum("0701")]
    Kategorie0701,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0702.
    /// </summary>
    [EnumMember(Value = "0702")]
    [XmlEnum("0702")]
    Kategorie0702,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0804.
    /// </summary>
    [EnumMember(Value = "0804")]
    [XmlEnum("0804")]
    Kategorie0804,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 0905.
    /// </summary>
    [EnumMember(Value = "0905")]
    [XmlEnum("0905")]
    Kategorie0905,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 1006.
    /// </summary>
    [EnumMember(Value = "1006")]
    [XmlEnum("1006")]
    Kategorie1006,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 1107.
    /// </summary>
    [EnumMember(Value = "1107")]
    [XmlEnum("1107")]
    Kategorie1107,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 1208.
    /// </summary>
    [EnumMember(Value = "1208")]
    [XmlEnum("1208")]
    Kategorie1208,

    /// <summary>
    /// Basiskategorien inkl. der Regelung. Code 1300.
    /// </summary>
    [EnumMember(Value = "1300")]
    [XmlEnum("1300")]
    Kategorie1300
}
