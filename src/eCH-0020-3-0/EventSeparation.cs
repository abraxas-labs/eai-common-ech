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
[JsonObject("eventSeparation")]
[XmlRoot(ElementName = "eventSeparation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventSeparation
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string SeparationPersonNullValidateExceptionMessage = "SeparationPerson is not valid! SeparationPerson is required";
    private const string SeparationDataNullValidateExceptionMessage = "SeparationData is not valid! SeparationData is required";

    private PersonIdentification _separationPerson;
    private SeparationData _separationData;

    public EventSeparation()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="separationPerson">Field is required.</param>
    /// <param name="separationData">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventSeparation Create(PersonIdentification separationPerson, SeparationData separationData, object extension = null)
    {
        return new EventSeparation()
        {
            SeparationPerson = separationPerson,
            SeparationData = separationData,
            Extension = extension
        };
    }

    [JsonProperty("separationPerson")]
    [XmlElement(ElementName = "separationPerson")]
    public PersonIdentification SeparationPerson
    {
        get { return _separationPerson; }

        set
        {
            _separationPerson = value ?? throw new XmlSchemaValidationException(SeparationPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("separationData")]
    [XmlElement(ElementName = "separationData")]
    public SeparationData SeparationData
    {
        get { return _separationData; }

        set
        {
            _separationData = value ?? throw new XmlSchemaValidationException(SeparationDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
