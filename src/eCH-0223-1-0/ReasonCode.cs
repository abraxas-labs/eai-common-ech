// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0223_1_0;

[Serializable]
[JsonObject("reasonCode")]
[XmlType(TypeName = "reasonCodeType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public class ReasonCode
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();
    private const string ReasonCodeNumberValidateExceptionMessage = "reasonCodeNumber is not valid! reasonCodeNumber must be an integer";
    private const string ReasonCodeTextValidateExceptionMessage = "reasonCodeText is not valid! reasonCodeText cannot be null";

    private string _reasonCodeNumber;
    private string _reasonCodeText;

    public ReasonCode()
    {
        Xmlns.Add("eCH-0223", "http://www.ech.ch/xmlns/eCH-0223/1");
    }

    [JsonProperty("reasonCodeNumber")]
    [XmlElement(ElementName = "reasonCodeNumber")]
    public string ReasonCodeNumber
    {
        get { return _reasonCodeNumber; }

        set
        {
            if (string.IsNullOrEmpty(value) || !int.TryParse(value, out var reasonCodeNumber))
            {
                throw new XmlSchemaValidationException(ReasonCodeNumberValidateExceptionMessage);
            }

            _reasonCodeNumber = value;
        }
    }

    [JsonProperty("reasonCodeText")]
    [XmlElement(ElementName = "reasonCodeText")]
    public string ReasonCodeText
    {
        get { return _reasonCodeText; }

        set
        {
            _reasonCodeText = value ?? throw new XmlSchemaValidationException(ReasonCodeTextValidateExceptionMessage);
        }
    }
}
