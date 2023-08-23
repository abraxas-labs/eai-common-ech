﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0044_4_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Austausch von Personenidentifikationen (eCH-0044)
/// personIdentificationLightType ist eine abgeschwächte Version, welche im Kontext von diversen Fachdomänen, z.B. Bau,
/// genutzt wird, da die Angaben zu Geschlecht und Geburtsdatum nicht vorhanden sind oder ausgetascht werden dürfentauscht.
/// </summary>
[Serializable]
[JsonObject("personIdentification")]
[XmlRoot(ElementName = "personIdentification", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044-f/4")]
public class PersonIdentificationLight : FieldValueChecker<PersonIdentificationLight>
{
    private ulong? _vn;
    private NamedPersonId _localPersonId;
    private List<NamedPersonId> _otherPersonIds;
    private string _officialName;
    private string _firstName;
    private string _originalName;
    private SexType? _sex;
    private DatePartiallyKnown _dateOfBirth;

    public PersonIdentificationLight()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044-f/4");
    }

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="vn">Field can be null.</param>
    /// <param name="localPersonId">Field is reqired.</param>
    /// <param name="otherPersonIds">Field can be null.</param>
    /// <param name="officialName">Field is reqired.</param>
    /// <param name="firstName">Field is reqired.</param>
    /// <param name="originalName">Field can be null.</param>
    /// <param name="sex">Field is reqired.</param>
    /// <param name="dateOfBirt">Field is reqired.</param>
    /// <returns>PersonIdentificationLight.</returns>
    public static PersonIdentificationLight Create(ulong? vn, eCH_0044_4_1.NamedPersonId localPersonId, List<eCH_0044_4_1.NamedPersonId> otherPersonIds, string officialName, string firstName, string originalName, eCH_0044_4_1.SexType? sex, eCH_0044_4_1.DatePartiallyKnown dateOfBirt)
    {
        List<eCH_0044_4_1f.NamedPersonId> fOtherPersonIds = new();

        foreach (var persId in otherPersonIds.Where(p => p != null))
        {
            fOtherPersonIds.Add(NamedPersonId.Create(persId.PersonIdCategory, persId.PersonId));
        }

        DatePartiallyKnown fDateOfBirth = new()
        {
            Year = dateOfBirt.Year,
            YearMonth = dateOfBirt.YearMonth,
            YearMonthDay = dateOfBirt.YearMonthDay
        };

        return new PersonIdentificationLight
        {
            Vn = vn,
            LocalPersonId = NamedPersonId.Create(localPersonId.PersonIdCategory, localPersonId.PersonId),
            OtherPersonIds = fOtherPersonIds,
            OfficialName = officialName,
            FirstName = firstName,
            OriginalName = originalName,
            Sex = (SexType?)Enum.Parse(typeof(SexType), sex.ToString()),
            DateOfBirth = fDateOfBirth
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="localPersonId">Field is reqired.</param>
    /// <param name="officialName">Field is reqired.</param>
    /// <param name="firstName">Field is reqired.</param>
    /// <param name="sex">Field is reqired.</param>
    /// <param name="dateOfBirt">Field is reqired.</param>
    /// <returns>PersonIdentificationLight.</returns>
    public static PersonIdentificationLight Create(eCH_0044_4_1.NamedPersonId localPersonId, string officialName, string firstName, eCH_0044_4_1.SexType? sex, eCH_0044_4_1.DatePartiallyKnown dateOfBirt)
    {
        DatePartiallyKnown fDateOfBirth = new()
        {
            Year = dateOfBirt.Year,
            YearMonth = dateOfBirt.YearMonth,
            YearMonthDay = dateOfBirt.YearMonthDay
        };

        return new PersonIdentificationLight
        {
            LocalPersonId = NamedPersonId.Create(localPersonId.PersonIdCategory, localPersonId.PersonId),
            OfficialName = officialName,
            FirstName = firstName,
            Sex = (SexType?)Enum.Parse(typeof(SexType), sex.ToString()),
            DateOfBirth = fDateOfBirth
        };
    }

    /// <summary>
    /// Creates the specified person identification.
    /// </summary>
    /// <param name="personIdentification">The person identification.</param>
    /// <returns></returns>
    public static PersonIdentificationLight Create(eCH_0044_4_1.PersonIdentification personIdentification)
    {
        return Create(
            personIdentification.Vn,
            personIdentification.LocalPersonId,
            personIdentification.OtherPersonIds,
            personIdentification.OfficialName,
            personIdentification.FirstName,
            personIdentification.OriginalName,
            personIdentification.Sex,
            personIdentification.DateOfBirth
        );
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

    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public NamedPersonId LocalPersonId
    {
        get => _localPersonId;
        set => CheckAndSetValue(ref _localPersonId, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool LocalPersonIdSpecified => LocalPersonId != null;

    [JsonProperty("otherPersonId")]
    [XmlElement(ElementName = "otherPersonId")]
    public List<NamedPersonId> OtherPersonIds
    {
        get => _otherPersonIds;
        set => CheckAndSetValue(ref _otherPersonIds, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OtherPersonIdsSpecified => OtherPersonIds != null && OtherPersonIds.Any();

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("officialName")]
    [XmlElement(DataType = "string", ElementName = "officialName")]
    public string OfficialName
    {
        get => _officialName;
        set => CheckAndSetValue(ref _officialName, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("firstName")]
    [XmlElement(DataType = "string", ElementName = "firstName")]
    public string FirstName
    {
        get => _firstName;
        set => CheckAndSetValue(ref _firstName, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("originalName")]
    [XmlElement(DataType = "string", ElementName = "originalName")]
    public string OriginalName
    {
        get => _originalName;
        set => CheckAndSetValue(ref _originalName, value);
    }

    [JsonProperty("sex")]
    [XmlElement(ElementName = "sex")]
    public SexType? Sex
    {
        get => _sex;
        set => CheckAndSetValue(ref _sex, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool SexSpecified => Sex.HasValue;

    [JsonProperty("dateOfBirth")]
    [XmlElement(ElementName = "dateOfBirth")]
    public DatePartiallyKnown DateOfBirth
    {
        get => _dateOfBirth;
        set => CheckAndSetValue(ref _dateOfBirth, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool DateOfBirthSpecified => DateOfBirth != null;
}