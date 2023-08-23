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
///     Abstimmungsfrage als Freitext von 700 Zeichen mit optionalem Titel von 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("ballotQuestion")]
[XmlRoot(ElementName = "ballotQuestion", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class BallotQuestion
{
    private const string BallotQuestionNullValidateExceptionMessage =
        "BallotQuestionInfo is not valid! BallotQuestionInfo is required";

    private const string BallotQuestionInfoOutOfRangeValidateExceptionMessage =
        "BallotQuestionInfo is not valid! BallotQuestionInfo needs at least one item";

    private List<BallotQuestionInfo> _ballotQuestionInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public BallotQuestion()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("ballotQuestionInfo")]
    [XmlElement(ElementName = "ballotQuestionInfo")]
    public List<BallotQuestionInfo> BallotQuestionInfo
    {
        get => _ballotQuestionInfo;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(BallotQuestionNullValidateExceptionMessage);
            }

            if (value.Count < 1)
            {
                throw new XmlSchemaValidationException(BallotQuestionInfoOutOfRangeValidateExceptionMessage);
            }

            _ballotQuestionInfo = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="ballotQuestionInfo">Field is required.</param>
    /// <returns>BallotQuestionInformation.</returns>
    public static BallotQuestion Create(List<BallotQuestionInfo> ballotQuestionInfo)
    {
        return new BallotQuestion
        {
            BallotQuestionInfo = ballotQuestionInfo
        };
    }
}
