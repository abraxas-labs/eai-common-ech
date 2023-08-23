// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using eCH_0007_5_0f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("hasSecondaryResidenceBaseDelivery")]
[XmlRoot(ElementName = "hasSecondaryResidenceBaseDelivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class HasSecondaryResidenceMoveIn : ReportingMunicipalityRestrictedMoveIn
{
    public HasSecondaryResidenceMoveIn()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingMunicipality">Field id required.</param>
    /// <param name="arrivalDate">Field id required.</param>
    /// <param name="comesFrom">Field id required.</param>
    /// <param name="dwellingAddress">Field id required.</param>
    /// <param name="mainResidences">Field id optional.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static HasSecondaryResidenceMoveIn Create(eCH_0007_5_0.SwissMunicipality reportingMunicipality, DateTime arrivalDate, eCH_0011_8_1.DwellingAddress dwellingAddress, eCH_0011_8_1.Destination comesFrom, List<eCH_0007_5_0.SwissMunicipality> mainResidences = null)
    {
        var fHasSecondaryResidenceMoveIn = new HasSecondaryResidenceMoveIn()
        {
            ReportingMunicipality = eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(reportingMunicipality),
            FederalRegister = null,
            ArrivalDate = arrivalDate,
            ComesFrom = eCH_0011_8_1f.Mapper.ECHtoECHf.GetDestination(comesFrom),
            DwellingAddress = eCH_0011_8_1f.Mapper.ECHtoECHf.GetDwellingAddress(dwellingAddress),
            MainResidences = null
        };

        if (mainResidences != null)
        {
            fHasSecondaryResidenceMoveIn.MainResidences = new List<SwissMunicipality>();

            foreach (var data in mainResidences)
            {
                fHasSecondaryResidenceMoveIn.MainResidences.Add(eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(data));
            }
        }

        return fHasSecondaryResidenceMoveIn;
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="federalRegister">Field id required.</param>
    /// <param name="arrivalDate">Field id required.</param>
    /// <param name="comesFrom">Field id required.</param>
    /// <param name="dwellingAddress">Field id required.</param>
    /// <param name="mainResidences">Field id optional.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static HasSecondaryResidenceMoveIn Create(eCH_0020_3_0.FederalRegisterType? federalRegister, DateTime arrivalDate, eCH_0011_8_1.DwellingAddress dwellingAddress, eCH_0011_8_1.Destination comesFrom, List<eCH_0007_5_0.SwissMunicipality> mainResidences = null)
    {
        var fHasSecondaryResidenceMoveIn = new HasSecondaryResidenceMoveIn()
        {
            ReportingMunicipality = null,
            FederalRegister = (federalRegister != null) ? (FederalRegisterType?)Enum.Parse(typeof(FederalRegisterType), federalRegister.ToString()) : null,
            ArrivalDate = arrivalDate,
            ComesFrom = eCH_0011_8_1f.Mapper.ECHtoECHf.GetDestination(comesFrom),
            DwellingAddress = eCH_0011_8_1f.Mapper.ECHtoECHf.GetDwellingAddress(dwellingAddress),
            MainResidences = null
        };

        if (mainResidences != null)
        {
            fHasSecondaryResidenceMoveIn.MainResidences = new List<SwissMunicipality>();

            foreach (var data in mainResidences)
            {
                fHasSecondaryResidenceMoveIn.MainResidences.Add(eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(data));
            }
        }

        return fHasSecondaryResidenceMoveIn;
    }

    [JsonProperty("mainResidence")]
    [XmlElement(ElementName = "mainResidence")]
    public List<SwissMunicipality> MainResidences { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MainResidencesSpecified => MainResidences != null && MainResidences.Any();
}
