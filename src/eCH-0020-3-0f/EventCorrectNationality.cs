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
/// EventCorrectNationality.
/// </summary>
[Serializable]
[JsonObject("eventCorrectNationality")]
[XmlRoot(ElementName = "eventCorrectNationality", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventCorrectNationality
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _correctNationalityPerson;
    private NationalityData _nationalityData;

    public EventCorrectNationality()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctNationalityPerson">Field is required.</param>
    /// <param name="nationalityData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectNationality Create(PersonIdentification correctNationalityPerson, NationalityData nationalityData, object extension = null)
    {
        return new EventCorrectNationality()
        {
            CorrectNationalityPerson = correctNationalityPerson,
            NationalityData = nationalityData,
            Extension = extension
        };
    }

    [JsonProperty("correctNationalityPerson")]
    [XmlElement(ElementName = "correctNationalityPerson")]
    public PersonIdentification CorrectNationalityPerson
    {
        get { return _correctNationalityPerson; }
        set { _correctNationalityPerson = value; }
    }

    [JsonProperty("nationalityData")]
    [XmlElement(ElementName = "nationalityData")]
    public NationalityData NationalityData
    {
        get { return _nationalityData; }
        set { _nationalityData = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
