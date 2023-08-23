// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0006_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Ausländerkategorien (eCH-0006)
/// Der residencePermitCategoryType bildet alle möglichen Basiskategorien für Ausländer ab.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0006/2")]
public enum ResidencePermitCategory
{
    /// <summary>
    /// Saisonarbeiterin / Saisonarbeiter.
    /// </summary>
    [EnumMember(Value = "01")]
    [XmlEnum("01")]
    SaisonarbeiterIn,

    /// <summary>
    /// Aufenthalterin / Aufenthalter.
    /// </summary>
    [EnumMember(Value = "02")]
    [XmlEnum("02")]
    AufenthalterIn,

    /// <summary>
    /// Niedergelassene / Niedergelassener.
    /// </summary>
    [EnumMember(Value = "03")]
    [XmlEnum("03")]
    Niedergelassener,

    /// <summary>
    /// Erwerbstätige Ehepartnerin / erwerbstätiger Ehepartner und Kinder von Angehörigen ausländischer Vertretungen oder staatlichen internationalen Organisationen.
    /// </summary>
    [EnumMember(Value = "04")]
    [XmlEnum("04")]
    ErwerbstaetigeEhepartnerIn,

    /// <summary>
    /// Vorläufig Aufgenommene / vorläufig Aufgenommener.
    /// </summary>
    [EnumMember(Value = "05")]
    [XmlEnum("05")]
    VorlaeufigAufgenommene,

    /// <summary>
    /// Grenzgängerin / Grenzgänger.
    /// </summary>
    [EnumMember(Value = "06")]
    [XmlEnum("06")]
    GrenzgaengerIn,

    /// <summary>
    /// Kurzaufenthalterin / Kurzaufenthalter.
    /// </summary>
    [EnumMember(Value = "07")]
    [XmlEnum("07")]
    KurzaufenthalterIn,

    /// <summary>
    /// Asylsuchende / Asylsuchender.
    /// </summary>
    [EnumMember(Value = "08")]
    [XmlEnum("08")]
    Asylsuchender,

    /// <summary>
    /// Schutzbedürftige / Schutzbedürftiger.
    /// </summary>
    [EnumMember(Value = "09")]
    [XmlEnum("09")]
    Schutzbedürftiger,

    /// <summary>
    /// Meldepflichtige / Meldepflichtiger bei ZEMIS (Zentrales Migrationssystem).
    /// </summary>
    [EnumMember(Value = "10")]
    [XmlEnum("10")]
    Meldepflichtiger,

    /// <summary>
    /// Diplomatin / Diplomat und internationale Funktionärin / internationaler Funktionär mit diplomatischer Immunität.
    /// </summary>
    [EnumMember(Value = "11")]
    [XmlEnum("11")]
    DiplomatIn,

    /// <summary>
    /// Internationale Funktionärin / internationaler Funktionär ohne diplomatische Immunität.
    /// </summary>
    [EnumMember(Value = "12")]
    [XmlEnum("12")]
    InternationaleFunktionaerIn,

    /// <summary>
    /// Nicht zugeteilt.
    /// </summary>
    [EnumMember(Value = "13")]
    [XmlEnum("13")]
    Unbekannt
}
