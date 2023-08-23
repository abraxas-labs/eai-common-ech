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
[JsonObject("foreignerPersonType")]
[XmlRoot(ElementName = "foreignerPersonType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class ForeignerPersonType : PersonType
{
    private ForeignerName _nameOnForeignPassport;
    private ForeignerName _declaredForeignName;
    private ResidencePermitData _residencePermit;

    public ForeignerPersonType()
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
    /// <param name="nameOnForeignPassport">Field is optional.</param>
    /// <param name="declaredForeignName">Field is optional.</param>
    /// <param name="residencePermit">Field is optional.</param>
    /// <returns>ForeignerPersonType.</returns>
    public static ForeignerPersonType Create(PersonIdentification personIdentification, string callName, string allianceName, LanguageType languageOfCorrespondance, ReligionData religionData,
        object extension, ForeignerName nameOnForeignPassport, ForeignerName declaredForeignName, ResidencePermitData residencePermit)
    {
        var foreignerPersonType = new ForeignerPersonType
        {
            PersonIdentification = personIdentification,
            CallName = callName,
            AllianceName = allianceName,
            LanguageOfCorrespondance = languageOfCorrespondance,
            ReligionData = religionData,
            Extension = extension,
            NameOnForeignPassport = nameOnForeignPassport,
            DeclaredForeignName = declaredForeignName,
            ResidencePermit = residencePermit
        };

        if (nameOnForeignPassport == null && declaredForeignName != null)
        {
            foreignerPersonType.DeclaredForeignName = declaredForeignName;
        }
        else if (nameOnForeignPassport != null && declaredForeignName == null)
        {
            foreignerPersonType.NameOnForeignPassport = nameOnForeignPassport;
        }
        else
        {
            throw new FieldValidationException("Either field 'nameOnForeignPassport' or field 'declaredForeignName' must be null!");
        }

        return foreignerPersonType;
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="languageOfCorrespondance">Field is required.</param>
    /// <returns>ForeignerPersonType.</returns>
    public static new ForeignerPersonType Create(PersonIdentification personIdentification, LanguageType languageOfCorrespondance)
    {
        return new ForeignerPersonType
        {
            PersonIdentification = personIdentification,
            LanguageOfCorrespondance = languageOfCorrespondance
        };
    }

    [JsonProperty("nameOnForeignPassport")]
    [XmlElement(ElementName = "nameOnForeignPassport", Order = 1)]
    public ForeignerName NameOnForeignPassport
    {
        get => _nameOnForeignPassport;
        set => CheckAndSetValue(ref _nameOnForeignPassport, value);
    }

    [JsonProperty("declaredForeignName")]
    [XmlElement(ElementName = "declaredForeignName", Order = 2)]
    public ForeignerName DeclaredForeignName
    {
        get => _declaredForeignName;
        set => CheckAndSetValue(ref _declaredForeignName, value);
    }

    [JsonProperty("residencePermit")]
    [XmlElement(ElementName = "residencePermit", Order = 3)]
    public ResidencePermitData ResidencePermit
    {
        get => _residencePermit;
        set => CheckAndSetValue(ref _residencePermit, value);
    }
}
