// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("authorityType")]
[XmlRoot(ElementName = "authorityType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class Authority
{
    private const string AuthorityChoiceNullValidateExceptionMessage =
        "AuthorityChoice is not valid! AuthorityChoice is required";

    private const string AuthorityChoiceOutOfRangeValidateExceptionMessage =
        "AuthorityChoice is not valid! AuthorityChoice is a false Type";

    [JsonIgnore][XmlIgnore] public AuthorityChoiceIdentifier ElementTypeName;
    private object _authorityChoice;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Authority()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [XmlElement("municipalityRegister", typeof(MunicipalityRegister))]
    [XmlElement("cantonalRegister", typeof(CantonalRegister))]
    [XmlElement("otherRegister", typeof(OtherRegister))]
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

        if (value is MunicipalityRegister)
        {
            ElementTypeName = AuthorityChoiceIdentifier.municipalityRegister;
        }
        else if (value is CantonalRegister)
        {
            ElementTypeName = AuthorityChoiceIdentifier.cantonalRegister;
        }
        else if (value is OtherRegister)
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
    public static Authority Create(object municipalityRegister)
    {
        return new Authority
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
    public static Authority Create(CantonalRegister cantonalRegister)
    {
        return new Authority
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
    public static Authority Create(OtherRegister otherRegister)
    {
        return new Authority
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
