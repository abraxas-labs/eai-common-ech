// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0008_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Sprachtyp (eCH-0008)
/// Status Staatsangehörigkeit.
/// </summary>
[XmlType(TypeName = "languageType", Namespace = "http://www.ech.ch/xmlns/eCH-0008/1")]
public enum LanguageType
{
    /// <summary>
    /// 0 = Staatsangehörigkeit unbekannt.
    /// </summary>
    [EnumMember(Value = "fr")]
    [XmlEnum("fr")]
    Fr = 0,

    /// <summary>
    /// 1 = Staatenlos.
    /// </summary>
    [EnumMember(Value = "it")]
    [XmlEnum("it")]
    It = 1,

    /// <summary>
    /// 2 = Staatsangehörigkeit bekannt.
    /// </summary>
    [EnumMember(Value = "dt")]
    [XmlEnum("dt")]
    Dt = 2,

    /// <summary>
    /// 2 = Staatsangehörigkeit bekannt.
    /// </summary>
    [EnumMember(Value = "en")]
    [XmlEnum("en")]
    En = 3
}
