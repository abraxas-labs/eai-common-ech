// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Abstimmung.
/// </summary>
[Serializable]
[JsonObject("vote")]
[XmlRoot(ElementName = "vote", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class VoteType : FieldValueChecker<VoteType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _voteIdentification;
    private string _domainOfInfluenceIdentification;
    private VoteDescriptionInformationType _voteDescription;

    public VoteType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 50)]
    [JsonProperty("voteIdentification")]
    [XmlElement(ElementName = "voteIdentification", Order = 1)]
    public string VoteIdentification
    {
        get => _voteIdentification;
        set => CheckAndSetValue(ref _voteIdentification, value);
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 50)]
    [JsonProperty("domainOfInfluenceIdentification")]
    [XmlElement(ElementName = "domainOfInfluenceIdentification", Order = 2)]
    public string DomainOfInfluenceIdentification
    {
        get => _domainOfInfluenceIdentification;
        set => CheckAndSetValue(ref _domainOfInfluenceIdentification, value);
    }

    [FieldRequired]
    [JsonProperty("voteDescription")]
    [XmlElement(ElementName = "voteDescription", Order = 3)]
    public VoteDescriptionInformationType VoteDescription
    {
        get => _voteDescription;
        set => CheckAndSetValue(ref _voteDescription, value);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="voteIdentification">Has dependency to domainOfInfluenceType.</param>
    /// <param name="domainOfInfluenceIdentification">Field is reqired.</param>
    /// <param name="voteDescription">Field is optional.</param>
    /// <returns>Vote.</returns>
    public static VoteType Create(string voteIdentification, string domainOfInfluenceIdentification,
        VoteDescriptionInformationType voteDescription)
    {
        return new VoteType
        {
            VoteIdentification = voteIdentification,
            DomainOfInfluenceIdentification = domainOfInfluenceIdentification,
            VoteDescription = voteDescription
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="voteIdentification">Has dependency to domainOfInfluenceType.</param>
    /// <param name="domainOfInfluence">Field is reqired.</param>
    /// <returns>Vote.</returns>
    public static VoteType Create(string voteIdentification, string domainOfInfluence)
    {
        return new VoteType
        {
            VoteIdentification = voteIdentification,
            DomainOfInfluenceIdentification = domainOfInfluence
        };
    }
}
