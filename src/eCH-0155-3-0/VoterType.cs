// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Typ der Wahl: Gibt an, ob es sich um eine Proporz- oder Majorzwahl handelt.
/// </summary>
[XmlType(TypeName = "VoterTypeType", Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public enum VoterType
{
    /// <summary>
    ///     Schweizer.
    /// </summary>
    [EnumMember(Value = "1")][XmlEnum("1")] Swiss,

    /// <summary>
    ///     Auslandschweizer.
    /// </summary>
    [EnumMember(Value = "2")][XmlEnum("2")] ForeignSwiss,

    /// <summary>
    ///     Auslandschweizer.
    /// </summary>
    [EnumMember(Value = "3")][XmlEnum("3")] Foreign
}
