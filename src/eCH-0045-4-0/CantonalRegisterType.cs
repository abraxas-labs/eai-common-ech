// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0007_6_0;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("cantonalRegisterType")]
[XmlRoot(ElementName = "cantonalRegisterType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class CantonalRegisterType : FieldValueChecker<CantonalRegisterType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _registerIdentification;
    private CantonAbbreviation _cantonAbbreviation;
    private string _registerName;

    public CantonalRegisterType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="registerIdentification">Field is required.</param>
    /// <param name="registerName">Field is required.</param>
    /// <param name="cantonAbbreviation">Field is required.</param>
    /// <returns>CantonalRegisterType.</returns>
    public static CantonalRegisterType Create(string registerIdentification, string registerName, CantonAbbreviation cantonAbbreviation)
    {
        return new CantonalRegisterType
        {
            RegisterIdentification = registerIdentification,
            CantonAbbreviation = cantonAbbreviation,
            RegisterName = registerName
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

    [FieldRequired]
    [JsonProperty("cantonAbbreviation")]
    [XmlElement(ElementName = "cantonAbbreviation", Order = 2)]
    public CantonAbbreviation CantonAbbreviation
    {
        get => _cantonAbbreviation;
        set => CheckAndSetValue(ref _cantonAbbreviation, value);
    }

    [FieldRequired]
    [FieldMaxLength(100)]
    [JsonProperty("registerName")]
    [XmlElement(ElementName = "registerName", Order = 3)]
    public string RegisterName
    {
        get => _registerName;
        set => CheckAndSetValue(ref _registerName, value);
    }
}
