// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("voter")]
[XmlRoot(ElementName = "voter", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class Voter : FieldValueChecker<Voter>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _person;

    public Voter()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="person">Field is required.</param>
    /// <param name="domainOfInfluence">Field is required.</param>
    /// <returns>Voter.</returns>
    public static Voter Create(PersonIdentification person, List<DomainOfInfluenceInfoType> domainOfInfluence)
    {
        return new Voter
        {
            Person = person,
            DomainOfInfluence = domainOfInfluence
        };
    }

    [FieldRequired]
    [JsonProperty("person")]
    [XmlElement(ElementName = "person", Order = 1)]
    public PersonIdentification Person
    {
        get => _person;
        set => CheckAndSetValue(ref _person, value);
    }

    [JsonProperty("domainOfInfluence")]
    [XmlElement(ElementName = "domainOfInfluence", Order = 2)]
    public List<DomainOfInfluenceInfoType> DomainOfInfluence { get; set; }
}
