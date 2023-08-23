// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0058_5_0;
using Newtonsoft.Json;

namespace eCH_0228;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard Druckdatenaustausch Stimmrechtsausweis  (eCH-0228).
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "delivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public class Delivery : FieldValueChecker<Delivery>
{
    [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
    public string xsiSchemaLocation = "http://www.ech.ch/xmlns/eCH-0228/1 http://www.ech.ch/xmlns/eCH-0228/1/eCH-0228-1-0.xsd";
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Header _deliveryHeader;

    private VotingCardDelivery _votingCardDelivery;

    private string _minorVersionField;

    public Delivery()
    {
        Xmlns.Add("eCH-0228", "http://www.ech.ch/xmlns/eCH-0228/1");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle minimalen Werte.
    /// </summary>
    /// <param name="header">Field is required.</param>
    /// <param name="votingCardDelivery">Field is required.</param>
    /// <returns>Delivery.</returns>
    public static Delivery Create(Header header, VotingCardDelivery votingCardDelivery)
    {
        return new Delivery
        {
            DeliveryHeader = header,
            VotingCardDelivery = votingCardDelivery
        };
    }

    [FieldRequired]
    [JsonProperty("deliveryHeader")]
    [XmlElement(ElementName = "deliveryHeader")]
    public Header DeliveryHeader
    {
        get => _deliveryHeader;
        set => CheckAndSetValue(ref _deliveryHeader, value);
    }

    [FieldRequired]
    [JsonProperty("votingCardDelivery")]
    [XmlElement(ElementName = "votingCardDelivery")]
    public VotingCardDelivery VotingCardDelivery
    {
        get => _votingCardDelivery;
        set => CheckAndSetValue(ref _votingCardDelivery, value);
    }

    [JsonProperty("minorVersion")]
    [XmlElement(ElementName = "minorVersion")]
    public string MinorVersion
    {
        get => _minorVersionField;
        set => CheckAndSetValue(ref _minorVersionField, value);
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
