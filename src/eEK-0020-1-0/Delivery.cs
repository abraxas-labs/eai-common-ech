// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eEK_0020_1_0;

/// <summary>
/// Vrsg Standard für Subject (Loganto)
/// An eCH-0020 angeleht, hat aber kleine differenzen.
/// Definiert die Schnittstelle LogantoMeldewesen Ereignissmeldung
/// Schnittstellenstandard Meldegründe Personenregister (eEK-0020).
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "delivery", IsNullable = true, Namespace = "http://xmlns.vrsg.ch/xmlns/eEK-0020/1")]
public class Delivery
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string DeliveryHeaderNullValidateExceptionMessage = "DeliveryHeader is not valid! DeliveryHeader is required";

    private Header _deliveryHeader;

    public Delivery()
    {
        Xmlns.Add("eEK-0020", "http://xmlns.vrsg.ch/xmlns/eEK-0020/1");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="deliveryHeader">Field is required.</param>
    /// <param name="baseDelivery"></param>
    /// <returns>Delivery.</returns>
    public static Delivery Create(Header deliveryHeader, EventBaseDelivery baseDelivery)
    {
        return new Delivery()
        {
            DeliveryHeader = deliveryHeader,
            BaseDelivery = baseDelivery
        };
    }

    [JsonProperty("version")]
    [XmlAttribute(AttributeName = "version")]
    public string Version
    {
        get { return "1.0"; }
        set { }
    }

    [JsonProperty("deliveryHeader")]
    [XmlElement(ElementName = "deliveryHeader")]
    public Header DeliveryHeader
    {
        get => _deliveryHeader;
        set => _deliveryHeader = value ?? throw new XmlSchemaValidationException(DeliveryHeaderNullValidateExceptionMessage);
    }

    [JsonProperty("delivery")]
    [XmlElement(ElementName = "delivery")]
    public EventBaseDelivery BaseDelivery { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BaseDeliverySpecified => BaseDelivery != null;
}
