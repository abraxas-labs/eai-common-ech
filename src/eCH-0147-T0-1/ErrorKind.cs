// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace eCH_0147_T0_1;

[XmlType("http://www.ech.ch/xmlns/eCH-0147/T0/1")]
public enum ErrorKind
{
    [EnumMember(Value = "notValid")]
    [XmlEnum("notValid")]
    NotValid,

    [EnumMember(Value = "fileWithoutReference")]
    [XmlEnum("fileWithoutReference")]
    FileWithoutReference,

    [EnumMember(Value = "referenceWithoutFile")]
    [XmlEnum("referenceWithoutFile")]
    ReferenceWithoutFile,

    [EnumMember(Value = "unknownRecipient")]
    [XmlEnum("unknownRecipient")]
    UnknownRecipient
}
