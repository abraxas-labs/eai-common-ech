// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// EventDeletedInRegister.
/// </summary>
[Serializable]
[JsonObject("eventDeletedInRegister")]
[XmlRoot(ElementName = "eventDeletedInRegister", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class EventDeletedInRegister
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string DeledetInRegisterPersonNullValidateExceptionMessage = "DeledetInRegisterPerson is not valid! DeledetInRegisterPerson is required";

    private PersonIdentification _deledetInRegisterPerson;

    public EventDeletedInRegister()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="deledetInRegisterPerson">Field is required.</param>
    /// <param name="extension">Field is optional.</param>
    /// <returns>EventBaseDelivery.</returns>
    public static EventDeletedInRegister Create(PersonIdentification deledetInRegisterPerson, object extension = null)
    {
        return new EventDeletedInRegister()
        {
            DeledetInRegisterPerson = deledetInRegisterPerson,
            Extension = extension
        };
    }

    [JsonProperty("deledetInRegisterPerson")]
    [XmlElement(ElementName = "deledetInRegisterPerson")]
    public PersonIdentification DeledetInRegisterPerson
    {
        get { return _deledetInRegisterPerson; }

        set
        {
            _deledetInRegisterPerson = value ?? throw new XmlSchemaValidationException(DeledetInRegisterPersonNullValidateExceptionMessage);
        }
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public object Extension { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ExtensionSpecified => Extension != null;
}
