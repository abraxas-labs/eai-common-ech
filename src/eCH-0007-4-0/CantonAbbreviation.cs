// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0007_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard Gemeinden (eCH-0007)
///     Zweistellige Abkürzungen der schweizer Kantone.
/// </summary>
[XmlType(TypeName = "cantonAbbreviation", Namespace = "http://www.ech.ch/xmlns/eCH-0007/4")]
public enum CantonAbbreviation
{
    /// <summary>
    /// Kanton Zürich.
    /// </summary>
    [EnumMember(Value = "ZH")]
    [XmlEnum("ZH")]
    ZH = 1,

    /// <summary>
    /// Kanton Bern.
    /// </summary>
    [EnumMember(Value = "BE")]
    [XmlEnum("BE")]
    BE = 2,

    /// <summary>
    /// Kanton Luzern.
    /// </summary>
    [EnumMember(Value = "LU")]
    [XmlEnum("LU")]
    LU = 3,

    /// <summary>
    /// Kanton Uri.
    /// </summary>
    [EnumMember(Value = "UR")]
    [XmlEnum("UR")]
    UR = 4,

    /// <summary>
    /// Kanton Schwyz.
    /// </summary>
    [EnumMember(Value = "SZ")]
    [XmlEnum("SZ")]
    SZ = 5,

    /// <summary>
    /// Kanton Obwalden.
    /// </summary>
    [EnumMember(Value = "OW")]
    [XmlEnum("OW")]
    OW = 6,

    /// <summary>
    /// Kanton Nidwalden.
    /// </summary>
    [EnumMember(Value = "NW")]
    [XmlEnum("NW")]
    NW = 7,

    /// <summary>
    /// Kanton Glarus.
    /// </summary>
    [EnumMember(Value = "GL")]
    [XmlEnum("GL")]
    GL = 8,

    /// <summary>
    /// Kanton Zug.
    /// </summary>
    [EnumMember(Value = "ZG")]
    [XmlEnum("ZG")]
    ZG = 9,

    /// <summary>
    /// Kanton Freiburg.
    /// </summary>
    [EnumMember(Value = "FR")]
    [XmlEnum("FR")]
    FR = 10,

    /// <summary>
    /// Kanton Solothurn.
    /// </summary>
    [EnumMember(Value = "SO")]
    [XmlEnum("SO")]
    SO = 11,

    /// <summary>
    /// Kanton Basel-Stadt.
    /// </summary>
    [EnumMember(Value = "BS")]
    [XmlEnum("BS")]
    BS = 12,

    /// <summary>
    /// Kanton Baselland.
    /// </summary>
    [EnumMember(Value = "BL")]
    [XmlEnum("BL")]
    BL = 13,

    /// <summary>
    /// Kanton Schaffhausen.
    /// </summary>
    [EnumMember(Value = "SH")]
    [XmlEnum("SH")]
    SH = 14,

    /// <summary>
    /// Kanton Appenzell Ausserrhoden.
    /// </summary>
    [EnumMember(Value = "AR")]
    [XmlEnum("AR")]
    AR = 15,

    /// <summary>
    /// Kanton Appenzell Innerrhoden.
    /// </summary>
    [EnumMember(Value = "AI")]
    [XmlEnum("AI")]
    AI = 16,

    /// <summary>
    /// Kanton St. Gallen.
    /// </summary>
    [EnumMember(Value = "SG")]
    [XmlEnum("SG")]
    SG = 17,

    /// <summary>
    /// Kanton Graubünden.
    /// </summary>
    [EnumMember(Value = "GR")]
    [XmlEnum("GR")]
    GR = 18,

    /// <summary>
    /// Kanton Aargau.
    /// </summary>
    [EnumMember(Value = "AG")]
    [XmlEnum("AG")]
    AG = 19,

    /// <summary>
    /// Kanton Thurgau.
    /// </summary>
    [EnumMember(Value = "TG")]
    [XmlEnum("TG")]
    TG = 20,

    /// <summary>
    /// Kanton Tessin.
    /// </summary>
    [EnumMember(Value = "TI")]
    [XmlEnum("TI")]
    TI = 21,

    /// <summary>
    /// Kanton Waadt.
    /// </summary>
    [EnumMember(Value = "VD")]
    [XmlEnum("VD")]
    VD = 22,

    /// <summary>
    /// Kanton Wallis.
    /// </summary>
    [EnumMember(Value = "VS")]
    [XmlEnum("VS")]
    VS = 23,

    /// <summary>
    /// Kanton Neuenburg.
    /// </summary>
    [EnumMember(Value = "NE")]
    [XmlEnum("NE")]
    NE = 24,

    /// <summary>
    /// Kanton Genf.
    /// </summary>
    [EnumMember(Value = "GE")]
    [XmlEnum("GE")]
    GE = 25,

    /// <summary>
    /// Kanton Jura.
    /// </summary>
    [EnumMember(Value = "JU")]
    [XmlEnum("JU")]
    JU = 26
}
