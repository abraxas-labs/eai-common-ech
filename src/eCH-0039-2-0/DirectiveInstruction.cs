// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0039_2_0;

[XmlType(TypeName = "directiveInstructionType", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2")]
public enum DirectiveInstruction
{
    [EnumMember(Value = "process")]
    [XmlEnum("process")]
    Process,

    [EnumMember(Value = "external_process")]
    [XmlEnum("external_process")]
    ExternalProcess,

    [EnumMember(Value = "information")]
    [XmlEnum("information")]
    Information,

    [EnumMember(Value = "comment")]
    [XmlEnum("comment")]
    Comment,

    [EnumMember(Value = "approve")]
    [XmlEnum("approve")]
    Approve,

    [EnumMember(Value = "sign")]
    [XmlEnum("sign")]
    Sign,

    [EnumMember(Value = "send")]
    [XmlEnum("send")]
    Send,

    [EnumMember(Value = "complete")]
    [XmlEnum("complete")]
    Complete
}
