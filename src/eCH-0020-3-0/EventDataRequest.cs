// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using eCH_0007_5_0;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventDataRequest.
/// </summary>
[Serializable]
[JsonObject("eventDataRequest")]
[XmlRoot(ElementName = "eventDataRequest", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventDataRequest
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public EventDataRequest()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="dataRequestPersons">Field is optional.</param>
    /// <param name="municipality">Field is optional.</param>
    /// <param name="dataValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventDataRequest Create(List<PersonIdentification> dataRequestPersons = null, SwissMunicipality municipality = null, DateTime? dataValidFrom = null, object extension = null)
    {
        return new EventDataRequest()
        {
            DataRequestPersons = dataRequestPersons,
            Extension = extension
        };
    }

    [JsonProperty("dataRequestPerson")]
    [XmlElement(ElementName = "dataRequestPerson")]
    public List<PersonIdentification> DataRequestPersons { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataRequestPersonsSpecified => DataRequestPersons != null && DataRequestPersons.Any();

    [JsonProperty("municipality")]
    [XmlElement(ElementName = "municipality")]
    public SwissMunicipality Municipality { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MunicipalitySpecified => Municipality != null;

    [JsonProperty("dataValidFrom")]
    [XmlElement(DataType = "date", ElementName = "dataValidFrom")]
    public DateTime? DataValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataValidFromSpecified => DataValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
