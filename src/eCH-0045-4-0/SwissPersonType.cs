// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0011_8_1;
using eCH_0021_7_0;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("swissPersonType")]
[XmlRoot(ElementName = "swissPersonType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class SwissPersonType : FieldValueChecker<SwissPersonType>
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

    public SwissPersonType()
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
    /// <param name="placeOfOrigin">Field is required.</param>
    /// <param name="placeOfOriginAddonData">Field is optional.</param>
    /// <returns>SwissPersonType.</returns>
    public static SwissPersonType Create(PersonIdentification personIdentification, string callName, string allianceName, LanguageType languageOfCorrespondance, ReligionData religionData,
        object extension, List<PlaceOfOrigin> placeOfOrigin, List<PlaceOfOriginAddonData> placeOfOriginAddonData)
    {
        return new SwissPersonType
        {
            PersonIdentification = personIdentification,
            CallName = callName,
            AllianceName = allianceName,
            LanguageOfCorrespondance = languageOfCorrespondance,
            ReligionData = religionData,
            Extension = extension,
            PlaceOfOrigin = placeOfOrigin,
            PlaceOfOriginAddonData = placeOfOriginAddonData
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="languageOfCorrespondance">Field is required.</param>
    /// <param name="placeOfOrigin">Field is required.</param>
    /// <returns>ForeignerPersonType.</returns>
    public static SwissPersonType Create(PersonIdentification personIdentification, LanguageType languageOfCorrespondance, List<PlaceOfOrigin> placeOfOrigin)
    {
        return new SwissPersonType
        {
            PersonIdentification = personIdentification,
            LanguageOfCorrespondance = languageOfCorrespondance,
            PlaceOfOrigin = placeOfOrigin
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

    [FieldRequired]
    [JsonProperty("placeOfOrigin")]
    [XmlElement(ElementName = "placeOfOrigin", Order = 7)]
    public List<PlaceOfOrigin> PlaceOfOrigin { get; set; }

    [JsonProperty("placeOfOriginAddonData")]
    [XmlElement(ElementName = "placeOfOriginAddonData", Order = 8)]
    public List<PlaceOfOriginAddonData> PlaceOfOriginAddonData { get; set; }
}
