// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0044_4_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Austausch von Personenidentifikationen (eCH-0044)
/// personIdentificationKeyOnlyType ohne zusätzliche identifizierende Merkmale.
/// Es sind ausschliesslich echte Schlüssel-Merkmal enthalten.
/// </summary>
[Serializable]
[JsonObject("personIdentificationKeyOnly")]
[XmlRoot(ElementName = "personIdentificationKeyOnly", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044-f/4")]
public class PersonIdentificationKeyOnly : FieldValueChecker<PersonIdentificationKeyOnly>
{
    private ulong? _vn;
    private NamedPersonId _localPersonId;
    private List<NamedPersonId> _otherPersonIds;
    private List<NamedPersonId> _euPersonIds;

    public PersonIdentificationKeyOnly()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044-f/4");
    }

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="vn">Field can be null.</param>
    /// <param name="localPersonId">Field is reqired.</param>
    /// <param name="otherPersonIds">Field can be null.</param>
    /// <param name="euPersonIds">Field can be null.</param>
    /// <returns></returns>
    public static PersonIdentificationKeyOnly Create(ulong? vn, NamedPersonId localPersonId, List<NamedPersonId> otherPersonIds, List<NamedPersonId> euPersonIds)
    {
        return new PersonIdentificationKeyOnly
        {
            Vn = vn,
            LocalPersonId = localPersonId,
            OtherPersonIds = otherPersonIds,
            EuPersonIds = euPersonIds
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt die minimalen Werte.
    /// </summary>
    /// <param name="localPersonId">Field is reqired.</param>
    /// <returns></returns>
    public static PersonIdentificationKeyOnly Createy(NamedPersonId localPersonId)
    {
        return new PersonIdentificationKeyOnly
        {
            LocalPersonId = localPersonId
        };
    }

    [FieldRangeInclusive(7560000000001, 7569999999999)]
    [JsonProperty("vn")]
    [XmlElement(DataType = "unsignedLong", ElementName = "vn")]
    public ulong? Vn
    {
        get => _vn;
        set => CheckAndSetValue(ref _vn, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool VnSpecified => Vn.HasValue;

    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId")]
    public NamedPersonId LocalPersonId
    {
        get => _localPersonId;
        set => CheckAndSetValue(ref _localPersonId, value);
    }

    [JsonProperty("otherPersonId")]
    [XmlElement(ElementName = "otherPersonId")]
    public List<NamedPersonId> OtherPersonIds
    {
        get => _otherPersonIds;
        set => CheckAndSetValue(ref _otherPersonIds, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool OtherPersonIdsSpecified => OtherPersonIds != null && OtherPersonIds.Any();

    [JsonProperty("euPersonId")]
    [XmlElement(ElementName = "euPersonId")]
    public List<NamedPersonId> EuPersonIds
    {
        get => _euPersonIds;
        set => CheckAndSetValue(ref _euPersonIds, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool EuPersonIdsSpecified => EuPersonIds != null && EuPersonIds.Any();
}
