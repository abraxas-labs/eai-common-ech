// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0007_5_0;
using eCH_0008_3_0;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("swissAbroadType")]
[XmlRoot(ElementName = "swissAbroadType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class SwissAbroad
{
    private const string SwissAbroadPersonNullValidateExceptionMessage =
        "SwissAbroadPerson is not valid! SwissAbroadPerson is required";

    private const string ResidenceCountryNullValidateExceptionMessage =
        "Country is not valid! Country is required";

    private const string PlaceChoiceNullValidateExceptionMessage =
        "PlaceChoice is not valid! PlaceChoice is required";

    private const string PlaceChoiceOutOfRangeValidateExceptionMessage =
        "PlaceChoice is not valid! PlaceChoice is a false Type";

    [JsonIgnore][XmlIgnore] public PlaceChoiceIdentifier ElementTypeName;
    private Person _swissAbroadPerson;
    private Country _residenceCountry;
    private object _placeChoice;
    private DateTime _dateOfRegistration;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public SwissAbroad()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("swissAbroadPerson")]
    [XmlElement(ElementName = "swissAbroadPerson")]
    public Person SwissAbroadPerson
    {
        get => _swissAbroadPerson;
        set => _swissAbroadPerson = value ?? throw new XmlSchemaValidationException(SwissAbroadPersonNullValidateExceptionMessage);
    }

    [JsonProperty("dateOfRegistration")]
    [XmlElement(DataType = "date", ElementName = "dateOfRegistration")]
    public DateTime DateOfRegistration
    {
        get => _dateOfRegistration;
        set => _dateOfRegistration = value;
    }

    [JsonProperty("residenceCountry")]
    [XmlElement(ElementName = "residenceCountry")]
    public Country ResidenceCountry
    {
        get => _residenceCountry;
        set => _residenceCountry = value ?? throw new XmlSchemaValidationException(ResidenceCountryNullValidateExceptionMessage);
    }

    [XmlElement("municipality", typeof(SwissMunicipality))]
    [XmlElement("canton", typeof(CantonAbbreviation))]
    [XmlChoiceIdentifier("ElementTypeName")]
    public object PlaceChoice
    {
        get => _placeChoice;
        set => _placeChoice = PlaceChoiceIsValid(value);
    }

    private object PlaceChoiceIsValid(object value)
    {
        if (value == null)
        {
            throw new XmlSchemaValidationException(PlaceChoiceNullValidateExceptionMessage);
        }

        if (value is SwissMunicipality)
        {
            ElementTypeName = PlaceChoiceIdentifier.municipality;
        }
        else if (value is CantonAbbreviation)
        {
            ElementTypeName = PlaceChoiceIdentifier.canton;
        }
        else
        {
            throw new XmlSchemaValidationException(PlaceChoiceOutOfRangeValidateExceptionMessage);
        }

        return value;
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swissAbroadPerson">Field is required.</param>
    /// <param name="dateOfRegistration">Field is required.</param>
    /// <param name="residenceCountry">Field is required.</param>
    /// <param name="municipality">Field is required.</param>
    /// <returns>SwissAbroad.</returns>
    public static SwissAbroad Create(Person swissAbroadPerson, DateTime dateOfRegistration, Country residenceCountry, SwissMunicipality municipality)
    {
        return new SwissAbroad
        {
            SwissAbroadPerson = swissAbroadPerson,
            DateOfRegistration = dateOfRegistration,
            ResidenceCountry = residenceCountry,
            PlaceChoice = municipality
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swissAbroadPerson">Field is required.</param>
    /// <param name="dateOfRegistration">Field is required.</param>
    /// <param name="residenceCountry">Field is required.</param>
    /// <param name="canton">Field is required.</param>
    /// <returns>SwissAbroad.</returns>
    public static SwissAbroad Create(Person swissAbroadPerson, DateTime dateOfRegistration, Country residenceCountry, CantonAbbreviation canton)
    {
        return new SwissAbroad
        {
            SwissAbroadPerson = swissAbroadPerson,
            DateOfRegistration = dateOfRegistration,
            ResidenceCountry = residenceCountry,
            PlaceChoice = canton
        };
    }
}
public enum PlaceChoiceIdentifier
{
    municipality,
    canton
}
