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
/// EventChangeNationality.
/// </summary>
[Serializable]
[JsonObject("eventChangeNationality")]
[XmlRoot(ElementName = "eventChangeNationality", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventChangeNationality
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _changeNationalityPerson;
    private NationalityData _nationalityData;

    public EventChangeNationality()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeNationalityPerson">Field is required.</param>
    /// <param name="nationalityData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeNationality Create(PersonIdentification changeNationalityPerson, NationalityData nationalityData, object extension = null)
    {
        return new EventChangeNationality()
        {
            ChangeNationalityPerson = changeNationalityPerson,
            NationalityData = nationalityData,
            Extension = extension
        };
    }

    [JsonProperty("changeNationalityPerson")]
    [XmlElement(ElementName = "changeNationalityPerson")]
    public PersonIdentification ChangeNationalityPerson
    {
        get { return _changeNationalityPerson; }
        set { _changeNationalityPerson = value; }
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
