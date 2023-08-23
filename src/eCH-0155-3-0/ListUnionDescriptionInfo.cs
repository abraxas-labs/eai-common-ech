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
///     Beschreibung einer Listenverbindung als Freitext von maximal 255 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("listUnionDescriptionInfo")]
[XmlRoot(ElementName = "listUnionDescriptionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class ListUnionDescriptionInfo
{
    private const string ListUnionDescriptionNullValidateExceptionMessage =
        "ListUnionDescription is not valid! ListUnionDescription is required";

    private const string ListUnionDescriptionOutOfRangeValidateExceptionMessage =
        "ListUnionDescription is not valid! ListUnionDescription has minimal leght of 1 and maximal length of 255";

    private string _listUnionDescription;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ListUnionDescriptionInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("language")]
    [XmlElement(ElementName = "language")]
    public Language Language { get; set; }

    [JsonProperty("listUnionDescription")]
    [XmlElement(ElementName = "listUnionDescription")]
    public string ListUnionDescription
    {
        get => _listUnionDescription;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(ListUnionDescriptionNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 255)
            {
                throw new XmlSchemaValidationException(ListUnionDescriptionOutOfRangeValidateExceptionMessage);
            }

            _listUnionDescription = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="listUnionDescription">Field is required.</param>
    /// <returns>ListUnionDescriptionInfo.</returns>
    public static ListUnionDescriptionInfo Create(Language language, string listUnionDescription)
    {
        return new ListUnionDescriptionInfo
        {
            Language = language,
            ListUnionDescription = listUnionDescription
        };
    }
}
