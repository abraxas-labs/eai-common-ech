// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using eCH_0007_5_0f;
using eCH_0011_8_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("hasMainResidence")]
[XmlRoot(ElementName = "hasMainResidence", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class HasMainResidenceBaseDelivery : ReportingMunicipalityRestrictedBaseMain
{
    public HasMainResidenceBaseDelivery()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingMunicipality">Field id required.</param>
    /// <param name="arrivalDate">Field id required.</param>
    /// <param name="comesFrom">Field id optional.</param>
    /// <param name="dwellingAddress">Field id required.</param>
    /// <param name="departureDate">Field id optional.</param>
    /// <param name="goesTo">Field id optional.</param>
    /// <param name="secondaryResidences">Field id optional.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static HasMainResidenceBaseDelivery Create(SwissMunicipality reportingMunicipality, DateTime arrivalDate, DwellingAddress dwellingAddress, Destination comesFrom = null, DateTime? departureDate = null, Destination goesTo = null, List<SwissMunicipality> secondaryResidences = null)
    {
        return new HasMainResidenceBaseDelivery()
        {
            ReportingMunicipality = reportingMunicipality,
            FederalRegister = null,
            ArrivalDate = arrivalDate,
            ComesFrom = comesFrom,
            DwellingAddress = dwellingAddress,
            DepartureDate = departureDate,
            GoesTo = goesTo,
            SecondaryResidences = secondaryResidences
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="federalRegister">Field id required.</param>
    /// <param name="arrivalDate">Field id required.</param>
    /// <param name="comesFrom">Field id optional.</param>
    /// <param name="dwellingAddress">Field id required.</param>
    /// <param name="departureDate">Field id optional.</param>
    /// <param name="goesTo">Field id optional.</param>
    /// <param name="secondaryResidences">Field id optional.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static HasMainResidenceBaseDelivery Create(FederalRegisterType? federalRegister, DateTime arrivalDate, DwellingAddress dwellingAddress, Destination comesFrom = null, DateTime? departureDate = null, Destination goesTo = null, List<SwissMunicipality> secondaryResidences = null)
    {
        return new HasMainResidenceBaseDelivery()
        {
            ReportingMunicipality = null,
            FederalRegister = federalRegister,
            ArrivalDate = arrivalDate,
            ComesFrom = comesFrom,
            DwellingAddress = dwellingAddress,
            DepartureDate = departureDate,
            GoesTo = goesTo,
            SecondaryResidences = secondaryResidences
        };
    }

    [JsonProperty("secondaryResidence")]
    [XmlElement(ElementName = "secondaryResidence")]
    public List<SwissMunicipality> SecondaryResidences { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SecondaryResidencesSpecified => SecondaryResidences != null && SecondaryResidences.Any();
}
