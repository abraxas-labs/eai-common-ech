// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0006_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Ausländerkategorien (eCH-0006)
/// Der residencePermitDetailedType bildet möglichst detaillierte Angabe der Ausländerkategorie ab (d.h. ohne übergeordnete Ausländerkategorien).
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0006/2")]
public enum ResidencePermitDetailed
{
    /// <summary>
    /// Ausländerkategorien 0102.
    /// </summary>
    [EnumMember(Value = "0102")]
    [XmlEnum("0102")]
    Kategorie0102,

    /// <summary>
    /// Ausländerkategorien 0201.
    /// </summary>
    [EnumMember(Value = "0201")]
    [XmlEnum("0201")]
    Kategorie0201,

    /// <summary>
    /// Ausländerkategorien 0202.
    /// </summary>
    [EnumMember(Value = "0202")]
    [XmlEnum("0202")]
    Kategorie0202,

    /// <summary>
    /// Ausländerkategorien 0301.
    /// </summary>
    [EnumMember(Value = "0301")]
    [XmlEnum("0301")]
    Kategorie0301,

    /// <summary>
    /// Ausländerkategorien 0302.
    /// </summary>
    [EnumMember(Value = "0302")]
    [XmlEnum("0302")]
    Kategorie0302,

    /// <summary>
    /// Ausländerkategorien 0401.
    /// </summary>
    [EnumMember(Value = "0401")]
    [XmlEnum("0401")]
    Kategorie0401,

    /// <summary>
    /// Ausländerkategorien 0402.
    /// </summary>
    [EnumMember(Value = "0402")]
    [XmlEnum("0402")]
    Kategorie0402,

    /// <summary>
    /// Ausländerkategorien 0503.
    /// </summary>
    [EnumMember(Value = "0503")]
    [XmlEnum("0503")]
    Kategorie0503,

    /// <summary>
    /// Ausländerkategorien 0601.
    /// </summary>
    [EnumMember(Value = "0601")]
    [XmlEnum("0601")]
    Kategorie0601,

    /// <summary>
    /// Ausländerkategorien 0602.
    /// </summary>
    [EnumMember(Value = "0602")]
    [XmlEnum("0602")]
    Kategorie0602,

    /// <summary>
    /// Ausländerkategorien 060101.
    /// </summary>
    [EnumMember(Value = "060101")]
    [XmlEnum("060101")]
    Kategorie060101,

    /// <summary>
    /// Ausländerkategorien 060201.
    /// </summary>
    [EnumMember(Value = "060201")]
    [XmlEnum("060201")]
    Kategorie060201,

    /// <summary>
    /// Ausländerkategorien 060102.
    /// </summary>
    [EnumMember(Value = "060102")]
    [XmlEnum("060102")]
    Kategorie060102,

    /// <summary>
    /// Ausländerkategorien 060202.
    /// </summary>
    [EnumMember(Value = "060202")]
    [XmlEnum("060202")]
    Kategorie060202,

    /// <summary>
    /// Ausländerkategorien 0701.
    /// </summary>
    [EnumMember(Value = "0701")]
    [XmlEnum("0701")]
    Kategorie0701,

    /// <summary>
    /// Ausländerkategorien 0702.
    /// </summary>
    [EnumMember(Value = "0702")]
    [XmlEnum("0702")]
    Kategorie0702,

    /// <summary>
    /// Ausländerkategorien 070101.
    /// </summary>
    [EnumMember(Value = "070101")]
    [XmlEnum("070101")]
    Kategorie070101,

    /// <summary>
    /// Ausländerkategorien 070201.
    /// </summary>
    [EnumMember(Value = "070201")]
    [XmlEnum("070201")]
    Kategorie070201,

    /// <summary>
    /// Ausländerkategorien 070102.
    /// </summary>
    [EnumMember(Value = "070102")]
    [XmlEnum("070102")]
    Kategorie070102,

    /// <summary>
    /// Ausländerkategorien 070202.
    /// </summary>
    [EnumMember(Value = "070202")]
    [XmlEnum("070202")]
    Kategorie070202,

    /// <summary>
    /// Ausländerkategorien 070103.
    /// </summary>
    [EnumMember(Value = "070103")]
    [XmlEnum("070103")]
    Kategorie070103,

    /// <summary>
    /// Ausländerkategorien 070104.
    /// </summary>
    [EnumMember(Value = "070104")]
    [XmlEnum("070104")]
    Kategorie070104,

    /// <summary>
    /// Ausländerkategorien 070204.
    /// </summary>
    [EnumMember(Value = "070204")]
    [XmlEnum("070204")]
    Kategorie070204,

    /// <summary>
    /// Ausländerkategorien 070105.
    /// </summary>
    [EnumMember(Value = "070105")]
    [XmlEnum("070105")]
    Kategorie070105,

    /// <summary>
    /// Ausländerkategorien 070205.
    /// </summary>
    [EnumMember(Value = "070205")]
    [XmlEnum("070205")]
    Kategorie070205,

    /// <summary>
    /// Ausländerkategorien 070206.
    /// </summary>
    [EnumMember(Value = "070206")]
    [XmlEnum("070206")]
    Kategorie070206,

    /// <summary>
    /// Ausländerkategorien 070907.
    /// </summary>
    [EnumMember(Value = "070907")]
    [XmlEnum("070907")]
    Kategorie070907,

    /// <summary>
    /// Ausländerkategorien 0804.
    /// </summary>
    [EnumMember(Value = "0804")]
    [XmlEnum("0804")]
    Kategorie0804,

    /// <summary>
    /// Ausländerkategorien 0905.
    /// </summary>
    [EnumMember(Value = "0905")]
    [XmlEnum("0905")]
    Kategorie0905,

    /// <summary>
    /// Ausländerkategorien 1006.
    /// </summary>
    [EnumMember(Value = "1006")]
    [XmlEnum("1006")]
    Kategorie1006,

    /// <summary>
    /// Ausländerkategorien 100601.
    /// </summary>
    [EnumMember(Value = "100601")]
    [XmlEnum("100601")]
    Kategorie100601,

    /// <summary>
    /// Ausländerkategorien 100602.
    /// </summary>
    [EnumMember(Value = "100602")]
    [XmlEnum("100602")]
    Kategorie100602,

    /// <summary>
    /// Ausländerkategorien 100603.
    /// </summary>
    [EnumMember(Value = "100603")]
    [XmlEnum("100603")]
    Kategorie100603,

    /// <summary>
    /// Ausländerkategorien 1107.
    /// </summary>
    [EnumMember(Value = "1107")]
    [XmlEnum("1107")]
    Kategorie1107,

    /// <summary>
    /// Ausländerkategorien 1208.
    /// </summary>
    [EnumMember(Value = "1208")]
    [XmlEnum("1208")]
    Kategorie1208,

    /// <summary>
    /// Ausländerkategorien 1300.
    /// </summary>
    [EnumMember(Value = "1300")]
    [XmlEnum("1300")]
    Kategorie1300
}
