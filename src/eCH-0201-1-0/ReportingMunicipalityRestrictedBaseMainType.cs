// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using eCH_0007_5_0;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eCH_0201_1_0;

[Serializable]
[JsonObject("reportingMunicipalityRestrictedBaseMainType")]
[XmlRoot(ElementName = "reportingMunicipalityRestrictedBaseMainType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0201/1")]
public class ReportingMunicipalityRestrictedBaseMainType : ReportingMunicipalityBase
{
    private List<SwissMunicipality> _secondaryResidence = new();

    public ReportingMunicipalityRestrictedBaseMainType()
    {
        Xmlns.Add("eCH-0201", "http://www.ech.ch/xmlns/eCH-0201/1");
    }

    [JsonProperty("secondaryResidence")]
    [XmlElement(ElementName = "secondaryResidence")]
    public List<SwissMunicipality> SecondaryResidence
    {
        get => _secondaryResidence;
        set
        {
            _secondaryResidence = value ?? new List<SwissMunicipality>();
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool SecondaryResidenceSpecified => SecondaryResidence != null && SecondaryResidence.Count > 0;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="reportingMunicipality">Field is reqired.</param>
    /// <param name="dwellingAddress">Field is reqired.</param>
    /// <param name="secondaryResidence">Field is optional.</param>
    /// <param name="arrivalDate">Field can be null.</param>
    /// <param name="departureDate">Field can be null.</param>
    /// <returns></returns>
    public static ReportingMunicipalityRestrictedBaseMainType Create(SwissMunicipality reportingMunicipality, DwellingAddress dwellingAddress, List<SwissMunicipality> secondaryResidence = null, DateTime? arrivalDate = null, DateTime? departureDate = null)
    {
        return new ReportingMunicipalityRestrictedBaseMainType
        {
            ReportingMunicipality = reportingMunicipality,
            ArrivalDate = arrivalDate,
            DwellingAddress = dwellingAddress,
            DepartureDate = departureDate,
            SecondaryResidence = secondaryResidence,
        };
    }
}
