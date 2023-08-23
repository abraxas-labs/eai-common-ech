// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

public abstract class Register
{
    private const string RegisterIdentificationNullValidateExceptionMessage =
        "RegisterIdentification is not valid! RegisterIdentification is required";

    private const string RegisterIdentificationValidateExceptionMessage =
        "RegisterIdentification is not valid! RegisterIdentification has to be max. 50 chars";

    private const string RegisterNameNullValidateExceptionMessage =
        "RegisterName is not valid! RegisterName is required";

    private const string RegisterNameValidateExceptionMessage =
        "RegisterName is not valid! RegisterName has to be max. 100 chars";

    private string _registerIdentification;
    private string _registerName;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Register()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("registerIdentification")]
    [XmlElement(ElementName = "registerIdentification")]
    public string RegisterIdentification
    {
        get => _registerIdentification;
        set => _registerIdentification = RegisterIdentificationIsValid(value);
    }

    private string RegisterIdentificationIsValid(string value)
    {
        if (value == null)
        {
            throw new XmlSchemaValidationException(RegisterIdentificationNullValidateExceptionMessage);
        }

        if (value.Length > 50)
        {
            throw new XmlSchemaValidationException(RegisterIdentificationValidateExceptionMessage);
        }

        return value;
    }

    [JsonProperty("registerName")]
    [XmlElement(ElementName = "registerName")]
    public string RegisterName
    {
        get => _registerName;
        set => _registerName = RegisterNameIsValid(value);
    }

    private string RegisterNameIsValid(string value)
    {
        if (value == null)
        {
            throw new XmlSchemaValidationException(RegisterNameNullValidateExceptionMessage);
        }

        if (value.Length > 100)
        {
            throw new XmlSchemaValidationException(RegisterNameValidateExceptionMessage);
        }

        return value;
    }
}
