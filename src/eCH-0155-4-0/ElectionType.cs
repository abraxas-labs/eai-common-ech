// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Die Wahlelectione enthält die Information welche Kandidaten für ein Amt gewählt werden können. In
///     spezifischen Fällen – z.B. bei Majorzwahlen – kann es sein, dass diese Kandidaten nicht
///     explizit geliefert werden.
/// </summary>
[Serializable]
[JsonObject("election")]
[XmlRoot(ElementName = "election", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ElectionType : FieldValueChecker<ElectionType>
{
    private string _electionIdentification;
    private TypeOfElectionType _typeOfElection;
    private uint _electionPosition;
    private int _numberOfMandates;
    private List<ReferencedElection> _referencedElection = new();

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ElectionType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 50)]
    [JsonProperty("electionIdentification")]
    [XmlElement(ElementName = "electionIdentification", Order = 1)]
    public string ElectionIdentification
    {
        get => _electionIdentification;
        set => CheckAndSetValue(ref _electionIdentification, value);
    }

    [FieldRequired]
    [JsonProperty("typeOfElection")]
    [XmlElement(ElementName = "typeOfElection", Order = 2)]
    public TypeOfElectionType TypeOfElection
    {
        get => _typeOfElection;
        set => CheckAndSetValue(ref _typeOfElection, value);
    }

    [FieldRequired]
    [JsonProperty("electionPosition")]
    [XmlElement(ElementName = "electionPosition", Order = 3)]
    public uint ElectionPosition
    {
        get => _electionPosition;
        set => CheckAndSetValue(ref _electionPosition, value);
    }

    [JsonProperty("electionDescription")]
    [XmlElement(ElementName = "electionDescription", Order = 4)]
    public ElectionDescriptionInformationType ElectionDescription { get; set; }

    [FieldRequired]
    [JsonProperty("numberOfMandates")]
    [XmlElement(ElementName = "numberOfMandates", Order = 5)]
    public int NumberOfMandates
    {
        get => _numberOfMandates;
        set => CheckAndSetValue(ref _numberOfMandates, value);
    }

    [JsonProperty("referencedElection")]
    [XmlElement(ElementName = "referencedElection", Order = 6)]
    public List<ReferencedElection> ReferencedElection
    {
        get => _referencedElection;
        set => CheckAndSetValue(ref _referencedElection, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ElectionDescriptionSpecified => ElectionDescription != null;

    [JsonIgnore]
    [XmlIgnore]
    public bool ReferencedElectionSpecified => ReferencedElection != null && ReferencedElection.Any();

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="electionIdentification">Field is required.</param>
    /// <param name="typeOfElection">Field is required.</param>
    /// <param name="electionPosition">Field is required.</param>
    /// <param name="electionDescription">Field is optional.</param>
    /// <param name="numberOfMandates">Field is required.</param>
    /// <param name="referencedElection">Field is optional.</param>
    /// <returns>Election.</returns>
    public static ElectionType Create(string electionIdentification, TypeOfElectionType typeOfElection, uint electionPosition,
        ElectionDescriptionInformationType electionDescription, int numberOfMandates, List<ReferencedElection> referencedElection)
    {
        return new ElectionType
        {
            ElectionIdentification = electionIdentification,
            TypeOfElection = typeOfElection,
            ElectionPosition = electionPosition,
            ElectionDescription = electionDescription,
            NumberOfMandates = numberOfMandates,
            ReferencedElection = referencedElection
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="electionIdentification">Field is required.</param>
    /// <param name="typeOfElection">Field is required.</param>
    /// <param name="numberOfMandates">Field is required.</param>
    /// <returns>Election.</returns>
    public static ElectionType Create(string electionIdentification, TypeOfElectionType typeOfElection, int numberOfMandates)
    {
        return new ElectionType
        {
            ElectionIdentification = electionIdentification,
            TypeOfElection = typeOfElection,
            NumberOfMandates = numberOfMandates
        };
    }
}
