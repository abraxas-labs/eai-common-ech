// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Berufsbezeichnung Freitext von maximal 250 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("occupationalTitleInfo")]
[XmlRoot(ElementName = "occupationalTitleInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class OccupationalTitleInfo
{
    private const string OccupationalTitleNullValidateExceptionMessage =
        "OccupationalTitle is not valid! OccupationalTitle is required";

    private const string OccupationalTitleOutOfRangeValidateExceptionMessage =
        "OccupationalTitle is not valid! OccupationalTitle has minimal leght of 1 and maximal length of 250";

    private string _occupationalTitle;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public OccupationalTitleInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("language")]
    [XmlElement(ElementName = "language")]
    public Language Language { get; set; }

    [JsonProperty("occupationalTitle")]
    [XmlElement(ElementName = "occupationalTitle")]
    public string OccupationalTitle
    {
        get => _occupationalTitle;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(OccupationalTitleNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 250)
            {
                throw new XmlSchemaValidationException(OccupationalTitleOutOfRangeValidateExceptionMessage);
            }

            _occupationalTitle = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="occupationalTitle">Field is required.</param>
    /// <returns>OccupationalTitleInfo.</returns>
    public static OccupationalTitleInfo Create(Language language, string occupationalTitle)
    {
        return new OccupationalTitleInfo
        {
            Language = language,
            OccupationalTitle = occupationalTitle
        };
    }
}
