// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0155_3_0;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard politische Rechte  (eCH-0155)
///     Gebiet, in der Regel geografisch zusammenhängend, für welches das Stimmrecht sowie
///     das aktive und passive Wahlrecht einer Person Gültigkeit hat.
/// </summary>
[Serializable]
[JsonObject("domainOfInfluence")]
[XmlRoot(ElementName = "domainOfInfluence", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0155/3")]
public class DomainOfInfluence
{
    private const string DomainOfInfluenceIdNullValidateExceptionMessage =
        "LocalDomainOfInfluenceId is not valid! LocalDomainOfInfluenceId is required";

    private const string DomainOfInfluenceIdOutOfRangeValidateExceptionMessage =
            "LocalDomainOfInfluenceId is not valid! LocalDomainOfInfluenceId has minimal leght of 1 and maximal length of 50"
        ;

    private const string DomainOfInfluenceNameNullValidateExceptionMessage =
        "DomainOfInfluenceName is not valid! DomainOfInfluenceName is required";

    private const string DomainOfInfluenceNameOutOfRangeValidateExceptionMessage =
            "DomainOfInfluenceName is not valid! DomainOfInfluenceName has minimal leght of 1 and maximal length of 100"
        ;

    private const string DomainOfInfluenceShortNameOutOfRangeValidateExceptionMessage =
        "DomainOfInfluenceName is not valid! DomainOfInfluenceName has minimal leght of 1 and maximal length of 5";

    private string _domainOfInfluenceName;
    private string _domainOfInfluenceShortName;
    private DomainOfInfluenceType _domainOfInfluenceType;

    private string _localDomainOfInfluenceId;

    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public DomainOfInfluence()
    {
        Xmlns.Add("eCH-0155", "http://www.ech.ch/xmlns/eCH-0155/3");
    }

    [JsonProperty("localDomainOfInfluenceType")]
    [XmlElement(ElementName = "localDomainOfInfluenceType")]
    public DomainOfInfluenceType DomainOfInfluenceType
    {
        get => _domainOfInfluenceType;
        set => _domainOfInfluenceType = value;
    }

    [JsonProperty("domainOfInfluenceId")]
    [XmlElement(ElementName = "domainOfInfluenceId")]
    public string LocalDomainOfInfluenceId
    {
        get => _localDomainOfInfluenceId;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(DomainOfInfluenceIdNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 50)
            {
                throw new XmlSchemaValidationException(DomainOfInfluenceIdOutOfRangeValidateExceptionMessage);
            }

            _localDomainOfInfluenceId = value;
        }
    }

    [JsonProperty("domainOfInfluenceName")]
    [XmlElement(ElementName = "domainOfInfluenceName")]
    public string DomainOfInfluenceName
    {
        get => _domainOfInfluenceName;
        set
        {
            if (value == null)
            {
                throw new XmlSchemaValidationException(DomainOfInfluenceNameNullValidateExceptionMessage);
            }

            if (value.Length < 1 || value.Length > 100)
            {
                throw new XmlSchemaValidationException(DomainOfInfluenceNameOutOfRangeValidateExceptionMessage);
            }

            _domainOfInfluenceName = value;
        }
    }

    [JsonProperty("domainOfInfluenceShortname")]
    [XmlElement(ElementName = "domainOfInfluenceShortname")]
    public string DomainOfInfluenceShortname
    {
        get => _domainOfInfluenceShortName;
        set
        {
            if (!string.IsNullOrEmpty(value) && (value.Length < 1 || value.Length > 5))
            {
                throw new XmlSchemaValidationException(
                    DomainOfInfluenceShortNameOutOfRangeValidateExceptionMessage);
            }

            _domainOfInfluenceShortName = value;
        }
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
    /// <param name="localDomainOfInfluenceId">Field is reqired.</param>
    /// <param name="domainOfIfnluenceName">Field is reqired.</param>
    /// <param name="domainOfInfluenceShortName">Field is reqired.</param>
    /// <returns>DomainOfInfluence.</returns>
    public static DomainOfInfluence Create(DomainOfInfluenceType domainOfInfluenceType,
        string localDomainOfInfluenceId, string domainOfIfnluenceName, string domainOfInfluenceShortName)
    {
        return new DomainOfInfluence
        {
            DomainOfInfluenceType = domainOfInfluenceType,
            LocalDomainOfInfluenceId = localDomainOfInfluenceId,
            DomainOfInfluenceName = domainOfIfnluenceName,
            DomainOfInfluenceShortname = domainOfInfluenceShortName
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="domainOfInfluenceType">Has dependency to domainOfInfluenceType.</param>
    /// <param name="localDomainOfInfluenceId">Field is reqired.</param>
    /// <param name="domainOfIfnluenceName">Field is reqired.</param>
    /// <returns>DomainOfInfluence.</returns>
    public static DomainOfInfluence Create(DomainOfInfluenceType domainOfInfluenceType,
        string localDomainOfInfluenceId, string domainOfIfnluenceName)
    {
        return new DomainOfInfluence
        {
            DomainOfInfluenceType = domainOfInfluenceType,
            LocalDomainOfInfluenceId = localDomainOfInfluenceId,
            DomainOfInfluenceName = domainOfIfnluenceName
        };
    }
}
