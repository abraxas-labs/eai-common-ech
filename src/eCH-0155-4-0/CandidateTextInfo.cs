﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Freitext 500 Zeichen, pro relevanter Sprache für Wahlliste.
/// </summary>
[Serializable]
[JsonObject("candidateTextInfo")]
[XmlRoot(ElementName = "candidateTextInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class CandidateTextInfo : FieldValueChecker<CandidateTextInfo>
{
    private const string CandidateTextNullValidateExceptionMessage =
        "CandidateText is not valid! CandidateText is required";

    private const string CandidateTextOutOfRangeValidateExceptionMessage =
        "CandidateText is not valid! CandidateText has minimal leght of 1 and maximal length of 500";

    private string _candiateText;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public CandidateTextInfo()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMaxLength(2)]
    [JsonProperty("language")]
    [XmlElement(ElementName = "language", Order = 1)]
    public string Language { get; set; }

    [JsonProperty("candidateText")]
    [XmlElement(ElementName = "candidateText", Order = 2)]
    public string CandidateText
    {
        get => _candiateText;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(CandidateTextNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 500)
            {
                throw new XmlSchemaValidationException(CandidateTextOutOfRangeValidateExceptionMessage);
            }

            _candiateText = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="language">Field is required.</param>
    /// <param name="candidateText">Field is required.</param>
    /// <returns>CandidateTextInfo.</returns>
    public static CandidateTextInfo Create(string language, string candidateText)
    {
        return new CandidateTextInfo
        {
            Language = language,
            CandidateText = candidateText
        };
    }
}
