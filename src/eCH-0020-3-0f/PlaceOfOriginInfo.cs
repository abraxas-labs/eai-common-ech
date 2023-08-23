// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using eCH_0021_7_0f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Heimatortinformationen.
/// </summary>
[Serializable]
[JsonObject("placeOfOriginInfo")]
[XmlRoot(ElementName = "placeOfOriginInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class PlaceOfOriginInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PlaceOfOrigin _placeOfOrigin;

    public PlaceOfOriginInfo()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="placeOfOrigin">Field is required.</param>
    /// <param name="placeOfOriginAddonData">Field is optional.</param>
    /// <returns>PlaceOfOriginInfo.</returns>
    public static PlaceOfOriginInfo Create(PlaceOfOrigin placeOfOrigin, PlaceOfOriginAddonData placeOfOriginAddonData = null)
    {
        return new PlaceOfOriginInfo()
        {
            PlaceOfOrigin = placeOfOrigin,
            PlaceOfOriginAddonData = placeOfOriginAddonData
        };
    }

    [JsonProperty("placeOfOrigin")]
    [XmlElement(ElementName = "placeOfOrigin")]
    public PlaceOfOrigin PlaceOfOrigin
    {
        get { return _placeOfOrigin; }
        set { _placeOfOrigin = value; }
    }

    [JsonProperty("placeOfOriginAddonData")]
    [XmlElement(ElementName = "placeOfOriginAddonData")]
    public PlaceOfOriginAddonData PlaceOfOriginAddonData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginAddonDataSpecified => PlaceOfOriginAddonData != null;
}
