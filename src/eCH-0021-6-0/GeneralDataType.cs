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
[JsonObject("generalDataType")]
[XmlRoot(ElementName = "generalDataType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class GeneralDataType : FieldValueChecker<GeneralDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _languageOfCorrespondance;
    private NameOfParentAtBirthType _nameOfFatherAtBirth;
    private NameOfParentAtBirthType _nameOfMotherAtBirth;
    private DataLockType _dataLock;
    private YesNoType _paperLock;
    private DateTime _generalDataValidFrom;

    public GeneralDataType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="languageOfCorrespondance">Field is optional.</param>
    /// <param name="nameOfFatherAtBirth">Field is optional.</param>
    /// <param name="nameOfMotherAtBirth">Field is optional.</param>
    /// <param name="dataLock">Field is optional.</param>
    /// <param name="paperLock">Field is optional.</param>
    /// <param name="generalDataValidFrom">Field is optional.</param>
    /// <returns>DeathDataType.</returns>
    public static GeneralDataType Create(string languageOfCorrespondance, NameOfParentAtBirthType nameOfFatherAtBirth,
        NameOfParentAtBirthType nameOfMotherAtBirth, DataLockType dataLock, YesNoType paperLock, DateTime generalDataValidFrom)
    {
        return new GeneralDataType
        {
            LanguageOfCorrespondance = languageOfCorrespondance,
            NameOfFatherAtBirth = nameOfFatherAtBirth,
            NameOfMotherAtBirth = nameOfMotherAtBirth,
            DataLock = dataLock,
            PaperLock = paperLock,
            GeneralDataValidFrom = generalDataValidFrom
        };
    }

    [JsonProperty("languageOfCorrespondance")]
    [XmlElement(ElementName = "languageOfCorrespondance")]
    public string LanguageOfCorrespondance
    {
        get => _languageOfCorrespondance;
        set => CheckAndSetValue(ref _languageOfCorrespondance, value);
    }

    [JsonProperty("nameOfFatherAtBirth")]
    [XmlElement(ElementName = "nameOfFatherAtBirth")]
    public NameOfParentAtBirthType NameOfFatherAtBirth
    {
        get => _nameOfFatherAtBirth;
        set => CheckAndSetValue(ref _nameOfFatherAtBirth, value);
    }

    [JsonProperty("nameOfMotherAtBirth")]
    [XmlElement(ElementName = "nameOfMotherAtBirth")]
    public NameOfParentAtBirthType NameOfMotherAtBirth
    {
        get => _nameOfMotherAtBirth;
        set => CheckAndSetValue(ref _nameOfMotherAtBirth, value);
    }

    [JsonProperty("dataLock")]
    [XmlElement(ElementName = "dataLock")]
    public DataLockType DataLock
    {
        get => _dataLock;
        set => CheckAndSetValue(ref _dataLock, value);
    }

    [JsonProperty("paperLock")]
    [XmlElement(ElementName = "paperLock")]
    public YesNoType PaperLock
    {
        get => _paperLock;
        set => CheckAndSetValue(ref _paperLock, value);
    }

    [JsonProperty("generalDataValidFrom")]
    [XmlElement(ElementName = "generalDataValidFrom")]
    public DateTime GeneralDataValidFrom
    {
        get => _generalDataValidFrom;
        set => CheckAndSetValue(ref _generalDataValidFrom, value);
    }
}
