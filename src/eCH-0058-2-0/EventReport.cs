// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0058_2_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Meldungsrahmen (eCH-0058)
///     Fachliche Quitungen, welche zu einer Meldung an den Liferanten als Antwort gesendet werden kann.
/// </summary>
[Serializable]
[JsonObject("eventReport")]
[XmlRoot(ElementName = "eventReport", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0058/2")]
public class EventReport
{
    private const string HeaderNullValidateExceptionMessage = "Header is not valid! Notice is required";
    private const string InfoNullValidateExceptionMessage = "Info is not valid! Notice is required";

    private Header _header;
    private Info _info;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public EventReport()
    {
        Xmlns.Add("eCH-0058", "http://www.ech.ch/xmlns/eCH-0058/2");
    }

    [JsonProperty("header")]
    [XmlElement(ElementName = "header")]
    public Header Header
    {
        get => _header;
        set => _header = value ?? throw new XmlSchemaValidationException(HeaderNullValidateExceptionMessage);
    }

    [JsonProperty("info")]
    [XmlElement(ElementName = "info")]
    public Info Info
    {
        get => _info;
        set => _info = value ?? throw new XmlSchemaValidationException(InfoNullValidateExceptionMessage);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode generiert das EventInfo Objekt mit den nötigen Werten.
    /// </summary>
    /// <param name="header">Field is reqired.</param>
    /// <param name="info">Field is reqired.</param>
    /// <returns>Report.</returns>
    public static EventReport Create(Header header, Info info)
    {
        return new EventReport
        {
            Header = header,
            Info = info
        };
    }
}
