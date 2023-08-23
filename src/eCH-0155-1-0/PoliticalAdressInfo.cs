// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0010_5_0;
using Newtonsoft.Json;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Politische Wohnadresse des Kandidaten, bestehend aus Strasse, Hausnummer, PLZ,
///     Ort und BFS_Nummer der politischen Gemeinde zum politischen Wohnsitz.
/// </summary>
[Serializable]
[JsonObject("politicalAdressInfo")]
[XmlRoot(ElementName = "politicalAdressInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class PoliticalAdressInfo
{
    private const string MunicipalityIdNullValidateExceptionMessage =
        "MunicipalityId is not valid! MunicipalityId is required";

    private const string InvalidNumberExceptionMessage =
        "MunicipalityId is not valid! MunicipalityId has to be a number between 1 and 9999";

    private const string SwissAddressInformationNullValidateExceptionMessage =
        "SwissAddressInformation is not valid! SwissAddressInformation is required";

    private short _municipalityId;

    private SwissAddressInformation _swissAddressInformation;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public PoliticalAdressInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("swissAddressInformation")]
    [XmlElement(ElementName = "swissAddressInformation")]
    public SwissAddressInformation SwissAddressInformation
    {
        get => _swissAddressInformation;
        set => _swissAddressInformation =
            value ?? throw new FormatException(SwissAddressInformationNullValidateExceptionMessage);
    }

    [JsonProperty("municipalityId")]
    [XmlElement(ElementName = "municipalityId")]
    public string MunicipalityId // Can be null???
    {
        get => _municipalityId.ToString().PadLeft(4, '0');
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new FormatException(MunicipalityIdNullValidateExceptionMessage);
            }

            if (!short.TryParse(value, out var number))
            {
                throw new FormatException(InvalidNumberExceptionMessage);
            }

            if (number < 1 || number > 9999)
            {
                throw new XmlSchemaValidationException(InvalidNumberExceptionMessage);
            }

            _municipalityId = number;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="swissAddressInformation">Has dependency to eCH-0010.SwissAddressInformation.</param>
    /// <param name="municipalityId">Field is reqired.</param>
    /// <returns>PoliticalAdressInfo.</returns>
    public static PoliticalAdressInfo Create(SwissAddressInformation swissAddressInformation, short municipalityId)
    {
        return new PoliticalAdressInfo
        {
            SwissAddressInformation = swissAddressInformation,
            MunicipalityId = municipalityId.ToString()
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="swissAddressInformation">Has dependency to eCH-0010.SwissAddressInformation.</param>
    /// <param name="municipalityId">Field is reqired.</param>
    /// <returns>PoliticalAdressInfo.</returns>
    public static PoliticalAdressInfo Create(SwissAddressInformation swissAddressInformation, string municipalityId)
    {
        return new PoliticalAdressInfo
        {
            SwissAddressInformation = swissAddressInformation,
            MunicipalityId = municipalityId
        };
    }
}
