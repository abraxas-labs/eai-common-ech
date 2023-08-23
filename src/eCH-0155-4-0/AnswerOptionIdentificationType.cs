// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
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
[JsonObject("answerOptionIdentificationType")]
[XmlRoot(ElementName = "answerOptionIdentificationType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class AnswerOptionIdentificationType : FieldValueChecker<AnswerOptionIdentificationType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _answerIdentification;
    private string _answerSequenceNumber;
    private List<AnswerTextInformationType> _answerTextInformation;

    public AnswerOptionIdentificationType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="answerIdentification">Field is required.</param>
    /// <param name="answerSequenceNumber">Field is required.</param>
    /// <param name="answerTextInformation">Field is required.</param>
    /// <returns>AnswerOptionIdentificationType.</returns>
    public static AnswerOptionIdentificationType Create(string answerIdentification, string answerSequenceNumber, List<AnswerTextInformationType> answerTextInformation)
    {
        return new AnswerOptionIdentificationType
        {
            AnswerIdentification = answerIdentification,
            AnswerSequenceNumber = answerSequenceNumber,
            AnswerTextInformation = answerTextInformation
        };
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 50)]
    [JsonProperty("answerIdentification")]
    [XmlElement(ElementName = "answerIdentification", Order = 1)]
    public string AnswerIdentification
    {
        get => _answerIdentification;
        set => CheckAndSetValue(ref _answerIdentification, value);
    }

    [FieldRequired]
    [JsonProperty("answerSequenceNumber")]
    [XmlElement(DataType = "nonNegativeInteger", ElementName = "answerSequenceNumber", Order = 2)]
    public string AnswerSequenceNumber
    {
        get => _answerSequenceNumber;
        set => CheckAndSetValue(ref _answerSequenceNumber, value);
    }

    [JsonProperty("answerTextInformation")]
    [XmlElement(ElementName = "answerTextInformation", Order = 3)]
    public List<AnswerTextInformationType> AnswerTextInformation
    {
        get => _answerTextInformation;
        set => CheckAndSetValue(ref _answerTextInformation, value);
    }
}
