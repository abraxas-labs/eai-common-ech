// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Meldegründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("messages")]
[XmlRoot(ElementName = "messages", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class KeyExchangeMessage
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string MessagesNullValidateExceptionMessage = "Messages is not valid! Messages is required";

    private List<EventKeyExchange> _keyExchanges;

    public KeyExchangeMessage()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="keyExchanges">Field is required.</param>
    /// <returns>KeyExchangeMessage.</returns>
    public static KeyExchangeMessage Create(List<EventKeyExchange> keyExchanges)
    {
        return new KeyExchangeMessage()
        {
            Messages = keyExchanges
        };
    }

    [JsonProperty("messages")]
    [XmlElement(ElementName = "messages")]
    public List<EventKeyExchange> Messages
    {
        get { return _keyExchanges; }

        set
        {
            if (value == null || value.Count == 0)
            {
                throw new XmlSchemaValidationException(MessagesNullValidateExceptionMessage);
            }
            _keyExchanges = value;
        }
    }
}
