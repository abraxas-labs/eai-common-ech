// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_3_0;
using Newtonsoft.Json;

namespace eCH_0157_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Kandidatenliste (eCH-0157)
///     Informationen zu einer Wahl.
/// </summary>
[Serializable]
[JsonObject("electionInformation")]
[XmlRoot(ElementName = "electionInformation", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0157/3")]
public class ElectionInformation : FieldValueChecker<ElectionInformation>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private Election _election;
    private List<Candidate> _candidate;
    private List<List> _list;
    private List<ListUnion> _listUnion;
    private ExtensionType _extension;

    public ElectionInformation()
    {
        Xmlns.Add("eCH-0157", "http://www.ech.ch/xmlns/eCH-0157/3");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="election">Field is required.</param>
    /// <param name="candidate">Field is optional.</param>
    /// <param name="list">Field is optional.</param>
    /// <param name="listUnion">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>ElectionInformation.</returns>
    public static ElectionInformation Create(Election election, List<Candidate> candidate = null, List<List> list = null, List<ListUnion> listUnion = null, ExtensionType extension = null)
    {
        return new ElectionInformation
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
    [XmlElement("election")]
    public Election Election
    {
        get => _election;
        set => CheckAndSetValue(ref _election, value);
    }

    [JsonProperty("candidate")]
    [XmlElement(ElementName = "candidate")]
    public List<Candidate> Candidate
    {
        get => _candidate;
        set => CheckAndSetValue(ref _candidate, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CandidateSpecified => Candidate != null && Candidate.Any();

    [JsonProperty("list")]
    [XmlElement(ElementName = "list")]
    public List<List> List
    {
        get => _list;
        set => CheckAndSetValue(ref _list, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ListSpecified => List != null && List.Any();

    [JsonProperty("listUnion")]
    [XmlElement(ElementName = "listUnion")]
    public List<ListUnion> ListUnion
    {
        get => _listUnion;
        set => CheckAndSetValue(ref _listUnion, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ListUnionSpecified => ListUnion != null && ListUnion.Any();

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public ExtensionType Extension
    {
        get => _extension;
        set => CheckAndSetValue(ref _extension, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
