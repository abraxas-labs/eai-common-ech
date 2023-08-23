// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("voterListType")]
[XmlRoot(ElementName = "voterListType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class VoterList
{
    private const string ReportingAuthorityNullValidateExceptionMessage =
        "ReportingAuthority is not valid! ReportingAuthority is required";

    private const string NumberOfVotersNullValidateExceptionMessage =
        "NumberOfVoters is not valid! NumberOfVoters is required";

    private const string VoterNullValidateExceptionMessage =
        "Voter is not valid! Voter is required";

    private Authority _reportingAuthority;
    private int _numberOfVoters;
    private List<VotingPerson> _voter;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public VoterList()
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

    [JsonProperty("numberOfVoters")]
    [XmlElement(ElementName = "numberOfVoters")]
    public int NumberOfVoters
    {
        get => _numberOfVoters;
        set => _numberOfVoters = NumberOfVotersIsValid(value);
    }

    private int NumberOfVotersIsValid(int value)
    {
        if (value < 0)
        {
            throw new XmlSchemaValidationException(NumberOfVotersNullValidateExceptionMessage);
        }

        return value;
    }

    [JsonProperty("voter")]
    [XmlElement(ElementName = "voter")]
    public List<VotingPerson> Voter
    {
        get => _voter;
        set => _voter = VoterIsValid(value);
    }

    private List<VotingPerson> VoterIsValid(List<VotingPerson> value)
    {
        if (value == null || value.Count <= 0)
        {
            throw new XmlSchemaValidationException(VoterNullValidateExceptionMessage);
        }

        return value;
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportingAuthority">Field is required.</param>
    /// <param name="numberOfVoters">Field is required.</param>
    /// <param name="voter">Field is required.</param>
    /// <returns>VoterList.</returns>
    public static VoterList Create(Authority reportingAuthority, int numberOfVoters, List<VotingPerson> voter)
    {
        return new VoterList
        {
            ReportingAuthority = reportingAuthority,
            NumberOfVoters = numberOfVoters,
            Voter = voter
        };
    }
}
