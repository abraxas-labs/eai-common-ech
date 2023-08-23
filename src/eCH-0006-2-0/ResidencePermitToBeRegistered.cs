// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0006_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Ausländerkategorien (eCH-0006)
/// Der residencePermitToBeRegisteredType bildet alle möglichen Unterkategorien für Meldepflichtige ab.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0006/2")]
public enum ResidencePermitToBeRegistered
{
    /// <summary>
    /// Arbeitnehmerin / Arbeitnehmer bei einem Schweizer Arbeitgeber.
    /// </summary>
    [EnumMember(Value = "01")]
    [XmlEnum("01")]
    Code01,

    /// <summary>
    /// Selbständige Dienstleistungserbringerin / selbständiger Dienstleistungserbringer.
    /// </summary>
    [EnumMember(Value = "02")]
    [XmlEnum("02")]
    Code02,

    /// <summary>
    /// Entsandte Arbeitnehmerin / entsandter Arbeitnehmer.
    /// </summary>
    [EnumMember(Value = "03")]
    [XmlEnum("03")]
    Code03
}
