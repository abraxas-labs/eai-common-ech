// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Linq;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_4_0;
using Newtonsoft.Json;

namespace eCH_0157_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Bei der Initiallieferung werden von der Wahlbehörde die Angaben zu allen Kandidaten und allen Listen an das
///     eVoting-System geliefert.
///     Bei den Kandidaten und Listen werden alle gemäss [eCH-0155] definierten Attribute geliefert. Sind
///     Listenverbindungen oder Nebenwahlen
///     vorhanden, so werden diese als Beziehungen zwischen den entsprechenden Listen geliefert.
/// </summary>
[Serializable]
[JsonObject("electionInformationType")]
[XmlRoot(ElementName = "electionInformationType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0157/4")]
public class ElectionInformationType : FieldValueChecker<ElectionInformationType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ElectionType _election;
    private CandidateType[] _candidate;
    private ListType[] _list;
    private ListUnionTypeType[] _listUnion;
    private ExtensionType _extension;

    public ElectionInformationType()
    {
        Xmlns.Add("eCH-0157", "http://www.ech.ch/xmlns/eCH-0157/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="election">Field is required.</param>
    /// <param name="candidate">Field is optional.</param>
    /// <param name="list">Field is optional.</param>
    /// <param name="listUnion">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>ElectionInformationType.</returns>
    public static ElectionInformationType Create(ElectionType election, CandidateType[] candidate = null, ListType[] list = null, ListUnionTypeType[] listUnion = null, ExtensionType extension = null)
    {
        return new ElectionInformationType
        {
            Election = election,
            Candidate = candidate,
            List = list,
            ListUnion = listUnion,
            Extension = extension
        };
    }

    [FieldRequired]
    [JsonProperty("election")]
    [XmlElement(ElementName = "election", Order = 1)]
    public ElectionType Election
    {
        get => _election;
        set => CheckAndSetValue(ref _election, value);
    }

    [JsonProperty("candidate")]
    [XmlElement(ElementName = "candidate", Order = 2)]
    public CandidateType[] Candidate
    {
        get => _candidate;
        set => _candidate = value;
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CandidateSpecified => Candidate != null && Candidate.Any();

    [JsonProperty("list")]
    [XmlElement(ElementName = "list", Order = 3)]
    public ListType[] List
    {
        get => _list;
        set => _list = value;
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ListSpecified => List != null && List.Any();

    [JsonProperty("listUnion")]
    [XmlElement(ElementName = "listUnion", Order = 4)]
    public ListUnionTypeType[] ListUnion
    {
        get => _listUnion;
        set => _listUnion = value;
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ListUnionSpecified => ListUnion != null && ListUnion.Any();

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension", Order = 5)]
    public ExtensionType Extension
    {
        get => _extension;
        set => CheckAndSetValue(ref _extension, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
