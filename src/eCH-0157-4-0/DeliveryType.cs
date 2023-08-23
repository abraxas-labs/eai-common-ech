// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0058_5_0;
using Newtonsoft.Json;

namespace eCH_0157_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Bei der Initiallieferung werden von der Wahlbehörde die Angaben zu allen Kandidaten und allen Listen an das
///     eVoting-System geliefert.
///     Bei den Kandidaten und Listen werden alle gemäss [eCH-0155] definierten Attribute geliefert. Sind
///     Listenverbindungen oder Nebenwahlen
///     vorhanden, so werden diese als Beziehungen zwischen den entsprechenden Listen geliefert.
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "delivery", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0157/4")]
public class DeliveryType : FieldValueChecker<DeliveryType>
{
    [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
    public string xsiSchemaLocation = "http://www.ech.ch/xmlns/eCH-0157/4 http://www.ech.ch/xmlns/eCH-0157/4/eCH-0157-4-0.xsd";
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Header _deliveryHeader;
    private EventInitialDeliveryType _eventInitialDelivery;

    public DeliveryType()
    {
        Xmlns.Add("eCH-0157", "http://www.ech.ch/xmlns/eCH-0157/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle minimalen Werte.
    /// </summary>
    /// <param name="header">Field is optional.</param>
    /// <param name="eventInitialDelivery">Field is required.</param>
    /// <returns>DeliveryType.</returns>
    public static DeliveryType Create(Header header, EventInitialDeliveryType eventInitialDelivery)
    {
        return new DeliveryType
        {
            DeliveryHeader = header,
            InitialDelivery = eventInitialDelivery
        };
    }

    [JsonProperty("minorVersion")]
    [XmlAttribute(AttributeName = "minorVersion")]
    public int MinorVersion => 0;

    [FieldRequired]
    [JsonProperty("deliveryHeader")]
    [XmlElement(ElementName = "deliveryHeader", Order = 1)]
    public Header DeliveryHeader
    {
        get => _deliveryHeader;
        set => CheckAndSetValue(ref _deliveryHeader, value);
    }

    [FieldRequired]
    [JsonProperty("initialDelivery")]
    [XmlElement("initialDelivery", Order = 2)]
    public EventInitialDeliveryType InitialDelivery
    {
        get => _eventInitialDelivery;
        set => CheckAndSetValue(ref _eventInitialDelivery, value);
    }
}
