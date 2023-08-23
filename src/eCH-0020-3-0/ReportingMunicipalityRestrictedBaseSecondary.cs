// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Meldegemeinde.
/// </summary>
[Serializable]
[JsonObject("hasOtherResidence")]
[XmlRoot(ElementName = "hasOtherResidence", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class ReportingMunicipalityRestrictedBaseSecondary
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private DwellingAddress _dwellingAddress;
    private Destination _comesFrom;

    private const string ReportingMunicipalityNullValidateExceptionMessage = "ReportingMunicipality is not valid! ReportingMunicipality is required";
    private const string FederalRegisterNullValidateExceptionMessage = "FederalRegister is not valid! FederalRegister is required";
    private const string DwellingAddressNullValidateExceptionMessage = "DwellingAddress is not valid! DwellingAddress is required";
    private const string ComesFromNullValidateExceptionMessage = "ComesFrom is not valid! ComesFrom is required";

    public ReportingMunicipalityRestrictedBaseSecondary()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingMunicipality">Field id required.</param>
    /// <param name="arrivalDate">Field id required.</param>
    /// <param name="comesFrom">Field id required.</param>
    /// <param name="dwellingAddress">Field id required.</param>
    /// <param name="departureDate">Field id optional.</param>
    /// <param name="goesTo">Field id optional.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static ReportingMunicipalityRestrictedBaseSecondary Create(SwissMunicipality reportingMunicipality, DateTime arrivalDate, DwellingAddress dwellingAddress, Destination comesFrom, DateTime? departureDate = null, Destination goesTo = null)
    {
        if (reportingMunicipality == null)
        {
            throw new XmlSchemaValidationException(ReportingMunicipalityNullValidateExceptionMessage);
        }
        return new ReportingMunicipalityRestrictedBaseSecondary()
        {
            ReportingMunicipality = reportingMunicipality,
            FederalRegister = null,
            ArrivalDate = arrivalDate,
            ComesFrom = comesFrom,
            DwellingAddress = dwellingAddress,
            DepartureDate = departureDate,
            GoesTo = goesTo
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="federalRegister">Field id required.</param>
    /// <param name="arrivalDate">Field id required.</param>
    /// <param name="comesFrom">Field id required.</param>
    /// <param name="dwellingAddress">Field id required.</param>
    /// <param name="departureDate">Field id optional.</param>
    /// <param name="goesTo">Field id optional.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static ReportingMunicipalityRestrictedBaseSecondary Create(FederalRegisterType? federalRegister, DateTime arrivalDate, DwellingAddress dwellingAddress, Destination comesFrom, DateTime? departureDate = null, Destination goesTo = null)
    {
        if (federalRegister == null)
        {
            throw new XmlSchemaValidationException(FederalRegisterNullValidateExceptionMessage);
        }
        return new ReportingMunicipalityRestrictedBaseSecondary()
        {
            ReportingMunicipality = null,
            FederalRegister = federalRegister,
            ArrivalDate = arrivalDate,
            ComesFrom = comesFrom,
            DwellingAddress = dwellingAddress,
            DepartureDate = departureDate,
            GoesTo = goesTo
        };
    }

    [JsonProperty("reportingMunicipality")]
    [XmlElement(ElementName = "reportingMunicipality")]
    public SwissMunicipality ReportingMunicipality { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ReportingMunicipalitySpecified => ReportingMunicipality != null;

    [JsonProperty("federalRegister")]
    [XmlElement(ElementName = "federalRegister")]
    public FederalRegisterType? FederalRegister { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool FederalRegisterSpecified => FederalRegister.HasValue;

    [JsonProperty("arrivalDate")]
    [XmlElement(DataType = "date", ElementName = "arrivalDate")]
    public DateTime ArrivalDate { get; set; }

    [JsonProperty("comesFrom")]
    [XmlElement(ElementName = "comesFrom")]
    public Destination ComesFrom
    {
        get { return _comesFrom; }

        set
        {
            _comesFrom = value ?? throw new XmlSchemaValidationException(ComesFromNullValidateExceptionMessage);
        }
    }

    [JsonProperty("dwellingAddress")]
    [XmlElement(ElementName = "dwellingAddress")]
    public DwellingAddress DwellingAddress
    {
        get { return _dwellingAddress; }

        set
        {
            _dwellingAddress = value ?? throw new XmlSchemaValidationException(DwellingAddressNullValidateExceptionMessage);
        }
    }

    [JsonProperty("departureDate")]
    [XmlElement(DataType = "date", ElementName = "departureDate")]
    public DateTime? DepartureDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DepartureDateSpecified => DepartureDate.HasValue;

    [JsonProperty("goesTo")]
    [XmlElement(ElementName = "goesTo")]
    public Destination GoesTo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GoesToSpecified => GoesTo != null;
}
