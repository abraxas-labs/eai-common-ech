// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Helferklasse um die Choice-Node vom Ballot abzubilden.
/// </summary>
[Serializable]
[JsonObject("variantBallot")]
[XmlRoot(ElementName = "variantBallot", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class VariantBallot
{
    private const string QuestionInformationOutOfRangeValidateExceptionMessage =
        "QuestionInformation is not valid! QuestionInformation must contain at least 2 Items";

    private List<QuestionInformation> _questionInformation = new();
    private List<TieBreakInformation> _tieBreakInformation = new();

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public VariantBallot()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("questionInformation")]
    [XmlElement(ElementName = "questionInformation")]
    public List<QuestionInformation> QuestionInformation
    {
        get => _questionInformation;
        set
        {
            if (value.Count < 2)
            {
                throw new XmlSchemaValidationException(QuestionInformationOutOfRangeValidateExceptionMessage);
            }

            _questionInformation = value;
        }
    }

    [JsonProperty("tieBreakInformation")]
    [XmlElement(ElementName = "tieBreakInformation")]
    public List<TieBreakInformation> TieBreakInformation
    {
        get => _tieBreakInformation;
        set => _tieBreakInformation = value;
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TieBreakInformationSpecified => TieBreakInformation != null && TieBreakInformation.Any();

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="questionInformation">Field is required.</param>
    /// <returns>VariantBallot.</returns>
    public static VariantBallot Create(List<QuestionInformation> questionInformation)
    {
        return new VariantBallot
        {
            QuestionInformation = questionInformation
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="questionInformation">Field is required.</param>
    /// <param name="tieBreakInformation">Field is optional.</param>
    /// <returns>VariantBallot.</returns>
    public static VariantBallot Create(List<QuestionInformation> questionInformation,
        List<TieBreakInformation> tieBreakInformation)
    {
        return new VariantBallot
        {
            QuestionInformation = questionInformation,
            TieBreakInformation = tieBreakInformation
        };
    }
}
