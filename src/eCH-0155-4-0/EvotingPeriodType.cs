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
///     Zeitraum E-Voting – eVotingPeriod.
/// </summary>
[Serializable]
[JsonObject("eVotingPeriodType")]
[XmlRoot(ElementName = "eVotingPeriodType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class EvotingPeriodType : FieldValueChecker<EvotingPeriodType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private DateTime _evotingPeriodFrom;
    private DateTime _evotingPeriodTill;

    public EvotingPeriodType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [JsonProperty("eVotingPeriodFrom")]
    [XmlElement(ElementName = "eVotingPeriodFrom", Order = 1)]
    public DateTime EvotingPeriodFrom
    {
        get => _evotingPeriodFrom;
        set => CheckAndSetValue(ref _evotingPeriodFrom, value);
    }

    [FieldRequired]
    [JsonProperty("eVotingPeriodTill")]
    [XmlElement(ElementName = "eVotingPeriodTill", Order = 2)]
    public DateTime EvotingPeriodTill
    {
        get => _evotingPeriodTill;
        set => CheckAndSetValue(ref _evotingPeriodTill, value);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="evotingPeriodFrom">Field is reqired.</param>
    /// <param name="evotingPeriodTill">Field is reqired.</param>
    /// <returns>EvotingPeriodType.</returns>
    public static EvotingPeriodType Create(DateTime evotingPeriodFrom, DateTime evotingPeriodTill)
    {
        return new EvotingPeriodType
        {
            EvotingPeriodFrom = evotingPeriodFrom,
            EvotingPeriodTill = evotingPeriodTill
        };
    }
}
