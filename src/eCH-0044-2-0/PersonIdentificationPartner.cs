// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0044_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Austausch von Personenidentifikationen (eCH-0044)
/// personIdentificationLightType ist eine abgeschwächte Version, welche im Kontext von diversen Fachdomänen, z.B. Bau,
/// genutzt wird, da die Angaben zu Geschlecht und Geburtsdatum nicht vorhanden sind oder ausgetascht werden dürfentauscht.
/// </summary>
[Serializable]
[JsonObject("personIdentification")]
[XmlRoot(ElementName = "personIdentification", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044/2")]
public class PersonIdentificationPartner : FieldValueChecker<PersonIdentificationPartner>
{
    private ulong? _vn;
    private NamedPersonId _localPersonId;
    private List<NamedPersonId> _otherPersonIds;
    private string _officialName;
    private string _firstName;
    private SexType? _sex;
    private DatePartiallyKnown _dateOfBirth;

    public PersonIdentificationPartner()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044/2");
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
    /// <param name="sex">Field is reqired.</param>
    /// <param name="dateOfBirt">Field is reqired.</param>
    /// <returns>PersonIdentificationLight.</returns>
    public static PersonIdentificationPartner Create(ulong? vn, NamedPersonId localPersonId, List<NamedPersonId> otherPersonIds, string officialName, string firstName, SexType? sex, DatePartiallyKnown dateOfBirt)
    {
        return new PersonIdentificationPartner
        {
            Vn = vn,
            LocalPersonId = localPersonId,
            OtherPersonIds = otherPersonIds,
            OfficialName = officialName,
            FirstName = firstName,
            Sex = sex,
            DateOfBirth = dateOfBirt
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
    public static PersonIdentificationPartner Create(NamedPersonId localPersonId, string officialName, string firstName, SexType? sex, DatePartiallyKnown dateOfBirt)
    {
        return new PersonIdentificationPartner
        {
            LocalPersonId = localPersonId,
            OfficialName = officialName,
            FirstName = firstName,
            Sex = sex,
            DateOfBirth = dateOfBirt
        };
    }

    /// <summary>
    /// Creates the specified person identification.
    /// </summary>
    /// <param name="personIdentification">The person identification.</param>
    /// <returns></returns>
    public static PersonIdentificationPartner Create(PersonIdentification personIdentification)
    {
        return Create(
            personIdentification.Vn,
            personIdentification.LocalPersonId,
            personIdentification.OtherPersonIds,
            personIdentification.OfficialName,
            personIdentification.FirstName,
            personIdentification.Sex,
            personIdentification.DateOfBirth
        );
    }

    [FieldRangeInclusive(7560000000001, 7569999999999)]
    [JsonProperty("vn")]
    [XmlElement(DataType = "UInt64", ElementName = "vn")]
    public ulong? Vn
    {
        get => _vn;
        set => CheckAndSetValue(ref _vn, value);
    }

    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public NamedPersonId LocalPersonId
    {
        get => _localPersonId;
        set => CheckAndSetValue(ref _localPersonId, value);
    }

    [JsonProperty("otherPersonId")]
    [XmlElement(ElementName = "otherPersonId")]
    public List<NamedPersonId> OtherPersonIds
    {
        get => _otherPersonIds;
        set => CheckAndSetValue(ref _otherPersonIds, value);
    }

    [FieldRequired]
    [FieldMaxLength(100)]
    [JsonProperty("officialName")]
    [XmlElement(DataType = "string", ElementName = "officialName")]
    public string OfficialName
    {
        get => _officialName;
        set => CheckAndSetValue(ref _officialName, value);
    }

    [FieldRequired]
    [FieldMaxLength(100)]
    [JsonProperty("firstName")]
    [XmlElement(DataType = "string", ElementName = "firstName")]
    public string FirstName
    {
        get => _firstName;
        set => CheckAndSetValue(ref _firstName, value);
    }

    [JsonProperty("sex")]
    [XmlElement(ElementName = "sex")]
    public SexType? Sex
    {
        get => _sex;
        set => CheckAndSetValue(ref _sex, value);
    }

    [JsonProperty("dateOfBirth")]
    [XmlElement(ElementName = "dateOfBirth")]
    public DatePartiallyKnown DateOfBirth
    {
        get => _dateOfBirth;
        set => CheckAndSetValue(ref _dateOfBirth, value);
    }

    #region MyRegion
    [JsonIgnore]
    [XmlIgnore]
    public bool VnSpecified => Vn.HasValue;

    [JsonIgnore]
    [XmlIgnore]
    public bool LocalPersonIdSpecified => LocalPersonId != null;

    [JsonIgnore]
    [XmlIgnore]
    public bool OtherPersonIdsSpecified => OtherPersonIds != null && OtherPersonIds.Any();

    [JsonIgnore]
    [XmlIgnore]
    public bool SexSpecified => Sex.HasValue;

    [JsonIgnore]
    [XmlIgnore]
    public bool DateOfBirthSpecified => DateOfBirth != null;
    #endregion
}
