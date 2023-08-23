// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0046_4_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Kontakt (eCH-0046)
/// internetCategory - Kategorie der Internet-Adresse.
/// </summary>
[XmlType("http://www.ech.ch/xmlns/eCH-0046/4")]
public enum InternetCategoryType
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
