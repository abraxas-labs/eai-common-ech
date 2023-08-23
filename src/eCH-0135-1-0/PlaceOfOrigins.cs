// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0135_1_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Heimatort (eCH-0135).
/// </summary>
[Serializable]
[JsonObject("placeOfOrigins")]
[XmlRoot(ElementName = "placeOfOrigins", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0135/1")]
public class PlaceOfOrigins
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PlaceOfOriginNullValidateExceptionMessage = "PlaceOfOrigins is not valid! PlaceOfOrigins is required";

    private List<PlaceOfOrigin> _placeOfOrigin;

    public PlaceOfOrigins()
    {
        Xmlns.Add("eCH-0135", "http://www.ech.ch/xmlns/eCH-0135/1");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="placeOfOrigin">Field is reqired.</param>
    /// <returns>PlaceOfOriginNomenclature.</returns>
    public static PlaceOfOrigins Create(List<PlaceOfOrigin> placeOfOrigin)
    {
        return new PlaceOfOrigins()
        {
            PlaceOfOrigin = placeOfOrigin
        };
    }

    [JsonProperty("placeOfOrigin")]
    [XmlElement(ElementName = "placeOfOrigin", Order = 1)]
    public List<PlaceOfOrigin> PlaceOfOrigin
    {
        get { return _placeOfOrigin; }

        set
        {
            _placeOfOrigin = value ?? throw new XmlSchemaValidationException(PlaceOfOriginNullValidateExceptionMessage);
        }
    }
}
