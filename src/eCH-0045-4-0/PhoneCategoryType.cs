// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0045_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Stimm- und Wahlregister(eCH-0045/4)
///     phoneCategory - Kategorie der Telefonnummer.
/// </summary>
[XmlType(TypeName = "phoneCategoryType", Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public enum PhoneCategoryType
{
    /// <summary>
    ///     PrivatePhone.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    PrivatePhone = 1,

    /// <summary>
    ///     PrivateMobile.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    PrivateMobile = 2,

    /// <summary>
    ///     PrivateFax.
    /// </summary>
    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    PrivateFax = 3,

    /// <summary>
    ///     PrivateInternetVoice.
    /// </summary>
    [EnumMember(Value = "4")]
    [XmlEnum("4")]
    PrivateInternetVoice = 4,

    /// <summary>
    ///     BusinessCentral.
    /// </summary>
    [EnumMember(Value = "5")]
    [XmlEnum("5")]
    BusinessCentral = 5,

    /// <summary>
    ///     BusinessDirect.
    /// </summary>
    [EnumMember(Value = "6")]
    [XmlEnum("6")]
    BusinessDirect = 6,

    /// <summary>
    ///     BusinessMobile.
    /// </summary>
    [EnumMember(Value = "7")]
    [XmlEnum("7")]
    BusinessMobile = 7,

    /// <summary>
    ///     BusinessFax.
    /// </summary>
    [EnumMember(Value = "8")]
    [XmlEnum("8")]
    BusinessFax = 8,

    /// <summary>
    ///     BusinessInternetVoice.
    /// </summary>
    [EnumMember(Value = "9")]
    [XmlEnum("9")]
    BusinessInternetVoice = 9,

    /// <summary>
    ///     Pager.
    /// </summary>
    [EnumMember(Value = "10")]
    [XmlEnum("10")]
    Pager = 10,
}
