// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_4_0;
using Newtonsoft.Json;

namespace eCH_0159_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0159).
/// </summary>
[Serializable]
[JsonObject("voteInformation")]
[XmlRoot(ElementName = "voteInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0159/4")]
public class VoteInformation : FieldValueChecker<VoteInformation>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private VoteType _voteType;
    private Ballot[] _ballot;

    public VoteInformation()
    {
        Xmlns.Add("eCH-0159", "http://www.ech.ch/xmlns/eCH-0159/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="voteType">Field is required.</param>
    /// <param name="ballot">Field is required.</param>
    /// <returns>VoteInformation.</returns>
    public static VoteInformation Create(VoteType voteType, Ballot[] ballot)
    {
        return new VoteInformation
        {
            Vote = voteType,
            Ballot = ballot
        };
    }

    [FieldRequired]
    [JsonProperty("vote")]
    [XmlElement(ElementName = "vote", Order = 1)]
    public VoteType Vote
    {
        get => _voteType;
        set => _voteType = value;
    }

    [FieldRequired]
    [JsonProperty("ballot")]
    [XmlElement(ElementName = "ballot", Order = 2)]
    public Ballot[] Ballot
    {
        get => _ballot;
        set => _ballot = value;
    }
}
