// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0006_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Ausländerkategorien (eCH-0006)
/// Der residencePermitBorderType bildet alle möglichen Unterkategorien für Grenzgänger ab. (Ausweis G).
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0006/2")]
public enum ResidencePermitBorder
{
    /// <summary>
    /// Aufenthalt &lt;12 Monate.
    /// </summary>
    [EnumMember(Value = "01")]
    [XmlEnum("01")]
    Aufenthalt01,

    /// <summary>
    /// Aufenthalt &gt;=12 Monate.
    /// </summary>
    [EnumMember(Value = "02")]
    [XmlEnum("02")]
    Aufenthalt02,
}
