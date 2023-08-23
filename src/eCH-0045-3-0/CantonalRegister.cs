// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("cantonalRegisterType")]
[XmlRoot(ElementName = "cantonalRegisterType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class CantonalRegister
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

    public CantonalRegister()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("registerIdentification")]
    [XmlElement(ElementName = "registerIdentification", Order = 1)]
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

    [JsonProperty("cantonAbbreviation")]
    [XmlElement(ElementName = "cantonAbbreviation", Order = 2)]
    public CantonAbbreviation CantonAbbreviation { get; set; }

    [JsonProperty("registerName")]
    [XmlElement(ElementName = "registerName", Order = 3)]
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

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="registerIdentification">Field is required.</param>
    /// <param name="registerName">Field is required.</param>
    /// <param name="cantonAbbreviation">Field is required.</param>
    /// <returns>CantonalRegister.</returns>
    public static CantonalRegister Create(string registerIdentification, string registerName, CantonAbbreviation cantonAbbreviation)
    {
        return new CantonalRegister
        {
            RegisterIdentification = registerIdentification,
            CantonAbbreviation = cantonAbbreviation,
            RegisterName = registerName
        };
    }
}
