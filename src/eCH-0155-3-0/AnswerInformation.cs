// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Bezeichnung einer Abstimmung von maximal 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("answerInformation")]
[XmlRoot(ElementName = "answerInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class AnswerInformation
{
    private List<AnswerInfo> _answerInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public AnswerInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("answerType")]
    [XmlElement(ElementName = "answerType")]
    public AnswerType AnswerType { get; set; }

    [JsonProperty("answerInfo")]
    [XmlElement(ElementName = "answerInfo")]
    public List<AnswerInfo> AnswerInfo
    {
        get => _answerInfo;
        set
        {
            _answerInfo = value;
        }
    }

    [JsonIgnore][XmlIgnore] public bool AnswereInfoSpecified = false;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="answerType">Field is required.</param>
    /// <returns>AnswerInformation.</returns>
    public static AnswerInformation Create(AnswerType answerType)
    {
        return new AnswerInformation
        {
            AnswerType = answerType,
        };
    }
}
