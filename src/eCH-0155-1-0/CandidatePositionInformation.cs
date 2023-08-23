// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Position des Kandidaten auf der Liste Kandidat
///     Attribut geführt.
/// </summary>
[Serializable]
[JsonObject("candidatePositionInformation")]
[XmlRoot(ElementName = "candidatePositionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class CandidatePositionInformation
{
    private const string PositionOnListOutOfRangeValidateExceptionMessage =
        "PositionOnList is not valid! PositionOnList has to be a positive number";

    private const string CandidateReferenceOnPositionNullValidateExceptionMessage =
        "CandidateReferenceOnPosition is not valid! CandidateReferenceOnPosition is required";

    private const string CandidateReferenceOnPositionOutOfRangeValidateExceptionMessage =
            "CandidateReferenceOnPosition is not valid! CandidateReferenceOnPosition has minimal leght of 1 and maximal length of 6";

    private string _candidateReferenceOnPosition;

    private int _positionOnList;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public CandidatePositionInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("positionOnList")]
    [XmlElement(ElementName = "positionOnList")]
    public int PositionOnList
    {
        get => _positionOnList;
        set
        {
            if (value < 0)
            {
                throw new XmlSchemaValidationException(PositionOnListOutOfRangeValidateExceptionMessage);
            }

            _positionOnList = value;
        }
    }

    [JsonProperty("candidateReferenceOnPosition")]
    [XmlElement(ElementName = "candidateReferenceOnPosition")]
    public string CandidateReferenceOnPosition
    {
        get => _candidateReferenceOnPosition;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(CandidateReferenceOnPositionNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 6)
            {
                throw new XmlSchemaValidationException(
                    CandidateReferenceOnPositionOutOfRangeValidateExceptionMessage);
            }

            _candidateReferenceOnPosition = value;
        }
    }

    [JsonProperty("candidateTextOnPosition")]
    [XmlElement(ElementName = "candidateTextOnPosition")]
    public CandidateTextInformation CandidateTextOnPosition { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CandidateTextOnPositionSpecified => CandidateTextOnPosition != null;

    [JsonProperty("checkingNumber")]
    [XmlElement(ElementName = "checkingNumber")]
    public string CheckingNumber { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool CheckingNumberSpecified => !string.IsNullOrEmpty(CheckingNumber);

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt nötigen alle Werte.
    /// </summary>
    /// <param name="positionOnList">Field is required.</param>
    /// <param name="candidateReferenceOnPosition">Field is required.</param>
    /// <param name="candidateTextOnPosition">Field is required.</param>
    /// <returns>CandidatePositionInformation.</returns>
    public static CandidatePositionInformation Create(int positionOnList, string candidateReferenceOnPosition,
         CandidateTextInformation candidateTextOnPosition)
    {
        return new CandidatePositionInformation
        {
            PositionOnList = positionOnList,
            CandidateReferenceOnPosition = candidateReferenceOnPosition,
            CandidateTextOnPosition = candidateTextOnPosition
        };
    }
}
