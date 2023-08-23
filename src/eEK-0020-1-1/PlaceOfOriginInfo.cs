// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0011_8_1;
using eCH_0021_7_0;
using Newtonsoft.Json;

namespace eEK_0020_1_1;

/// <summary>
/// Vrsg Standard für Subject (Loganto)
/// An eCH-0020 angeleht, hat aber kleine differenzen.
/// Definiert die Schnittstelle LogantoMeldewesen Ereignissmeldung
/// Schnittstellenstandard Meldegründe Personenregister (eEK-0020).
/// </summary>
[Serializable]
[JsonObject("placeOfOriginInfo")]
[XmlRoot(ElementName = "placeOfOriginInfo", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class PlaceOfOriginInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PlaceOfOriginNullValidateExceptionMessage = "PlaceOfOrigin is not valid! PlaceOfOrigin is required";

    private PlaceOfOrigin _placeOfOrigin;

    public PlaceOfOriginInfo()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
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

        set
        {
            _placeOfOrigin = value ?? throw new XmlSchemaValidationException(PlaceOfOriginNullValidateExceptionMessage);
        }
    }

    [JsonProperty("placeOfOriginAddonData")]
    [XmlElement(ElementName = "placeOfOriginAddonData")]
    public PlaceOfOriginAddonData PlaceOfOriginAddonData { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfOriginAddonDataSpecified => PlaceOfOriginAddonData != null;
}
