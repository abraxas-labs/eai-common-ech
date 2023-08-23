// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0008_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Staaten und Gebiete (eCH-0008)
/// Mit der Kurzform des Ländernamens wird die Bedeutung der numerischen BFS-Ländernummer in Textform dokumentiert.
/// </summary>
[Serializable]
[JsonObject("countryShort")]
[XmlRoot(ElementName = "countryShort", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0008/2")]
public class CountryShort : FieldValueChecker<CountryShort>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _countryNameShort;

    public CountryShort()
    {
        Xmlns.Add("eCH-0008", "http://www.ech.ch/xmlns/eCH-0008/2");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="countryNameShort">Field is reqired.</param>
    /// <returns>CountryShort.</returns>
    public static CountryShort Create(string countryNameShort)
    {
        return new CountryShort
        {
            CountryNameShort = countryNameShort
        };
    }

    [FieldRequired]
    [FieldMaxLength(50)]
    [JsonProperty("countryNameShort")]
    [XmlElement(ElementName = "countryNameShort")]
    public string CountryNameShort
    {
        get => _countryNameShort;
        set => CheckAndSetValue(ref _countryNameShort, value);
    }
}
