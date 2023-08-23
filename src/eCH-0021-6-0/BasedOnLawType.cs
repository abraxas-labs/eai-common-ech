// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angabe ob die Eltern die elterliche Sorge besitzen.
/// </summary>
[XmlType(TypeName = "basedOnLawType", Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public enum BasedOnLawType
{
    /// <summary>
    /// 0 = keine elterliche Sorge oder nicht abgeklärt.
    /// </summary>
    [EnumMember(Value = "368")]
    [XmlEnum("368")]
    ZGB368 = 368,

    [EnumMember(Value = "369")]
    [XmlEnum("369")]
    ZGB369 = 369,

    [EnumMember(Value = "370")]
    [XmlEnum("370")]
    ZGB370 = 370,

    [EnumMember(Value = "371")]
    [XmlEnum("371")]
    ZGB371 = 371,

    [EnumMember(Value = "372")]
    [XmlEnum("372")]
    ZGB372 = 372,

    [EnumMember(Value = "327-a")]
    [XmlEnum("327-a")]
    ZGB327a = 327,

    [EnumMember(Value = "393")]
    [XmlEnum("393")]
    ZGB393 = 393,

    [EnumMember(Value = "394")]
    [XmlEnum("394")]
    ZGB394 = 394,

    [EnumMember(Value = "395")]
    [XmlEnum("395")]
    ZGB395 = 395,

    [EnumMember(Value = "396")]
    [XmlEnum("396")]
    ZGB396 = 396,

    [EnumMember(Value = "397")]
    [XmlEnum("397")]
    ZGB397 = 397,

    [EnumMember(Value = "398")]
    [XmlEnum("398")]
    ZGB398 = 398,

    [EnumMember(Value = "399")]
    [XmlEnum("399")]
    ZGB399 = 399
}
