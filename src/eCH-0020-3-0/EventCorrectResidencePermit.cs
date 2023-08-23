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
/// EventCorrectResidencePermit.
/// </summary>
[Serializable]
[JsonObject("eventCorrectResidencePermit")]
[XmlRoot(ElementName = "eventCorrectResidencePermit", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectResidencePermit
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectResidencePermitPersonNullValidateExceptionMessage = "CorrectResidencePermitPerson is not valid! CorrectResidencePermitPerson is required";

    private PersonIdentification _correctResidencePermitPerson;

    public EventCorrectResidencePermit()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctResidencePermitPerson">Field is required.</param>
    /// <param name="residencePermitData">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectResidencePermit Create(PersonIdentification correctResidencePermitPerson, ResidencePermitData residencePermitData = null, object extension = null)
    {
        return new EventCorrectResidencePermit()
        {
            CorrectResidencePermitPerson = correctResidencePermitPerson,
            ResidencePermitData = residencePermitData,
            Extension = extension
        };
    }

    [JsonProperty("correctResidencePermitPerson")]
    [XmlElement(ElementName = "correctResidencePermitPerson")]
    public PersonIdentification CorrectResidencePermitPerson
    {
        get { return _correctResidencePermitPerson; }

        set
        {
            _correctResidencePermitPerson = value ?? throw new XmlSchemaValidationException(CorrectResidencePermitPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("residencePermitData")]
    [XmlElement(ElementName = "residencePermitData")]
    public ResidencePermitData ResidencePermitData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ResidencePermitDataSpecified => ResidencePermitData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
