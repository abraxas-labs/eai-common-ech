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
/// EventCorrectReligion.
/// </summary>
[Serializable]
[JsonObject("eventCorrectReligion")]
[XmlRoot(ElementName = "eventCorrectReligion", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventCorrectReligion
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string CorrectReligionPersonNullValidateExceptionMessage = "CorrectReligionPerson is not valid! CorrectReligionPerson is required";
    private const string ReligionDataNullValidateExceptionMessage = "ReligionData is not valid! ReligionData is required";

    private PersonIdentification _correctReligionPerson;
    private ReligionData _religionData;

    public EventCorrectReligion()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="correctReligionPerson">Field is required.</param>
    /// <param name="religionData">Field is reqired.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventCorrectReligion Create(PersonIdentification correctReligionPerson, ReligionData religionData, object extension = null)
    {
        return new EventCorrectReligion()
        {
            CorrectReligionPerson = correctReligionPerson,
            ReligionData = religionData,
            Extension = extension
        };
    }

    [JsonProperty("correctReligionPerson")]
    [XmlElement(ElementName = "correctReligionPerson")]
    public PersonIdentification CorrectReligionPerson
    {
        get { return _correctReligionPerson; }

        set
        {
            _correctReligionPerson = value ?? throw new XmlSchemaValidationException(CorrectReligionPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("religionData")]
    [XmlElement(ElementName = "religionData")]
    public ReligionData ReligionData
    {
        get { return _religionData; }

        set
        {
            _religionData = value ?? throw new XmlSchemaValidationException(ReligionDataNullValidateExceptionMessage);
        }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
