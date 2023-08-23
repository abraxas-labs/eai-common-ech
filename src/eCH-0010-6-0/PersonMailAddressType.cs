// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0010_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Postadresse für natürliche Personen, Firmen, Organisationen und Behörden (eCH-0010)
/// Postadresse einer natürlichen Person im In- oder Ausland.
/// </summary>
[Serializable]
[JsonObject("personMailAddress")]
[XmlRoot(ElementName = "personMailAddress", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010/6")]
public class PersonMailAddressType : FieldValueChecker<PersonMailAddressType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonMailAddressInfoType _personMailAddressInfo;
    private AddressInformationType _addressInformation;

    public PersonMailAddressType()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="personMailAddressInfo">Field is reqired.</param>
    /// <param name="addressInformation">Field is reqired.</param>
    /// <returns>PersonMailAddress.</returns>
    public static PersonMailAddressType Create(PersonMailAddressInfoType personMailAddressInfo, AddressInformationType addressInformation)
    {
        return new PersonMailAddressType
        {
            PersonMailAddressInfo = personMailAddressInfo,
            AddressInformation = addressInformation
        };
    }

    [FieldRequired]
    [JsonProperty("person")]
    [XmlElement(ElementName = "person", Order = 1)]
    public PersonMailAddressInfoType PersonMailAddressInfo
    {
        get => _personMailAddressInfo;
        set => CheckAndSetValue(ref _personMailAddressInfo, value);
    }

    [FieldRequired]
    [JsonProperty("addressInformation")]
    [XmlElement(ElementName = "addressInformation", Order = 2)]
    public AddressInformationType AddressInformation
    {
        get => _addressInformation;
        set => CheckAndSetValue(ref _addressInformation, value);
    }
}
