// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Die Wahlelectione enthält die Information welche Kandidaten für ein Amt gewählt werden können. In
///     spezifischen Fällen – z.B. bei Majorzwahlen – kann es sein, dass diese Kandidaten nicht
///     explizit geliefert werden.
/// </summary>
[Serializable]
[JsonObject("election")]
[XmlRoot(ElementName = "election", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class Election
{
    private const string ElectionIdentificationNullValidateExceptionMessage =
        "ElectionIdentification is not valid! ElectionIdentification is required";

    private const string ElectionIdentificationOutOfRangeValidateExceptionMessage =
            "ElectionIdentification is not valid! ElectionIdentification has minimal leght of 1 and maximal length of 50";

    private const string DomainOfInfluenceNullValidateExceptionMessage =
        "DomainOfInfluence is not valid! DomainOfInfluence is required";

    private const string NumberOfMandatesOutOfRangeValidateExceptionMessage =
        "NumberOfMandates is not valid! NumberOfMandates has to be a positive number";

    private string _domainOfInfluence;

    private string _electionIdentification;
    private int _numberOfMandates;
    private List<ReferenceElection> _referenceElection = new();

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Election()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("electionIdentification")]
    [XmlElement(ElementName = "electionIdentification")]
    public string ElectionIdentification
    {
        get => _electionIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ElectionIdentificationNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(ElectionIdentificationOutOfRangeValidateExceptionMessage);
            }

            _electionIdentification = value;
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

    [JsonProperty("typeOfElection")]
    [XmlElement(ElementName = "typeOfElection")]
    public ElectionType TypeOfElection { get; set; }

    [JsonProperty("electionDescription")]
    [XmlElement(ElementName = "electionDescription")]
    public ElectionDescriptionInformation ElectionDescription { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ElectionDescriptionSpecified => ElectionDescription != null;

    [JsonProperty("numberOfMandates")]
    [XmlElement(ElementName = "numberOfMandates")]
    public int NumberOfMandates
    {
        get => _numberOfMandates;
        set
        {
            if (value < 0)
            {
                throw new XmlSchemaValidationException(NumberOfMandatesOutOfRangeValidateExceptionMessage);
            }

            _numberOfMandates = value;
        }
    }

    [JsonProperty("referenceElection")]
    [XmlElement(ElementName = "referenceElection")]
    public List<ReferenceElection> ReferenceElection
    {
        get => _referenceElection;
        set => _referenceElection = value;
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CandidatePositionSpecified => ReferenceElection != null && ReferenceElection.Any();

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="electionIdentification">Field is required.</param>
    /// <param name="domainOfInfluence">Field is required.</param>
    /// <param name="typeOfElection">Field is required.</param>
    /// <param name="electionDescription">Field is optional.</param>
    /// <param name="numberOfMandates">Field is required.</param>
    /// <param name="referenceElection">Field is optional.</param>
    /// <returns>Election.</returns>
    public static Election Create(string electionIdentification, string domainOfInfluence,
        ElectionType typeOfElection, ElectionDescriptionInformation electionDescription, int numberOfMandates,
        List<ReferenceElection> referenceElection)
    {
        return new Election
        {
            ElectionIdentification = electionIdentification,
            DomainOfInfluence = domainOfInfluence,
            TypeOfElection = typeOfElection,
            ElectionDescription = electionDescription,
            NumberOfMandates = numberOfMandates,
            ReferenceElection = referenceElection
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="electionIdentification">Field is required.</param>
    /// <param name="domainOfInfluence">Field is required.</param>
    /// <param name="typeOfElection">Field is required.</param>
    /// <param name="numberOfMandates">Field is required.</param>
    /// <returns>Election.</returns>
    public static Election Create(string electionIdentification, string domainOfInfluence,
        ElectionType typeOfElection, int numberOfMandates)
    {
        return new Election
        {
            ElectionIdentification = electionIdentification,
            DomainOfInfluence = domainOfInfluence,
            TypeOfElection = typeOfElection,
            NumberOfMandates = numberOfMandates
        };
    }
}
