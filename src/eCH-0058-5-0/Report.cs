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
/// Die Informationen können in beliebiger Form übermittelt werden.
/// </summary>
[Serializable]
[JsonObject("report")]
[XmlRoot(ElementName = "report", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0058/5")]
public class Report
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string NoticeNullValidateExceptionMessage = "Notice is not valid! Notice is required";

    private object _notice;

    public Report()
    {
        Xmlns.Add("eCH-0058", "http://www.ech.ch/xmlns/eCH-0058/5");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt das Notize Feld, da es Pflicht ist.
    /// Optional kann noch das Data - Feld mitgeliefert werden.
    /// </summary>
    /// <param name="notice">Field is reqired.</param>
    /// <param name="data">Field is optional.</param>
    /// <returns>Report.</returns>
    public static Report Create(object notice, object data = null)
    {
        return new Report()
        {
            Notice = notice,
            Data = data
        };
    }

    [JsonProperty("notice")]
    [XmlElement(ElementName = "notice", Order = 1)]
    public object Notice
    {
        get { return _notice; }

        set
        {
            _notice = value ?? throw new XmlSchemaValidationException(NoticeNullValidateExceptionMessage);
        }
    }

    [JsonProperty("data")]
    [XmlElement(ElementName = "data", Order = 2)]
    public object Data { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DataSpecified => Data != null;
}
