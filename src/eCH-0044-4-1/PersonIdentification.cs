// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0044_4_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Austausch von Personenidentifikationen (eCH-0044)
/// personIdentificationType beinhaltet zusätzlich zu Identifikationsnummern weitere identifizierende Merkmale
/// wie der Amtliche Name, die Vornamen, das Geschlecht und das Geburtsdatum für eine sichere Identifikation.
/// </summary>
[Serializable]
[JsonObject("personIdentification")]
[XmlRoot(ElementName = "personIdentification", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044/4")]
public class PersonIdentification : FieldValueChecker<PersonIdentification>
{
    private ulong? _vn;
    private NamedPersonId _localPersonId;
    private List<NamedPersonId> _otherPersonIds;
    private List<NamedPersonId> _euPersonIds;
    private string _officialName;
    private string _firstName;
    private string _originalName;
    private SexType _sex;
    private DatePartiallyKnown _dateOfBirth;

    public PersonIdentification()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044/4");
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
    /// <param name="euPersonIds">Field can be null.</param>
    /// <param name="officialName">Field is reqired.</param>
    /// <param name="firstName">Field is reqired.</param>
    /// <param name="originalName">Field can be null.</param>
    /// <param name="sex">Field is reqired.</param>
    /// <param name="dateOfBirt">Field is reqired.</param>
    /// <returns>PersonIdentification.</returns>
    public static PersonIdentification Create(ulong? vn, NamedPersonId localPersonId, List<NamedPersonId> otherPersonIds, List<NamedPersonId> euPersonIds, string officialName, string firstName, string originalName, SexType sex, DatePartiallyKnown dateOfBirt)
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
    /// <returns>PersonIdentification.</returns>
    public static PersonIdentification Create(NamedPersonId localPersonId, string officialName, string firstName, SexType sex, DatePartiallyKnown dateOfBirt)
    {
        return new PersonIdentification()
        {
            LocalPersonId = localPersonId,
            OfficialName = officialName,
            FirstName = firstName,
            Sex = sex,
            DateOfBirth = dateOfBirt
        };
    }

    [FieldRangeInclusive(7560000000001, 7569999999999)]
    [JsonProperty("vn")]
    [XmlElement(DataType = "unsignedLong", ElementName = "vn", Order = 1)]
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
    [XmlElement(ElementName = "localPersonId", Order = 2)]
    public NamedPersonId LocalPersonId
    {
        get => _localPersonId;
        set => CheckAndSetValue(ref _localPersonId, value);
    }

    [JsonProperty("otherPersonId")]
    [XmlElement(ElementName = "otherPersonId", Order = 3)]
    public List<NamedPersonId> OtherPersonIds
    {
        get => _otherPersonIds;
        set => CheckAndSetValue(ref _otherPersonIds, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OtherPersonIdsSpecified => OtherPersonIds != null && OtherPersonIds.Any();

    [JsonProperty("euPersonId")]
    [XmlElement(ElementName = "euPersonId", Order = 4)]
    public List<NamedPersonId> EuPersonIds
    {
        get => _euPersonIds;
        set => CheckAndSetValue(ref _euPersonIds, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool EuPersonIdsSpecified => EuPersonIds != null && EuPersonIds.Any();

    [FieldRequired]
    [FieldMinMaxLength(1, 100)]
    [JsonProperty("officialName")]
    [XmlElement(DataType = "string", ElementName = "officialName", Order = 5)]
    public string OfficialName
    {
        get => _officialName;
        set => CheckAndSetValue(ref _officialName, value);
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 100)]
    [JsonProperty("firstName")]
    [XmlElement(DataType = "string", ElementName = "firstName", Order = 6)]
    public string FirstName
    {
        get => _firstName;
        set => CheckAndSetValue(ref _firstName, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("originalName")]
    [XmlElement(DataType = "string", ElementName = "originalName", Order = 7)]
    public string OriginalName
    {
        get => _originalName;
        set => CheckAndSetValue(ref _originalName, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OriginalNameSpecified => !string.IsNullOrEmpty(OriginalName);

    [FieldRequired]
    [JsonProperty("sex")]
    [XmlElement(ElementName = "sex", Order = 8)]
    public SexType Sex
    {
        get => _sex;
        set => CheckAndSetValue(ref _sex, value);
    }

    [FieldRequired]
    [JsonProperty("dateOfBirth")]
    [XmlElement(ElementName = "dateOfBirth", Order = 9)]
    public DatePartiallyKnown DateOfBirth
    {
        get => _dateOfBirth;
        set => CheckAndSetValue(ref _dateOfBirth, value);
    }
}
