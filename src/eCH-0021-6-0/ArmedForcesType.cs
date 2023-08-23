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
[JsonObject("armedForcesType")]
[XmlRoot(ElementName = "armedForcesType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class ArmedForcesType : FieldValueChecker<ArmedForcesType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private YesNoType? _armedForcesService;
    private YesNoType? _armedForcesLiability;
    private DateTime? _armedForcesValidFrom;

    public ArmedForcesType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="armedForcesService">Field is optional.</param>
    /// <param name="armedForcesLiability">Field is optional.</param>
    /// <param name="armedForcesValidFrom">Field is optional.</param>
    /// <returns>ArmedForcesType.</returns>
    public static ArmedForcesType Create(YesNoType? armedForcesService = null, YesNoType? armedForcesLiability = null, DateTime? armedForcesValidFrom = null)
    {
        return new ArmedForcesType()
        {
            ArmedForcesService = armedForcesService,
            ArmedForcesLiability = armedForcesLiability,
            ArmedForcesValidFrom = armedForcesValidFrom
        };
    }

    [JsonProperty("armedForcesService")]
    [XmlElement(ElementName = "armedForcesService")]
    public YesNoType? ArmedForcesService
    {
        get => _armedForcesService;
        set => CheckAndSetValue(ref _armedForcesService, value);
    }

    [JsonProperty("armedForcesLiability")]
    [XmlElement(ElementName = "armedForcesLiability")]
    public YesNoType? ArmedForcesLiability
    {
        get => _armedForcesLiability;
        set => CheckAndSetValue(ref _armedForcesLiability, value);
    }

    [JsonProperty("armedForcesValidFrom")]
    [XmlElement(DataType = "date", ElementName = "armedForcesValidFrom")]
    public DateTime? ArmedForcesValidFrom
    {
        get => _armedForcesValidFrom;
        set => CheckAndSetValue(ref _armedForcesValidFrom, value);
    }
}
