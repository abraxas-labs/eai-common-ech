// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Helferklasse um den Choiche-Node vom Candidate abzubilden.
/// </summary>
[Serializable]
[JsonObject("swiss")]
[XmlRoot(ElementName = "swiss", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class Swiss
{
    private const string OrigniOutOfRangeExceptionMessage =
        "Origni is not valid! Origni has minimal leght of 1 and maximal length of 80";

    private string _origin;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Swiss()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("origin")]
    [XmlElement(ElementName = "origin", Order = 1)]
    public string Origin
    {
        get => _origin;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 80))
            {
                throw new FormatException(OrigniOutOfRangeExceptionMessage);
            }

            _origin = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="origin">This parameter is optional.</param>
    /// <returns>Swiss.</returns>
    public static Swiss Create(string origin)
    {
        return new Swiss
        {
            Origin = origin
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <returns>PoliticalAdressInfo.</returns>
    public static Swiss Create()
    {
        return new Swiss();
    }
}
