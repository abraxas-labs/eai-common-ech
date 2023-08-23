// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0007_5_0;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eCH_0201_1_0;

[Serializable]
[JsonObject("reportingMunicipalityRestrictedBaseSecondaryType")]
[XmlRoot(ElementName = "reportingMunicipalityRestrictedBaseSecondaryType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0201/1")]
public class ReportingMunicipalityRestrictedBaseSecondaryType : ReportingMunicipalityBase
{
    public ReportingMunicipalityRestrictedBaseSecondaryType()
    {
        Xmlns.Add("eCH-0201", "http://www.ech.ch/xmlns/eCH-0201/1");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="reportingMunicipality">Field is reqired.</param>
    /// <param name="dwellingAddress">Field is reqired.</param>
    /// <param name="arrivalDate">Field can be null.</param>
    /// <param name="departureDate">Field can be null.</param>
    /// <returns></returns>
    public static ReportingMunicipalityRestrictedBaseSecondaryType Create(SwissMunicipality reportingMunicipality, DwellingAddress dwellingAddress, DateTime arrivalDate, DateTime? departureDate = null)
    {
        return new ReportingMunicipalityRestrictedBaseSecondaryType
        {
            ReportingMunicipality = reportingMunicipality,
            ArrivalDate = arrivalDate,
            DwellingAddress = dwellingAddress,
            DepartureDate = departureDate,
        };
    }
}
