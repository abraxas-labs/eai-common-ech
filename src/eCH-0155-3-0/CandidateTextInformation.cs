// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Bezeichnung des Kandidaten wie er auf der Wahlliste ausgewiesen werden soll.
/// </summary>
[Serializable]
[JsonObject("candidateTextInformation")]
[XmlRoot(ElementName = "candidateTextInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class CandidateTextInformation
{
    private const string CandidateTextNullValidateExceptionMessage =
        "CandidateTextInfo is not valid! CandidateTextInfo is required";

    private const string CandidateTextInfoOutOfRangeValidateExceptionMessage =
        "CandidateTextInfo is not valid! CandidateTextInfo needs adt least one item";

    private List<CandidateTextInfo> _candiateTextInfo;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public CandidateTextInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("candidateTextInfo")]
    [XmlElement(ElementName = "candidateTextInfo")]
    public List<CandidateTextInfo> CandidateTextInfo
    {
        get => _candiateTextInfo;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(CandidateTextNullValidateExceptionMessage);
            }

            if (value.Count < 1)
            {
                throw new XmlSchemaValidationException(CandidateTextInfoOutOfRangeValidateExceptionMessage);
            }

            _candiateTextInfo = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="candidateTextInfo">Field is required.</param>
    /// <returns>CandidateTextInformation.</returns>
    public static CandidateTextInformation Create(List<CandidateTextInfo> candidateTextInfo)
    {
        return new CandidateTextInformation
        {
            CandidateTextInfo = candidateTextInfo
        };
    }
}
