// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("otherRegisterType")]
[XmlRoot(ElementName = "otherRegisterType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class OtherRegisterType : FieldValueChecker<OtherRegisterType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _registerIdentification;
    private string _registerName;

    public OtherRegisterType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="registerIdentification">Field is required.</param>
    /// <param name="registerName">Field is required.</param>
    /// <returns>OtherRegister.</returns>
    public static OtherRegisterType Create(string registerIdentification, string registerName)
    {
        return new OtherRegisterType
        {
            RegisterIdentification = registerIdentification,
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

    [XmlIgnore]
    [JsonIgnore]
    public bool RegisterIdentificationSpecified => !string.IsNullOrWhiteSpace(RegisterIdentification);

    [FieldRequired]
    [FieldMaxLength(100)]
    [JsonProperty("registerName")]
    [XmlElement(ElementName = "registerName", Order = 2)]
    public string RegisterName
    {
        get => _registerName;
        set => CheckAndSetValue(ref _registerName, value);
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool RegisterNameSpecified => !string.IsNullOrWhiteSpace(RegisterName);
}
