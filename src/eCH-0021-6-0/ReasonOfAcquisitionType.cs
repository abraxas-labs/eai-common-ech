// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Datensperre.
/// </summary>
[XmlType(TypeName = "reasonOfAcquisitionType", Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public enum ReasonOfAcquisitionType
{
    /// <summary>
    /// 1 = Abstammung.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Abstammung = 1,

    /// <summary>
    /// 2= Heirat.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Heirat = 2,

    /// <summary>
    /// 3= Einbürgerung.
    /// </summary>
    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Einbuergerung = 3,

    /// <summary>
    /// 4= Bürgerrechtsanerkennung.
    /// </summary>
    [EnumMember(Value = "4")]
    [XmlEnum("4")]
    Buergerrechtsanerkennung = 4,

    /// <summary>
    /// 5= Wiedereinbürgerung/-annahme.
    /// </summary>
    [EnumMember(Value = "5")]
    [XmlEnum("5")]
    WiedereinbuergerungAnnahme = 5,

    /// <summary>
    /// 6= Erleichterte Einbürgerung.
    /// </summary>
    [EnumMember(Value = "6")]
    [XmlEnum("6")]
    ErleichterteEinbuergerung = 6,

    /// <summary>
    /// 8= Anerkennung.
    /// </summary>
    [EnumMember(Value = "8")]
    [XmlEnum("8")]
    Anerkennung = 8,

    /// <summary>
    /// 9= Unbekannt.
    /// </summary>
    [EnumMember(Value = "9")]
    [XmlEnum("9")]
    Unbekannt = 9,

    /// <summary>
    /// 10= Erwerb von Gesetzes wegen.
    /// </summary>
    [EnumMember(Value = "10")]
    [XmlEnum("10")]
    ErwerbVonGesetzesWegen = 10,

    /// <summary>
    /// 11= Namensänderung mit Bürgerrechtswirkung.
    /// </summary>
    [EnumMember(Value = "11")]
    [XmlEnum("11")]
    NamensänderungMitBuergerrechtswirkung = 11
}
