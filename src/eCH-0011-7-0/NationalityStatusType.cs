// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0011_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Status Staatsangehörigkeit.
/// </summary>
[XmlType(TypeName = "nationalityStatusType", Namespace = "http://www.ech.ch/xmlns/eCH-0011/7")]
public enum NationalityStatusType
{
    /// <summary>
    /// 0 = Staatsangehörigkeit unbekannt.
    /// </summary>
    [EnumMember(Value = "0")]
    [XmlEnum("0")]
    Unbekannt = 0,

    /// <summary>
    /// 1 = Staatenlos.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Staatenlos = 1,

    /// <summary>
    /// 2 = Staatsangehörigkeit bekannt.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Bekannt = 2
}
