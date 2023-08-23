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
///     Antwortoptions Identifikation – answerOptionIdentification.
/// </summary>
[Serializable]
[JsonObject("answerTextInformationType")]
[XmlRoot(ElementName = "answerTextInformationType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class AnswerTextInformationType : FieldValueChecker<AnswerTextInformationType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _language;
    private string _answerText;

    public AnswerTextInformationType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="answerText">Field is required.</param>
    /// <returns>AnswerTextInformationType.</returns>
    public static AnswerTextInformationType Create(string language, string answerText)
    {
        return new AnswerTextInformationType
        {
            Language = language,
            AnswerText = answerText
        };
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

    [FieldRequired]
    [FieldMinMaxLength(1, 30)]
    [JsonProperty("answerText")]
    [XmlElement(ElementName = "answerText", Order = 2)]
    public string AnswerText
    {
        get => _answerText;
        set => CheckAndSetValue(ref _answerText, value);
    }
}
