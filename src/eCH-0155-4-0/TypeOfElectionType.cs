// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Typ der Wahl: Gibt an, ob es sich um eine Proporz- oder Majorzwahl handelt.
/// </summary>
[XmlType(TypeName = "TypeOfElectionType", Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public enum TypeOfElectionType
{
    /// <summary>
    ///     Proporzwahl.
    /// </summary>
    [EnumMember(Value = "1")][XmlEnum("1")] Proporz = 1,

    /// <summary>
    ///     Majorzwahl.
    /// </summary>
    [EnumMember(Value = "2")][XmlEnum("2")] Majorz = 2
}
