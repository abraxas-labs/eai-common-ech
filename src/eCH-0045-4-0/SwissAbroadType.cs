// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_6_0;
using eCH_0008_3_0;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("swissAbroadType")]
[XmlRoot(ElementName = "swissAbroadType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class SwissAbroadType : FieldValueChecker<SwissAbroadType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PlaceChoiceNullValidateExceptionMessage = "PlaceChoice is not valid! PlaceChoice is required";
    private const string PlaceChoiceOutOfRangeValidateExceptionMessage = "PlaceChoice is not valid! PlaceChoice is a false Type";

    [JsonIgnore]
    [XmlIgnore]
    public PlaceChoiceIdentifier ElementTypeName;
    private SwissPersonType _swissAbroadPerson;
    private DateTime _dateOfRegistration;
    private Country _residenceCountry;
    private object _placeChoice;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swissAbroadPerson">Field is required.</param>
    /// <param name="dateOfRegistration">Field is required.</param>
    /// <param name="residenceCountry">Field is required.</param>
    /// <param name="municipality">Field is required.</param>
    /// <returns>SwissAbroad.</returns>
    public static SwissAbroadType Create(SwissPersonType swissAbroadPerson, DateTime dateOfRegistration, Country residenceCountry, SwissMunicipality municipality)
    {
        return new SwissAbroadType
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
    public static SwissAbroadType Create(SwissPersonType swissAbroadPerson, DateTime dateOfRegistration, Country residenceCountry, CantonAbbreviation canton)
    {
        return new SwissAbroadType
        {
            SwissAbroadPerson = swissAbroadPerson,
            DateOfRegistration = dateOfRegistration,
            ResidenceCountry = residenceCountry,
            PlaceChoice = canton
        };
    }

    public SwissAbroadType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    [FieldRequired]
    [JsonProperty("swissAbroadPerson")]
    [XmlElement(ElementName = "swissAbroadPerson", Order = 1)]
    public SwissPersonType SwissAbroadPerson
    {
        get => _swissAbroadPerson;
        set => CheckAndSetValue(ref _swissAbroadPerson, value);
    }

    [FieldRequired]
    [JsonProperty("dateOfRegistration")]
    [XmlElement(DataType = "date", ElementName = "dateOfRegistration", Order = 2)]
    public DateTime DateOfRegistration
    {
        get => _dateOfRegistration;
        set => CheckAndSetValue(ref _dateOfRegistration, value);
    }

    [FieldRequired]
    [JsonProperty("residenceCountry")]
    [XmlElement(ElementName = "residenceCountry", Order = 3)]
    public Country ResidenceCountry
    {
        get => _residenceCountry;
        set => CheckAndSetValue(ref _residenceCountry, value);
    }

    [XmlElement("municipality", typeof(SwissMunicipality), Order = 4)]
    [XmlElement("canton", typeof(CantonAbbreviation), Order = 4)]
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
}
public enum PlaceChoiceIdentifier
{
    municipality,
    canton
}
