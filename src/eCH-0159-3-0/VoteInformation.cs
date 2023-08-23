// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_3_0;
using Newtonsoft.Json;

namespace eCH_0159_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0159).
/// </summary>
[Serializable]
[JsonObject("voteInformation")]
[XmlRoot(ElementName = "voteInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0159/3")]
public class VoteInformation : FieldValueChecker<VoteInformation>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Vote _vote;
    private List<Ballot> _ballot;

    public VoteInformation()
    {
        Xmlns.Add("eCH-0159", "http://www.ech.ch/xmlns/eCH-0159/3");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="vote">Field is required.</param>
    /// /// <param name="ballot">Field is required.</param>
    /// <returns>VoteInformation.</returns>
    public static VoteInformation Create(Vote vote, List<Ballot> ballot)
    {
        return new VoteInformation
        {
            Vote = vote,
            Ballot = ballot
        };
    }

    [FieldRequired]
    [JsonProperty("vote")]
    [XmlElement(ElementName = "vote")]
    public Vote Vote
    {
        get => _vote;
        set => CheckAndSetValue(ref _vote, value);
    }

    [FieldRequired]
    [JsonProperty("ballot")]
    [XmlElement(ElementName = "ballot")]
    public List<Ballot> Ballot
    {
        get => _ballot;
        set => CheckAndSetValue(ref _ballot, value);
    }
}
