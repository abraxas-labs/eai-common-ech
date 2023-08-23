// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0010_5_1f;
using eCH_0044_3_0f;
using Newtonsoft.Json;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Eine gemeldete Person ist eine Person, welche in der Schweiz in mindestens einer Schweizer Gemeinde gemeldet
/// ist, d.h. dort ihren Haupt- bzw. Nebenwohnsitz hat und daher mit den betroffenen Gemeinden ein Meldeverhältnis hat.
/// </summary>
[Serializable]
[JsonObject("contact")]
[XmlRoot(ElementName = "contact", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public class ContactType : FieldValueChecker<ContactType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonIdentification _personIdentification;
    private PersonIdentificationLight _personIdentificationPartner;
    private PartnerIdOrganisationType _partnerIdOrganisation;
    private MailAddress _contactAddress;
    private DateTime _contactValidTill;

    public ContactType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="personIdentification">Just one of the fields 'personIdentification', 'personIdentificationPartner' and 'partnerIdOrganisation' is required.</param>
    /// <param name="personIdentificationPartner">Just one of the fields 'personIdentification', 'personIdentificationPartner' and 'partnerIdOrganisation' is required.</param>
    /// <param name="partnerIdOrganisation">Just one of the fields 'personIdentification', 'personIdentificationPartner' and 'partnerIdOrganisation' is required.</param>
    /// <param name="contactAddress">Field is required.</param>
    /// <param name="contactValidTill">Field is optional.</param>
    /// <returns>ContactType.</returns>
    public static ContactType Create(PersonIdentification personIdentification,
        PersonIdentificationLight personIdentificationPartner,
        PartnerIdOrganisationType partnerIdOrganisation, MailAddress contactAddress, DateTime contactValidTill)
    {
        var res = new ContactType
        {
            ContactAddress = contactAddress,
            ContactValidTill = contactValidTill
        };

        if (personIdentification != null && personIdentificationPartner == null && partnerIdOrganisation == null)
        {
            res.PersonIdentification = personIdentification;
            return res;
        }

        if (personIdentification == null && personIdentificationPartner != null && partnerIdOrganisation == null)
        {
            res.PersonIdentificationPartner = personIdentificationPartner;
            return res;
        }

        if (personIdentification == null && personIdentificationPartner == null && partnerIdOrganisation != null)
        {
            res.PartnerIdOrganisation = partnerIdOrganisation;
            return res;
        }

        throw new FieldValidationException("Just one of the elements 'personIdentification', 'personIdentificationPartner' and 'partnerIdOrganisation' must be filled.");
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

    [FieldRequired]
    [JsonProperty("contactAddress")]
    [XmlElement(ElementName = "contactAddress")]
    public MailAddress ContactAddress
    {
        get => _contactAddress;
        set => CheckAndSetValue(ref _contactAddress, value);
    }

    [JsonProperty("contactValidTill")]
    [XmlElement(ElementName = "contactValidTill")]
    public DateTime ContactValidTill
    {
        get => _contactValidTill;
        set => CheckAndSetValue(ref _contactValidTill, value);
    }
}
