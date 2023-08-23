// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0046_4_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Kontakt (eCH-0046)
/// phoneCategory - Kategorie der Telefonnummer.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0046/4")]
public enum PhoneCategoryType
{
    /// <summary>
    /// 1 = private Telefonnummer.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    PrivatePhone = 1,

    /// <summary>
    /// 2 = private Mobil-Nummer.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    PrivateMobile = 2,

    /// <summary>
    /// 3 = private Fax-Nummer.
    /// </summary>
    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    PrivateFax = 3,

    /// <summary>
    /// 4 = private Internettelefonie-Nummer.
    /// </summary>
    [EnumMember(Value = "4")]
    [XmlEnum("4")]
    PrivateInternetVoice = 4,

    /// <summary>
    /// 5 = geschäftliche Nummer (Zentrale).
    /// </summary>
    [EnumMember(Value = "5")]
    [XmlEnum("5")]
    BusinessCentral = 5,

    /// <summary>
    /// 6 = geschäftliche Nummer (Durchwahl).
    /// </summary>
    [EnumMember(Value = "6")]
    [XmlEnum("6")]
    BusinessDirect = 6,

    /// <summary>
    /// 7 = geschäftliche Mobil-Nummer.
    /// </summary>
    [EnumMember(Value = "7")]
    [XmlEnum("7")]
    BusinessMobile = 7,

    /// <summary>
    /// 8 = geschäftliche Fax-Nummer.
    /// </summary>
    [EnumMember(Value = "8")]
    [XmlEnum("8")]
    BusinessFax = 8,

    /// <summary>
    /// 9 = geschäftliche Internettelefonie-Nummer.
    /// </summary>
    [EnumMember(Value = "9")]
    [XmlEnum("9")]
    BusinessInternetVoice = 9,

    /// <summary>
    /// 10 = Pager.
    /// </summary>
    [EnumMember(Value = "10")]
    [XmlEnum("10")]
    Pager = 10
}
