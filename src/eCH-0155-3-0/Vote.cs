// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Abstimmung.
/// </summary>
[Serializable]
[JsonObject("vote")]
[XmlRoot(ElementName = "vote", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class Vote
{
    private const string VoteIdentificationNullValidateExceptionMessage =
        "VoteIdentification is not valid! VoteIdentification is required";

    private const string VoteIdentificationOutOfRangeValidateExceptionMessage =
        "VoteIdentification is not valid! VoteIdentification has minimal leght of 1 and maximal length of 50";

    private const string DomainOfInfluenceNullValidateExceptionMessage =
        "DomainOfInfluence is not valid! DomainOfInfluence is required";

    private string _domainOfInfluence;

    private string _voteIdentification;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Vote()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("voteIdentification")]
    [XmlElement(ElementName = "voteIdentification")]
    public string VoteIdentification
    {
        get => _voteIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(VoteIdentificationNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(VoteIdentificationOutOfRangeValidateExceptionMessage);
            }

            _voteIdentification = value;
        }
    }

    [JsonProperty("domainOfInfluence")]
    [XmlElement(ElementName = "domainOfInfluence")]
    public string DomainOfInfluence
    {
        get => _domainOfInfluence;
        set => _domainOfInfluence =
            value ?? throw new XmlSchemaValidationException(DomainOfInfluenceNullValidateExceptionMessage);
    }

    [JsonProperty("voteDescription")]
    [XmlElement(ElementName = "voteDescription")]
    public VoteDescriptionInformation VoteDescription { get; set; }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="voteIdentification">Has dependency to domainOfInfluenceType.</param>
    /// <param name="domainOfInfluence">Field is reqired.</param>
    /// <param name="voteDescription">Field is optional.</param>
    /// <returns>Vote.</returns>
    public static Vote Create(string voteIdentification, string domainOfInfluence,
        VoteDescriptionInformation voteDescription)
    {
        return new Vote
        {
            VoteIdentification = voteIdentification,
            DomainOfInfluence = domainOfInfluence,
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
    public static Vote Create(string voteIdentification, string domainOfInfluence)
    {
        return new Vote
        {
            VoteIdentification = voteIdentification,
            DomainOfInfluence = domainOfInfluence
        };
    }
}
