// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0011_7_0;
using eCH_0044_3_0;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zur beruflichen Tätigkeit.
/// </summary>
[Serializable]
[JsonObject("birthDataType")]
[XmlRoot(ElementName = "birthDataType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class BirthDataType : FieldValueChecker<BirthDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private DatePartiallyKnown _dateOfBirth;
    private BirthPlaceType _birthPlace;

    public BirthDataType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="dateOfBirth">Field is required.</param>
    /// <param name="birthPlace">Field is required.</param>
    /// <returns>BirthDataType.</returns>
    public static BirthDataType Create(DatePartiallyKnown dateOfBirth, BirthPlaceType birthPlace)
    {
        return new BirthDataType
        {
            DateOfBirth = dateOfBirth,
            BirthPlace = birthPlace
        };
    }

    [FieldRequired]
    [JsonProperty("dateOfBirth")]
    [XmlElement(ElementName = "dateOfBirth")]
    public DatePartiallyKnown DateOfBirth
    {
        get => _dateOfBirth;
        set => CheckAndSetValue(ref _dateOfBirth, value);
    }

    [FieldRequired]
    [JsonProperty("birthPlace")]
    [XmlElement(ElementName = "birthPlace")]
    public BirthPlaceType BirthPlace
    {
        get => _birthPlace;
        set => CheckAndSetValue(ref _birthPlace, value);
    }
}
