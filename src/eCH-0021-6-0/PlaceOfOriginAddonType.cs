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
/// Zusatzangaben zum Heimatort.
/// </summary>
[Serializable]
[JsonObject("placeOfOriginAddonData")]
[XmlRoot(ElementName = "placeOfOriginAddonData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class PlaceOfOriginAddonType : FieldValueChecker<PlaceOfOriginAddonType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PlaceOfOriginType _origin;
    private ReasonOfAcquisitionType _reasonOfAcquisition;
    private DateTime? _naturalizationDate;
    private DateTime? _expatriationDate;
    private DateTime? _placeOfOriginValidFrom;

    public PlaceOfOriginAddonType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="origin">Field is required.</param>
    /// <param name="reasonOfAcquisition">Field is optional.</param>
    /// <param name="naturalizationDate">Field is optional.</param>
    /// <param name="expatriationDate">Field is optional.</param>
    /// <param name="placeOfOriginValidFrom">Field is optional.</param>
    /// <returns>PlaceOfOriginAddonType.</returns>
    public static PlaceOfOriginAddonType Create(PlaceOfOriginType origin, ReasonOfAcquisitionType reasonOfAcquisition, DateTime? naturalizationDate = null, DateTime? expatriationDate = null, DateTime? placeOfOriginValidFrom = null)
    {
        return new PlaceOfOriginAddonType
        {
            Origin = origin,
            ReasonOfAcquisition = reasonOfAcquisition,
            NaturalizationDate = naturalizationDate,
            ExpatriationDate = expatriationDate,
            PlaceOfOriginValidFrom = placeOfOriginValidFrom
        };
    }

    [FieldRequired]
    [JsonProperty("origin")]
    [XmlElement(ElementName = "origin")]
    public PlaceOfOriginType Origin
    {
        get => _origin;
        set => CheckAndSetValue(ref _origin, value);
    }

    [JsonProperty("reasonOfAcquisition")]
    [XmlElement(ElementName = "reasonOfAcquisition")]
    public ReasonOfAcquisitionType ReasonOfAcquisition
    {
        get => _reasonOfAcquisition;
        set => CheckAndSetValue(ref _reasonOfAcquisition, value);
    }

    [JsonProperty("naturalizationDate")]
    [XmlElement(DataType = "date", ElementName = "naturalizationDate")]
    public DateTime? NaturalizationDate
    {
        get => _naturalizationDate;
        set => CheckAndSetValue(ref _naturalizationDate, value);
    }

    [JsonProperty("expatriationDate")]
    [XmlElement(DataType = "date", ElementName = "expatriationDate")]
    public DateTime? ExpatriationDate
    {
        get => _expatriationDate;
        set => CheckAndSetValue(ref _expatriationDate, value);
    }

    [JsonProperty("placeOfOriginValidFrom")]
    [XmlElement(DataType = "date", ElementName = "placeOfOriginValidFrom")]
    public DateTime? PlaceOfOriginValidFrom
    {
        get => _placeOfOriginValidFrom;
        set => CheckAndSetValue(ref _placeOfOriginValidFrom, value);
    }
}
