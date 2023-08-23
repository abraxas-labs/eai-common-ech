// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0039_2_0;

[XmlType(TypeName = "reportActionType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2")]
public enum ReportAction
{
    [EnumMember(Value = "8")]
    [XmlEnum("8")]
    ReportAction8 = 8,

    [EnumMember(Value = "9")]
    [XmlEnum("9")]
    ReportAction9 = 9,

    [EnumMember(Value = "11")]
    [XmlEnum("11")]
    ReportAction11 = 11
}
