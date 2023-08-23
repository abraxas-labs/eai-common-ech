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
///     Gebiet, in der Regel geografisch zusammenhängend, in welchem die Stimmen gezählt werden.
/// </summary>
[Serializable]
[JsonObject("candidateTextInfo")]
[XmlRoot(ElementName = "candidateTextInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class CountingCircleType
{
    private const string CountingCircleIdOutOfRangeValidateExceptionMessage =
        "DomainOfInfluenceId is not valid! DomainOfInfluenceId has minimal leght of 1 and maximal length of 50";

    private const string CountingCircleNameOutOfRangeValidateExceptionMessage =
            "DomainOfInfluenceName is not valid! DomainOfInfluenceName has minimal leght of 1 and maximal length of 100"
        ;

    private string _countingCircleId;
    private string _countingCircleName;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public CountingCircleType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("countingCircleId")]
    [XmlElement(ElementName = "countingCircleId")]
    public string CountingCircleId
    {
        get => _countingCircleId;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 50))
            {
                throw new XmlSchemaValidationException(CountingCircleIdOutOfRangeValidateExceptionMessage);
            }

            _countingCircleId = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountingCircleIdSpecified => !string.IsNullOrEmpty(CountingCircleId);

    [JsonProperty("countingCircleName")]
    [XmlElement(ElementName = "countingCircleName")]
    public string CountingCircleName
    {
        get => _countingCircleName;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 100))
            {
                throw new XmlSchemaValidationException(CountingCircleNameOutOfRangeValidateExceptionMessage);
            }

            _countingCircleName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CountingCircleNameSpecified => !string.IsNullOrEmpty(CountingCircleName);

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="countingCirlceId">Field can be empty.</param>
    /// <param name="countingCircleName">Field can be empty.</param>
    /// <returns>CountingCircleType.</returns>
    public static CountingCircleType Create(string countingCirlceId, string countingCircleName)
    {
        return new CountingCircleType
        {
            CountingCircleId = countingCirlceId,
            CountingCircleName = countingCircleName
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <returns>CountingCircleType.</returns>
    public static CountingCircleType Create()
    {
        return new CountingCircleType();
    }
}
