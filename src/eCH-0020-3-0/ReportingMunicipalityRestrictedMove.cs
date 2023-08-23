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
[JsonObject("reportingMunicipalityRestrictedMove")]
[XmlRoot(ElementName = "reportingMunicipalityRestrictedMove", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class ReportingMunicipalityRestrictedMove
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private DwellingAddress _dwellingAddress;

    private const string ReportingMunicipalityNullValidateExceptionMessage = "ReportingMunicipality is not valid! ReportingMunicipality is required";
    private const string FederalRegisterNullValidateExceptionMessage = "FederalRegister is not valid! FederalRegister is required";
    private const string DwellingAddressNullValidateExceptionMessage = "DwellingAddress is not valid! DwellingAddress is required";

    public ReportingMunicipalityRestrictedMove()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingMunicipality">Field id required.</param>
    /// <param name="dwellingAddress">Field id required.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static ReportingMunicipalityRestrictedMove Create(SwissMunicipality reportingMunicipality, DwellingAddress dwellingAddress)
    {
        if (reportingMunicipality == null)
        {
            throw new XmlSchemaValidationException(ReportingMunicipalityNullValidateExceptionMessage);
        }
        return new ReportingMunicipalityRestrictedMove()
        {
            ReportingMunicipality = reportingMunicipality,
            FederalRegister = null,
            DwellingAddress = dwellingAddress
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="federalRegister">Field id required.</param>
    /// <param name="dwellingAddress">Field id required.</param>
    /// <returns>ReportingMunicipalityType.</returns>
    public static ReportingMunicipalityRestrictedMove Create(FederalRegisterType? federalRegister, DwellingAddress dwellingAddress)
    {
        if (federalRegister == null)
        {
            throw new XmlSchemaValidationException(FederalRegisterNullValidateExceptionMessage);
        }
        return new ReportingMunicipalityRestrictedMove()
        {
            ReportingMunicipality = null,
            FederalRegister = federalRegister,
            DwellingAddress = dwellingAddress
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
}
