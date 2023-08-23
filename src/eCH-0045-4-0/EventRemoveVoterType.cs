// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("eventAddVoterType")]
[XmlRoot(ElementName = "eventAddVoterType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class EventRemoveVoterType : FieldValueChecker<EventRemoveVoterType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private AuthorityType _reportingAuthority;
    private ContestType _contest;
    private PersonIdentification _voter;

    public EventRemoveVoterType()
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
    /// <returns>EventRemoveVoter.</returns>
    public static EventRemoveVoterType Create(AuthorityType reportingAuthority, ContestType contest, PersonIdentification voter)
    {
        return new EventRemoveVoterType
        {
            ReportingAuthority = reportingAuthority,
            Contest = contest,
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
    public PersonIdentification Voter
    {
        get => _voter;
        set => CheckAndSetValue(ref _voter, value);
    }
}
