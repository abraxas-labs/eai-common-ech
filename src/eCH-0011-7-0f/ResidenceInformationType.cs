// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_5_0f;
using Newtonsoft.Json;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Konfessionsangaben.
/// </summary>
[Serializable]
[JsonObject("residence")]
[XmlRoot(ElementName = "residence", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public class ResidenceInformationType : FieldValueChecker<ResidenceInformationType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private SwissMunicipality _reportingMunicipality;
    private DateTime _arrivalDate;
    private DestinationType _comesFrom;
    private DwellingAddressType _dwellingAddress;
    private DateTime _departureDate;
    private DestinationType _goesTo;

    public ResidenceInformationType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingMunicipality">Field is required.</param>
    /// <param name="arrivalDate">Field is required.</param>
    /// <param name="comesFrom">Field is optional.</param>
    /// <param name="dwellingAddress">Field is required.</param>
    /// <param name="departureDate">Field is optional.</param>
    /// <param name="goesTo">Field is optional.</param>
    /// <returns>ForeignerName.</returns>
    public static ResidenceInformationType Create(SwissMunicipality reportingMunicipality, DateTime arrivalDate, DestinationType comesFrom, DwellingAddressType dwellingAddress, DateTime departureDate, DestinationType goesTo)
    {
        return new ResidenceInformationType
        {
            ReportingMunicipality = reportingMunicipality,
            ArrivalDate = arrivalDate,
            ComesFrom = comesFrom,
            DwellingAddress = dwellingAddress,
            DepartureDate = departureDate,
            GoesTo = goesTo
        };
    }

    [FieldRequired]
    [JsonProperty("reportingMunicipality")]
    [XmlElement(ElementName = "reportingMunicipality")]
    public SwissMunicipality ReportingMunicipality
    {
        get => _reportingMunicipality;
        set => CheckAndSetValue(ref _reportingMunicipality, value);
    }

    [FieldRequired]
    [JsonProperty("arrivalDate")]
    [XmlElement(ElementName = "arrivalDate")]
    public DateTime ArrivalDate
    {
        get => _arrivalDate;
        set => CheckAndSetValue(ref _arrivalDate, value);
    }

    [JsonProperty("comesFrom")]
    [XmlElement(ElementName = "comesFrom")]
    public DestinationType ComesFrom
    {
        get => _comesFrom;
        set => CheckAndSetValue(ref _comesFrom, value);
    }

    [FieldRequired]
    [JsonProperty("dwellingAddress")]
    [XmlElement(ElementName = "dwellingAddress")]
    public DwellingAddressType DwellingAddress
    {
        get => _dwellingAddress;
        set => CheckAndSetValue(ref _dwellingAddress, value);
    }

    [JsonProperty("departureDate")]
    [XmlElement(ElementName = "departureDate")]
    public DateTime DepartureDate
    {
        get => _departureDate;
        set => CheckAndSetValue(ref _departureDate, value);
    }

    [JsonProperty("goesTo")]
    [XmlElement(ElementName = "goesTo")]
    public DestinationType GoesTo
    {
        get => _goesTo;
        set => CheckAndSetValue(ref _goesTo, value);
    }
}
