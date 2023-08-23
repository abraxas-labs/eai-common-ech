// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("HasMainResidenceMoveIn")]
[XmlRoot(ElementName = "HasMainResidenceMoveIn", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class HasMainResidenceMoveIn : ReportingMunicipalityRestrictedMoveIn
{
    private const string ReportingMunicipalityNullValidateExceptionMessage = "ReportingMunicipality is not valid! ReportingMunicipality is required";
    private const string FederalRegisterNullValidateExceptionMessage = "FederalRegister is not valid! FederalRegister is required";

    public HasMainResidenceMoveIn()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingMunicipality">Field id required.</param>
    /// <param name="arrivalDate">Field id required.</param>
    /// <param name="comesFrom">Field id optional.</param>
    /// <param name="dwellingAddress">Field id required.</param>
    /// <param name="secondaryResidences">Field id optional.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static HasMainResidenceMoveIn Create(SwissMunicipality reportingMunicipality, DateTime arrivalDate, DwellingAddress dwellingAddress, Destination comesFrom, List<SwissMunicipality> secondaryResidences = null)
    {
        if (reportingMunicipality == null)
        {
            throw new XmlSchemaValidationException(ReportingMunicipalityNullValidateExceptionMessage);
        }
        return new HasMainResidenceMoveIn()
        {
            ReportingMunicipality = reportingMunicipality,
            FederalRegister = null,
            ArrivalDate = arrivalDate,
            ComesFrom = comesFrom,
            DwellingAddress = dwellingAddress,
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
    /// <param name="secondaryResidences">Field id optional.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static HasMainResidenceMoveIn Create(FederalRegisterType? federalRegister, DateTime arrivalDate, DwellingAddress dwellingAddress, Destination comesFrom, List<SwissMunicipality> secondaryResidences)
    {
        if (federalRegister == null)
        {
            throw new XmlSchemaValidationException(FederalRegisterNullValidateExceptionMessage);
        }
        return new HasMainResidenceMoveIn()
        {
            ReportingMunicipality = null,
            FederalRegister = federalRegister,
            ArrivalDate = arrivalDate,
            ComesFrom = comesFrom,
            DwellingAddress = dwellingAddress,
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
