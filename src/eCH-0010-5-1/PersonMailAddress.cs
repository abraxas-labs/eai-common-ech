// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0010_5_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Postadresse für natürliche Personen, Firmen, Organisationen und Behörden (eCH-0010)
/// Postadresse einer natürlichen Person im In- oder Ausland.
/// </summary>
[Serializable]
[JsonObject("personMailAddress")]
[XmlRoot(ElementName = "personMailAddress", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0010/5")]
public class PersonMailAddress : FieldValueChecker<PersonMailAddress>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private PersonMailAddressInfo _personMailAddressInfo;
    private AddressInformation _addressInformation;

    public PersonMailAddress()
    {
        Xmlns.Add("eCH-0010", "http://www.ech.ch/xmlns/eCH-0010/5");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle Werte.
    /// </summary>
    /// <param name="personMailAddressInfo">Field is reqired.</param>
    /// <param name="addressInformation">Field is reqired.</param>
    /// <returns>PersonMailAddress.</returns>
    public static PersonMailAddress Create(PersonMailAddressInfo personMailAddressInfo,
        AddressInformation addressInformation)
    {
        return new PersonMailAddress
        {
            PersonMailAddressInfo = personMailAddressInfo,
            AddressInformation = addressInformation
        };
    }

    [FieldRequired]
    [JsonProperty("person")]
    [XmlElement(ElementName = "person", Order = 1)]
    public PersonMailAddressInfo PersonMailAddressInfo
    {
        get => _personMailAddressInfo;
        set => CheckAndSetValue(ref _personMailAddressInfo, value);
    }

    [FieldRequired]
    [JsonProperty("addressInformation")]
    [XmlElement(ElementName = "addressInformation", Order = 2)]
    public AddressInformation AddressInformation
    {
        get => _addressInformation;
        set => CheckAndSetValue(ref _addressInformation, value);
    }
}
