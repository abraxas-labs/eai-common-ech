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
[JsonObject("ElectionGroupBallotType")]
[XmlRoot(ElementName = "ElectionGroupBallotType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0157/4")]
public class ElectionGroupBallotType : FieldValueChecker<ElectionGroupBallotType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _electionGroupIdentification;
    private ElectionGroupDescriptionType _electionGroupDescription;
    private string _domainOfInfluenceIdentification;
    private uint? _electionGroupPosition;
    private ElectionInformationType[] _electionInformation;

    public ElectionGroupBallotType()
    {
        Xmlns.Add("eCH-0157", "http://www.ech.ch/xmlns/eCH-0157/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="domainOfInfluenceIdentification">Field is required.</param>
    /// <param name="electionInformation">Field is required.</param>
    /// <param name="electionGroupIdentification">Field is optional.</param>
    /// <param name="electionGroupDescription">Field is optional.</param>
    /// <param name="electionGroupPosition">Field is optional.</param>
    /// <returns>ElectionGroupBallot.</returns>
    public static ElectionGroupBallotType Create(string domainOfInfluenceIdentification, ElectionInformationType[] electionInformation,
        string electionGroupIdentification = null, ElectionGroupDescriptionType electionGroupDescription = null, uint? electionGroupPosition = null)
    {
        return new ElectionGroupBallotType
        {
            DomainOfInfluenceIdentification = domainOfInfluenceIdentification,
            ElectionInformation = electionInformation,
            ElectionGroupIdentification = electionGroupIdentification,
            ElectionGroupPosition = electionGroupPosition
        };
    }

    [FieldMinMaxLength(1, 50)]
    [JsonProperty("electionGroupIdentification")]
    [XmlElement(ElementName = "electionGroupIdentification", Order = 1)]
    public string ElectionGroupIdentification
    {
        get => _electionGroupIdentification;
        set => CheckAndSetValue(ref _electionGroupIdentification, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ElectionGroupIdentificationSpecified => string.IsNullOrWhiteSpace(ElectionGroupIdentification);

    [JsonProperty("electionGroupDescription")]
    [XmlElement(ElementName = "electionGroupDescription", Order = 2)]
    public ElectionGroupDescriptionType ElectionGroupDescription
    {
        get => _electionGroupDescription;
        set => CheckAndSetValue(ref _electionGroupDescription, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ElectionGroupDescriptionSpecified => ElectionGroupDescription != null && ElectionGroupDescription.ElectionDescriptionInfo != null && ElectionGroupDescription.ElectionDescriptionInfo.Any();

    [FieldRequired]
    [FieldMinMaxLength(1, 50)]
    [JsonProperty("domainOfInfluenceIdentification")]
    [XmlElement(ElementName = "domainOfInfluenceIdentification", Order = 3)]
    public string DomainOfInfluenceIdentification
    {
        get => _domainOfInfluenceIdentification;
        set => CheckAndSetValue(ref _domainOfInfluenceIdentification, value);
    }

    [JsonProperty("electionGroupPosition")]
    [XmlElement(DataType = "unsignedInt", ElementName = "electionGroupPosition", Order = 4)]
    public uint? ElectionGroupPosition
    {
        get => _electionGroupPosition;
        set => CheckAndSetValue(ref _electionGroupPosition, value);
    }

    public bool ElectionGroupPositionSpecified => ElectionGroupPosition.HasValue;

    [FieldRequired]
    [JsonProperty("electionInformation")]
    [XmlElement(ElementName = "electionInformation", Order = 5)]
    public ElectionInformationType[] ElectionInformation
    {
        get => _electionInformation;
        set => _electionInformation = value;
    }

    public bool ElectionInformationSpecified => ElectionInformation != null && ElectionInformation.Any();
}
