// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0006_2_0;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zur beruflichen Tätigkeit.
/// </summary>
[Serializable]
[JsonObject("residencePermitDataType")]
[XmlRoot(ElementName = "residencePermitDataType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class ResidencePermitDataType : FieldValueChecker<ResidencePermitDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ResidencePermit _residencePermit;
    private DateTime? _residencePermitTill;
    private DateTime? _residencePermitValidFrom;

    public ResidencePermitDataType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="residencePermit">Field is required.</param>
    /// <param name="residencePermitTill">Field is optional.</param>
    /// <param name="residencePermitValidFrom">Field is optional.</param>
    /// <returns>ResidencePermitDataType.</returns>
    public static ResidencePermitDataType Create(ResidencePermit residencePermit, DateTime? residencePermitTill, DateTime? residencePermitValidFrom)
    {
        return new ResidencePermitDataType
        {
            ResidencePermit = residencePermit,
            ResidencePermitTill = residencePermitTill,
            ResidencePermitValidFrom = residencePermitValidFrom
        };
    }

    [FieldRequired]
    [JsonProperty("residencePermit")]
    [XmlElement(ElementName = "residencePermit")]
    public ResidencePermit ResidencePermit
    {
        get => _residencePermit;
        set => CheckAndSetValue(ref _residencePermit, value);
    }

    [JsonProperty("residencePermitTill")]
    [XmlElement(ElementName = "residencePermitTill")]
    public DateTime? ResidencePermitTill
    {
        get => _residencePermitTill;
        set => CheckAndSetValue(ref _residencePermitTill, value);
    }

    [JsonProperty("residencePermitValidFrom")]
    [XmlElement(ElementName = "residencePermitValidFrom")]
    public DateTime? ResidencePermitValidFrom
    {
        get => _residencePermitValidFrom;
        set => CheckAndSetValue(ref _residencePermitValidFrom, value);
    }
}
