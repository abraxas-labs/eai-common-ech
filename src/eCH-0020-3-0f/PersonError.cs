﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0020_3_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020).
/// </summary>
[Serializable]
[JsonObject("personInfo")]
[XmlRoot(ElementName = "personInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020-f/3")]
public class PersonInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _personIdentification;
    private List<Info> _errorInfos;

    public PersonInfo()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020-f/3");
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
            ErrorInfos = errorInfos
        };
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification
    {
        get { return _personIdentification; }
        set { _personIdentification = value; }
    }

    [JsonProperty("errorInfo")]
    [XmlElement(ElementName = "errorInfo")]
    public List<Info> ErrorInfos
    {
        get { return _errorInfos; }
        set { _errorInfos = value; }
    }
}
