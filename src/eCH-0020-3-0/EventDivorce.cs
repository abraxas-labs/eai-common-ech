// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventKeyExchange.
/// </summary>
[Serializable]
[JsonObject("eventDivorce")]
[XmlRoot(ElementName = "eventDivorce", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventDivorce
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string DivorcePersonNullValidateExceptionMessage = "DivorcePerson is not valid! DivorcePerson is required";
    private const string MaritalDataNullValidateExceptionMessage = "MaritalData is not valid! MaritalData is required";

    private PersonIdentification _divorcePerson;
    private MaritalDataRestrictedDivorce _maritalData;

    public EventDivorce()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="divorcePerson">Field is required.</param>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventDivorce Create(PersonIdentification divorcePerson, MaritalDataRestrictedDivorce maritalData, object extension = null)
    {
        return new EventDivorce()
        {
            DivorcePerson = divorcePerson,
            MaritalData = maritalData,
            Extension = extension
        };
    }

    [JsonProperty("divorcePerson")]
    [XmlElement(ElementName = "divorcePerson")]
    public PersonIdentification DivorcePerson
    {
        get { return _divorcePerson; }

        set
        {
            _divorcePerson = value ?? throw new XmlSchemaValidationException(DivorcePersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalDataRestrictedDivorce MaritalData
    {
        get { return _maritalData; }

        set
        {
            _maritalData = value ?? throw new XmlSchemaValidationException(MaritalDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
