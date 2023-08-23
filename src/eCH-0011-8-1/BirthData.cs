// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Geburtsangaben.
/// </summary>
[Serializable]
[JsonObject("birthData")]
[XmlRoot(ElementName = "birthData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class BirthData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string DateOfBirthNullValidateExceptionMessage = "DateOfBirth is not valid! DateOfBirth is required";
    private const string PlaceOfBirthNullValidateExceptionMessage = "PlaceOfBirth is not valid! PlaceOfBirth is required";

    private DatePartiallyKnown _dateOfBirth;
    private GeneralPlace _placeOfBirth;

    public BirthData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="dateOfBirth">Field is required.</param>
    /// <param name="placeOfBirth">Field is required.</param>
    /// <param name="sex">Field is required.</param>
    /// <returns>BirthData.</returns>
    public static BirthData Create(DatePartiallyKnown dateOfBirth, GeneralPlace placeOfBirth, SexType sex)
    {
        return new BirthData()
        {
            DateOfBirth = dateOfBirth,
            PlaceOfBirth = placeOfBirth,
            Sex = sex
        };
    }

    [JsonProperty("dateOfBirth")]
    [XmlElement(ElementName = "dateOfBirth", Order = 1)]
    public DatePartiallyKnown DateOfBirth
    {
        get { return _dateOfBirth; }

        set
        {
            _dateOfBirth = value ?? throw new XmlSchemaValidationException(DateOfBirthNullValidateExceptionMessage);
        }
    }

    [JsonProperty("placeOfBirth")]
    [XmlElement(ElementName = "placeOfBirth", Order = 2)]
    public GeneralPlace PlaceOfBirth
    {
        get { return _placeOfBirth; }

        set
        {
            _placeOfBirth = value ?? throw new XmlSchemaValidationException(PlaceOfBirthNullValidateExceptionMessage);
        }
    }

    [JsonProperty("sex")]
    [XmlElement(ElementName = "sex", Order = 3)]
    public SexType Sex { get; set; }
}
