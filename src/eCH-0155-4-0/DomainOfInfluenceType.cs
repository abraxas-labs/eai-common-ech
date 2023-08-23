// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0155_4_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Gebiet, in der Regel geografisch zusammenhängend, für welches das Stimmrecht sowie
///     das aktive und passive Wahlrecht einer Person Gültigkeit hat.
/// </summary>
[Serializable]
[JsonObject("domainOfInfluence")]
[XmlRoot(ElementName = "domainOfInfluenceType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/4")]
public class DomainOfInfluenceType : FieldValueChecker<DomainOfInfluenceType>
{
    private DomainOfInfluenceTypeType _typeOfDomainOfInfluence;
    private string _localDomainOfInfluenceIdentification;
    private string _domainOfInfluenceName;
    private string _domainOfInfluenceShortName;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public DomainOfInfluenceType()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/4");
    }

    [FieldRequired]
    [JsonProperty("domainOfInfluenceType")]
    [XmlElement(ElementName = "domainOfInfluenceType", Order = 1)]
    public DomainOfInfluenceTypeType TypeOfDomainOfInfluence
    {
        get => _typeOfDomainOfInfluence;
        set => CheckAndSetValue(ref _typeOfDomainOfInfluence, value);
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 50)]
    [JsonProperty("localDomainOfInfluenceIdentification")]
    [XmlElement(ElementName = "localDomainOfInfluenceIdentification", Order = 2)]
    public string LocalDomainOfInfluenceIdentification
    {
        get => _localDomainOfInfluenceIdentification;
        set => CheckAndSetValue(ref _localDomainOfInfluenceIdentification, value);
    }

    [FieldRequired]
    [FieldMinMaxLength(1, 100)]
    [JsonProperty("domainOfInfluenceName")]
    [XmlElement(ElementName = "domainOfInfluenceName", Order = 3)]
    public string DomainOfInfluenceName
    {
        get => _domainOfInfluenceName;
        set => CheckAndSetValue(ref _domainOfInfluenceName, value);
    }

    [FieldMinMaxLength(1, 5)]
    [JsonProperty("domainOfInfluenceShortname")]
    [XmlElement(ElementName = "domainOfInfluenceShortname", Order = 4)]
    public string DomainOfInfluenceShortname
    {
        get => _domainOfInfluenceShortName;
        set => CheckAndSetValue(ref _domainOfInfluenceShortName, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool DomainOfInfluenceShortnameSpecified => !string.IsNullOrEmpty(DomainOfInfluenceShortname);

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="domainOfInfluenceType">Has dependency to domainOfInfluenceType.</param>
    /// <param name="localDomainOfInfluenceIdentification">Field is reqired.</param>
    /// <param name="domainOfIfnluenceName">Field is reqired.</param>
    /// <param name="domainOfInfluenceShortName">Field is reqired.</param>
    /// <returns>DomainOfInfluence.</returns>
    public static DomainOfInfluenceType Create(DomainOfInfluenceTypeType domainOfInfluenceType,
        string localDomainOfInfluenceIdentification, string domainOfIfnluenceName, string domainOfInfluenceShortName)
    {
        return new DomainOfInfluenceType
        {
            TypeOfDomainOfInfluence = domainOfInfluenceType,
            LocalDomainOfInfluenceIdentification = localDomainOfInfluenceIdentification,
            DomainOfInfluenceName = domainOfIfnluenceName,
            DomainOfInfluenceShortname = domainOfInfluenceShortName
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="typeOfDomainOfInfluence">Has dependency to domainOfInfluenceType.</param>
    /// <param name="localDomainOfInfluenceId">Field is reqired.</param>
    /// <param name="domainOfIfnluenceName">Field is reqired.</param>
    /// <returns>DomainOfInfluence.</returns>
    public static DomainOfInfluenceType Create(DomainOfInfluenceTypeType typeOfDomainOfInfluence,
        string localDomainOfInfluenceId, string domainOfIfnluenceName)
    {
        return new DomainOfInfluenceType
        {
            TypeOfDomainOfInfluence = typeOfDomainOfInfluence,
            LocalDomainOfInfluenceIdentification = localDomainOfInfluenceId,
            DomainOfInfluenceName = domainOfIfnluenceName
        };
    }
}
