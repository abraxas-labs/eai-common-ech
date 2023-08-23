// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("voterListType")]
[XmlRoot(ElementName = "voterListType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class VoterListType : FieldValueChecker<VoterListType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private AuthorityType _reportingAuthority;
    private ContestType _contest;
    private uint _numberOfVoters;

    public VoterListType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
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
    [JsonProperty("numberOfVoters")]
    [XmlElement(ElementName = "numberOfVoters", Order = 3)]
    public uint NumberOfVoters
    {
        get => _numberOfVoters;
        set => CheckAndSetValue(ref _numberOfVoters, value);
    }

    [FieldRequired]
    [JsonProperty("voter")]
    [XmlElement(ElementName = "voter", Order = 4)]
    public List<VotingPersonType> Voter { get; set; }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingAuthority">Field is required.</param>
    /// <param name="contest">Field is optional.</param>
    /// <param name="numberOfVoters">Field is required.</param>
    /// <param name="voter">Field is required.</param>
    /// <returns>VoterList.</returns>
    public static VoterListType Create(AuthorityType reportingAuthority, ContestType contest, uint numberOfVoters, List<VotingPersonType> voter)
    {
        return new VoterListType
        {
            ReportingAuthority = reportingAuthority,
            Contest = contest,
            NumberOfVoters = numberOfVoters,
            Voter = voter
        };
    }
}
