// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_3_0;
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
[JsonObject("votingPersonIdentification")]
[XmlRoot(ElementName = "votingPersonIdentification", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/1")]
public class VotingPersonIdentification
{
    private const string VnValidateExceptionMessage =
        "Vn is not valid! Vn has to be between 7560000000001 and 7569999999999";

    private const string LocalPersonIdNullValidateExceptionMessage =
        "LocalPersonId is not valid! LocalPersonId is required";

    private const string LocalPersonIdOutOfRangeValidateExceptionMessage =
        "LocalPersonId is not valid! LocalPersonId has minimal leght of 1 and maximal length of 36";

    private const string OtherPersonIdNullValidateExceptionMessage =
        "OtherPersonId is not valid! OtherPersonId must have at least one entry";

    private const string OtherPersonIdOutOfRangeValidateExceptionMessage =
        "OtherPersonId is not valid! OtherPersonId has minimal leght of 1 and maximal length of 36";

    private const string OfficialNameOutOfRangeValidateExceptionMessage =
        "OfficialName is not valid! OfficialName has minimal leght of 1 and maximal length of 100";

    private const string FirstNameOutOfRangeValidateExceptionMessage =
        "FirstName is not valid! FirstName has minimal leght of 1 and maximal length of 100";

    private string _firstName;
    private string _localPersonId;
    private string _officialName;
    private List<string> _otherPersonId;

    private string _vn;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public VotingPersonIdentification()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/1");
    }

    [JsonProperty("vn")]
    [XmlElement(DataType = "string", ElementName = "vn")]
    public string Vn
    {
        get => _vn;
        set
        {
            if (!string.IsNullOrEmpty(value) && (long.Parse(value) < 7560000000001 || long.Parse(value) > 7569999999999))
            {
                throw new XmlSchemaValidationException(VnValidateExceptionMessage);
            }

            _vn = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool VnSpecified => !string.IsNullOrEmpty(Vn);

    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public string LocalPersonId
    {
        get => _localPersonId;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(LocalPersonIdNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 36)
            {
                throw new XmlSchemaValidationException(LocalPersonIdOutOfRangeValidateExceptionMessage);
            }

            _localPersonId = value;
        }
    }

    [JsonProperty("otherPersonId")]
    [XmlElement(ElementName = "otherPersonId")]
    public List<string> OtherPersonId
    {
        get => _otherPersonId;
        set
        {
            if (!value.Any())
            {
                throw new XmlSchemaValidationException(OtherPersonIdNullValidateExceptionMessage);
            }

            if (value.Any(x => string.IsNullOrEmpty(x) || x.Length < 1 || x.Length > 36))
            {
                throw new XmlSchemaValidationException(OtherPersonIdOutOfRangeValidateExceptionMessage);
            }

            _otherPersonId = value;
        }
    }

    [JsonProperty("officialName")]
    [XmlElement(ElementName = "officialName")]
    public string OfficialName
    {
        get => _officialName;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 100))
            {
                throw new XmlSchemaValidationException(OfficialNameOutOfRangeValidateExceptionMessage);
            }

            _officialName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OfficialNameSpecified => !string.IsNullOrEmpty(OfficialName);

    [JsonProperty("firstName")]
    [XmlElement(ElementName = "firstName")]
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 100))
            {
                throw new XmlSchemaValidationException(FirstNameOutOfRangeValidateExceptionMessage);
            }

            _firstName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool FirstNameSpecified => !string.IsNullOrEmpty(FirstName);

    [JsonProperty("sex")]
    [XmlElement("sex")]
    public SexType? Sex { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool SexSpecified => Sex.HasValue;

    [JsonProperty("dateOfBirth")]
    [XmlElement(ElementName = "dateOfBirth")]
    public DatePartiallyKnown DateOfBirth { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DateOfBirthSpecified => DateOfBirth != null;

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="vn">Field is required.</param>
    /// <param name="localPersonId">Field is required.</param>
    /// <param name="otherPersonId">Field is required.</param>
    /// <param name="officialName">Field is optional.</param>
    /// <param name="firstName">Field is optional.</param>
    /// <param name="sex">Field is optional.</param>
    /// <param name="dateOfBirth">Field is optional.</param>
    /// <returns>VotingPersonIdentification.</returns>
    public static VotingPersonIdentification Create(string vn, string localPersonId, List<string> otherPersonId,
        string officialName, string firstName, SexType sex, DatePartiallyKnown dateOfBirth)
    {
        return new VotingPersonIdentification
        {
            Vn = vn,
            LocalPersonId = localPersonId,
            OtherPersonId = otherPersonId,
            OfficialName = officialName,
            FirstName = firstName,
            Sex = sex,
            DateOfBirth = dateOfBirth
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle nötigen Werte.
    /// </summary>
    /// <param name="vn">Field is required.</param>
    /// <param name="localPersonId">Field is required.</param>
    /// <param name="otherPersonId">Field is required.</param>
    /// <returns>VotingPersonIdentification.</returns>
    public static VotingPersonIdentification Create(string vn, string localPersonId, List<string> otherPersonId)
    {
        return new VotingPersonIdentification
        {
            Vn = vn,
            LocalPersonId = localPersonId,
            OtherPersonId = otherPersonId
        };
    }
}
