// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Der Antworttyp definiert welche Antworten auf eine Abstimmungsfrage zulässig sind.
/// </summary>
[XmlType(TypeName = "AnswerType", Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public enum AnswerType
{
    /// <summary>
    ///     Ja/Nein.
    /// </summary>
    [EnumMember(Value = "1")][XmlEnum("1")] YesNo,

    /// <summary>
    ///     Ja/Nein/Leer.
    /// </summary>
    [EnumMember(Value = "2")][XmlEnum("2")] YesNoEmpty,

    /// <summary>
    ///     angekreuzt/leer.
    /// </summary>
    [EnumMember(Value = "3")][XmlEnum("3")] CheckedEmpty,

    /// <summary>
    ///     Initiative/Gegenentwuf.
    /// </summary>
    [EnumMember(Value = "4")][XmlEnum("4")] InitiativeCounterdraft,
}
