// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Ja oder Nein definition.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0021/6")]
public enum YesNoType
{
    /// <summary>
    /// 0 = Nein.
    /// </summary>
    [EnumMember(Value = "0")]
    [XmlEnum("0")]
    No = 0,

    /// <summary>
    /// 1 = Ja.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Yes = 1
}
