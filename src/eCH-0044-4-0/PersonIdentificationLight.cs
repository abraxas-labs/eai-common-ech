// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0044_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard Austausch von Personenidentifikationen (eCH-0044)
///     personIdentificationLightType ist eine abgeschwächte Version, welche im Kontext von diversen Fachdomänen, z.B. Bau,
///     genutzt wird, da die Angaben zu Geschlecht und Geburtsdatum nicht vorhanden sind oder ausgetascht werden
///     dürfentauscht.
/// </summary>
[Serializable]
[JsonObject("personIdentification")]
[XmlRoot(ElementName = "personIdentification", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044/4")]
public class PersonIdentificationLight
{
    private const string VnValidateExceptionMessage =
        "Vn is not valid! Vn has to be between 7560000000001 and 7569999999999";

    private const string OfficialNameValidateExceptionMessage =
        "OfficialName is not valid! OfficialName can not be null or empty and has max Length 100";

    private const string FirstNameValidateExceptionMessage =
        "FirstName is not valid! FirstName can not be null or empty and has max Length 100";

    private const string OriginalNameValidateExceptionMessage =
        "originalName is not valid! originalName has max Length 100";

    private const string SexValidateExceptionMessage = "Sex is not valid! Sex can not be null or empty";
    private string _firstName;
    private string _officialName;
    private string _originalName;
    private SexType? _sex;
    private string _vn;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public PersonIdentificationLight()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044/4");
    }

    [JsonProperty("vn")]
    [XmlElement(DataType = "string", ElementName = "vn")]
    public string Vn
    {
        get => _vn;
        set
        {
            if (!string.IsNullOrEmpty(value) && (long.Parse(value) < 7560000000001 || (long.Parse(value) > 7569999999999)))
            {
                IsInvalidValue(VnValidateExceptionMessage);
            }

            _vn = value;
        }
    }

    [XmlIgnore]
    public bool VnSpecified => !string.IsNullOrEmpty(Vn);

    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public NamedPersonId LocalPersonId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool LocalPersonIdSpecified => LocalPersonId != null;

    [JsonProperty("otherPersonId")]
    [XmlElement(ElementName = "otherPersonId")]
    public List<NamedPersonId> OtherPersonIds { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OtherPersonIdsSpecified => OtherPersonIds != null && OtherPersonIds.Any();

    [JsonProperty("officialName")]
    [XmlElement(DataType = "string", ElementName = "officialName")]
    public string OfficialName
    {
        get => _officialName;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 100)
            {
                IsInvalidValue(OfficialNameValidateExceptionMessage);
            }

            _officialName = value;
        }
    }

    [JsonProperty("firstName")]
    [XmlElement(DataType = "string", ElementName = "firstName")]
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 100)
            {
                IsInvalidValue(FirstNameValidateExceptionMessage);
            }

            _firstName = value;
        }
    }

    [JsonProperty("originalName")]
    [XmlElement(DataType = "string", ElementName = "originalName")]
    public string OriginalName
    {
        get => _originalName;
        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                IsInvalidValue(OriginalNameValidateExceptionMessage);
            }

            _originalName = value;
        }
    }

    [JsonProperty("sex")]
    [XmlElement(ElementName = "sex")]
    public SexType? Sex
    {
        get => _sex;
        set
        {
            if (CheckValue(value))
            {
                IsInvalidValue(SexValidateExceptionMessage);
            }

            _sex = value;
        }
    }

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
    ///     Diese Methode befüllt alle möglichen Werte.
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
    public static PersonIdentificationLight Create(string vn, NamedPersonId localPersonId,
        List<NamedPersonId> otherPersonIds, string officialName, string firstName, string originalName,
        SexType? sex, DatePartiallyKnown dateOfBirt)
    {
        return new PersonIdentificationLight
        {
            Vn = vn,
            LocalPersonId = localPersonId,
            OtherPersonIds = otherPersonIds,
            OfficialName = officialName,
            FirstName = firstName,
            OriginalName = originalName,
            Sex = sex,
            DateOfBirth = dateOfBirt
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="localPersonId">Field is reqired.</param>
    /// <param name="officialName">Field is reqired.</param>
    /// <param name="firstName">Field is reqired.</param>
    /// <param name="sex">Field is reqired.</param>
    /// <param name="dateOfBirt">Field is reqired.</param>
    /// <returns>PersonIdentificationLight.</returns>
    public static PersonIdentificationLight Create(NamedPersonId localPersonId, string officialName,
        string firstName, SexType? sex, DatePartiallyKnown dateOfBirt)
    {
        return new PersonIdentificationLight
        {
            LocalPersonId = localPersonId,
            OfficialName = officialName,
            FirstName = firstName,
            Sex = sex,
            DateOfBirth = dateOfBirt
        };
    }

    protected static bool CheckValue(object obj)
    {
        return obj == null;
    }

    private static void IsInvalidValue(string message)
    {
        throw new XmlSchemaValidationException(message);
    }
}
