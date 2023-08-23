// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0011_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("coredata")]
[XmlRoot(ElementName = "coredata", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/7")]
public class CoreDataType : FieldValueChecker<CoreDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _originalName;
    private string _alliancePartnershipName;
    private string _aliasName;
    private string _otherName;
    private string _callName;
    private BirthPlaceType _placeOfBirth;
    private DateTime _dateOfDeath;
    private MaritalDataType _maritalData;
    private NationalityType _nationality;
    private ContactType _contact;
    private string _languageOfCorrespondance;
    private string _religion;

    public CoreDataType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="originalName">Field is optional.</param>
    /// <param name="alliancePartnershipName">Field is optional.</param>
    /// <param name="aliasName">Field is optional.</param>
    /// <param name="otherName">Field is optional.</param>
    /// <param name="callName">Field is optional.</param>
    /// <param name="placeOfBirth">Field is required.</param>
    /// <param name="dateOfDeath">Field is optional.</param>
    /// <param name="maritalData">Field is required.</param>
    /// <param name="nationality">Field is required.</param>
    /// <param name="contact">Field is optional.</param>
    /// <param name="languageOfCorrespondance">Field is optional.</param>
    /// <param name="religion">Field is required.</param>
    /// <returns>CoreData.</returns>
    public static CoreDataType Create(string originalName, string alliancePartnershipName, string aliasName, string otherName, string callName, BirthPlaceType placeOfBirth,
        DateTime dateOfDeath, MaritalDataType maritalData, NationalityType nationality, ContactType contact, string languageOfCorrespondance, string religion)
    {
        return new CoreDataType
        {
            OriginalName = originalName,
            AlliancePartnershipName = alliancePartnershipName,
            AliasName = aliasName,
            OtherName = otherName,
            CallName = callName,
            PlaceOfBirth = placeOfBirth,
            DateOfDeath = dateOfDeath,
            MaritalData = maritalData,
            Nationality = nationality,
            Contact = contact,
            LanguageOfCorrespondance = languageOfCorrespondance,
            Religion = religion
        };
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("originalName")]
    [XmlElement(ElementName = "originalName")]
    public string OriginalName
    {
        get => _originalName;
        set => CheckAndSetValue(ref _originalName, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("alliancePartnershipName")]
    [XmlElement(ElementName = "alliancePartnershipName")]
    public string AlliancePartnershipName
    {
        get => _alliancePartnershipName;
        set => CheckAndSetValue(ref _alliancePartnershipName, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("aliasName")]
    [XmlElement(ElementName = "aliasName")]
    public string AliasName
    {
        get => _aliasName;
        set => CheckAndSetValue(ref _aliasName, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("otherName")]
    [XmlElement(ElementName = "otherName")]
    public string OtherName
    {
        get => _otherName;
        set => CheckAndSetValue(ref _otherName, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("callName")]
    [XmlElement(ElementName = "callName")]
    public string CallName
    {
        get => _callName;
        set => CheckAndSetValue(ref _callName, value);
    }

    [FieldRequired]
    [JsonProperty("placeOfBirth")]
    [XmlElement(ElementName = "placeOfBirth")]
    public BirthPlaceType PlaceOfBirth
    {
        get => _placeOfBirth;
        set => CheckAndSetValue(ref _placeOfBirth, value);
    }

    [JsonProperty("dateOfDeath")]
    [XmlElement(ElementName = "dateOfDeath")]
    public DateTime DateOfDeath
    {
        get => _dateOfDeath;
        set => CheckAndSetValue(ref _dateOfDeath, value);
    }

    [FieldRequired]
    [JsonProperty("maritalData")]
    [XmlElement(ElementName = "maritalData")]
    public MaritalDataType MaritalData
    {
        get => _maritalData;
        set => CheckAndSetValue(ref _maritalData, value);
    }

    [FieldRequired]
    [JsonProperty("nationality")]
    [XmlElement(ElementName = "nationality")]
    public NationalityType Nationality
    {
        get => _nationality;
        set => CheckAndSetValue(ref _nationality, value);
    }

    [JsonProperty("contact")]
    [XmlElement(ElementName = "contact")]
    public ContactType Contact
    {
        get => _contact;
        set => CheckAndSetValue(ref _contact, value);
    }

    [JsonProperty("languageOfCorrespondance")]
    [XmlElement(ElementName = "languageOfCorrespondance")]
    public string LanguageOfCorrespondance
    {
        get => _languageOfCorrespondance;
        set => CheckAndSetValue(ref _languageOfCorrespondance, value);
    }

    [FieldRegex("\\d{3,6}")]
    [JsonProperty("religion")]
    [XmlElement(ElementName = "religion")]
    public string Religion
    {
        get => _religion;
        set => CheckAndSetValue(ref _religion, value);
    }
}
