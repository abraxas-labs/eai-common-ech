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
[JsonObject("reportingMunicipalityRestrictedMoveIn")]
[XmlRoot(ElementName = "reportingMunicipalityRestrictedMoveIn", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class ReportingMunicipalityRestrictedMoveIn
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private DwellingAddress _dwellingAddress;

    public ReportingMunicipalityRestrictedMoveIn()
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
    /// <returns>ReportingMunicipalityType.</returns>
    public static ReportingMunicipalityRestrictedMoveIn Create(eCH_0007_5_0.SwissMunicipality reportingMunicipality, DateTime arrivalDate, eCH_0011_8_1.DwellingAddress dwellingAddress, eCH_0011_8_1.Destination comesFrom)
    {
        return new ReportingMunicipalityRestrictedMoveIn()
        {
            ReportingMunicipality = eCH_0007_5_0f.Mapper.ECHtoECHf.GetSwissMunicipality(reportingMunicipality),
            FederalRegister = null,
            ArrivalDate = arrivalDate,
            ComesFrom = eCH_0011_8_1f.Mapper.ECHtoECHf.GetDestination(comesFrom),
            DwellingAddress = eCH_0011_8_1f.Mapper.ECHtoECHf.GetDwellingAddress(dwellingAddress)
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
    /// <returns>ReportingMunicipalityType.</returns>
    public static ReportingMunicipalityRestrictedMoveIn Create(eCH_0020_3_0.FederalRegisterType? federalRegister, DateTime arrivalDate, eCH_0011_8_1.DwellingAddress dwellingAddress, eCH_0011_8_1.Destination comesFrom)
    {
        return new ReportingMunicipalityRestrictedMoveIn()
        {
            ReportingMunicipality = null,
            FederalRegister = (federalRegister != null) ? (FederalRegisterType?)Enum.Parse(typeof(FederalRegisterType), federalRegister.ToString()) : null,
            ArrivalDate = arrivalDate,
            ComesFrom = eCH_0011_8_1f.Mapper.ECHtoECHf.GetDestination(comesFrom),
            DwellingAddress = eCH_0011_8_1f.Mapper.ECHtoECHf.GetDwellingAddress(dwellingAddress)
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
    public DateTime? ArrivalDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ArrivalDateSpecified => ArrivalDate.HasValue;

    [JsonProperty("comesFrom")]
    [XmlElement(ElementName = "comesFrom")]
    public Destination ComesFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ComesFromSpecified => ComesFrom != null;

    [JsonProperty("dwellingAddress")]
    [XmlElement(ElementName = "dwellingAddress")]
    public DwellingAddress DwellingAddress
    {
        get { return _dwellingAddress; }
        set { _dwellingAddress = value; }
    }
}
