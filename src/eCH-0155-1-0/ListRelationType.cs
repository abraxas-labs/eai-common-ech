// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Kantone als Bfs-Nummern.
/// </summary>
[XmlType(TypeName = "ListRelationType", Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public enum ListRelationType
{
    /// <summary>
    ///     Listenverbindung.
    /// </summary>
    [EnumMember(Value = "1")][XmlEnum("1")] ListUnion,

    /// <summary>
    ///     Unterlistenverbindung.
    /// </summary>
    [EnumMember(Value = "2")][XmlEnum("2")] SubListUnion
}
