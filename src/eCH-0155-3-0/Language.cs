// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Beschreibt die Stufe. Können einzelne Einflussbereiche keinem der explizit definierten
///     Landessprachen.
/// </summary>
[XmlType(TypeName = "Lagnuage", Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public enum Language
{
    /// <summary>
    ///     Deutsch.
    /// </summary>
    [EnumMember(Value = "de")][XmlEnum("de")] de,

    /// <summary>
    ///     Französisch.
    /// </summary>
    [EnumMember(Value = "fr")][XmlEnum("fr")] fr,

    /// <summary>
    ///     Italienisch.
    /// </summary>
    [EnumMember(Value = "it")][XmlEnum("it")] it,

    /// <summary>
    ///     Rätoromanisch.
    /// </summary>
    [EnumMember(Value = "rm")][XmlEnum("rm")] rm
}
