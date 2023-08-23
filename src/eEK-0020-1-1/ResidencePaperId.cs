// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eEK_0020_1_1;

[XmlType(TypeName = "residencePaperIdType", Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public enum ResidencePaperId
{
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    Heimatschein = 1,

    [EnumMember(Value = "2")]
    [XmlEnum("2")]
    Heimatausweis = 2,

    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    Vorl_keineHinterlegung = 3,

    [EnumMember(Value = "4")]
    [XmlEnum("4")]
    Interimsausweis = 4,

    [EnumMember(Value = "5")]
    [XmlEnum("5")]
    Dienstpass = 5,

    [EnumMember(Value = "6")]
    [XmlEnum("6")]
    Diplomatenausweis = 6,

    [EnumMember(Value = "7")]
    [XmlEnum("7")]
    Fremdenpass = 7,

    [EnumMember(Value = "8")]
    [XmlEnum("8")]
    Heimatschein_Auslaender = 8,

    [EnumMember(Value = "9")]
    [XmlEnum("9")]
    Identitätsausweis = 9,

    [EnumMember(Value = "10")]
    [XmlEnum("10")]
    Identitaetskarte = 10,

    [EnumMember(Value = "11")]
    [XmlEnum("11")]
    InSchriftenEhemann = 11,

    [EnumMember(Value = "12")]
    [XmlEnum("12")]
    InSchriftenMutter = 12,

    [EnumMember(Value = "13")]
    [XmlEnum("13")]
    InSchriftenVater = 13,

    [EnumMember(Value = "14")]
    [XmlEnum("14")]
    KeineSchriften = 14,

    [EnumMember(Value = "15")]
    [XmlEnum("15")]
    Kinderausweis = 15,

    [EnumMember(Value = "16")]
    [XmlEnum("16")]
    Konsulatsbestaetigung = 16,

    [EnumMember(Value = "17")]
    [XmlEnum("17")]
    Laissez_passer = 17,

    [EnumMember(Value = "18")]
    [XmlEnum("18")]
    Pass = 18,

    [EnumMember(Value = "19")]
    [XmlEnum("19")]
    Passersatz = 19,

    [EnumMember(Value = "20")]
    [XmlEnum("20")]
    Personalausweis = 20,

    [EnumMember(Value = "21")]
    [XmlEnum("21")]
    Reiseausweis = 21,

    [EnumMember(Value = "22")]
    [XmlEnum("22")]
    Heimatausweis_Auslaender = 22,

    [EnumMember(Value = "23")]
    [XmlEnum("23")]
    KeineHinterlage = 23,

    [EnumMember(Value = "24")]
    [XmlEnum("24")]
    Hinterlagenichtnotwendig = 24,

    [EnumMember(Value = "25")]
    [XmlEnum("25")]
    HinterlagenichtnotwendigOB = 25,

    [EnumMember(Value = "26")]
    [XmlEnum("26")]
    HeimatausweisfuergetrenntlebendeFrauen = 26
}
