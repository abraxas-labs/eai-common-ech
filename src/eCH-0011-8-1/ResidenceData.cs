// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// /// eCH eGovernment - Standards
/// Schnittstellenstandard Meldungsrahmen (eCH-0058)
/// Eine Person, welche in der Schweiz Wohnsitz hat oder nimmt, muss sich bei der zuständigen
/// Gemeinde melden. Dadurch geht sie mit der Gemeinde ein Meldeverhältnis ein.
/// </summary>
[Serializable]
[JsonObject("residenceData")]
[XmlRoot(ElementName = "residenceData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class ResidenceData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ReportingMunicipalityNullValidateExceptionMessage = "ReportingMunicipality is not valid! ReportingMunicipality is required";
    private const string DwellingAddressNullValidateExceptionMessage = "DwellingAddress is not valid! DwellingAddress is required";

    private SwissMunicipality _reportingMunicipality;
    private DwellingAddress _dwellingAddress;

    public ResidenceData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingMunicipality">Field is required.</param>
    /// <param name="arrivalDate">Field is optional.</param>
    /// <param name="dwellingAddress">Field is optional.</param>
    /// <param name="comesFrom">Field is optional.</param>
    /// <param name="departureDate">Field is optional.</param>
    /// <param name="goesTo"></param>
    /// <returns>ResidenceData.</returns>
    public static ResidenceData Create(SwissMunicipality reportingMunicipality, DateTime arrivalDate, DwellingAddress dwellingAddress, Destination comesFrom = null, DateTime? departureDate = null, Destination goesTo = null)
    {
        return new ResidenceData()
        {
            ReportingMunicipality = reportingMunicipality,
            ArrivalDate = arrivalDate,
            DwellingAddress = dwellingAddress,
            ComesFrom = comesFrom,
            DepartureDate = departureDate,
            GoesTo = goesTo
        };
    }

    [JsonProperty("reportingMunicipality")]
    [XmlElement(ElementName = "reportingMunicipality", Order = 1)]
    public SwissMunicipality ReportingMunicipality
    {
        get { return _reportingMunicipality; }

        set
        {
            _reportingMunicipality = value ?? throw new XmlSchemaValidationException(ReportingMunicipalityNullValidateExceptionMessage);
        }
    }

    [JsonProperty("arrivalDate")]
    [XmlElement(DataType = "date", ElementName = "arrivalDate", Order = 2)]
    public DateTime ArrivalDate { get; set; }

    [JsonProperty("comesFrom")]
    [XmlElement(ElementName = "comesFrom", Order = 3)]
    public Destination ComesFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ComesFromSpecified => ComesFrom != null;

    [JsonProperty("dwellingAddress")]
    [XmlElement(ElementName = "dwellingAddress", Order = 4)]
    public DwellingAddress DwellingAddress
    {
        get { return _dwellingAddress; }

        set
        {
            _dwellingAddress = value ?? throw new XmlSchemaValidationException(DwellingAddressNullValidateExceptionMessage);
        }
    }

    [JsonProperty("departureDate")]
    [XmlElement(DataType = "date", ElementName = "departureDate", Order = 5)]
    public DateTime? DepartureDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DepartureDateSpecified => DepartureDate.HasValue;

    [JsonProperty("goesTo")]
    [XmlElement(ElementName = "goesTo", Order = 6)]
    public Destination GoesTo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool GoesToSpecified => GoesTo != null;
}
