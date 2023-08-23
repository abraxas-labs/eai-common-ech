// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Abstimmungsfrage als Freitext von 700 Zeichen mit optionalem Titel von 100 Zeichen, pro relevanter Sprache.
/// </summary>
[Serializable]
[JsonObject("ballotQuestion")]
[XmlRoot(ElementName = "ballotQuestion", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class BallotQuestion
{
    private const string BallotQuestionNullValidateExceptionMessage =
        "BallotQuestionInfo is not valid! BallotQuestionInfo is required";

    private List<BallotQuestionInfo> _ballotQuestionInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public BallotQuestion()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("ballotQuestionInfo")]
    [XmlElement(ElementName = "ballotQuestionInfo", Order = 1)]
    public List<BallotQuestionInfo> BallotQuestionInfo
    {
        get => _ballotQuestionInfo;
        set
        {
            _ballotQuestionInfo = value ?? throw new XmlSchemaValidationException(BallotQuestionNullValidateExceptionMessage);
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
