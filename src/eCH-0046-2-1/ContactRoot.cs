// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0046_2_1;

[Serializable]
[JsonObject("contactType")]
[XmlRoot(ElementName = "contactRoot", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0046/2")]
public class ContactRoot : FieldValueChecker<ContactRoot>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ContactType _contact;

    public ContactRoot()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0046/2");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <returns>ContactRoot.</returns>
    public static ContactRoot Create(ContactType contact)
    {
        return new ContactRoot
        {
            Contact = contact
        };
    }

    [FieldRequired]
    [JsonProperty("contact")]
    [XmlElement(ElementName = "contact")]
    public ContactType Contact
    {
        get => _contact;
        set => CheckAndSetValue(ref _contact, value);
    }
}
