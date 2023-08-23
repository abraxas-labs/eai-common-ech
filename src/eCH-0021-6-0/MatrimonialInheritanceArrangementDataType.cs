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
/// Angaben hinsichtlich Güter- und/oder erbrechtlicher Vereinbarungen.
/// </summary>
[Serializable]
[JsonObject("matrimonialInheritanceArrangementData")]
[XmlRoot(ElementName = "matrimonialInheritanceArrangementData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class MatrimonialInheritanceArrangementDataType : FieldValueChecker<MatrimonialInheritanceArrangementDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private YesNoType _matrimonialInheritanceArrangement;
    private DateTime? _matrimonialInheritanceArrangementValidFrom;

    public MatrimonialInheritanceArrangementDataType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="matrimonialInheritanceArrangement">Field is required.</param>
    /// <param name="matrimonialInheritanceArrangementValidFrom">Field is optional.</param>
    /// <returns>MatrimonialInheritanceArrangementDataType.</returns>
    public static MatrimonialInheritanceArrangementDataType Create(YesNoType matrimonialInheritanceArrangement, DateTime? matrimonialInheritanceArrangementValidFrom = null)
    {
        return new MatrimonialInheritanceArrangementDataType()
        {
            MatrimonialInheritanceArrangement = matrimonialInheritanceArrangement,
            MatrimonialInheritanceArrangementValidFrom = matrimonialInheritanceArrangementValidFrom
        };
    }

    [FieldRequired]
    [JsonProperty("matrimonialInheritanceArrangement")]
    [XmlElement(ElementName = "matrimonialInheritanceArrangement")]
    public YesNoType MatrimonialInheritanceArrangement
    {
        get => _matrimonialInheritanceArrangement;
        set => CheckAndSetValue(ref _matrimonialInheritanceArrangement, value);
    }

    [JsonProperty("matrimonialInheritanceArrangementValidFrom")]
    [XmlElement(DataType = "date", ElementName = "matrimonialInheritanceArrangementValidFrom")]
    public DateTime? MatrimonialInheritanceArrangementValidFrom
    {
        get => _matrimonialInheritanceArrangementValidFrom;
        set => CheckAndSetValue(ref _matrimonialInheritanceArrangementValidFrom, value);
    }
}
