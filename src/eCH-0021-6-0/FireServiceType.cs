// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Militärdienstpflichtangaben.
/// </summary>
[Serializable]
[JsonObject("fireServiceType")]
[XmlRoot(ElementName = "fireServiceType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class FireServiceType : FieldValueChecker<FireServiceType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private YesNoType? _fireService;
    private YesNoType? _fireServiceLiability;
    private DateTime? _fireServiceValidFrom;

    public FireServiceType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="fireService">Field is optional.</param>
    /// <param name="fireServiceLiability">Field is optional.</param>
    /// <param name="fireServiceValidFrom">Field is optional.</param>
    /// <returns>FireServiceData.</returns>
    public static FireServiceType Create(YesNoType? fireService = null, YesNoType? fireServiceLiability = null, DateTime? fireServiceValidFrom = null)
    {
        return new FireServiceType
        {
            FireService = fireService,
            FireServiceLiability = fireServiceLiability,
            FireServiceValidFrom = fireServiceValidFrom
        };
    }

    [JsonProperty("fireService")]
    [XmlElement(ElementName = "fireService")]
    public YesNoType? FireService
    {
        get => _fireService;
        set => CheckAndSetValue(ref _fireService, value);
    }

    [JsonProperty("fireServiceLiability")]
    [XmlElement(ElementName = "fireServiceLiability")]
    public YesNoType? FireServiceLiability
    {
        get => _fireServiceLiability;
        set => CheckAndSetValue(ref _fireServiceLiability, value);
    }

    [JsonProperty("fireServiceValidFrom")]
    [XmlElement(DataType = "date", ElementName = "fireServiceValidFrom")]
    public DateTime? FireServiceValidFrom
    {
        get => _fireServiceValidFrom;
        set => CheckAndSetValue(ref _fireServiceValidFrom, value);
    }
}
