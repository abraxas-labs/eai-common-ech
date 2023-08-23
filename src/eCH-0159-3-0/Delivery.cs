// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0058_5_0;
using Newtonsoft.Json;

namespace eCH_0159_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0159).
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "delivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0159/3")]
public class Delivery : FieldValueChecker<Delivery>
{
    [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
    public string xsiSchemaLocation = "http://www.ech.ch/xmlns/eCH-0159/3 http://www.ech.ch/xmlns/eCH-0159/3/eCH-0159-3-0.xsd";
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Header _deliveryHeader;
    private EventInitialDelivery _initialDelivery;

    public Delivery()
    {
        Xmlns.Add("eCH-0159", "http://www.ech.ch/xmlns/eCH-0159/3");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle minimalen Werte.
    /// </summary>
    /// <param name="header">Field is required.</param>
    /// <param name="eventInitialDelivery">Field is required.</param>
    /// <returns>Delivery.</returns>
    public static Delivery Create(Header header, EventInitialDelivery eventInitialDelivery)
    {
        return new Delivery
        {
            DeliveryHeader = header,
            InitialDelivery = eventInitialDelivery
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
    [JsonProperty("initialDelivery")]
    [XmlElement(ElementName = "initialDelivery")]
    public EventInitialDelivery InitialDelivery
    {
        get => _initialDelivery;
        set => CheckAndSetValue(ref _initialDelivery, value);
    }
}
