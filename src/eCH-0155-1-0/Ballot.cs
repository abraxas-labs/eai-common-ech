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
///     Vorlage: Bei einer Abstimmung wird über Vorlagen entschieden. Dabei kann  es sich entweder um eine Standard-Vorlage
///     (standard-ballot) oder eine sogenannte Varianten Vorlage (variants ballot) handeln.
///     Achtung: bei Variantenabstimmungen gibt es mehrere Typen.
/// </summary>
[Serializable]
[JsonObject("ballot")]
[XmlRoot(ElementName = "String", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class Ballot
{
    private const string BallotIdentificationNullValidateExceptionMessage =
        "BallotIdentification is not valid! BallotIdentification is required";

    private const string BallotIdentificationOutOfRangeValidateExceptionMessage =
        "BallotIdentification is not valid! BallotIdentification has minimal leght of 1 and maximal length of 50";

    private const string BallotPositionOutOfRangeValidateExceptionMessage =
        "BallotPosition is not valid! BallotPosition has to be a positive number";

    private const string BallotGroupOutOfRangeValidateExceptionMessage =
        "BallotGroup is not valid! BallotGroup has minimal leght of 1 and maximal length of 100";

    private string _ballotGroup;

    private string _ballotIdentification;
    private int _ballotPosition;
    private object _ballotTypeChoice;

    [JsonIgnore][XmlIgnore] public BallotTypeIdentifier BallotTypeName;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Ballot()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("ballotIdentification")]
    [XmlElement(ElementName = "ballotIdentification")]
    public string BallotIdentification
    {
        get => _ballotIdentification;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(BallotIdentificationNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(BallotIdentificationOutOfRangeValidateExceptionMessage);
            }

            _ballotIdentification = value;
        }
    }

    [JsonProperty("ballotPosition")]
    [XmlElement(ElementName = "ballotPosition")]
    public int BallotPosition
    {
        get => _ballotPosition;
        set
        {
            if (value < 0)
            {
                throw new XmlSchemaValidationException(BallotPositionOutOfRangeValidateExceptionMessage);
            }

            _ballotPosition = value;
        }
    }

    [JsonProperty("ballotDescription")]
    [XmlElement(ElementName = "ballotDescription")]
    public BallotDescriptionInformation BallotDescription { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BallotDescriptionSpecified => BallotDescription != null;

    [JsonProperty("ballotGroup")]
    [XmlElement(ElementName = "ballotGroup")]
    public string BallotGroup
    {
        get => _ballotGroup;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 100))
            {
                throw new XmlSchemaValidationException(BallotGroupOutOfRangeValidateExceptionMessage);
            }

            _ballotGroup = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool BallotGroupSpecified => !string.IsNullOrEmpty(BallotGroup);

    [XmlElement("standardBallot", typeof(StandardBallot))]
    [XmlElement("variantBallot", typeof(VariantBallot))]
    [XmlChoiceIdentifier("BallotTypeName")]
    public object BallotTypeChoice
    {
        get => _ballotTypeChoice;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException();
            }

            if (value is StandardBallot)
            {
                BallotTypeName = BallotTypeIdentifier.standardBallot;
            }
            else if (value is VariantBallot)
            {
                BallotTypeName = BallotTypeIdentifier.variantBallot;
            }
            else
            {
                throw new XmlSchemaValidationException();
            }

            _ballotTypeChoice = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="ballotIdentification">Field is required.</param>
    /// <param name="ballotPosition">Field is required.</param>
    /// <param name="ballotDescription">Field is optional.</param>
    /// <param name="ballotGroup">Field is optional.</param>
    /// <param name="ballotTypeChoice">Field is required.</param>
    /// <returns>Ballot.</returns>
    public static Ballot Create(string ballotIdentification, int ballotPosition,
        BallotDescriptionInformation ballotDescription, string ballotGroup, object ballotTypeChoice)
    {
        return new Ballot
        {
            BallotIdentification = ballotIdentification,
            BallotPosition = ballotPosition,
            BallotDescription = ballotDescription,
            BallotGroup = ballotGroup,
            BallotTypeChoice = ballotTypeChoice,
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="ballotIdentification">Field is required.</param>
    /// <param name="ballotPosition">Field is required.</param>
    /// <param name="ballotTypeChoice">Field is required.</param>
    /// <returns>Ballot.</returns>
    public static Ballot Create(string ballotIdentification, int ballotPosition, object ballotTypeChoice)
    {
        return new Ballot
        {
            BallotIdentification = ballotIdentification,
            BallotPosition = ballotPosition,
            BallotTypeChoice = ballotTypeChoice
        };
    }
}

[XmlType(IncludeInSchema = false)]
public enum BallotTypeIdentifier
{
    standardBallot,
    variantBallot
}
