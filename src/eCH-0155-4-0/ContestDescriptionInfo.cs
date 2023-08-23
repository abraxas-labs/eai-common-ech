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
///     Bezeichnung des Urnengangs von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("contestDescriptionInfo")]
[XmlRoot(ElementName = "contestDescriptionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ContestDescriptionInfo : FieldValueChecker<ContestDescriptionInfo>
{
    private const string ContestDescriptionNullValidateExceptionMessage =
        "ContestDescription is not valid! ContestDescription is required";

    private const string ContestDescriptionOutOfRangeValidateExceptionMessage =
        "ContestDescription is not valid! ContestDescription has minimal leght of 1 and maximal length of 100";

    private string _contestDescription;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ContestDescriptionInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMaxLength(2)]
    [JsonProperty("language")]
    [XmlElement(ElementName = "language", Order = 1)]
    public string Language { get; set; }

    [JsonProperty("contestDescription")]
    [XmlElement(ElementName = "contestDescription", Order = 2)]
    public string ContestDescription
    {
        get => _contestDescription;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(ContestDescriptionNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 100)
            {
                throw new XmlSchemaValidationException(ContestDescriptionOutOfRangeValidateExceptionMessage);
            }

            _contestDescription = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="contestDescription">Field is required.</param>
    /// <returns>ContestDescriptionInfo.</returns>
    public static ContestDescriptionInfo Create(string language, string contestDescription)
    {
        return new ContestDescriptionInfo
        {
            Language = language,
            ContestDescription = contestDescription
        };
    }
}
