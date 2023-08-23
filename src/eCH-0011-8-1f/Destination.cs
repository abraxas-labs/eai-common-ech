// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0007_5_0f;
using eCH_0010_5_1f;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Herkunfts- oder Zielort.
/// </summary>
[Serializable]
[JsonObject("destination")]
[XmlRoot(ElementName = "destination", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class Destination
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public Destination()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="unknown">Field is required.</param>
    /// <param name="mailAddress"></param>
    /// <returns>GeneralPlace.</returns>
    public static Destination Create(string unknown, AddressInformation mailAddress = null)
    {
        return new Destination()
        {
            Unknown = "0",
            ForeignCountry = null,
            SwissTown = null,
            MailAddress = mailAddress
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="foreignCountry">Field is required.</param>
    /// <param name="mailAddress"></param>
    /// <returns>GeneralPlace.</returns>
    public static Destination Create(ForeignCountry foreignCountry, AddressInformation mailAddress = null)
    {
        return new Destination()
        {
            Unknown = null,
            ForeignCountry = foreignCountry,
            SwissTown = null,
            MailAddress = mailAddress
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="swissTown">Field is required.</param>
    /// <param name="mailAddress"></param>
    /// <returns>GeneralPlace.</returns>
    public static Destination Create(SwissMunicipality swissTown, AddressInformation mailAddress = null)
    {
        return new Destination()
        {
            Unknown = null,
            ForeignCountry = null,
            SwissTown = swissTown,
            MailAddress = mailAddress
        };
    }

    [JsonProperty("unknown")]
    [XmlElement(ElementName = "unknown")]
    public string Unknown { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool UnknownSpecified => Unknown != null;

    [JsonProperty("swissTown")]
    [XmlElement(ElementName = "swissTown")]
    public SwissMunicipality SwissTown { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SwissTownSpecified => SwissTown != null;

    [JsonProperty("foreignCountry")]
    [XmlElement(ElementName = "foreignCountry")]
    public ForeignCountry ForeignCountry { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ForeignCountrySpecified => ForeignCountry != null;

    [JsonProperty("mailAddress")]
    [XmlElement(ElementName = "mailAddress")]
    public AddressInformation MailAddress { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MailAddressSpecified => MailAddress != null;
}
