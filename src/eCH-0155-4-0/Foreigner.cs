// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0006_2_0;
using eCH_0010_6_0;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Helferklasse um den Choiche-Node vom Candidate abzubilden.
/// </summary>
[Serializable]
[JsonObject("foreigner")]
[XmlRoot(ElementName = "foreigner", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class Foreigner
{
    private const string DwellingAddressNullValidateExceptionMessage =
        "DwellingAddress is not valid! DwellingAddress is required";

    private const string NationalityNullValidateExceptionMessage =
        "Nationality is not valid! Nationality is required";

    private SwissAddressInformationType _dwellingAddress;
    private CountryType _nationality;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Foreigner()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("residencePermit")]
    [XmlElement(ElementName = "residencePermit", Order = 1)]
    public ResidencePermit ResidencePermit { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidencePermitSpecified => ResidencePermit != null;

    [JsonProperty("dwellingAddress")]
    [XmlElement(ElementName = "dwellingAddress", Order = 2)]
    public SwissAddressInformationType DwellingAddress
    {
        get => _dwellingAddress;
        set => _dwellingAddress = value ?? throw new FormatException(DwellingAddressNullValidateExceptionMessage);
    }

    [JsonProperty("inCantonSince")]
    [XmlElement(ElementName = "inCantonSince", DataType = "date", Order = 3)]
    public DateTime InCantonSince { get; set; }

    [JsonProperty("nationality")]
    [XmlElement(ElementName = "nationality", Order = 4)]
    public CountryType Nationality
    {
        get => _nationality;
        set => _nationality = value ?? throw new FormatException(NationalityNullValidateExceptionMessage);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="residencePermit">Has dependency to eCH-0006.ResidencePermit. Field is optional.</param>
    /// <param name="dwellingAddress">Has dependency to eCH-0010.SwissAddressInformation. Field is reqired.</param>
    /// <param name="inCantonSince">Field is optional.</param>
    /// <param name="nationality">Has dependency to eCH-0008.Country. Field is required.</param>
    /// <returns>Foreigner.</returns>
    public static Foreigner Create(ResidencePermit residencePermit, SwissAddressInformationType dwellingAddress,
        DateTime inCantonSince, CountryType nationality)
    {
        return new Foreigner
        {
            ResidencePermit = residencePermit,
            DwellingAddress = dwellingAddress,
            InCantonSince = inCantonSince,
            Nationality = nationality
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="dwellingAddress">Has dependency to eCH-0010.SwissAddressInformation. Field is reqired.</param>
    /// <param name="inCantonSince">Field is optional.</param>
    /// <returns>Foreigner.</returns>
    public static Foreigner Create(SwissAddressInformationType dwellingAddress, DateTime inCantonSince)
    {
        return new Foreigner
        {
            DwellingAddress = dwellingAddress,
            InCantonSince = inCantonSince
        };
    }
}
