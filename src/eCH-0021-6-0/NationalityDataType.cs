// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0008_3_0;
using eCH_0011_7_0;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zur beruflichen Tätigkeit.
/// </summary>
[Serializable]
[JsonObject("nationalityDataType")]
[XmlRoot(ElementName = "nationalityDataType", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class NationalityDataType : FieldValueChecker<NationalityDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private NationalityStatusType _nationalityStatus;
    private Country _country;
    private DateTime? _nationalityValidFrom;

    public NationalityDataType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="nationalityStatus">Field is required.</param>
    /// <param name="country">Field is optional.</param>
    /// <param name="nationalityValidFrom">Field is optional.</param>
    /// <returns>NationalityDataType.</returns>
    public static NationalityDataType Create(NationalityStatusType nationalityStatus, Country country, DateTime? nationalityValidFrom)
    {
        return new NationalityDataType
        {
            NationalityStatus = nationalityStatus,
            Country = country,
            NationalityValidFrom = nationalityValidFrom
        };
    }

    [FieldRequired]
    [JsonProperty("nationalityStatus")]
    [XmlElement(ElementName = "nationalityStatus")]
    public NationalityStatusType NationalityStatus
    {
        get => _nationalityStatus;
        set => CheckAndSetValue(ref _nationalityStatus, value);
    }

    [JsonProperty("country")]
    [XmlElement(ElementName = "country")]
    public Country Country
    {
        get => _country;
        set => CheckAndSetValue(ref _country, value);
    }

    [JsonProperty("nationalityValidFrom")]
    [XmlElement(ElementName = "nationalityValidFrom")]
    public DateTime? NationalityValidFrom
    {
        get => _nationalityValidFrom;
        set => CheckAndSetValue(ref _nationalityValidFrom, value);
    }
}
