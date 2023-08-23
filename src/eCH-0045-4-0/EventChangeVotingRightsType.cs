// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("eventChangeVotingRightsType")]
[XmlRoot(ElementName = "eventChangeVotingRightsType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class EventChangeVotingRightsType : FieldValueChecker<EventChangeVotingRightsType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();
    private AuthorityType _reportingAuthority;
    private ContestType _contest;
    private Voter _voter;

    public EventChangeVotingRightsType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingAuthority">Field is required.</param>
    /// <param name="contest">Field is optional.</param>
    /// <param name="voter">Field is required.</param>
    /// <returns>EventChangeVotingRights.</returns>
    public static EventChangeVotingRightsType Create(AuthorityType reportingAuthority, ContestType contest, Voter voter)
    {
        return new EventChangeVotingRightsType
        {
            ReportingAuthority = reportingAuthority,
            Voter = voter
        };
    }

    [FieldRequired]
    [JsonProperty("reportingAuthority")]
    [XmlElement(ElementName = "reportingAuthority", Order = 1)]
    public AuthorityType ReportingAuthority
    {
        get => _reportingAuthority;
        set => CheckAndSetValue(ref _reportingAuthority, value);
    }

    [JsonProperty("contest")]
    [XmlElement(ElementName = "contest", Order = 2)]
    public ContestType Contest
    {
        get => _contest;
        set => CheckAndSetValue(ref _contest, value);
    }

    [FieldRequired]
    [JsonProperty("voter")]
    [XmlElement(ElementName = "voter", Order = 3)]
    public Voter Voter
    {
        get => _voter;
        set => CheckAndSetValue(ref _voter, value);
    }
}
