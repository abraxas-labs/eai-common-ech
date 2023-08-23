// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("eventChangeVotingRightsType")]
[XmlRoot(ElementName = "eventChangeVotingRightsType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class EventChangeVotingRights
{
    private const string ReportingAuthorityNullValidateExceptionMessage =
        "ReportingAuthority not valid! ReportingAuthority is required";

    private const string VoterNullValidateExceptionMessage =
        "Voter not valid! Voter is required";

    private Authority _reportingAuthority;
    private Voter _voter;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public EventChangeVotingRights()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("reportingAuthority")]
    [XmlElement(ElementName = "reportingAuthority")]
    public Authority ReportingAuthority
    {
        get => _reportingAuthority;
        set => _reportingAuthority = value ?? throw new XmlSchemaValidationException(ReportingAuthorityNullValidateExceptionMessage);
    }

    [JsonProperty("voter")]
    [XmlElement(ElementName = "voter")]
    public Voter Voter
    {
        get => _voter;
        set => _voter = value ?? throw new XmlSchemaValidationException(VoterNullValidateExceptionMessage);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingAuthority">Field is required.</param>
    /// <param name="voter">Field is required.</param>
    /// <returns>EventChangeVotingRights.</returns>
    public static EventChangeVotingRights Create(Authority reportingAuthority, Voter voter)
    {
        return new EventChangeVotingRights
        {
            ReportingAuthority = reportingAuthority,
            Voter = voter
        };
    }
}
