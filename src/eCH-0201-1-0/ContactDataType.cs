// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0010_5_1;
using Newtonsoft.Json;

namespace eCH_0201_1_0;

/// <summary>
///     eCH eGovernment - Standards
///     Schnittstellenstandard Lieferung Personendaten für Haushaltabgabe (eCH-0201)
///     Kontaktdaten.
/// </summary>
[Serializable]
[JsonObject("contactData")]
[XmlRoot(ElementName = "contactData", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0201/1")]
public class ContactDataType : FieldValueChecker<ContactDataType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private MailAddress _contactAddress;
    private DateTime? _contactValidFrom;
    private DateTime? _contactValidTill;

    public ContactDataType()
    {
        Xmlns.Add("eCH-0201", "http://www.ech.ch/xmlns/eCH-0201/1");
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    ///     Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="contacAddress">Field is reqired.</param>
    /// <param name="contactValidFrom">Field can be null.</param>
    /// <param name="contactValidTill">Field can be null.</param>
    /// <returns>PersonIdentification.</returns>
    public static ContactDataType Create(MailAddress contacAddress, DateTime? contactValidFrom = null, DateTime? contactValidTill = null)
    {
        return new ContactDataType
        {
            ContactAddress = contacAddress,
            ContactValidFrom = contactValidFrom,
            ContactValidTill = contactValidTill,
        };
    }

    [FieldRequired]
    [JsonProperty("contactAddress")]
    [XmlElement(ElementName = "contactAddress")]
    public MailAddress ContactAddress
    {
        get => _contactAddress;
        set => CheckAndSetValue(ref _contactAddress, value);
    }

    [JsonProperty("contactValidFrom")]
    [XmlElement(DataType = "date", ElementName = "contactValidFrom")]
    public DateTime? ContactValidFrom
    {
        get => _contactValidFrom;
        set => CheckAndSetValue(ref _contactValidFrom, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactValidFromSpecified => ContactValidFrom.HasValue;

    [JsonProperty("contactValidTill")]
    [XmlElement(DataType = "date", ElementName = "contactValidTill")]
    public DateTime? ContactValidTill
    {
        get => _contactValidTill;
        set => CheckAndSetValue(ref _contactValidTill, value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool ContactValidTillSpecified => ContactValidTill.HasValue;
}
