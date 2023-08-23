// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Electionenbezeichnung Bezeichnung von maximal 100 Zeichen und optionale Kurzbezeichnung
///     von maximal 12 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("electionDescriptionInfo")]
[XmlRoot(ElementName = "electionDescriptionInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ElectionDescriptionInfoType : FieldValueChecker<ElectionDescriptionInfoType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _language;
    private string _electionDescription;
    private string _electionDescriptionShort;

    public ElectionDescriptionInfoType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMaxLength(2)]
    [JsonProperty("language")]
    [XmlElement(ElementName = "language", Order = 1)]
    public string Language
    {
        get => _language;
        set => CheckAndSetValue(ref _language, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("electionDescriptionShort")]
    [XmlElement(ElementName = "electionDescriptionShort", Order = 2)]
    public string ElectionDescriptionShort
    {
        get => _electionDescriptionShort;
        set => CheckAndSetValue(ref _electionDescriptionShort, value);
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 255)]
    [JsonProperty("electionDescription")]
    [XmlElement(ElementName = "electionDescription", Order = 3)]
    public string ElectionDescription
    {
        get => _electionDescription;
        set => CheckAndSetValue(ref _electionDescription, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ElectionDescriptionShortSpecified => !string.IsNullOrEmpty(ElectionDescriptionShort);

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="electionDescription">Field is required.</param>
    /// <param name="electionDescriptionShort">Field is optional.</param>
    /// <returns>ElectionDescriptionInfo.</returns>
    public static ElectionDescriptionInfoType Create(string language, string electionDescription,
        string electionDescriptionShort = null)
    {
        return new ElectionDescriptionInfoType
        {
            Language = language,
            ElectionDescription = electionDescription,
            ElectionDescriptionShort = electionDescriptionShort
        };
    }
}
