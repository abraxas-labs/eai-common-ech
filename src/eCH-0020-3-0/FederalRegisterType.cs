// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Codierung der Bundesregister (federalRegister).
/// </summary>
[XmlType(TypeName = "federalRegisterType", Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public enum FederalRegisterType
{
    /// <summary>
    /// 1 = INFOSTAR.
    /// </summary>
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    INFOSTAR = 1,

    /// <summary>
    /// 2 = Ordipro.
    /// </summary>
    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Ordipro = 2,

    /// <summary>
    /// 3 = ZEMIS.
    /// </summary>
    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    ZEMIS = 3
}
