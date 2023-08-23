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
/// EventCorrectContact.
/// </summary>
[Serializable]
[JsonObject("eventCorrectContact")]
[XmlRoot(ElementName = "eventCorrectContact", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectContact
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _correctContactPerson;

    private const string CorrectContactPersonNullValidateExceptionMessage = "CorrectContactPerson is not valid! CorrectContactPerson is required";

    public EventCorrectContact()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctContactPerson">Field is required.</param>
    /// <param name="contactData">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectContact Create(PersonIdentification correctContactPerson, ContactData contactData = null, object extension = null)
    {
        return new EventCorrectContact()
        {
            CorrectContactPerson = correctContactPerson,
            ContactData = contactData,
            Extension = extension
        };
    }

    [JsonProperty("correctContactPerson")]
    [XmlElement(ElementName = "correctContactPerson")]
    public PersonIdentification CorrectContactPerson
    {
        get { return _correctContactPerson; }

        set
        {
            _correctContactPerson = value ?? throw new XmlSchemaValidationException(CorrectContactPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("contactData")]
    [XmlElement(ElementName = "contactData")]
    public ContactData ContactData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactDataSpecified => ContactData != null;

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
