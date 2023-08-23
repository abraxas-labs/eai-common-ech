// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0011_7_0;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zur beruflichen Tätigkeit.
/// </summary>
[Serializable]
[JsonObject("deathDataType")]
[XmlRoot(ElementName = "deathDataType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class DeathDataType : FieldValueChecker<DeathDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private DateTime _dateOfDeath;
    private BirthPlaceType _placeOfDeath;

    public DeathDataType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="dateOfDeath">Field is required.</param>
    /// <param name="placeOfDeath">Field is optional.</param>
    /// <returns>DeathDataType.</returns>
    public static DeathDataType Create(DateTime dateOfDeath, BirthPlaceType placeOfDeath)
    {
        return new DeathDataType
        {
            DateOfDeath = dateOfDeath,
            PlaceOfDeath = placeOfDeath
        };
    }

    [FieldRequired]
    [JsonProperty("dateOfDeath")]
    [XmlElement(ElementName = "dateOfDeath")]
    public DateTime DateOfDeath
    {
        get => _dateOfDeath;
        set => CheckAndSetValue(ref _dateOfDeath, value);
    }

    [JsonProperty("placeOfDeath")]
    [XmlElement(ElementName = "placeOfDeath")]
    public BirthPlaceType PlaceOfDeath
    {
        get => _placeOfDeath;
        set => CheckAndSetValue(ref _placeOfDeath, value);
    }
}
