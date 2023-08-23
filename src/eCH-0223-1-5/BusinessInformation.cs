// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0223_1_5;

[Serializable]
[JsonObject("businessInformation")]
[XmlType(TypeName = "businessInformationType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class BusinessInformation
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string BusinessCommentValidateExceptionMessage = "businessComment is not valid! businessComment cannot be null and the length must be less or equal than 1024 characters";

    private string _businessComment;

    public BusinessInformation()
    {
        Xmlns.Add("eCH-0223", "http://www.ech.ch/xmlns/eCH-0223/1");
    }

    [JsonProperty("businessComment")]
    [XmlElement(ElementName = "businessComment")]
    public string BusinessComment
    {
        get { return _businessComment; }

        set
        {
            if (value == null || value.Length > 1024)
            {
                throw new XmlSchemaValidationException(BusinessCommentValidateExceptionMessage);
            }

            _businessComment = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool BusinessCommentSpecified => BusinessComment != null;

    [JsonProperty("businessKey")]
    [XmlElement(ElementName = "businessKey")]
    public BusinessKey? BusinessKey { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BusinessKeySpecified => BusinessKey != null;

    [JsonProperty("encashment")]
    [XmlElement(ElementName = "encashment")]
    public bool? Encashment { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool EncashmentSpecified => Encashment != null;

    [JsonProperty("deadline")]
    [XmlElement(DataType = "date", ElementName = "deadline")]
    public DateTime? Deadline { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DeadlineSpecified => Deadline != null;
}
