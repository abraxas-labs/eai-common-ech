// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Stichfrage als Freitext von 700 Zeichen mit optionalem Titel von 100 Zeichen und optionaler zweiter Stichfrage von
///     700 Zeichen,
///     pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("tieBreakQuestion")]
[XmlRoot(ElementName = "tieBreakQuestion", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class TieBreakQuestion
{
    private const string TieBreakQuestionNullValidateExceptionMessage =
        "TieBreakQuestionInfo is not valid! TieBreakQuestionInfo is required";

    private const string TieBreakQuestionInfoOutOfRangeValidateExceptionMessage =
        "TieBreakQuestionInfo is not valid! TieBreakQuestionInfo needs at least one item";

    private List<TieBreakQuestionInfo> _tieBreakQuestionInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public TieBreakQuestion()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("tieBreakQuestionInfo")]
    [XmlElement(ElementName = "tieBreakQuestionInfo")]
    public List<TieBreakQuestionInfo> TieBreakQuestionInfo
    {
        get => _tieBreakQuestionInfo;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(TieBreakQuestionNullValidateExceptionMessage);
            }

            if (value.Count < 1)
            {
                throw new XmlSchemaValidationException(TieBreakQuestionInfoOutOfRangeValidateExceptionMessage);
            }

            _tieBreakQuestionInfo = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="tieBreakQuestionInfo">Field is required.</param>
    /// <returns>TieBreakQuestionInformation.</returns>
    public static TieBreakQuestion Create(List<TieBreakQuestionInfo> tieBreakQuestionInfo)
    {
        return new TieBreakQuestion
        {
            TieBreakQuestionInfo = tieBreakQuestionInfo
        };
    }
}
