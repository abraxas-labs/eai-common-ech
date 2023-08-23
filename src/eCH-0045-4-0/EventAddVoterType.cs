// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("eventAddVoterType")]
[XmlRoot(ElementName = "eventAddVoterType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class EventAddVoterType : FieldValueChecker<EventAddVoterType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private AuthorityType _reportingAuthority;
    private ContestType _contest;
    private VotingPersonType _votingPerson;

    public EventAddVoterType()
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
    /// <returns>EventAddVoter.</returns>
    public static EventAddVoterType Create(AuthorityType reportingAuthority, ContestType contest, VotingPersonType voter)
    {
        return new EventAddVoterType
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
    public VotingPersonType Voter
    {
        get => _votingPerson;
        set => CheckAndSetValue(ref _votingPerson, value);
    }
}
