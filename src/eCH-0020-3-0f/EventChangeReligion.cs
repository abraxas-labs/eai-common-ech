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
/// EventChangeReligion.
/// </summary>
[Serializable]
[JsonObject("eventChangeReligion")]
[XmlRoot(ElementName = "eventChangeReligion", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class EventChangeReligion
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _changeReligionPerson;
    private ReligionData _religionData;

    public EventChangeReligion()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="changeReligionPerson">Field is required.</param>
    /// <param name="religionData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventChangeReligion Create(PersonIdentification changeReligionPerson, ReligionData religionData, object extension = null)
    {
        return new EventChangeReligion()
        {
            ChangeReligionPerson = changeReligionPerson,
            ReligionData = religionData,
            Extension = extension
        };
    }

    [JsonProperty("changeReligionPerson")]
    [XmlElement(ElementName = "changeReligionPerson")]
    public PersonIdentification ChangeReligionPerson
    {
        get { return _changeReligionPerson; }
        set { _changeReligionPerson = value; }
    }

    [JsonProperty("religionData")]
    [XmlElement(ElementName = "religionData")]
    public ReligionData ReligionData
    {
        get { return _religionData; }
        set { _religionData = value; }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
