﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0010_5_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Postadresse für natürliche Personen, Firmen, Organisationen und Behörden (eCH-0010)
/// Postadresse einer Firma, Organisation oder Behörde.
/// </summary>
[Serializable]
[JsonObject("organisation")]
[XmlRoot(ElementName = "organisation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010/5")]
public class OrganisationMailAddressInfo : FieldValueChecker<OrganisationMailAddressInfo>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _organisationName;
    private string _organisationNameAddOn1;
    private string _organisationNameAddOn2;
    private string _title;
    private string _firstName;
    private string _lastName;

    public OrganisationMailAddressInfo()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010/5");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="organisationName">Field is reqired.</param>
    /// <param name="organisationNameAddOn1">Field can be null.</param>
    /// <param name="organisationNameAddOn2">Field can be null.</param>
    /// <param name="title">Field can be null.</param>
    /// <param name="firstName">Field can be null.</param>
    /// <param name="lastName">Field can be null.</param>
    /// <returns>OrganisationMailAddressInfo.</returns>
    public static OrganisationMailAddressInfo Create(string organisationName, string organisationNameAddOn1, string organisationNameAddOn2, string title, string firstName, string lastName)
    {
        return new OrganisationMailAddressInfo
        {
            OrganisationName = organisationName,
            OrganisationNameAddOn1 = organisationNameAddOn1,
            OrganisationNameAddOn2 = organisationNameAddOn2,
            Title = title,
            FirstName = firstName,
            LastName = lastName
        };
    }

    /// <summary>
    /// tatische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="organisationName">Field is reqired.</param>
    /// <returns>OrganisationMailAddressInfo.</returns>
    public static OrganisationMailAddressInfo Create(string organisationName)
    {
        return new OrganisationMailAddressInfo
        {
            OrganisationName = organisationName,
            OrganisationNameAddOn1 = null,
            OrganisationNameAddOn2 = null,
            Title = null,
            FirstName = null,
            LastName = null
        };
    }

    [FieldRequired]
    [FieldMaxLength(60)]
    [JsonProperty("organisationName")]
    [XmlElement(ElementName = "organisationName")]
    public string OrganisationName
    {
        get => _organisationName;
        set => CheckAndSetValue(ref _organisationName, value);
    }

    [FieldMaxLength(60)]
    [JsonProperty("organisationNameAddOn1")]
    [XmlElement(ElementName = "organisationNameAddOn1")]
    public string OrganisationNameAddOn1
    {
        get => _organisationNameAddOn1;
        set => CheckAndSetValue(ref _organisationNameAddOn1, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OrganisationNameAddOn1Specified => !string.IsNullOrEmpty(OrganisationNameAddOn1);

    [FieldMaxLength(60)]
    [JsonProperty("organisationNameAddOn2")]
    [XmlElement(ElementName = "organisationNameAddOn2")]
    public string OrganisationNameAddOn2
    {
        get => _organisationNameAddOn2;
        set => CheckAndSetValue(ref _organisationNameAddOn2, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OrganisationNameAddOn2Specified => !string.IsNullOrEmpty(OrganisationNameAddOn2);

    [FieldMaxLength(20)]
    [JsonProperty("title")]
    [XmlElement(ElementName = "title")]
    public string Title
    {
        get => _title;
        set => CheckAndSetValue(ref _title, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TitleSpecified => string.IsNullOrEmpty(Title);

    [FieldMaxLength(30)]
    [JsonProperty("firstName")]
    [XmlElement(ElementName = "firstName")]
    public string FirstName
    {
        get => _firstName;
        set => CheckAndSetValue(ref _firstName, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool FirstNameSpecified => !string.IsNullOrEmpty(FirstName);

    [FieldMaxLength(30)]
    [JsonProperty("lastName")]
    [XmlElement(ElementName = "lastName")]
    public string LastName
    {
        get => _lastName;
        set => CheckAndSetValue(ref _lastName, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool LastNameSpecified => !string.IsNullOrEmpty(LastName);
}
