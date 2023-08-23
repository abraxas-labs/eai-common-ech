// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0011_8_1f;
using Newtonsoft.Json;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021).
/// </summary>
[Serializable]
[JsonObject("maritalDataAddon")]
[XmlRoot(ElementName = "maritalDataAddon", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class MaritalDataAddon
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public MaritalDataAddon()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="placeOfMarriage">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static MaritalDataAddon Create(GeneralPlace placeOfMarriage = null)
    {
        return new MaritalDataAddon()
        {
            PlaceOfMarriage = placeOfMarriage
        };
    }

    [JsonProperty("placeOfMarriage")]
    [XmlElement(ElementName = "placeOfMarriage")]
    public GeneralPlace PlaceOfMarriage { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfMarriageSpecified => PlaceOfMarriage != null;
}
