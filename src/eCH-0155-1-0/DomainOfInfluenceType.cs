// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Beschreibt die Stufe. Können einzelne Einflussbereiche keinem der explizit definierten
///     Typen zugeordnet werden, so ist für diese „AN“ (andere) zu verwenden.
/// </summary>
[XmlType(TypeName = "DomainOfInfluenceType", Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public enum DomainOfInfluenceType
{
    /// <summary>
    ///     Bund.
    /// </summary>
    [EnumMember(Value = "CH")][XmlEnum("CH")] CH,

    /// <summary>
    ///     Kandon.
    /// </summary>
    [EnumMember(Value = "CT")][XmlEnum("CT")] CT,

    /// <summary>
    ///     Bezirk / Amt / Verwaltungskreis.
    /// </summary>
    [EnumMember(Value = "BZ")][XmlEnum("BZ")] BZ,

    /// <summary>
    ///     Gemeinde.
    /// </summary>
    [EnumMember(Value = "MU")][XmlEnum("MU")] MU,

    /// <summary>
    ///     Schulgemeinde.
    /// </summary>
    [EnumMember(Value = "SC")][XmlEnum("SC")] SC,

    /// <summary>
    ///     Krichgemeinde.
    /// </summary>
    [EnumMember(Value = "KI")][XmlEnum("KI")] KI,

    /// <summary>
    ///     Ortsbürgergemeinde.
    /// </summary>
    [EnumMember(Value = "OG")][XmlEnum("OG")] OG,

    /// <summary>
    ///     Korporation.
    /// </summary>
    [EnumMember(Value = "KO")][XmlEnum("KO")] KO,

    /// <summary>
    ///     Stadtkreis.
    /// </summary>
    [EnumMember(Value = "SK")][XmlEnum("SK")] SK,

    /// <summary>
    ///     Andere.
    /// </summary>
    [EnumMember(Value = "AN")][XmlEnum("AN")] AN
}
