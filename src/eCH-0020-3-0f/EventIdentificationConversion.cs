// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventIdentificationConversion.
/// </summary>
[Serializable]
[JsonObject("eventIdentificationConversion")]
[XmlRoot(ElementName = "eventIdentificationConversion", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventIdentificationConversion
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private List<IdentificationConversionPerson> _identificationConversionPersons;

    public EventIdentificationConversion()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="identificationConversionPersons">Field is required.</param>
    /// <param name="identificationValidFrom">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventIdentificationConversion Create(List<IdentificationConversionPerson> identificationConversionPersons, DateTime? identificationValidFrom, object extension = null)
    {
        return new EventIdentificationConversion()
        {
            IdentificationConversionPersons = identificationConversionPersons,
            IdentificationValidFrom = identificationValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("identificationConversionPerson")]
    [XmlElement(ElementName = "identificationConversionPerson")]
    public List<IdentificationConversionPerson> IdentificationConversionPersons
    {
        get { return _identificationConversionPersons; }
        set { _identificationConversionPersons = value; }
    }

    [JsonProperty("identificationValidFrom")]
    [XmlElement(ElementName = "identificationValidFrom")]
    public DateTime? IdentificationValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool IdentificationValidFromSpecified => IdentificationValidFrom.HasValue;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
