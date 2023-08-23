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
///     Vorlage: Bei einer Abstimmung wird über Vorlagen entschieden. Dabei kann  es sich entweder um eine Standard-Vorlage
///     (standard-ballot) oder eine sogenannte Varianten Vorlage (variants ballot) handeln.
///     Achtung: bei Variantenabstimmungen gibt es mehrere Typen.
/// </summary>
[Serializable]
[JsonObject("votingCard")]
[XmlRoot(ElementName = "votingCard", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class VotingCard
{
    private const string VotingCardNumberOutOfRangeValidateExceptionMessage =
        "VotingCardNumber is not valid! VotingCardNumber has minimal leght of 1 and maximal length of 50";

    private const string DateOfVotingOutOfRangeValidateExceptionMessage =
        "DateOfVoting is not valid! DateOfVoting has to be a valid Date";

    private const string TimeOfVotingOutOfRangeValidateExceptionMessage =
        "TimeOfVoting is not valid! TimeOfVoting has to be a valid Time";

    private const string PlaceOfVotingOutOfRangeValidateExceptionMessage =
        "PlaceOfVoting is not valid! PlaceOfVoting has to has minimal legnth of 1 and maximal legnt of 100";

    private DateTime? _dateOfVoting;
    private string _placeOfVoting;
    private DateTime? _timeOfVoting;

    private string _votingCardNumber;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public VotingCard()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [JsonProperty("votingCardNumber")]
    [XmlElement(ElementName = "votingCardNumber", Order = 1)]
    public string VotingCardNumber
    {
        get => _votingCardNumber;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 50))
            {
                throw new XmlSchemaValidationException(VotingCardNumberOutOfRangeValidateExceptionMessage);
            }

            _votingCardNumber = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool VotingCardNumberSpecified => !string.IsNullOrEmpty(VotingCardNumber);

    [JsonProperty("votingPersonIdentification")]
    [XmlElement(ElementName = "votingPersonIdentification", Order = 2)]
    public VotingPersonIdentification VotingPersonIdentification { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool VotingPersonIdentificationSpecified => VotingPersonIdentification != null;

    [JsonProperty("domainOfInfluence")]
    [XmlElement(ElementName = "domainOfInfluence", Order = 3)]
    public DomainOfInfluenceType DomainOfInfluence { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DomainOfInfluenceSpecified => DomainOfInfluence != null;

    [JsonProperty("voterType")]
    [XmlElement(ElementName = "voterType", Order = 4)]
    public VoterType? VoterType { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool VoterTypeSpecified => VoterType.HasValue;

    [JsonProperty("votingChannel")]
    [XmlElement(ElementName = "votingChannel", Order = 5)]
    public VotingChannel? VotingChannel { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool VotingChannelSpecified => VotingChannel.HasValue;

    [JsonProperty("dateOfVoting")]
    [XmlElement(ElementName = "dateOfVoting", Order = 6)]
    public string DateOfVoting
    {
        get => _dateOfVoting?.ToShortDateString() ?? string.Empty;
        set
        {
            var date = default(DateTime);

            if (value != null && !DateTime.TryParse(value, out date))
            {
                throw new XmlSchemaValidationException(DateOfVotingOutOfRangeValidateExceptionMessage);
            }

            _dateOfVoting = date;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool DateOfVotingSpecified => !string.IsNullOrEmpty(DateOfVoting);

    [JsonProperty("timeOfVoting")]
    [XmlElement(ElementName = "timeOfVoting", Order = 7)]
    public string TimeOfVoting
    {
        get => _timeOfVoting?.ToShortTimeString() ?? string.Empty;
        set
        {
            var time = default(DateTime);

            if (value != null && !DateTime.TryParse(value, out time))
            {
                throw new XmlSchemaValidationException(TimeOfVotingOutOfRangeValidateExceptionMessage);
            }

            _timeOfVoting = time;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TimeOfVotingSpecified => !string.IsNullOrEmpty(TimeOfVoting);

    [JsonProperty("dateOfVoting")]
    [XmlElement(ElementName = "dateOfVoting", Order = 8)]
    public string PlaceOfVoting
    {
        get => _placeOfVoting;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 100))
            {
                throw new XmlSchemaValidationException(PlaceOfVotingOutOfRangeValidateExceptionMessage);
            }

            _placeOfVoting = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfVotingSpecified => !string.IsNullOrEmpty(PlaceOfVoting);

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension", Order = 9)]
    public ExtensionType Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="votingCardNumber">Field is optional.</param>
    /// <param name="votingPersonIdentification">Field is optional.</param>
    /// <param name="domainOfInfluence">Field is optional.</param>
    /// <param name="voterType">Field is optional.</param>
    /// <param name="dateOfVoting">Field is optional.</param>
    /// <param name="timeOfVoting">Field is optional.</param>
    /// <param name="placeOfVoting">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>VotingCard.</returns>
    public static VotingCard Create(string votingCardNumber, VotingPersonIdentification votingPersonIdentification,
        DomainOfInfluenceType domainOfInfluence, VoterType voterType, string dateOfVoting, string timeOfVoting,
        string placeOfVoting, ExtensionType extension)
    {
        return new VotingCard
        {
            VotingCardNumber = votingCardNumber,
            VotingPersonIdentification = votingPersonIdentification,
            DomainOfInfluence = domainOfInfluence,
            VoterType = voterType,
            DateOfVoting = dateOfVoting,
            TimeOfVoting = timeOfVoting,
            PlaceOfVoting = placeOfVoting,
            Extension = extension
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <returns>VotingCard.</returns>
    public static VotingCard Create()
    {
        return new VotingCard();
    }
}
