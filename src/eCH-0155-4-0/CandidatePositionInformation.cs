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
///     Position des Kandidaten auf der Liste Kandidat
///     Attribut geführt.
/// </summary>
[Serializable]
[JsonObject("candidatePositionInformation")]
[XmlRoot(ElementName = "candidatePositionInformation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class CandidatePositionInformation
{
    private const string PositionOnListOutOfRangeValidateExceptionMessage =
        "PositionOnList is not valid! PositionOnList has to be a positive number";

    private const string CandidateReferenceOnPositionNullValidateExceptionMessage =
        "CandidateReferenceOnPosition is not valid! CandidateReferenceOnPosition is required";

    private const string CandidateReferenceOnPositionOutOfRangeValidateExceptionMessage =
            "CandidateReferenceOnPosition is not valid! CandidateReferenceOnPosition has minimal leght of 1 and maximal length of 10"
        ;

    private const string CandidateIdentificationNullValidateExceptionMessage =
        "CandidateIdentification is not valid! CandidateIdentification is required";

    private const string CandidateIdentificationOutOfRangeValidateExceptionMessage =
            "CandidateIdentification is not valid! CandidateIdentification has minimal leght of 1 and maximal length of 50"
        ;

    private const string CandidateTextOnPositionNullValidateExceptionMessage =
        "CandidateTextOnPosition is not valid! CandidateTextOnPosition is required";

    private string _candidateIdentification;
    private string _candidateReferenceOnPosition;
    private CandidateTextInformation _candidateTextOnPosition;

    private int _positionOnList;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public CandidatePositionInformation()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("positionOnList")]
    [XmlElement(ElementName = "positionOnList", Order = 1)]
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
    [XmlElement(ElementName = "candidateReferenceOnPosition", Order = 2)]
    public string CandidateReferenceOnPosition
    {
        get => _candidateReferenceOnPosition;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(CandidateReferenceOnPositionNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 10)
            {
                throw new XmlSchemaValidationException(
                    CandidateReferenceOnPositionOutOfRangeValidateExceptionMessage);
            }

            _candidateReferenceOnPosition = value;
        }
    }

    [JsonProperty("candidateIdentification")]
    [XmlElement(ElementName = "candidateIdentification", Order = 3)]
    public string CandidateIdentification
    {
        get => _candidateIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(CandidateIdentificationNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(CandidateIdentificationOutOfRangeValidateExceptionMessage);
            }

            _candidateIdentification = value;
        }
    }

    [JsonProperty("candidateTextOnPosition")]
    [XmlElement(ElementName = "candidateTextOnPosition", Order = 4)]
    public CandidateTextInformation CandidateTextOnPosition
    {
        get => _candidateTextOnPosition;
        set => _candidateTextOnPosition =
            value ?? throw new XmlSchemaValidationException(CandidateTextOnPositionNullValidateExceptionMessage);
    }

    [JsonProperty("checkingNumber")]
    [XmlElement(ElementName = "checkingNumber", Order = 5)]
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
    /// <param name="candidateIdentification">Field is required.</param>
    /// <param name="candidateTextOnPosition">Field is required.</param>
    /// <returns>CandidatePositionInformation.</returns>
    public static CandidatePositionInformation Create(int positionOnList, string candidateReferenceOnPosition,
        string candidateIdentification, CandidateTextInformation candidateTextOnPosition)
    {
        return new CandidatePositionInformation
        {
            PositionOnList = positionOnList,
            CandidateReferenceOnPosition = candidateReferenceOnPosition,
            CandidateIdentification = candidateIdentification,
            CandidateTextOnPosition = candidateTextOnPosition
        };
    }
}
