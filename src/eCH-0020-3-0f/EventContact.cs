// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventContact.
/// </summary>
[Serializable]
[JsonObject("eventContact")]
[XmlRoot(ElementName = "eventContact", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventContact
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _contactPerson;
    private ContactData _contactData;

    public EventContact()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="contactPerson">Field is required.</param>
    /// <param name="contactData">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventContact Create(PersonIdentification contactPerson, ContactData contactData, object extension = null)
    {
        return new EventContact()
        {
            ContactPerson = contactPerson,
            ContactData = contactData,
            Extension = extension
        };
    }

    [JsonProperty("contactPerson")]
    [XmlElement(ElementName = "contactPerson")]
    public PersonIdentification ContactPerson
    {
        get { return _contactPerson; }
        set { _contactPerson = value; }
    }

    [JsonProperty("contactData")]
    [XmlElement(ElementName = "contactData")]
    public ContactData ContactData
    {
        get { return _contactData; }
        set { _contactData = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
