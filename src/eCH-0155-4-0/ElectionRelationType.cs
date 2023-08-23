// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Typ der Referenzwahl.
/// </summary>
[XmlType(TypeName = "ElectionRelationType", Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public enum ElectionRelationType
{
    /// <summary>
    ///     Hauptwahl.
    /// </summary>
    [EnumMember(Value = "1")][XmlEnum("1")] Major,

    /// <summary>
    ///     Nebenwahl.
    /// </summary>
    [EnumMember(Value = "2")][XmlEnum("2")] Minor
}
