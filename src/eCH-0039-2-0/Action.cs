// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0039_2_0;

/// <summary>
/// Aktion für Erstmeldungen: Fachliche Austauschanweisung für den Empfänger.
/// </summary>
[XmlType(TypeName = "actionType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2")]
public enum ActionType
{
    [EnumMember(Value = "1")]
    [XmlEnum("1")]
    ReportAction1 = 1,

    [EnumMember(Value = "3")]
    [XmlEnum("3")]
    ReportAction3 = 3,

    [EnumMember(Value = "4")]
    [XmlEnum("4")]
    ReportAction4 = 4,

    [EnumMember(Value = "5")]
    [XmlEnum("5")]
    ReportAction5 = 5,

    [EnumMember(Value = "6")]
    [XmlEnum("6")]
    ReportAction6 = 6,

    [EnumMember(Value = "7")]
    [XmlEnum("7")]
    ReportAction7 = 7,

    [EnumMember(Value = "10")]
    [XmlEnum("10")]
    ReportAction10 = 10,

    [EnumMember(Value = "12")]
    [XmlEnum("12")]
    ReportAction12 = 12
}
