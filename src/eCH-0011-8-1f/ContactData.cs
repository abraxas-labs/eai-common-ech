// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using eCH_0010_5_1f;
using eCH_0044_4_1f;
using Newtonsoft.Json;

namespace eCH_0011_8_1f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Informationen, wie die Person kontaktiert werden kann, mindestens mit der Zustelladresse.
/// </summary>
[Serializable]
[JsonObject("contactData")]
[XmlRoot(ElementName = "contactData", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/8")]
public class ContactData
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private MailAddress _contactAddress;

    public ContactData()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Field is required.</param>
    /// <param name="contactAddress">Field is required.</param>
    /// <param name="contactValidFrom">Field is optional.</param>
    /// <param name="contactValidTill">Field is optional.</param>
    /// <returns>ContactData.</returns>
    public static ContactData Create(PersonIdentification personIdentification, MailAddress contactAddress, DateTime? contactValidFrom = null, DateTime? contactValidTill = null)
    {
        return new ContactData()
        {
            PersonIdentification = personIdentification,
            PersonIdentificationPartner = null,
            PartnerIdOrganisation = null,
            ContactAddress = contactAddress,
            ContactValidFrom = contactValidFrom,
            ContactValidTill = contactValidTill
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentificationPartner">Field is required.</param>
    /// <param name="contactAddress">Field is required.</param>
    /// <param name="contactValidFrom">Field is optional.</param>
    /// <param name="contactValidTill">Field is optional.</param>
    /// <returns>ContactData.</returns>
    public static ContactData Create(PersonIdentificationLight personIdentificationPartner, MailAddress contactAddress, DateTime? contactValidFrom = null, DateTime? contactValidTill = null)
    {
        return new ContactData()
        {
            PersonIdentification = null,
            PersonIdentificationPartner = personIdentificationPartner,
            PartnerIdOrganisation = null,
            ContactAddress = contactAddress,
            ContactValidFrom = contactValidFrom,
            ContactValidTill = contactValidTill
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="partnerIdOrganisation">Field is required.</param>
    /// <param name="contactAddress">Field is required.</param>
    /// <param name="contactValidFrom">Field is optional.</param>
    /// <param name="contactValidTill">Field is optional.</param>
    /// <returns>ContactData.</returns>
    public static ContactData Create(PartnerIdOrganisation partnerIdOrganisation, MailAddress contactAddress, DateTime? contactValidFrom = null, DateTime? contactValidTill = null)
    {
        return new ContactData()
        {
            PersonIdentification = null,
            PersonIdentificationPartner = null,
            PartnerIdOrganisation = partnerIdOrganisation,
            ContactAddress = contactAddress,
            ContactValidFrom = contactValidFrom,
            ContactValidTill = contactValidTill
        };
    }

    [JsonProperty("personIdentification")]
    [XmlElement(ElementName = "personIdentification")]
    public PersonIdentification PersonIdentification { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonIdentificationSpecified => PersonIdentification != null;

    [JsonProperty("personIdentificationPartner")]
    [XmlElement(ElementName = "personIdentificationPartner")]
    public PersonIdentificationLight PersonIdentificationPartner { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PersonIdentificationPartnerSpecified => PersonIdentificationPartner != null;

    [JsonProperty("partnerIdOrganisation")]
    [XmlElement(ElementName = "partnerIdOrganisation")]
    public PartnerIdOrganisation PartnerIdOrganisation { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool PartnerIdOrganisationSpecified => PartnerIdOrganisation != null;

    [JsonProperty("contactAddress")]
    [XmlElement(ElementName = "contactAddress")]
    public MailAddress ContactAddress
    {
        get { return _contactAddress; }
        set { _contactAddress = value; }
    }

    [JsonProperty("contactValidFrom")]
    [XmlElement(DataType = "date", ElementName = "contactValidFrom")]
    public DateTime? ContactValidFrom { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactValidFromSpecified => ContactValidFrom.HasValue;

    [JsonProperty("contactValidTill")]
    [XmlElement(DataType = "date", ElementName = "contactValidTill")]
    public DateTime? ContactValidTill { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactValidTillSpecified => ContactValidTill.HasValue;
}
