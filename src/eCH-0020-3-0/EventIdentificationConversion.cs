// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventIdentificationConversion.
/// </summary>
[Serializable]
[JsonObject("eventIdentificationConversion")]
[XmlRoot(ElementName = "eventIdentificationConversion", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventIdentificationConversion
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string IdentificationConversionPersonNullValidateExceptionMessage = "IdentificationConversionPerson is not valid! IdentificationConversionPerson is required";

    private IdentificationConversionPerson[] _identificationConversionPersons;

    public EventIdentificationConversion()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
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
            IdentificationConversionPersons = (identificationConversionPersons != null) ? identificationConversionPersons.ToArray() : null,
            IdentificationValidFrom = identificationValidFrom,
            Extension = extension
        };
    }

    [JsonProperty("identificationConversionPerson")]
    [XmlElement(ElementName = "identificationConversionPerson")]
    public IdentificationConversionPerson[] IdentificationConversionPersons
    {
        get { return _identificationConversionPersons; }

        set
        {
            _identificationConversionPersons = (value != null && value.Any()) ? value : throw new XmlSchemaValidationException(IdentificationConversionPersonNullValidateExceptionMessage);
        }
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
