// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using eCH_0011_8_1;
using Newtonsoft.Json;

namespace eCH_0201_1_0;

[Serializable]
[JsonObject("reportingMunicipalityType")]
[XmlRoot(ElementName = "reportingMunicipality", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0201/1")]
public abstract class ReportingMunicipalityBase
{
    private const string ReportingMunicipalityValidationExceptionMessage = "ReportingMunicipality is not valid! ReportingMunicipality can not be null";
    private const string DwellingAddressOutOfRangeValidationExceptionMessage = "DwellingAddress is not valid! DwellingAddress can not be null";

    private SwissMunicipality _reportingMunicipality;
    private DwellingAddress _dwellingAddress;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    [JsonProperty("reportingMunicipality")]
    [XmlElement(ElementName = "reportingMunicipality")]
    public SwissMunicipality ReportingMunicipality
    {
        get => _reportingMunicipality;
        set
        {
            _reportingMunicipality = value ?? throw new XmlSchemaValidationException(ReportingMunicipalityValidationExceptionMessage);
        }
    }

    [JsonProperty("arrivalDate")]
    [XmlElement(DataType = "date", ElementName = "arrivalDate")]
    public DateTime? ArrivalDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ArrivalDateSpecified => ArrivalDate.HasValue;

    [JsonProperty("dwellingAddress")]
    [XmlElement(ElementName = "dwellingAddress")]
    public DwellingAddress DwellingAddress
    {
        get => _dwellingAddress;
        set
        {
            _dwellingAddress = value ?? throw new XmlSchemaValidationException(DwellingAddressOutOfRangeValidationExceptionMessage);
        }
    }

    [JsonProperty("departureDate")]
    [XmlElement(DataType = "date", ElementName = "departureDate")]
    public DateTime? DepartureDate { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DepartureDateSpecified => DepartureDate.HasValue;
}
