// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0045_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Stimm- und Wahlregister(eCH-0045/4)
///     emailCategory - Kategorie der E-Mail-Adresse.
/// </summary>
[XmlType(TypeName = "emailCategoryType", Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public enum EmailCategoryType
{
    /// <summary>
    ///     privat.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Privat = 1,

    /// <summary>
    ///     geschaeftlich.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Geschaeftlich = 2
}
