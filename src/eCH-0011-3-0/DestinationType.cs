// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_3_0;
using eCH_0010_3_0;
using Newtonsoft.Json;

namespace eCH_0011_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Herkunfts- oder Zielort.
/// </summary>
[Serializable]
[JsonObject("destination")]
[XmlRoot(ElementName = "destination", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/3")]
public class DestinationType : FieldValueChecker<DestinationType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _unknown;
    private SwissMunicipality _swissTown;
    private ForeignCountryType _foreignCountry;
    private AddressInformation _mailAddress;

    public DestinationType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="unknown">Field is required.</param>
    /// <param name="mailAddress"></param>
    /// <returns>GeneralPlace.</returns>
    public static DestinationType Create(string unknown, AddressInformation mailAddress = null)
    {
        return new DestinationType()
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
    public static DestinationType Create(ForeignCountryType foreignCountry, AddressInformation mailAddress = null)
    {
        return new DestinationType()
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
    public static DestinationType Create(SwissMunicipality swissTown, AddressInformation mailAddress = null)
    {
        return new DestinationType()
        {
            Unknown = null,
            ForeignCountry = null,
            SwissTown = swissTown,
            MailAddress = mailAddress
        };
    }

    [JsonProperty("unknown")]
    [XmlElement(ElementName = "unknown")]
    public string Unknown
    {
        get => _unknown;
        set => CheckAndSetValue(ref _unknown, value);
    }

    [JsonProperty("swissTown")]
    [XmlElement(ElementName = "swissTown")]
    public SwissMunicipality SwissTown
    {
        get => _swissTown;
        set => CheckAndSetValue(ref _swissTown, value);
    }

    [JsonProperty("foreignCountry")]
    [XmlElement(ElementName = "foreignCountry")]
    public ForeignCountryType ForeignCountry
    {
        get => _foreignCountry;
        set => CheckAndSetValue(ref _foreignCountry, value);
    }

    [JsonProperty("mailAddress")]
    [XmlElement(ElementName = "mailAddress")]
    public AddressInformation MailAddress
    {
        get
        {
            if (SwissTown == null)
            {
                return null;
            }

            return _mailAddress;
        }
        set => CheckAndSetValue(ref _mailAddress, value);
    }
}
