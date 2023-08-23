// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0007_5_0;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Der Geburtsort kann entweder als „unbekannt“, Ort in der Schweiz oder
/// Ausland (mit optionaler Angabe des Ortes) erfasst werden.
/// </summary>
[Serializable]
[JsonObject("generalPlaceType")]
[XmlRoot(ElementName = "generalPlaceType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class GeneralPlace
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public GeneralPlace()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="unknown">Field is required.</param>
    /// <returns>GeneralPlace.</returns>
    public static GeneralPlace Create(string unknown)
    {
        return new GeneralPlace()
        {
            Unknown = "0",
            ForeignCountry = null,
            SwissTown = null
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="foreignCountry">Field is required.</param>
    /// <returns>GeneralPlace.</returns>
    public static GeneralPlace Create(ForeignCountry foreignCountry)
    {
        return new GeneralPlace()
        {
            Unknown = null,
            ForeignCountry = foreignCountry,
            SwissTown = null
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swissTown">Field is required.</param>
    /// <returns>GeneralPlace.</returns>
    public static GeneralPlace Create(SwissMunicipality swissTown)
    {
        return new GeneralPlace()
        {
            Unknown = null,
            ForeignCountry = null,
            SwissTown = swissTown
        };
    }

    [JsonProperty("unknown")]
    [XmlElement(ElementName = "unknown", Order = 1)]
    public string Unknown { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UnknownSpecified => Unknown != null;

    [JsonProperty("swissTown")]
    [XmlElement(ElementName = "swissTown", Order = 2)]
    public SwissMunicipality SwissTown { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SwissTownSpecified => SwissTown != null;

    [JsonProperty("foreignCountry")]
    [XmlElement(ElementName = "foreignCountry", Order = 3)]
    public ForeignCountry ForeignCountry { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ForeignCountrySpecified => ForeignCountry != null;
}
