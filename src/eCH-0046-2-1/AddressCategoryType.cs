// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0046_2_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Ja oder Nein definition.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0046/2")]
public enum AddressCategoryType
{
    /// <summary>
    /// 1 = private.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Private = 1,

    /// <summary>
    /// 2 = business.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Business = 2
}
