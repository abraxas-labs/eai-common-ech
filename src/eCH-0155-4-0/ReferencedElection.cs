// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Verbindung zwischen Wahlen (Haupt-/Nebenwahl).
/// </summary>
[Serializable]
[JsonObject("referencedElection")]
[XmlRoot(ElementName = "referencedElection", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ReferencedElection
{
    private const string ReferencedElectionIdentificationNullValidateExceptionMessage =
        "ReferencedElectionIdentification is not valid! ReferencedElectionIdentification is required";

    private const string ReferencedElectionIdentificationOutOfRangeValidateExceptionMessage =
            "ReferencedElectionIdentification is not valid! ReferencedElectionIdentification has minimal leght of 1 and maximal length of 50";

    private string _referencedElectionIdentification;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ReferencedElection()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("referencedElection")]
    [XmlElement(ElementName = "referencedElection", Order = 1)]
    public string ReferencedElectionIdentification
    {
        get => _referencedElectionIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ReferencedElectionIdentificationNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(
                    ReferencedElectionIdentificationOutOfRangeValidateExceptionMessage);
            }

            _referencedElectionIdentification = value;
        }
    }

    [JsonProperty("electionRelation")]
    [XmlElement(ElementName = "electionRelation", Order = 2)]
    public ElectionRelationType ElectionRelation { get; set; }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="referencedElectionIdentification">Field is required.</param>
    /// <param name="electionRelation">Field is required.</param>
    /// <returns>ReferencedElection. </returns>
    public static ReferencedElection Create(string referencedElectionIdentification,
        ElectionRelationType electionRelation)
    {
        return new ReferencedElection
        {
            ReferencedElectionIdentification = referencedElectionIdentification,
            ElectionRelation = electionRelation
        };
    }
}
