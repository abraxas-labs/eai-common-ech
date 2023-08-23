// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0223_1_4;

[Serializable]
[JsonObject("notice")]
[XmlType(TypeName = "noticeType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class Notice
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string NoticeTextValidateExceptionMessage = "noticeText is not valid! noticeText cannot be null and the length must be less or equal than 250 characters";

    private string _noticeText;

    public Notice()
    {
        Xmlns.Add("eCH-0223", "http://www.ech.ch/xmlns/eCH-0223/1");
    }

    [JsonProperty("noticeText")]
    [XmlElement(ElementName = "noticeText")]
    public string NoticeText
    {
        get { return _noticeText; }

        set
        {
            if (value == null || value.Length > 250)
            {
                throw new XmlSchemaValidationException(NoticeTextValidateExceptionMessage);
            }

            _noticeText = value;
        }
    }
}
