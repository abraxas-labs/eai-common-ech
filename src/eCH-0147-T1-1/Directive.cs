// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0039_2_0;
using eCH_0147_T0_1;
using Newtonsoft.Json;

namespace eCH_0147_T1_1;

[Serializable]
[JsonObject("directive")]
[XmlType("directiveType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T1/1")]
public class Directive : FieldValueChecker<Directive>
{
    private string _uuid;
    private DirectiveInstruction? _instruction;
    private Priority? _priority;

    [FieldRequired]
    [JsonProperty("uuid")]
    [XmlElement("uuid", Form = XmlSchemaForm.Unqualified, DataType = "token")]
    public string Uuid
    {
        get => _uuid;
        set => CheckAndSetValue(ref _uuid, value);
    }

    [FieldRequired]
    [JsonProperty("instruction")]
    [XmlElement("instruction", Form = XmlSchemaForm.Unqualified)]
    public DirectiveInstruction? Instruction
    {
        get => _instruction;
        set => CheckAndSetValue(ref _instruction, value);
    }

    [FieldRequired]
    [JsonProperty("priority")]
    [XmlElement("priority", Form = XmlSchemaForm.Unqualified)]
    public Priority? Priority
    {
        get => _priority;
        set => CheckAndSetValue(ref _priority, value);
    }

    [JsonProperty("titles")]
    [XmlArray("titles", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("title", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Title[] Titles { get; set; }

    [JsonProperty("deadline")]
    [XmlElement("deadline", Form = XmlSchemaForm.Unqualified, DataType = "date")]
    public DateTime? Deadline { get; set; }

    [JsonProperty("serviceId")]
    [XmlElement("serviceId", Form = XmlSchemaForm.Unqualified, DataType = "token")]
    public string ServiceId { get; set; }

    [JsonProperty("comments")]
    [XmlArray("comments", Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("comment", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Comment[] Comments { get; set; }

    [JsonProperty("applicationCustom")]
    [XmlElement("applicationCustom", Form = XmlSchemaForm.Unqualified)]
    public ApplicationCustom[] ApplicationCustoms { get; set; }
}
