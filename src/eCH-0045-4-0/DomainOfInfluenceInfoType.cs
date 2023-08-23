// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_4_0;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("DomainOfInfluenceInfoType")]
[XmlRoot(ElementName = "DomainOfInfluenceInfoType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class DomainOfInfluenceInfoType : FieldValueChecker<DomainOfInfluenceInfoType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private DomainOfInfluenceType _domainOfInfluence;
    private CountingCircleType _countingCircle;

    public DomainOfInfluenceInfoType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="domainOfInfluenceInfo">Field is required.</param>
    /// <param name="countingCircle">Field is optional.</param>
    /// <returns>DomainOfInfluenceInfoType.</returns>
    public static DomainOfInfluenceInfoType Create(DomainOfInfluenceType domainOfInfluenceInfo, CountingCircleType countingCircle)
    {
        return new DomainOfInfluenceInfoType
        {
            DomainOfInfluence = domainOfInfluenceInfo,
            CountingCircle = countingCircle
        };
    }

    [FieldRequired]
    [JsonProperty("domainOfInfluence")]
    [XmlElement(ElementName = "domainOfInfluence", Order = 1)]
    public DomainOfInfluenceType DomainOfInfluence
    {
        get => _domainOfInfluence;
        set => CheckAndSetValue(ref _domainOfInfluence, value);
    }

    [JsonProperty("countingCircle")]
    [XmlElement(ElementName = "countingCircle", Order = 2)]
    public CountingCircleType CountingCircle
    {
        get => _countingCircle;
        set => CheckAndSetValue(ref _countingCircle, value);
    }
}
