// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("eventAddVoterType")]
[XmlRoot(ElementName = "eventAddVoterType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class EventAddVoter
{
    private const string ReportingAuthorityNullValidateExceptionMessage =
        "ReportingAuthority is not valid! ReportingAuthority is required";

    private const string VoterNullValidateExceptionMessage =
        "Voter is not valid! Voter is required";

    private Authority _reportingAuthority;
    private VotingPerson _votingPerson;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public EventAddVoter()
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
    public VotingPerson Voter
    {
        get => _votingPerson;
        set => _votingPerson = value ?? throw new XmlSchemaValidationException(VoterNullValidateExceptionMessage);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingAuthority">Field is required.</param>
    /// <param name="voter">Field is required.</param>
    /// <returns>EventAddVoter.</returns>
    public static EventAddVoter Create(Authority reportingAuthority, VotingPerson voter)
    {
        return new EventAddVoter
        {
            ReportingAuthority = reportingAuthority,
            Voter = voter
        };
    }
}
