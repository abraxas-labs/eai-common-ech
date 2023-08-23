// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Kantone als Bfs-Nummern.
/// </summary>
[XmlType(TypeName = "DomainOfInfluenceType", Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public enum BfsNumberCanton
{
    [EnumMember(Value = "1")][XmlEnum("1")] ZH,
    [EnumMember(Value = "2")][XmlEnum("2")] BE,
    [EnumMember(Value = "3")][XmlEnum("3")] LU,
    [EnumMember(Value = "4")][XmlEnum("4")] UR,
    [EnumMember(Value = "5")][XmlEnum("5")] SZ,
    [EnumMember(Value = "6")][XmlEnum("6")] OW,
    [EnumMember(Value = "7")][XmlEnum("7")] NW,
    [EnumMember(Value = "8")][XmlEnum("8")] GL,
    [EnumMember(Value = "9")][XmlEnum("9")] ZG,
    [EnumMember(Value = "10")][XmlEnum("10")] FR,
    [EnumMember(Value = "11")][XmlEnum("11")] SO,
    [EnumMember(Value = "12")][XmlEnum("12")] BS,
    [EnumMember(Value = "13")][XmlEnum("13")] BL,
    [EnumMember(Value = "14")][XmlEnum("14")] SH,
    [EnumMember(Value = "15")][XmlEnum("15")] AR,
    [EnumMember(Value = "16")][XmlEnum("16")] AI,
    [EnumMember(Value = "17")][XmlEnum("17")] SG,
    [EnumMember(Value = "18")][XmlEnum("18")] GR,
    [EnumMember(Value = "19")][XmlEnum("19")] AG,
    [EnumMember(Value = "20")][XmlEnum("20")] TG,
    [EnumMember(Value = "21")][XmlEnum("21")] TI,
    [EnumMember(Value = "22")][XmlEnum("22")] VD,
    [EnumMember(Value = "23")][XmlEnum("23")] VS,
    [EnumMember(Value = "24")][XmlEnum("24")] NE,
    [EnumMember(Value = "25")][XmlEnum("25")] GE,
    [EnumMember(Value = "26")][XmlEnum("26")] JU
}
