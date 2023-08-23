// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0010_5_0;
using eCH_0011_7_0;
using eCH_0044_3_0;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Beziehungsangaben.
/// </summary>
[Serializable]
[JsonObject("partner")]
[XmlRoot(ElementName = "partner", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class PartnerType : FieldValueChecker<PartnerType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _personIdentification;
    private PersonIdentificationLight _personIdentificationPartner;
    private PartnerIdOrganisationType _partnerIdOrganisation;
    private MailAddress _address;

    public PartnerType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>PartnerType.</returns>
    public static PartnerType Create(PersonIdentification personIdentification, MailAddress address = null)
    {
        return new PartnerType
        {
            PersonIdentification = personIdentification,
            PersonIdentificationPartner = null,
            PartnerIdOrganisation = null,
            Address = address
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentificationPartner">Field is required.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static PartnerType Create(PersonIdentificationLight personIdentificationPartner, MailAddress address = null)
    {
        return new PartnerType
        {
            PersonIdentification = null,
            PersonIdentificationPartner = personIdentificationPartner,
            PartnerIdOrganisation = null,
            Address = address
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="partnerIdOrganisation">Field is required.</param>
    /// <param name="address">Field is optional.</param>
    /// <returns>LockData.</returns>
    public static PartnerType Create(PartnerIdOrganisationType partnerIdOrganisation, MailAddress address = null)
    {
        return new PartnerType
        {
            PersonIdentification = null,
            PersonIdentificationPartner = null,
            PartnerIdOrganisation = partnerIdOrganisation,
            Address = address
        };
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification
    {
        get => _personIdentification;
        set => CheckAndSetValue(ref _personIdentification, value);
    }

    [JsonProperty("personIdentificationPartner")]
    [XmlElement(ElementName = "personIdentificationPartner")]
    public PersonIdentificationLight PersonIdentificationPartner
    {
        get => _personIdentificationPartner;
        set => CheckAndSetValue(ref _personIdentificationPartner, value);
    }

    [JsonProperty("partnerIdOrganisation")]
    [XmlElement(ElementName = "partnerIdOrganisation")]
    public PartnerIdOrganisationType PartnerIdOrganisation
    {
        get => _partnerIdOrganisation;
        set => CheckAndSetValue(ref _partnerIdOrganisation, value);
    }

    [JsonProperty("address")]
    [XmlElement(ElementName = "address")]
    public MailAddress Address
    {
        get => _address;
        set => CheckAndSetValue(ref _address, value);
    }
}
