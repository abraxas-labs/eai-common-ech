// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0201_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Lieferung Personendaten für Haushaltabgabe (eCH-0201)
///     Personendaten.
/// </summary>
[Serializable]
[JsonObject("person")]
[XmlRoot(ElementName = "person", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0201/1")]
public class PersonType : FieldValueChecker<PersonType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ulong? _vn;
    private NamedPersonId _localPersonId;
    private string _officialName;
    private string _firstName;
    private string _callName;
    private DatePartiallyKnown _dateOfBirth;
    private DateTime? _dateOfDeath;
    private SexType _sex;
    private string _languageOfCorrespondance;
    private ContactDataType _contactData;

    public PersonType()
    {
        Xmlns.Add("eCH-0201", "http://www.ech.ch/xmlns/eCH-0201/1");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="vn">Field is optional.</param>
    /// <param name="localPersonId">Field is reqired.</param>
    /// <param name="otherPersonIds">Field can be null.</param>
    /// <param name="euPersonIds">Field can be null.</param>
    /// <param name="officialName">Field is reqired.</param>
    /// <param name="firstName">Field is reqired.</param>
    /// <param name="originalName">Field can be null.</param>
    /// <param name="sex">Field is reqired.</param>
    /// <param name="dateOfBirt">Field is reqired.</param>
    /// <returns>PersonIdentification.</returns>
    public static PersonIdentification Create(ulong? vn, NamedPersonId localPersonId,
        List<NamedPersonId> otherPersonIds, List<NamedPersonId> euPersonIds, string officialName, string firstName,
        string originalName, SexType sex, DatePartiallyKnown dateOfBirt)
    {
        return new PersonIdentification
        {
            Vn = vn,
            LocalPersonId = localPersonId,
            OtherPersonIds = otherPersonIds,
            EuPersonIds = euPersonIds,
            OfficialName = officialName,
            FirstName = firstName,
            OriginalName = originalName,
            Sex = sex,
            DateOfBirth = dateOfBirt
        };
    }

    [FieldRangeInclusive(7560000000001, 7569999999999)]
    [JsonProperty("vn")]
    [XmlElement(DataType = "unsignedLong", ElementName = "vn")]
    public ulong? Vn
    {
        get => _vn;
        set => CheckAndSetValue(ref _vn, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool VnSpecified => Vn.HasValue;

    [FieldRequired]
    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public NamedPersonId LocalPersonId
    {
        get => _localPersonId;
        set => CheckAndSetValue(ref _localPersonId, value);
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 100)]
    [JsonProperty("officialName")]
    [XmlElement(DataType = "string", ElementName = "officialName")]
    public string OfficialName
    {
        get => _officialName;
        set => CheckAndSetValue(ref _officialName, value);
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 100)]
    [JsonProperty("firstName")]
    [XmlElement(DataType = "string", ElementName = "firstName")]
    public string FirstName
    {
        get => _firstName;
        set => CheckAndSetValue(ref _firstName, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("callName")]
    [XmlElement(DataType = "string", ElementName = "callName")]
    public string CallName
    {
        get => _callName;
        set => CheckAndSetValue(ref _callName, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CallNameSpecified => !string.IsNullOrWhiteSpace(CallName);

    [FieldRequired]
    [JsonProperty("dateOfBirth")]
    [XmlElement(ElementName = "dateOfBirth")]
    public DatePartiallyKnown DateOfBirth
    {
        get => _dateOfBirth;
        set => CheckAndSetValue(ref _dateOfBirth, value);
    }

    [JsonProperty("dateOfDeath")]
    [XmlElement(DataType = "date", ElementName = "dateOfDeath")]
    public DateTime? DateOfDeath
    {
        get => _dateOfDeath;
        set => CheckAndSetValue(ref _dateOfDeath, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool DateOfDeathSpecified => DateOfDeath.HasValue;

    [JsonProperty("sex")]
    [XmlElement(ElementName = "sex")]
    public SexType Sex
    {
        get => _sex;
        set => CheckAndSetValue(ref _sex, value);
    }

    [FieldMaxLength(2)]
    [JsonProperty("languageOfCorrespondance")]
    [XmlElement(ElementName = "languageOfCorrespondance")]
    public string LanguageOfCorrespondance
    {
        get => _languageOfCorrespondance;
        set => CheckAndSetValue(ref _languageOfCorrespondance, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool LanguageOfCorrespondanceSpecified => !string.IsNullOrWhiteSpace(LanguageOfCorrespondance);

    [JsonProperty("contactData")]
    [XmlElement(ElementName = "contactData")]
    public ContactDataType ContactData
    {
        get => _contactData;
        set => CheckAndSetValue(ref _contactData, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactDataSpecified => ContactData != null;
}
