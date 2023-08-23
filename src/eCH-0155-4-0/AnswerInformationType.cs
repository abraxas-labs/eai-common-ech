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
///     Bezeichnung einer Abstimmung von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("answerInformation")]
[XmlRoot(ElementName = "answerInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class AnswerInformationType : FieldValueChecker<AnswerInformationType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private AnswerType _answerType;
    private List<AnswerOptionIdentificationType> _answerOptionIdentification;

    public AnswerInformationType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [JsonProperty("answerType")]
    [XmlElement(ElementName = "answerType", Order = 1)]
    public AnswerType AnswerType
    {
        get => _answerType;
        set => CheckAndSetValue(ref _answerType, value);
    }

    [JsonProperty("answerOptionIdentification")]
    [XmlElement(ElementName = "answerOptionIdentification", Order = 2)]
    public List<AnswerOptionIdentificationType> AnswerOptionIdentification
    {
        get => _answerOptionIdentification;
        set => CheckAndSetValue(ref _answerOptionIdentification, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool AnswereInfoSpecified = false;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="answerType">Field is required.</param>
    /// <param name="answerOptionIdentification">Field is optional.</param>
    /// <returns>AnswerInformation.</returns>
    public static AnswerInformationType Create(AnswerType answerType, List<AnswerOptionIdentificationType> answerOptionIdentification = null)
    {
        return new AnswerInformationType
        {
            AnswerType = answerType,
            AnswerOptionIdentification = answerOptionIdentification
        };
    }
}
