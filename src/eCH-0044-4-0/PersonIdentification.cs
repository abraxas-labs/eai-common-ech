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
///     personIdentificationType beinhaltet zusätzlich zu Identifikationsnummern weitere identifizierende Merkmale
///     wie der Amtliche Name, die Vornamen, das Geschlecht und das Geburtsdatum für eine sichere Identifikation.
/// </summary>
[Serializable]
[JsonObject("personIdentification")]
[XmlRoot(ElementName = "personIdentification", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044/4")]
public class PersonIdentification
{
    private const string VnValidateExceptionMessage =
        "Vn is not valid! Vn has to be between 7560000000001 and 7569999999999";

    private const string LocalPersonIdValidateExceptionMessage =
        "LocalPersonId is not valid! LocalPersonId can not be null";

    private const string OfficialNameValidateExceptionMessage =
        "OfficialName is not valid! OfficialName can not be null or empty and has max Length 100";

    private const string FirstNameValidateExceptionMessage =
        "FirstName is not valid! FirstName can not be null or empty and has max Length 100";

    private const string OriginalNameValidateExceptionMessage =
        "originalName is not valid! originalName has max Length 100";

    private const string SexValidateExceptionMessage = "Sex is not valid! Sex can not be null or empty";

    private const string DateOfBirtValidateExceptionMessage =
        "DateOfBirt is not valid! DateOfBirt can not be null or empty";

    private DatePartiallyKnown _dateOfBirth;
    private List<NamedPersonId> _euPersonIds;
    private string _firstName;
    private NamedPersonId _localPersonId;
    private string _officialName;
    private string _originalName;
    private List<NamedPersonId> _otherPersonIds;
    private SexType _sex;
    private string _vn;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public PersonIdentification()
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
            if (!string.IsNullOrEmpty(value) && (long.Parse(value) < 7560000000001 || long.Parse(value) > 7569999999999))
            {
                IsInvalidValue(VnValidateExceptionMessage);
            }

            _vn = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool VnSpecified => !string.IsNullOrEmpty(Vn);

    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public NamedPersonId LocalPersonId
    {
        get => _localPersonId;
        set
        {
            if (CheckValue(value))
            {
                IsInvalidValue(LocalPersonIdValidateExceptionMessage);
            }

            _localPersonId = value;
        }
    }

    [JsonProperty("otherPersonId")]
    [XmlElement(ElementName = "otherPersonId")]
    public List<NamedPersonId> OtherPersonIds
    {
        get => _otherPersonIds;
        set => _otherPersonIds = value;
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OtherPersonIdsSpecified => OtherPersonIds != null && OtherPersonIds.Any();

    [JsonProperty("euPersonId")]
    [XmlElement(ElementName = "euPersonId")]
    public List<NamedPersonId> EuPersonIds
    {
        get => _euPersonIds;
        set => _euPersonIds = value;
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool EuPersonIdsSpecified => EuPersonIds != null && EuPersonIds.Any();

    [JsonProperty("officialName")]
    [XmlElement(DataType = "string", ElementName = "officialName")]
    public string OfficialName
    {
        get => _officialName;
        set
        {
            if (value != null && (string.IsNullOrEmpty(value) || value.Length > 100))
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
            if (value != null && (string.IsNullOrEmpty(value) || value.Length > 100))
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

    [JsonIgnore]
    [XmlIgnore]
    public bool OriginalNameSpecified => !string.IsNullOrEmpty(OriginalName);

    [JsonProperty("sex")]
    [XmlElement(ElementName = "sex")]
    public SexType Sex
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

    [JsonProperty("dateOfBirth")]
    [XmlElement(ElementName = "dateOfBirth")]
    public DatePartiallyKnown DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            if (CheckValue(value))
            {
                IsInvalidValue(DateOfBirtValidateExceptionMessage);
            }

            _dateOfBirth = value;
        }
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
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
    public static PersonIdentification Create(string vn, NamedPersonId localPersonId,
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
    /// <returns>PersonIdentification.</returns>
    public static PersonIdentification Create(NamedPersonId localPersonId, string officialName, string firstName,
        SexType sex, DatePartiallyKnown dateOfBirt)
    {
        return new PersonIdentification
        {
            LocalPersonId = localPersonId,
            OfficialName = officialName,
            FirstName = firstName,
            Sex = sex,
            DateOfBirth = dateOfBirt
        };
    }

    private static void IsInvalidValue(string message) => throw new XmlSchemaValidationException(message);

    private bool CheckValue(object obj)
    {
        return obj == null;
    }
}
