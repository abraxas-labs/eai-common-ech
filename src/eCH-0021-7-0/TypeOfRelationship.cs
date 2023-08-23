// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Datensperre.
/// </summary>
[XmlType(TypeName = "typeOfRelationship", Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public enum TypeOfRelationship
{
    /// <summary>
    /// 1 = ist Ehepartner.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Ehepartner = 1,

    /// <summary>
    /// 2 = ist Partner in Eingetragener Partnerschaft.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Partnerschaft = 2,

    /// <summary>
    /// 3 = ist Mutter.
    /// </summary>
    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Mutter = 3,

    /// <summary>
    /// 4 = ist Vater.
    /// </summary>
    [EnumMember(Value = "4")]
    [XmlEnum("4")]
    Vater = 4,

    /// <summary>
    /// 5 = ist Pflegevater.
    /// </summary>
    [EnumMember(Value = "5")]
    [XmlEnum("5")]
    Pflegevater = 5,

    /// <summary>
    /// 6 = ist Pflegemutter.
    /// </summary>
    [EnumMember(Value = "6")]
    [XmlEnum("6")]
    Pflegemutter = 6,

    /// <summary>
    /// 7 = ist Beistand (von verbeiständeter Person).
    /// </summary>
    [EnumMember(Value = "7")]
    [XmlEnum("7")]
    Beistand = 7,

    /// <summary>
    /// 8 = ist Beirat (von verbeirateter Person).
    /// </summary>
    [EnumMember(Value = "8")]
    [XmlEnum("8")]
    Beirat = 8,

    /// <summary>
    /// 9 = ist Vormund (von bevormundeter minderjähriger Person).
    /// </summary>
    [EnumMember(Value = "9")]
    [XmlEnum("9")]
    Vormund = 9,

    /// <summary>
    /// 10 = ist Vorsorgebeauftragter (von Person).
    /// </summary>
    [EnumMember(Value = "10")]
    [XmlEnum("10")]
    Vorsorgebeauftragter = 10
}
