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
///     Verbindung zwischen Wahlen (Haupt-/Nebenwahl).
/// </summary>
[Serializable]
[JsonObject("referenceElection")]
[XmlRoot(ElementName = "referenceElection", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class ReferenceElection
{
    private const string ReferenceElectionIdentificationNullValidateExceptionMessage =
        "ReferenceElectionIdentification is not valid! ReferenceElectionIdentification is required";

    private const string ReferenceElectionIdentificationOutOfRangeValidateExceptionMessage =
            "ReferenceElectionIdentification is not valid! ReferenceElectionIdentification has minimal leght of 1 and maximal length of 50"
        ;

    private string _referenceElectionIdentification;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public ReferenceElection()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("referenceElectionIdentification")]
    [XmlElement(ElementName = "referenceElectionIdentification")]
    public string ReferenceElectionIdentification
    {
        get => _referenceElectionIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ReferenceElectionIdentificationNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(
                    ReferenceElectionIdentificationOutOfRangeValidateExceptionMessage);
            }

            _referenceElectionIdentification = value;
        }
    }

    [JsonProperty("electeionRelation")]
    [XmlElement(ElementName = "electeionRelation")]
    public ElectionRelationType ElectionRelation { get; set; }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="referenceElectionIdentification">Field is required.</param>
    /// <param name="electionRelation">Field is required.</param>
    /// <returns>ReferenceElection. </returns>
    public static ReferenceElection Create(string referenceElectionIdentification,
        ElectionRelationType electionRelation)
    {
        return new ReferenceElection
        {
            ReferenceElectionIdentification = referenceElectionIdentification,
            ElectionRelation = electionRelation
        };
    }
}
