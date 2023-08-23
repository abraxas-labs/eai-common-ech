// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eEK_0020_1_1;

[XmlType(TypeName = "decisionIdType", Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public enum DecisionId
{
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Adoptionsbeschluss = 1,

    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Anerkennungsbeschluss = 2,

    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Legitimationsbeschluss = 3,

    [EnumMember(Value = "4")]
    [XmlEnum("4")]
    Namensaenderungsbeschluss = 4,

    [EnumMember(Value = "5")]
    [XmlEnum("5")]
    Einbuergerungsbeschluss = 5,

    [EnumMember(Value = "6")]
    [XmlEnum("6")]
    Beschluss_ueber_einen_Beistand = 6,

    [EnumMember(Value = "9")]
    [XmlEnum("9")]
    Beschluss_des_Regierungsrates = 9,

    [EnumMember(Value = "10")]
    [XmlEnum("10")]
    Beschluss_des_Parlaments = 10,

    [EnumMember(Value = "11")]
    [XmlEnum("11")]
    Beschluss_des_Buergerrates = 11,

    [EnumMember(Value = "12")]
    [XmlEnum("12")]
    Beschluss_eines_Gerichtes = 12,

    [EnumMember(Value = "13")]
    [XmlEnum("13")]
    Beschluss_einer_Behoerde = 13,

    [EnumMember(Value = "14")]
    [XmlEnum("14")]
    Ausbuergerungsbeschluss = 14
}
