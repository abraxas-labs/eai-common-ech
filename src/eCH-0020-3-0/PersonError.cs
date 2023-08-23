// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020).
/// </summary>
[Serializable]
[JsonObject("personInfo")]
[XmlRoot(ElementName = "personInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class PersonInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string PersonIdentificationNullValidateExceptionMessage = "PersonIdentification is not valid! PersonIdentification is required";
    private const string ErrorInfosNullValidateExceptionMessage = "ErrorInfos is not valid! ErrorInfos is required";

    private PersonIdentification _personIdentification;
    private Info[] _errorInfos;

    public PersonInfo()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="errorInfos">Field is required.</param>
    /// <returns>NameInfo.</returns>
    public static PersonInfo Create(PersonIdentification personIdentification, List<Info> errorInfos)
    {
        return new PersonInfo()
        {
            PersonIdentification = personIdentification,
            ErrorInfos = (errorInfos != null) ? errorInfos.ToArray() : null
        };
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification
    {
        get { return _personIdentification; }

        set
        {
            _personIdentification = value ?? throw new XmlSchemaValidationException(PersonIdentificationNullValidateExceptionMessage);
        }
    }

    [JsonProperty("errorInfo")]
    [XmlElement(ElementName = "errorInfo")]
    public Info[] ErrorInfos
    {
        get { return _errorInfos; }

        set
        {
            _errorInfos = (value != null && value.Any()) ? value : throw new XmlSchemaValidationException(ErrorInfosNullValidateExceptionMessage);
        }
    }
}
