// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Namensangaben.
/// </summary>
[Serializable]
[JsonObject("nameData")]
[XmlRoot(ElementName = "nameData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class NameData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string OfficialNameNullValidateExceptionMessage = "OfficialName is not valid! OfficialName is required";
    private const string OfficialNameValidateExceptionMessage = "OfficialName is not valid! OfficialName  has max Length of 100";
    private const string FirstNameNullValidateExceptionMessage = "FirstName is not valid! FirstName is required";
    private const string FirstNameValidateExceptionMessage = "FirstName is not valid! FirstName  has max Length of 100";
    private const string OriginalNameValidateExceptionMessage = "OriginalName is not valid! OriginalName  has max Length of 100";
    private const string AllianceNameValidateExceptionMessage = "AllianceName is not valid! AllianceName  has max Length of 100";
    private const string AliasNameValidateExceptionMessage = "AliasName is not valid! AliasName  has max Length of 100";
    private const string OtherNameValidateExceptionMessage = "OtherName is not valid! OtherName  has max Length of 100";
    private const string CallNameValidateExceptionMessage = "CallName is not valid! CallName  has max Length of 100";

    private string _officialName;
    private string _firstName;
    private string _originalName;
    private string _allianceName;
    private string _aliasName;
    private string _otherName;
    private string _callName;

    public NameData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="officialName">Field is required.</param>
    /// <param name="firstName">Field is required.</param>
    /// <param name="originalName">Field is optional.</param>
    /// <param name="allianceName">Field is optional.</param>
    /// <param name="aliasName">Field is optional.</param>
    /// <param name="otherName">Field is optional.</param>
    /// <param name="callName">Field is optional.</param>
    /// <param name="foreignNameSource">Field is optional.</param>
    /// <param name="foreignName">Field is optional.</param>
    /// <returns>NameData.</returns>
    public static NameData Create(string officialName, string firstName, string originalName = null, string allianceName = null, string aliasName = null, string otherName = null, string callName = null, ForeignNameSource? foreignNameSource = null, ForeignerName foreignName = null)
    {
        return new NameData()
        {
            OfficialName = officialName,
            FirstName = firstName,
            OriginalName = originalName,
            AllianceName = allianceName,
            AliasName = aliasName,
            OtherName = otherName,
            CallName = callName,
            NameOnForeignPassport = foreignNameSource != null && foreignNameSource.Value == ForeignNameSource.nameOnForeignPassport ? foreignName : null,
            DeclaredForeignName = foreignNameSource != null && foreignNameSource.Value == ForeignNameSource.declaredForeignName ? foreignName : null
        };
    }

    [JsonProperty("officialName")]
    [XmlElement(ElementName = "officialName", Order = 1)]
    public string OfficialName
    {
        get { return _officialName; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(OfficialNameNullValidateExceptionMessage);
            }
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(OfficialNameValidateExceptionMessage);
            }
            _officialName = value;
        }
    }

    [JsonProperty("firstName")]
    [XmlElement(ElementName = "firstName", Order = 2)]
    public string FirstName
    {
        get { return _firstName; }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new XmlSchemaValidationException(FirstNameNullValidateExceptionMessage);
            }
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(FirstNameValidateExceptionMessage);
            }
            _firstName = value;
        }
    }

    [JsonProperty("originalName")]
    [XmlElement(ElementName = "originalName", Order = 3)]
    public string OriginalName
    {
        get { return _originalName; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(OriginalNameValidateExceptionMessage);
            }
            _originalName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OriginalNameSpecified => !string.IsNullOrEmpty(OriginalName);

    [JsonProperty("allianceName")]
    [XmlElement(ElementName = "allianceName", Order = 4)]
    public string AllianceName
    {
        get { return _allianceName; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(AllianceNameValidateExceptionMessage);
            }
            _allianceName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool AllianceNameSpecified => !string.IsNullOrEmpty(AllianceName);

    [JsonProperty("aliasName")]
    [XmlElement(ElementName = "aliasName", Order = 5)]
    public string AliasName
    {
        get { return _aliasName; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(AliasNameValidateExceptionMessage);
            }
            _aliasName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool AliasNameSpecified => !string.IsNullOrEmpty(AliasName);

    [JsonProperty("otherName")]
    [XmlElement(ElementName = "otherName", Order = 6)]
    public string OtherName
    {
        get { return _otherName; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(OtherNameValidateExceptionMessage);
            }
            _otherName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OtherNameSpecified => !string.IsNullOrEmpty(OtherName);

    [JsonProperty("callName")]
    [XmlElement(ElementName = "callName", Order = 7)]
    public string CallName
    {
        get { return _callName; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(CallNameValidateExceptionMessage);
            }
            _callName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool CallNameSpecified => !string.IsNullOrEmpty(CallName);

    [JsonProperty("nameOnForeignPassport")]
    [XmlElement(ElementName = "nameOnForeignPassport", Order = 8)]
    public ForeignerName NameOnForeignPassport { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool NameOnForeignPassportSpecified => NameOnForeignPassport != null;

    [JsonProperty("declaredForeignName")]
    [XmlElement(ElementName = "declaredForeignName", Order = 9)]
    public ForeignerName DeclaredForeignName { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool DeclaredForeignNameSpecified => DeclaredForeignName != null;
}

public enum ForeignNameSource
{
    nameOnForeignPassport,
    declaredForeignName
}
