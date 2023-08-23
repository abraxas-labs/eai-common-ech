// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0058_5_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Meldungsrahmen (eCH-0058)
/// Fachliche Quitungen, welche zu einer Meldung an den Liferanten als Antwort gesendet werden kann.
/// </summary>
[Serializable]
[JsonObject("eventReport")]
[XmlRoot(ElementName = "eventReport", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0058/5")]
public class EventReport
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string HeaderNullValidateExceptionMessage = "Header is not valid! Notice is required";
    private const string InfoNullValidateExceptionMessage = "Info is not valid! Notice is required";

    private Header _header;
    private Info _info;

    public EventReport()
    {
        Xmlns.Add("eCH-0058", "http://www.ech.ch/xmlns/eCH-0058/5");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode generiert das EventInfo Objekt mit den nötigen Werten.
    /// </summary>
    /// <param name="header">Field is reqired.</param>
    /// <param name="info">Field is reqired.</param>
    /// <returns>Report.</returns>
    public static EventReport Create(Header header, Info info)
    {
        return new EventReport()
        {
            Header = header,
            Info = info
        };
    }

    [JsonProperty("header")]
    [XmlElement(ElementName = "header", Order = 1)]
    public Header Header
    {
        get { return _header; }

        set
        {
            _header = value ?? throw new XmlSchemaValidationException(HeaderNullValidateExceptionMessage);
        }
    }

    [JsonProperty("info")]
    [XmlElement(ElementName = "info", Order = 2)]
    public Info Info
    {
        get { return _info; }

        set
        {
            _info = value ?? throw new XmlSchemaValidationException(InfoNullValidateExceptionMessage);
        }
    }
}
