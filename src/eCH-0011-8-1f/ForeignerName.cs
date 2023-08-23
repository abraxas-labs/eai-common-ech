// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Für Personen mit ausländischer Nationalität, die keine offiziellen Dokumente besitzen.
/// </summary>
[Serializable]
[JsonObject("foreignerName")]
[XmlRoot(ElementName = "foreignerName", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class ForeignerName
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string NameNoticeValidateExceptionMessage = "Notice is not valid! Notice is required";
    private const string FirstNameNoticeValidateExceptionMessage = "Notice is not valid! Notice is required";

    private string _name;
    private string _firstName;

    public ForeignerName()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="name">Field is optional.</param>
    /// <param name="firstName">Field is optional.</param>
    /// <returns>ForeignerName.</returns>
    public static ForeignerName Create(string name = null, string firstName = null)
    {
        return new ForeignerName()
        {
            Name = name,
            FirstName = firstName
        };
    }

    [JsonProperty("name")]
    [XmlElement(ElementName = "name")]
    public string Name
    {
        get { return _name; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(NameNoticeValidateExceptionMessage);
            }
            _name = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool NameSpecified => !string.IsNullOrEmpty(Name);

    [JsonProperty("firstName")]
    [XmlElement(ElementName = "firstName")]
    public string FirstName
    {
        get { return _firstName; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(FirstNameNoticeValidateExceptionMessage);
            }
            _firstName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool FirstNameSpecified => !string.IsNullOrEmpty(FirstName);
}
