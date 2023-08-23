// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0147_T1_1;

[Serializable]
[JsonObject("message")]
[XmlType("messageType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T1/1")]
[XmlRoot("message", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T1/1", IsNullable = false)]
public class Message : FieldValueChecker<Message>
{
    private Header _header;
    private Content _content;

    [FieldRequired]
    [JsonProperty("header")]
    [XmlElement("header", Form = XmlSchemaForm.Unqualified)]
    public Header Header
    {
        get => _header;
        set => CheckAndSetValue(ref _header, value);
    }

    [FieldRequired]
    [JsonProperty("content")]
    [XmlElement("content", Form = XmlSchemaForm.Unqualified)]
    public Content Content
    {
        get => _content;
        set => CheckAndSetValue(ref _content, value);
    }
}
