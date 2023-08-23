// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("authorityType")]
[XmlRoot(ElementName = "authorityType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class AuthorityType : FieldValueChecker<AuthorityType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string AuthorityChoiceNullValidateExceptionMessage = "AuthorityChoice is not valid! AuthorityChoice is required";
    private const string AuthorityChoiceOutOfRangeValidateExceptionMessage = "AuthorityChoice is not valid! AuthorityChoice is a false Type";

    [JsonIgnore]
    [XmlIgnore]
    public AuthorityChoiceIdentifier ElementTypeName;

    private object _authorityChoice;

    public AuthorityType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    [XmlElement("municipalityRegister", typeof(MunicipalityRegisterType))]
    [XmlElement("cantonalRegister", typeof(CantonalRegisterType))]
    [XmlElement("otherRegister", typeof(OtherRegisterType))]
    [XmlChoiceIdentifier("ElementTypeName")]
    public object AuthorityChoice
    {
        get => _authorityChoice;
        set => _authorityChoice = AuthorityChoiceIsValid(value);
    }

    private object AuthorityChoiceIsValid(object value)
    {
        if (value == null)
        {
            throw new XmlSchemaValidationException(AuthorityChoiceNullValidateExceptionMessage);
        }

        if (value is MunicipalityRegisterType)
        {
            ElementTypeName = AuthorityChoiceIdentifier.municipalityRegister;
        }
        else if (value is CantonalRegisterType)
        {
            ElementTypeName = AuthorityChoiceIdentifier.cantonalRegister;
        }
        else if (value is OtherRegisterType)
        {
            ElementTypeName = AuthorityChoiceIdentifier.otherRegister;
        }
        else
        {
            throw new XmlSchemaValidationException(AuthorityChoiceOutOfRangeValidateExceptionMessage);
        }

        return value;
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="municipalityRegister">Field is required.</param>
    /// <returns>Authority.</returns>
    public static AuthorityType Create(object municipalityRegister)
    {
        return new AuthorityType
        {
            AuthorityChoice = municipalityRegister
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="cantonalRegister">Field is required.</param>
    /// <returns>Authority.</returns>
    public static AuthorityType Create(CantonalRegisterType cantonalRegister)
    {
        return new AuthorityType
        {
            AuthorityChoice = cantonalRegister
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="otherRegister">Field is required.</param>
    /// <returns>Authority.</returns>
    public static AuthorityType Create(OtherRegisterType otherRegister)
    {
        return new AuthorityType
        {
            AuthorityChoice = otherRegister
        };
    }
}
public enum AuthorityChoiceIdentifier
{
    municipalityRegister,
    cantonalRegister,
    otherRegister
}
