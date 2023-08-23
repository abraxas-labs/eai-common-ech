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
/// EventChangeReligion.
/// </summary>
[Serializable]
[JsonObject("eventChangeReligion")]
[XmlRoot(ElementName = "eventChangeReligion", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventChangeReligion
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ChangeReligionPersonNullValidateExceptionMessage = "ChangeReligionPerson is not valid! ChangeReligionPerson is required";
    private const string ReligionDataNullValidateExceptionMessage = "ReligionData is not valid! ReligionData is required";

    private PersonIdentification _changeReligionPerson;
    private ReligionData _religionData;

    public EventChangeReligion()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
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

        set
        {
            _changeReligionPerson = value ?? throw new XmlSchemaValidationException(ChangeReligionPersonNullValidateExceptionMessage);
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
