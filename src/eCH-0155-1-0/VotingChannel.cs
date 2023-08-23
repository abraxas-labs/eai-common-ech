// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Art der Abstimmung.
/// </summary>
[XmlType(TypeName = "VotingChannelType", Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public enum VotingChannel
{
    /// <summary>
    ///     Urne.
    /// </summary>
    [EnumMember(Value = "1")][XmlEnum("1")] Urn,

    /// <summary>
    ///     brieflich.
    /// </summary>
    [EnumMember(Value = "2")][XmlEnum("2")] letter,

    /// <summary>
    ///     elektronisch.
    /// </summary>
    [EnumMember(Value = "3")][XmlEnum("3")] electronic,

    /// <summary>
    ///     Papier (Urne und brieflich).
    /// </summary>
    [EnumMember(Value = "3")][XmlEnum("3")] Paper
}
