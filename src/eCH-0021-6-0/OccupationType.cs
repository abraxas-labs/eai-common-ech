// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0010_5_0;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Arbeitgeberangaben.
/// </summary>
[Serializable]
[JsonObject("occupationType")]
[XmlRoot(ElementName = "occupationType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class OccupationType : FieldValueChecker<OccupationType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _employer;
    private AddressInformation _placeOfWork;
    private AddressInformation _placeOfEmployer;
    private DateTime? _occupationValidTill;
    private DateTime? _occupationValidFrom;

    public OccupationType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="employer">Field is optional.</param>
    /// <param name="placeOfWork">Field is optional.</param>
    /// <param name="placeOfEmployer">Field is optional.</param>
    /// <param name="occupationValidFrom">Field is optional.</param>
    /// <param name="occupationValidTill">Field is optional.</param>
    /// <returns>OccupationType.</returns>
    public static OccupationType Create(string employer, AddressInformation placeOfWork, AddressInformation placeOfEmployer, DateTime? occupationValidTill = null, DateTime? occupationValidFrom = null)
    {
        return new OccupationType
        {
            Employer = employer,
            PlaceOfWork = placeOfWork,
            PlaceOfEmployer = placeOfEmployer,
            OccupationValidFrom = occupationValidFrom,
            OccupationValidTill = occupationValidTill
        };
    }

    [FieldMaxLength(100)]
    [JsonProperty("employer")]
    [XmlElement(ElementName = "employer")]
    public string Employer
    {
        get => _employer;
        set => CheckAndSetValue(ref _employer, value);
    }

    [JsonProperty("placeOfWork")]
    [XmlElement(ElementName = "placeOfWork")]
    public AddressInformation PlaceOfWork
    {
        get => _placeOfWork;
        set => CheckAndSetValue(ref _placeOfWork, value);
    }

    [JsonProperty("placeOfEmployer")]
    [XmlElement(ElementName = "placeOfEmployer")]
    public AddressInformation PlaceOfEmployer
    {
        get => _placeOfEmployer;
        set => CheckAndSetValue(ref _placeOfEmployer, value);
    }

    [JsonProperty("occupationValidTill")]
    [XmlElement(DataType = "date", ElementName = "occupationValidTill")]
    public DateTime? OccupationValidTill
    {
        get => _occupationValidTill;
        set => CheckAndSetValue(ref _occupationValidTill, value);
    }

    [JsonProperty("occupationValidFrom")]
    [XmlElement(DataType = "date", ElementName = "occupationValidFrom")]
    public DateTime? OccupationValidFrom
    {
        get => _occupationValidFrom;
        set => CheckAndSetValue(ref _occupationValidFrom, value);
    }
}
