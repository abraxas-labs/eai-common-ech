// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Meldegründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("messages")]
[XmlRoot(ElementName = "messages", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class BaseDeliveryMessage
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private List<EventBaseDelivery> _baseDeliveries;

    public BaseDeliveryMessage()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="baseDeliveries">Field is required.</param>
    /// <returns>BaseDeliveryMessage.</returns>
    public static BaseDeliveryMessage Create(List<EventBaseDelivery> baseDeliveries)
    {
        return new BaseDeliveryMessage()
        {
            Messages = baseDeliveries
        };
    }

    [JsonProperty("messages")]
    [XmlElement(ElementName = "messages")]
    public List<EventBaseDelivery> Messages
    {
        get { return _baseDeliveries; }
        set { _baseDeliveries = value; }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool MessagesSpecified => Messages != null && Messages.Count > 0;
}
