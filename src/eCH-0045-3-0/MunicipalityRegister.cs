// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("municipalityRegisterType")]
[XmlRoot(ElementName = "municipalityRegisterType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class MunicipalityRegister : Register
{
    private const string MunicipalityNameValidateExceptionMessage =
        "MunicipalityName is not valid! MunicipalityName has max Length 40";

    private const string MunicipalityNameNullValidateExceptionMessage =
        "MunicipalityName is not valid! MunicipalityName is required";

    private string _municipalityName;

    [JsonProperty("municipalityName")]
    [XmlElement(ElementName = "municipalityName")]
    public string MunicipalityName
    {
        get => _municipalityName;
        set => _municipalityName = MunicipalityNameIsValid(value);
    }

    private string MunicipalityNameIsValid(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new XmlSchemaValidationException(MunicipalityNameNullValidateExceptionMessage);
        }

        if (value.Length > 40)
        {
            throw new XmlSchemaValidationException(MunicipalityNameValidateExceptionMessage);
        }

        return value;
    }

    [JsonProperty("cantonAbbreviation")]
    [XmlElement(ElementName = "cantonAbbreviation")]
    public CantonAbbreviation? CantonAbbreviation { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public bool CantonAbbreviationSpecified => CantonAbbreviation != null;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="registerIdentification">Field is required.</param>
    /// <param name="registerName">Field is required.</param>
    /// <param name="municipalityName">Field is required.</param>
    /// <param name="cantonAbbreviation">Field is optional.</param>
    /// <returns>MunicipalityRegister.</returns>
    public static MunicipalityRegister Create(string registerIdentification, string registerName, string municipalityName = null, CantonAbbreviation? cantonAbbreviation = null)
    {
        return new MunicipalityRegister
        {
            RegisterIdentification = registerIdentification,
            RegisterName = registerName,
            CantonAbbreviation = cantonAbbreviation,
            MunicipalityName = municipalityName
        };
    }
}
