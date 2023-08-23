// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_3_0;
using eCH_0155_1_0;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("voter")]
[XmlRoot(ElementName = "voter", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class Voter
{
    private const string PersonNullValidateExceptionMessage =
        "Person not valid! Person is required";

    private const string DomainOfInfluenceNullValidateExceptionMessage =
        "DomainOfInfluence not valid! DomainOfInfluence is required";

    private PersonIdentification _person;
    private DomainOfInfluence _domainOfInfluence;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public Voter()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("person")]
    [XmlElement(ElementName = "person")]
    public PersonIdentification Person
    {
        get => _person;
        set => _person = value ?? throw new XmlSchemaValidationException(PersonNullValidateExceptionMessage);
    }

    [JsonProperty("domainOfInfluence")]
    [XmlElement(ElementName = "domainOfInfluence")]
    public DomainOfInfluence DomainOfInfluence
    {
        get => _domainOfInfluence;
        set => _domainOfInfluence = value ?? throw new XmlSchemaValidationException(DomainOfInfluenceNullValidateExceptionMessage);
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="person">Field is required.</param>
    /// <param name="domainOfInfluence">Field is required.</param>
    /// <returns>Voter.</returns>
    public static Voter Create(PersonIdentification person, DomainOfInfluence domainOfInfluence)
    {
        return new Voter
        {
            Person = person,
            DomainOfInfluence = domainOfInfluence
        };
    }
}
