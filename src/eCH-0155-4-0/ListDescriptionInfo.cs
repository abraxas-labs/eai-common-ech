// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Listenbezeichnung Bezeichnung von maximal 100 Zeichen und optionale Kurzbezeichnung
///     von maximal 12 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("listDescriptionInfo")]
[XmlRoot(ElementName = "listDescriptionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ListDescriptionInfo : FieldValueChecker<ListDescriptionInfo>
{
    private const string ListDescriptionNullValidateExceptionMessage =
        "ListDescription is not valid! ListDescription is required";

    private const string ListDescriptionOutOfRangeValidateExceptionMessage =
        "ListDescription is not valid! ListDescription has minimal leght of 1 and maximal length of 100";

    private const string ListDescriptionShortOutOfRangeValidateExceptionMessage =
        "ListDescription is not valid! ListDescription has minimal leght of 1 and maximal length of 20";

    private string _listDescription;
    private string _listDescriptionShort;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ListDescriptionInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMaxLength(2)]
    [JsonProperty("language")]
    [XmlElement(ElementName = "language", Order = 1)]
    public string Language { get; set; }

    [JsonProperty("listDescriptionShort")]
    [XmlElement(ElementName = "listDescriptionShort", Order = 2)]
    public string ListDescriptionShort
    {
        get => _listDescriptionShort;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 100))
            {
                throw new XmlSchemaValidationException(ListDescriptionShortOutOfRangeValidateExceptionMessage);
            }

            _listDescriptionShort = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ListDescriptionShortSpecified => !string.IsNullOrEmpty(ListDescriptionShort);

    [JsonProperty("listDescription")]
    [XmlElement(ElementName = "listDescription", Order = 3)]
    public string ListDescription
    {
        get => _listDescription;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(ListDescriptionNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 100)
            {
                throw new XmlSchemaValidationException(ListDescriptionOutOfRangeValidateExceptionMessage);
            }

            _listDescription = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="listDescription">Field is required.</param>
    /// <param name="listDescriptionShort">Field is optional.</param>
    /// <returns>ListDescriptionInfo.</returns>
    public static ListDescriptionInfo Create(string language, string listDescription, string listDescriptionShort)
    {
        return new ListDescriptionInfo
        {
            Language = language,
            ListDescription = listDescription,
            ListDescriptionShort = listDescriptionShort
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="listDescription">Field is required.</param>
    /// <returns>ListDescriptionInfo.</returns>
    public static ListDescriptionInfo Create(string language, string listDescription)
    {
        return new ListDescriptionInfo
        {
            Language = language,
            ListDescription = listDescription
        };
    }
}
