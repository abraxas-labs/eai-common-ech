// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0011_8_1;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("personType")]
[XmlRoot(ElementName = "personType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class PersonType : FieldValueChecker<PersonType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _personIdentification;
    private string _callName;
    private string _allianceName;
    private LanguageType _languageOfCorrespondance;
    private ReligionData _religionData;
    private object _extension;

    public PersonType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="callName">Field is optional.</param>
    /// <param name="allianceName">Field is optional.</param>
    /// <param name="languageOfCorrespondance">Field is required.</param>
    /// <param name="religionData">Field is optional.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>Person.</returns>
    public static PersonType Create(PersonIdentification personIdentification, string callName, string allianceName, LanguageType languageOfCorrespondance, ReligionData religionData, object extension)
    {
        return new PersonType
        {
            PersonIdentification = personIdentification,
            CallName = callName,
            AllianceName = allianceName,
            LanguageOfCorrespondance = languageOfCorrespondance,
            ReligionData = religionData,
            Extension = extension
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="languageOfCorrespondance">Field is required.</param>
    /// <returns>Person.</returns>
    public static PersonType Create(PersonIdentification personIdentification, LanguageType languageOfCorrespondance)
    {
        return new PersonType
        {
            PersonIdentification = personIdentification,
            LanguageOfCorrespondance = languageOfCorrespondance
        };
    }

    [FieldRequired]
    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification", Order = 1)]
    public PersonIdentification PersonIdentification
    {
        get => _personIdentification;
        set => CheckAndSetValue(ref _personIdentification, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("callName")]
    [XmlElement(ElementName = "callName", Order = 2)]
    public string CallName
    {
        get => _callName;
        set => CheckAndSetValue(ref _callName, value);
    }

    [FieldMinMaxLength(1, 100)]
    [JsonProperty("allianceName")]
    [XmlElement(ElementName = "allianceName", Order = 3)]
    public string AllianceName
    {
        get => _allianceName;
        set => CheckAndSetValue(ref _allianceName, value);
    }

    [FieldRequired]
    [FieldMaxLength(2)]
    [JsonProperty("languageOfCorrespondance")]
    [XmlElement(ElementName = "languageOfCorrespondance", Order = 4)]
    public LanguageType LanguageOfCorrespondance
    {
        get => _languageOfCorrespondance;
        set => CheckAndSetValue(ref _languageOfCorrespondance, value);
    }

    [JsonProperty("religionData")]
    [XmlElement(ElementName = "religionData", Order = 5)]
    public ReligionData ReligionData
    {
        get => _religionData;
        set => CheckAndSetValue(ref _religionData, value);
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension", Order = 6)]
    public object Extension
    {
        get => _extension;
        set => CheckAndSetValue(ref _extension, value);
    }
}
