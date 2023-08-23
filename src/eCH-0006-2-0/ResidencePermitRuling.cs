// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0006_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Ausländerkategorien (eCH-0006)
/// Der residencePermitRulingType bildet Ausländerkategorie inkl. Angabe der Regelung ab.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0006/2")]
public enum ResidencePermitRuling
{
    /// <summary>
    /// Regelung nach EU/EFTA-Abkommen (VEP).
    /// </summary>
    [EnumMember(Value = "01")]
    [XmlEnum("01")]
    Regelung01,

    /// <summary>
    /// Regelung nicht EU/EFTA-Abkommen (BVO).
    /// </summary>
    [EnumMember(Value = "02")]
    [XmlEnum("02")]
    Regelung02,

    /// <summary>
    /// Regelung für vorläufig Aufgenommene (ANAG / AsylG).
    /// </summary>
    [EnumMember(Value = "03")]
    [XmlEnum("03")]
    Regelung03,

    /// <summary>
    /// Regelung für Asylsuchende (AsylG).
    /// </summary>
    [EnumMember(Value = "04")]
    [XmlEnum("04")]
    Regelung04,

    /// <summary>
    /// Regelung für Schutzbedürftige (AsylG).
    /// </summary>
    [EnumMember(Value = "05")]
    [XmlEnum("05")]
    Regelung05,

    /// <summary>
    /// Regelung für Meldepflichtige (EntsG).
    /// </summary>
    [EnumMember(Value = "06")]
    [XmlEnum("06")]
    Regelung06,

    /// <summary>
    /// Regelung für Diplomatin / Diplomat und internationale Funktionärin / internationaler Funktionär mit diplomatischer Immunität (Wiener Übereinkommen).
    /// </summary>
    [EnumMember(Value = "07")]
    [XmlEnum("07")]
    Regelung07,

    /// <summary>
    /// Regelung für Internationale Funktionärin / internationaler Funktionär ohne diplomatische Immunität (Abkommen und Briefwechsel).
    /// </summary>
    [EnumMember(Value = "08")]
    [XmlEnum("08")]
    Regelung08,

    /// <summary>
    /// Regelung gemäss verschiedener Stagiaires-Abkommen (Bilaterale Abkommen).
    /// </summary>
    [EnumMember(Value = "09")]
    [XmlEnum("09")]
    Regelung09
}
