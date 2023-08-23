// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0007_5_0f;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// /// eCH eGovernment - Standards
/// Schnittstellenstandard Meldungsrahmen (eCH-0058)
/// Eine Person, welche in der Schweiz Wohnsitz hat oder nimmt, muss sich bei der zuständigen
/// Gemeinde melden. Dadurch geht sie mit der Gemeinde ein Meldeverhältnis ein.
/// </summary>
[Serializable]
[JsonObject("residenceData")]
[XmlRoot(ElementName = "residenceData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class SecondaryResidenceData : ResidenceData
{
    private Destination _comesFrom;

    public SecondaryResidenceData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingMunicipality">Field is required.</param>
    /// <param name="arrivalDate">Field is required.</param>
    /// <param name="dwellingAddress">Field is required.</param>
    /// <param name="comesFrom">Field is required.</param>
    /// <param name="departureDate">Field is optional.</param>
    /// <param name="goesTo"></param>
    /// <returns>ResidenceData.</returns>
    public static new ResidenceData Create(SwissMunicipality reportingMunicipality, DateTime arrivalDate, DwellingAddress dwellingAddress, Destination comesFrom, DateTime? departureDate = null, Destination goesTo = null)
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

    [JsonProperty("comesFrom")]
    [XmlElement(ElementName = "comesFrom")]
    public Destination ComesFrom
    {
        get { return _comesFrom; }
        set { _comesFrom = value; }
    }
}
