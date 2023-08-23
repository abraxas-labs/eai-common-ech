// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0044_4_1;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Ids der Partnerorganisationen.
/// </summary>
[Serializable]
[JsonObject("partnerIdOrganisation")]
[XmlRoot(ElementName = "partnerIdOrganisation", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class PartnerIdOrganisation
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string LocalPersonIdNullValidateExceptionMessage = "LocalPersonId is not valid! LocalPersonId is required";

    private NamedPersonId _localPersonId;

    public PartnerIdOrganisation()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="localPersonId">Field is required.</param>
    /// <param name="otherPersonId">Field is optional.</param>
    /// <returns>DeathData.</returns>
    public static PartnerIdOrganisation Create(NamedPersonId localPersonId, List<NamedPersonId> otherPersonId = null)
    {
        return new PartnerIdOrganisation()
        {
            LocalPersonId = localPersonId,
            OtherPersonId = otherPersonId
        };
    }

    [JsonProperty("localPersonId")]
    [XmlElement(ElementName = "localPersonId", Order = 1)]
    public NamedPersonId LocalPersonId
    {
        get { return _localPersonId; }

        set
        {
            _localPersonId = value ?? throw new XmlSchemaValidationException(LocalPersonIdNullValidateExceptionMessage);
        }
    }

    [JsonProperty("otherPersonId")]
    [XmlElement(ElementName = "otherPersonId", Order = 2)]
    public List<NamedPersonId> OtherPersonId { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PlaceOfDeathSpecified => OtherPersonId != null && OtherPersonId.Any();
}
