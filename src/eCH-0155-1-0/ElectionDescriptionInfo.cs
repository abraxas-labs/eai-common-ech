// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Electionenbezeichnung Bezeichnung von maximal 100 Zeichen und optionale Kurzbezeichnung
///     von maximal 12 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("electionDescriptionInfo")]
[XmlRoot(ElementName = "electionDescriptionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class ElectionDescriptionInfo
{
    private const string ElectionDescriptionNullValidateExceptionMessage =
        "TypeOfElection is not valid! TypeOfElection is required";

    private const string ElectionDescriptionOutOfRangeValidateExceptionMessage =
        "TypeOfElection is not valid! TypeOfElection has minimal leght of 1 and maximal length of 255";

    private string _electionDescription;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ElectionDescriptionInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("language")]
    [XmlElement(ElementName = "language")]
    public Language Language { get; set; }

    [JsonProperty("electionDescription")]
    [XmlElement(ElementName = "electionDescription")]
    public string ElectionDescription
    {
        get => _electionDescription;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(ElectionDescriptionNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 255)
            {
                throw new XmlSchemaValidationException(ElectionDescriptionOutOfRangeValidateExceptionMessage);
            }

            _electionDescription = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="electionDescription">Field is required.</param>
    /// <returns>ElectionDescriptionInfo.</returns>
    public static ElectionDescriptionInfo Create(Language language, string electionDescription)
    {
        return new ElectionDescriptionInfo
        {
            Language = language,
            ElectionDescription = electionDescription,
        };
    }
}
