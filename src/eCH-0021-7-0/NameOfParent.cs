// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Amtliche Namen der Eltern.
/// </summary>
[Serializable]
[JsonObject("nameOfParent")]
[XmlRoot(ElementName = "nameOfParent", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class NameOfParent
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string FirstNameValidateExceptionMessage = "FirstName is not valid! FirstName has to be maximum length 100";
    private const string FirstNameNullValidateExceptionMessage = "FirstName is not valid! FirstName is required";
    private const string OfficialNameValidateExceptionMessage = "OfficialName is not valid! OfficialName has to be maximum length 100";
    private const string OfficialNameNullValidateExceptionMessage = "OfficialName is not valid! OfficialName is required";
    private const string FirstNameOnlyValidateExceptionMessage = "FirstNameOnly is not valid! FirstNameOnly has to be maximum length 100";
    private const string NameOnlyNullValidateExceptionMessage = "NameOnly is not valid! NameOnly is required";
    private const string OfficialNameOnlyValidateExceptionMessage = "OfficialNameOnly is not valid! OfficialNameOnly has to be maximum length 100";

    private string _title;
    private string _officialName;
    private string _firstNameOnly;
    private string _officialNameOnly;

    public NameOfParent()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="firstName">Field is required.</param>
    /// <param name="officialName">Field is required.</param>
    /// <param name="officialProofOfNameOfParentsYesNo">Field is optional.</param>
    /// <returns>NameOfParent.</returns>
    public static NameOfParent Create(string firstName, string officialName, bool? officialProofOfNameOfParentsYesNo = null)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new XmlSchemaValidationException(FirstNameNullValidateExceptionMessage);
        }
        if (string.IsNullOrEmpty(officialName))
        {
            throw new XmlSchemaValidationException(OfficialNameNullValidateExceptionMessage);
        }
        return new NameOfParent()
        {
            FirstName = firstName,
            OfficialName = officialName,
            FirstNameOnly = null,
            OfficialNameOnly = null,
            OfficialProofOfNameOfParentsYesNo = officialProofOfNameOfParentsYesNo
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="nameOnly">Field is required.</param>
    /// <param name="whatNameOnly">Field is required.</param>
    /// <param name="officialProofOfNameOfParentsYesNo">Field is optional.</param>
    /// <returns>NameOfParent.</returns>
    public static NameOfParent Create(string nameOnly, NameOnly whatNameOnly, bool? officialProofOfNameOfParentsYesNo = null)
    {
        if (string.IsNullOrEmpty(nameOnly))
        {
            throw new XmlSchemaValidationException(NameOnlyNullValidateExceptionMessage);
        }
        return new NameOfParent()
        {
            FirstName = null,
            OfficialName = null,
            FirstNameOnly = whatNameOnly == NameOnly.FirstNameOnly ? nameOnly : null,
            OfficialNameOnly = whatNameOnly == NameOnly.OfficialNameOnly ? nameOnly : null,
            OfficialProofOfNameOfParentsYesNo = officialProofOfNameOfParentsYesNo
        };
    }

    [JsonProperty("firstName")]
    [XmlElement(ElementName = "firstName", Order = 1)]
    public string FirstName
    {
        get { return _title; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(FirstNameValidateExceptionMessage);
            }
            _title = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool FirstNameSpecified => !string.IsNullOrEmpty(FirstName);

    [JsonProperty("officialName")]
    [XmlElement(ElementName = "officialName", Order = 2)]
    public string OfficialName
    {
        get { return _officialName; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(OfficialNameValidateExceptionMessage);
            }
            _officialName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OfficialNameSpecified => !string.IsNullOrEmpty(OfficialName);

    [JsonProperty("firstNameOnly")]
    [XmlElement(ElementName = "firstNameOnly", Order = 3)]
    public string FirstNameOnly
    {
        get { return _firstNameOnly; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(FirstNameOnlyValidateExceptionMessage);
            }
            _firstNameOnly = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool FirstNameOnlySpecified => !string.IsNullOrEmpty(FirstNameOnly);

    [JsonProperty("officialNameOnly")]
    [XmlElement(ElementName = "officialNameOnly", Order = 4)]
    public string OfficialNameOnly
    {
        get { return _officialNameOnly; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(OfficialNameOnlyValidateExceptionMessage);
            }
            _officialNameOnly = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OfficialNameOnlySpecified => !string.IsNullOrEmpty(OfficialNameOnly);

    [JsonProperty("officialProofOfNameOfParentsYesNo")]
    [XmlElement(ElementName = "officialProofOfNameOfParentsYesNo", Order = 5)]
    public bool? OfficialProofOfNameOfParentsYesNo { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool OfficialProofOfNameOfParentsYesNoSpecified => OfficialProofOfNameOfParentsYesNo.HasValue;
}

public enum NameOnly
{
    FirstNameOnly,
    OfficialNameOnly
}
