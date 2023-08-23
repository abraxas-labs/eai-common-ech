// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_6_0;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("municipalityRegisterType")]
[XmlRoot(ElementName = "municipalityRegisterType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class MunicipalityRegisterType : FieldValueChecker<MunicipalityRegisterType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _registerIdentification;
    private string _municipalityName;
    private CantonAbbreviation? _cantonAbbreviation;
    private string _registerName;

    public MunicipalityRegisterType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="registerIdentification">Field is required.</param>
    /// <param name="registerName">Field is required.</param>
    /// <param name="municipalityName">Field is required.</param>
    /// <param name="cantonAbbreviation">Field is optional.</param>
    /// <returns>MunicipalityRegister.</returns>
    public static MunicipalityRegisterType Create(string registerIdentification, string registerName, string municipalityName = null, CantonAbbreviation? cantonAbbreviation = null)
    {
        return new MunicipalityRegisterType
        {
            RegisterIdentification = registerIdentification,
            RegisterName = registerName,
            CantonAbbreviation = cantonAbbreviation,
            MunicipalityName = municipalityName
        };
    }

    [FieldRequired]
    [FieldMaxLength(50)]
    [JsonProperty("registerIdentification")]
    [XmlElement(ElementName = "registerIdentification", Order = 1)]
    public string RegisterIdentification
    {
        get => _registerIdentification;
        set => CheckAndSetValue(ref _registerIdentification, value);
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool RegisterIdentificationSpecified => !string.IsNullOrWhiteSpace(RegisterIdentification);

    [FieldRequired]
    [FieldMaxLength(40)]
    [JsonProperty("municipalityName")]
    [XmlElement(ElementName = "municipalityName", Order = 2)]
    public string MunicipalityName
    {
        get => _municipalityName;
        set => CheckAndSetValue(ref _municipalityName, value);
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool MunicipalityNameSpecified => !string.IsNullOrWhiteSpace(MunicipalityName);

    [JsonProperty("cantonAbbreviation")]
    [XmlElement(ElementName = "cantonAbbreviation", Order = 3)]
    public CantonAbbreviation? CantonAbbreviation
    {
        get => _cantonAbbreviation;
        set => CheckAndSetValue(ref _cantonAbbreviation, value);
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool CantonAbbreviationSpecified => CantonAbbreviation != null;

    [FieldRequired]
    [FieldMaxLength(100)]
    [JsonProperty("registerName")]
    [XmlElement(ElementName = "registerName", Order = 4)]
    public string RegisterName
    {
        get => _registerName;
        set => CheckAndSetValue(ref _registerName, value);
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool RegisterNameSpecified => !string.IsNullOrWhiteSpace(RegisterName);
}
