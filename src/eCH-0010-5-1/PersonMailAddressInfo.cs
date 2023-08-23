// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0010_5_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Postadresse für natürliche Personen, Firmen, Organisationen und Behörden (eCH-0010)
/// Postadresse einer natürlichen Person im In- oder Ausland.
/// </summary>
[Serializable]
[JsonObject("person")]
[XmlRoot(ElementName = "person", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010/5")]
public class PersonMailAddressInfo : FieldValueChecker<PersonMailAddressInfo>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _title;
    private string _firstName;
    private string _lastName;

    public PersonMailAddressInfo()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010/5");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="mrMr">Field can be null.</param>
    /// <param name="title">Field can be null.</param>
    /// <param name="firstName">Field can be null.</param>
    /// <param name="lastName">Field is reqired.</param>
    /// <returns>PersonMailAddressInfo.</returns>
    public static PersonMailAddressInfo Create(MrMrs mrMr, string title, string firstName, string lastName)
    {
        return new PersonMailAddressInfo
        {
            MrMrs = mrMr,
            Title = title,
            FirstName = firstName,
            LastName = lastName
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="lastName">Field is reqired.</param>
    /// <returns>PersonMailAddressInfo.</returns>
    public static PersonMailAddressInfo Create(string lastName)
    {
        return new PersonMailAddressInfo
        {
            MrMrs = null,
            Title = null,
            FirstName = null,
            LastName = lastName
        };
    }

    [JsonProperty("mrMrs")]
    [XmlElement(ElementName = "mrMrs", Order = 1)]
    public MrMrs? MrMrs { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool MrMrsSpecified => MrMrs.HasValue;

    [FieldMaxLength(50)]
    [JsonProperty("title")]
    [XmlElement(ElementName = "title", Order = 2)]
    public string Title
    {
        get => _title;
        set => CheckAndSetValue(ref _title, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool TitleSpecified => !string.IsNullOrWhiteSpace(Title);

    [FieldMaxLength(30)]
    [JsonProperty("firstName")]
    [XmlElement(ElementName = "firstName", Order = 3)]
    public string FirstName
    {
        get => _firstName;
        set => CheckAndSetValue(ref _firstName, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool FirstNameSpecified => !string.IsNullOrWhiteSpace(FirstName);

    [FieldRequired]
    [FieldMaxLength(30)]
    [JsonProperty("lastName")]
    [XmlElement(ElementName = "lastName", Order = 4)]
    public string LastName
    {
        get => _lastName;
        set => CheckAndSetValue(ref _lastName, value);
    }
}
