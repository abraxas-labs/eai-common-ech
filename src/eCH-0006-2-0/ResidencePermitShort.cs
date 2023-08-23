// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0006_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Ausländerkategorien (eCH-0006)
/// Der residencePermitShortType bildet alle möglichen Unterkategorien für Kurzaufenthalter ab. (Ausweis L).
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0006/2")]
public enum ResidencePermitShort
{
    /// <summary>
    /// Kurzaufenthalterin / Kurzaufenthalter &gt;=12 Monate.
    /// </summary>
    [EnumMember(Value = "01")]
    [XmlEnum("01")]
    KurzaufenthalterIn01,

    /// <summary>
    /// Kurzaufenthalterin / Kurzaufenthalter &gt;4 bis &lt;12 Monate.
    /// </summary>
    [EnumMember(Value = "02")]
    [XmlEnum("02")]
    KurzaufenthalterIn02,

    /// <summary>
    /// Dienstleistungserbringerin / Dienstleistungserbringer &lt;=4 Monate.
    /// </summary>
    [EnumMember(Value = "03")]
    [XmlEnum("03")]
    DienstleistungserbringerIn,

    /// <summary>
    /// Kurzaufenthalterin / Kurzaufenthalter &lt;=4 Monate.
    /// </summary>
    [EnumMember(Value = "04")]
    [XmlEnum("04")]
    KurzaufenthalterIn03,

    /// <summary>
    /// Musikerin und Künstlerin / Musiker und Künstler &lt;=8 Monate.
    /// </summary>
    [EnumMember(Value = "05")]
    [XmlEnum("05")]
    MusikerIn,

    /// <summary>
    /// Tänzer/Tänzerin &lt;=8 Monate.
    /// </summary>
    [EnumMember(Value = "06")]
    [XmlEnum("06")]
    Taenzer,

    /// <summary>
    /// Stagiaires &lt;=18 Monate.
    /// </summary>
    [EnumMember(Value = "07")]
    [XmlEnum("07")]
    Stagiaires
}
