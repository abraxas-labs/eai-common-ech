// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0020_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Schnittstellenstandard Mel-degründe Personenregister (eCH-0020)
/// Namensinformationen.
/// </summary>
[Serializable]
[JsonObject("personIdOnly")]
[XmlRoot(ElementName = "personIdOnly", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0020/3")]
public class PersonIdOnly
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string VnValidateExceptionMessage =
        "Vn is not valid! Vn has to be between 7560000000001 and 7569999999999";

    private const string LocalPersonIdValidateExceptionMessage =
        "LocalPersonId is not valid! LocalPersonId can not be null";

    private ulong? _vn;
    private NamedPersonId _localPersonId;

    public PersonIdOnly()
    {
        Xmlns.Add("eCH-0020", "http://www.ech.ch/xmlns/eCH-0020/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="vn">Field can be null.</param>
    /// <param name="localPersonId">Field is reqired.</param>
    /// <param name="otherPersonIds">Field can be null.</param>
    /// <param name="euPersonIds">Field can be null.</param>
    /// <returns></returns>
    public static PersonIdOnly Create(NamedPersonId localPersonId, ulong? vn = null, List<NamedPersonId> otherPersonIds = null, List<NamedPersonId> euPersonIds = null)
    {
        return new PersonIdOnly()
        {
            Vn = vn,
            LocalPersonId = localPersonId,
            OtherPersonIds = otherPersonIds,
            EuPersonIds = euPersonIds
        };
    }

    [JsonProperty("vn")]
    [XmlElement(DataType = "unsignedLong", ElementName = "vn")]
    public ulong? Vn
    {
        get { return _vn; }

        set
        {
            if (value.HasValue && (value < 7560000000001 || value > 7569999999999))
            {
                IsInvalidValue(VnValidateExceptionMessage);
            }
            _vn = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool VnSpecified => Vn != null;

    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public NamedPersonId LocalPersonId
    {
        get { return _localPersonId; }

        set
        {
            if (checkValue(value))
            {
                IsInvalidValue(LocalPersonIdValidateExceptionMessage);
            }
            _localPersonId = value;
        }
    }

    [JsonProperty("otherPersonId")]
    [XmlElement(ElementName = "otherPersonId")]
    public List<NamedPersonId> OtherPersonIds { get; private set; }

    [JsonProperty("euPersonId")]
    [XmlElement(ElementName = "euPersonId")]
    public List<NamedPersonId> EuPersonIds { get; private set; }

    private static bool checkValue(object obj)
    {
        return obj == null;
    }

    private static void IsInvalidValue(string message)
    {
        throw new XmlSchemaValidationException(message);
    }
}
