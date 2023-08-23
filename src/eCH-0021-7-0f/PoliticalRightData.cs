// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Politische Rechte.
/// </summary>
[Serializable]
[JsonObject("politicalRightData")]
[XmlRoot(ElementName = "politicalRightData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class PoliticalRightData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public PoliticalRightData()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="restrictedVotingAndElectionRightFederation"></param>
    /// <returns>PoliticalRightData.</returns>
    public static PoliticalRightData Create(bool? restrictedVotingAndElectionRightFederation = null)
    {
        return new PoliticalRightData()
        {
            RestrictedVotingAndElectionRightFederation = restrictedVotingAndElectionRightFederation
        };
    }

    [JsonProperty("restrictedVotingAndElectionRightFederation")]
    [XmlElement(ElementName = "restrictedVotingAndElectionRightFederation")]
    public bool? RestrictedVotingAndElectionRightFederation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool RestrictedVotingAndElectionRightFederationSpecified => RestrictedVotingAndElectionRightFederation.HasValue;
}
