// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zur beruflichen Tätigkeit.
/// </summary>
[Serializable]
[JsonObject("nameOfParentAtBirthType")]
[XmlRoot(ElementName = "nameOfParentAtBirthType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class NameOfParentAtBirthType : FieldValueChecker<NameOfParentAtBirthType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _firstName;
    private string _officialName;
    private string _firstNameOnly;
    private string _officialNameOnly;
    private bool? _officialProofOfNameOfParentsYesNo;

    public NameOfParentAtBirthType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="firstName">Field is optional.</param>
    /// <param name="officialName">Field is required.</param>
    /// <param name="firstNameOnly">Field is required.</param>
    /// <param name="officialNameOnly">Field is required.</param>
    /// <param name="officialProofOfNameOfParentsYesNo">Field is optional.</param>
    /// <returns>NameOfParentAtBirthType.</returns>
    public static NameOfParentAtBirthType Create(string firstName, string officialName, string firstNameOnly, string officialNameOnly, bool officialProofOfNameOfParentsYesNo)
    {
        if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(officialName))
        {
            if (!string.IsNullOrWhiteSpace(firstNameOnly) || string.IsNullOrWhiteSpace(officialNameOnly))
            {
                throw new FieldValidationException("Fields 'firstNameOnly' and 'officialNameOnly' must be empty if fields 'firstName' and 'officialName' are filled.");
            }

            return new NameOfParentAtBirthType
            {
                FirstName = firstName,
                OfficialName = officialName,
                FirstNameOnly = null,
                OfficialNameOnly = null,
                OfficialProofOfNameOfParentsYesNo = officialProofOfNameOfParentsYesNo
            };
        }

        if (!string.IsNullOrWhiteSpace(firstNameOnly))
        {
            if (!string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(officialName) || string.IsNullOrWhiteSpace(officialNameOnly))
            {
                throw new FieldValidationException("Fields 'firstName', 'officialName' and 'officialNameOnly' must be empty if field 'firstNameOnly' is filled.");
            }

            return new NameOfParentAtBirthType
            {
                FirstName = null,
                OfficialName = null,
                FirstNameOnly = firstNameOnly,
                OfficialNameOnly = null,
                OfficialProofOfNameOfParentsYesNo = officialProofOfNameOfParentsYesNo
            };
        }

        if (!string.IsNullOrWhiteSpace(officialNameOnly))
        {
            if (!string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(officialName) || string.IsNullOrWhiteSpace(firstNameOnly))
            {
                throw new FieldValidationException("Fields 'firstName', 'officialName' and 'firstNameOnly' must be empty if field 'officialNameOnly' is filled.");
            }

            return new NameOfParentAtBirthType
            {
                FirstName = null,
                OfficialName = null,
                FirstNameOnly = null,
                OfficialNameOnly = officialNameOnly,
                OfficialProofOfNameOfParentsYesNo = officialProofOfNameOfParentsYesNo
            };
        }

        throw new FieldValidationException("Wrong combination of filled and empty fields. Please see eCH-0021-6-0 ducomentation on https://www.ech.ch/vechweb/page?p=dossier&documentNumber=eCH-0021&documentVersion=6.0");
    }

    [JsonProperty("firstName")]
    [XmlElement(ElementName = "firstName")]
    public string FirstName
    {
        get => _firstName;
        set => CheckAndSetValue(ref _firstName, value);
    }

    [JsonProperty("officialName")]
    [XmlElement(ElementName = "officialName")]
    public string OfficialName
    {
        get => _officialName;
        set => CheckAndSetValue(ref _officialName, value);
    }

    [JsonProperty("firstNameOnly")]
    [XmlElement(ElementName = "firstNameOnly")]
    public string FirstNameOnly
    {
        get => _firstNameOnly;
        set => CheckAndSetValue(ref _firstNameOnly, value);
    }

    [JsonProperty("officialNameOnly")]
    [XmlElement(ElementName = "officialNameOnly")]
    public string OfficialNameOnly
    {
        get => _officialNameOnly;
        set => CheckAndSetValue(ref _officialNameOnly, value);
    }

    [JsonProperty("OfficialProofOfNameOfParentsYesNo")]
    [XmlElement(ElementName = "OfficialProofOfNameOfParentsYesNo")]
    public bool? OfficialProofOfNameOfParentsYesNo
    {
        get => _officialProofOfNameOfParentsYesNo;
        set => CheckAndSetValue(ref _officialProofOfNameOfParentsYesNo, value);
    }
}
