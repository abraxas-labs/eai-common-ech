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
[JsonObject("nameDataType")]
[XmlRoot(ElementName = "nameDataType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class NameDataType : FieldValueChecker<NameDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _officialName;
    private string _firstName;
    private string _originalName;
    private string _alliancePartnershipName;
    private string _aliasName;
    private string _otherName;
    private string _callName;
    private string _nameOnPassport;
    private string _firstNameOnPassport;
    private string _title;
    private DateTime? _nameValidFrom;

    public NameDataType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="officialName">Field is required.</param>
    /// <param name="firstName">Field is required. </param >
    /// <param name="originalName">Field is optional.</param>
    /// <param name="alliancePartnershipName">Field is optional. </param>
    /// <param name="aliasName">Field is optional.</param>
    /// <param name="otherName">Field is optional.</param>
    /// <param name="callName">Field is optional.</param>
    /// <param name="nameOnPassport">Field is optional.</param>
    /// <param name="firstNameOnPassport">Field is optional.</param>
    /// <param name="title">Field is optional.</param>
    /// <param name="nameValidFrom">Field is optional.</param>
    /// <returns>DeathDataType.</returns>
    public static NameDataType Create(string officialName, string firstName, string originalName, string alliancePartnershipName, string aliasName,
        string otherName, string callName, string nameOnPassport, string firstNameOnPassport, string title, DateTime? nameValidFrom)
    {
        return new NameDataType
        {
            OfficialName = officialName,
            FirstName = firstName,
            OriginalName = originalName,
            AlliancePartnershipName = alliancePartnershipName,
            AliasName = aliasName,
            OtherName = otherName,
            CallName = callName,
            NameOnPassport = nameOnPassport,
            FirstNameOnPassport = firstNameOnPassport,
            Title = title,
            NameValidFrom = nameValidFrom
        };
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 100)]
    [JsonProperty("officialName")]
    [XmlElement(ElementName = "officialName")]
    public string OfficialName
    {
        get => _officialName;
        set => CheckAndSetValue(ref _officialName, value);
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 100)]
    [JsonProperty("firstName")]
    [XmlElement(ElementName = "firstName")]
    public string FirstName
    {
        get => _firstName;
        set => CheckAndSetValue(ref _firstName, value);
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

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("nameOnPassport")]
    [XmlElement(ElementName = "nameOnPassport")]
    public string NameOnPassport
    {
        get => _nameOnPassport;
        set => CheckAndSetValue(ref _nameOnPassport, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("firstNameOnPassport")]
    [XmlElement(ElementName = "firstNameOnPassport")]
    public string FirstNameOnPassport
    {
        get => _firstNameOnPassport;
        set => CheckAndSetValue(ref _firstNameOnPassport, value);
    }

    [FieldMaxLength(20)]
    [JsonProperty("title")]
    [XmlElement(ElementName = "title")]
    public string Title
    {
        get => _title;
        set => CheckAndSetValue(ref _title, value);
    }

    [FieldRequired]
    [JsonProperty("nameValidFrom")]
    [XmlElement(ElementName = "nameValidFrom")]
    public DateTime? NameValidFrom
    {
        get => _nameValidFrom;
        set => CheckAndSetValue(ref _nameValidFrom, value);
    }
}
