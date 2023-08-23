// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

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
[XmlRoot(ElementName = "contest", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class ContestType : FieldValueChecker<ContestType>
{
    private string _contestIdentification;
    private DateTime _contestDate;
    private ContestDescriptionInformation _contestDescription;
    private EvotingPeriodType _evotingPeriod;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public ContestType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 50)]
    [JsonProperty("contestIdentification")]
    [XmlElement(ElementName = "contestIdentification", Order = 1)]
    public string ContestIdentification
    {
        get => _contestIdentification;
        set => CheckAndSetValue(ref _contestIdentification, value);
    }

    [FieldRequired]
    [JsonProperty("contestDate")]
    [XmlElement(ElementName = "contestDate", DataType = "date", Order = 2)]
    public DateTime ContestDate
    {
        get => _contestDate;
        set => CheckAndSetValue(ref _contestDate, value);
    }

    [JsonProperty("contestDescription")]
    [XmlElement(ElementName = "contestDescription", Order = 3)]
    public ContestDescriptionInformation ContestDescription
    {
        get => _contestDescription;
        set => CheckAndSetValue(ref _contestDescription, value);
    }

    [JsonProperty("eVotingPeriod")]
    [XmlElement(ElementName = "eVotingPeriod", Order = 4)]
    public EvotingPeriodType EvotingPeriod
    {
        get => _evotingPeriod;
        set => CheckAndSetValue(ref _evotingPeriod, value);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="contestIdentification">Has dependency to domainOfInfluenceType.</param>
    /// <param name="contestDate">Field is reqired.</param>
    /// <param name="contestDescription">Field is optional.</param>
    /// <param name="evotingPeriod">Field is optional.</param>
    /// <returns>Contest.</returns>
    public static ContestType Create(string contestIdentification, DateTime contestDate,
        ContestDescriptionInformation contestDescription, EvotingPeriodType evotingPeriod)
    {
        return new ContestType
        {
            ContestIdentification = contestIdentification,
            ContestDate = contestDate,
            ContestDescription = contestDescription,
            EvotingPeriod = evotingPeriod
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
    public static ContestType Create(string contestIdentification, DateTime contestDate)
    {
        return new ContestType
        {
            ContestIdentification = contestIdentification,
            ContestDate = contestDate
        };
    }
}
