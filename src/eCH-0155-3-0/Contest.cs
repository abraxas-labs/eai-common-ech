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
///     Urnengang / Scrutin Die Informationen bezüglich der zulässigen Abstimmungskanäle (brieflich, elektronisch, Urne)
///     sowie der damit
///     verbunden Daten werden in der Regel bei der Initialisierung der eVotings-Systeme gesetzt und werden daher im Moment
///     in diesem Standard
///     nicht berücksichtigt. Es ist denkbar, dass diese Informationen berücksichtigt werden, wenn für den Austausch der
///     Logistikdaten auch ein
///     Standard erstellt werden sollte.
/// </summary>
[Serializable]
[JsonObject("contest")]
[XmlRoot(ElementName = "contest", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class Contest
{
    private const string ContestIdentificationNullValidateExceptionMessage =
        "ContestIdentification is not valid! ContestIdentification is required";

    private const string ContestIdentificationOutOfRangeValidateExceptionMessage =
        "ContestIdentification is not valid! ContestIdentification has minimal leght of 1 and maximal length of 50";

    private string _contestIdentification;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Contest()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("contestIdentification")]
    [XmlElement(ElementName = "contestIdentification")]
    public string ContestIdentification
    {
        get => _contestIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(ContestIdentificationNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(ContestIdentificationOutOfRangeValidateExceptionMessage);
            }

            _contestIdentification = value;
        }
    }

    [JsonProperty("contestDate")]
    [XmlElement(ElementName = "contestDate", DataType = "date")]
    public DateTime ContestDate { get; set; }

    [JsonProperty("contestDescription")]
    [XmlElement(ElementName = "contestDescription")]
    public ContestDescriptionInformation ContestDescription { get; set; }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="contestIdentification">Has dependency to domainOfInfluenceType.</param>
    /// <param name="contestDate">Field is reqired.</param>
    /// <param name="contestDescription">Field is optional.</param>
    /// <returns>Contest.</returns>
    public static Contest Create(string contestIdentification, DateTime contestDate,
        ContestDescriptionInformation contestDescription)
    {
        return new Contest
        {
            ContestIdentification = contestIdentification,
            ContestDate = contestDate,
            ContestDescription = contestDescription
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="contestIdentification">Has dependency to domainOfInfluenceType.</param>
    /// <param name="contestDate">Field is reqired.</param>
    /// <returns>Contest.</returns>
    public static Contest Create(string contestIdentification, DateTime contestDate)
    {
        return new Contest
        {
            ContestIdentification = contestIdentification,
            ContestDate = contestDate
        };
    }
}
