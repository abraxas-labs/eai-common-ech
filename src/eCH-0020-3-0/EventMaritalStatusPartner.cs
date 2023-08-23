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
/// EventMaritalStatusPartner.
/// </summary>
[Serializable]
[JsonObject("eventMaritalStatusPartner")]
[XmlRoot(ElementName = "eventMaritalStatusPartner", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventMaritalStatusPartner
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string MaritalStatusPartnerPersonNullValidateExceptionMessage = "MaritalStatusPartnerPerson is not valid! MaritalStatusPartnerPerson is required";
    private const string MaritalDataNullValidateExceptionMessage = "MaritalData is not valid! MaritalData is required";

    private PersonIdentification _maritalStatusPartnerPerson;
    private MaritalDataRestrictedMaritalStatusPartner _maritalData;

    public EventMaritalStatusPartner()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="maritalStatusPartnerPerson">Field is required.</param>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventMaritalStatusPartner Create(PersonIdentification maritalStatusPartnerPerson, MaritalDataRestrictedMaritalStatusPartner maritalData, object extension = null)
    {
        return new EventMaritalStatusPartner()
        {
            MaritalStatusPartnerPerson = maritalStatusPartnerPerson,
            MaritalData = maritalData,
            Extension = extension
        };
    }

    [JsonProperty("maritalStatusPartnerPerson")]
    [XmlElement(ElementName = "maritalStatusPartnerPerson")]
    public PersonIdentification MaritalStatusPartnerPerson
    {
        get { return _maritalStatusPartnerPerson; }

        set
        {
            _maritalStatusPartnerPerson = value ?? throw new XmlSchemaValidationException(MaritalStatusPartnerPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalDataRestrictedMaritalStatusPartner MaritalData
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
