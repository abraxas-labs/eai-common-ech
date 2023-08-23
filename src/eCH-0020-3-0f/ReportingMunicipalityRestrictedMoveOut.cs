// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0007_5_0f;
using eCH_0011_8_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Meldegemeinde.
/// </summary>
[Serializable]
[JsonObject("reportingMunicipalityRestrictedMoveOut")]
[XmlRoot(ElementName = "reportingMunicipalityRestrictedMoveOut", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class ReportingMunicipalityRestrictedMoveOut
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Destination _goesTo;

    public ReportingMunicipalityRestrictedMoveOut()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingMunicipality">Field id required.</param>
    /// <param name="departureDate">Field id optional.</param>
    /// <param name="goesTo">Field id optional.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static ReportingMunicipalityRestrictedMoveOut Create(SwissMunicipality reportingMunicipality, DateTime departureDate, Destination goesTo)
    {
        return new ReportingMunicipalityRestrictedMoveOut()
        {
            ReportingMunicipality = reportingMunicipality,
            FederalRegister = null,
            DepartureDate = departureDate,
            GoesTo = goesTo
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="federalRegister">Field id required.</param>
    /// <param name="departureDate">Field id required.</param>
    /// <param name="goesTo">Field id required.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static ReportingMunicipalityRestrictedMoveOut Create(FederalRegisterType? federalRegister, DateTime departureDate, Destination goesTo)
    {
        return new ReportingMunicipalityRestrictedMoveOut()
        {
            ReportingMunicipality = null,
            FederalRegister = federalRegister,
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

    [JsonProperty("departureDate")]
    [XmlElement(DataType = "date", ElementName = "departureDate")]
    public DateTime? DepartureDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DepartureDateSpecified => DepartureDate.HasValue;

    [JsonProperty("goesTo")]
    [XmlElement(ElementName = "goesTo")]
    public Destination GoesTo
    {
        get { return _goesTo; }
        set { _goesTo = value; }
    }
}
