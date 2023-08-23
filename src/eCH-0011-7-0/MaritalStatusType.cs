// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0011_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Zivilstandsangaben zu einer Person.
/// </summary>
[XmlType(TypeName = "maritalStatusType", Namespace = "http://www.ech.ch/xmlns/eCH-0011/7")]
public enum MaritalStatusType
{
    /// <summary>
    /// 1 = ledig.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Ledig = 1,

    /// <summary>
    /// 2 = verheiratet.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Verheiratet = 2,

    /// <summary>
    /// 3 = verwitwet.
    /// </summary>
    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Verwitwet = 3,

    /// <summary>
    /// 4 = geschieden.
    /// </summary>
    [EnumMember(Value = "4")]
    [XmlEnum("4")]
    Geschieden = 4,

    /// <summary>
    /// 5 = unverheiratet.
    /// </summary>
    [EnumMember(Value = "5")]
    [XmlEnum("5")]
    Unverheiratet = 5,

    /// <summary>
    /// 6 = in eingetragener Partnerschaft.
    /// </summary>
    [EnumMember(Value = "6")]
    [XmlEnum("6")]
    InEingetragenerPartnerschaft = 6,

    /// <summary>
    /// 7 = aufgelöste Partnerschaft.
    /// </summary>
    [EnumMember(Value = "7")]
    [XmlEnum("7")]
    AufgeloestePartnerschaft = 7
}
