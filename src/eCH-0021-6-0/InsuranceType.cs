// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0010_5_0;
using Newtonsoft.Json;

namespace eCH_0021_6_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zum Institut bei welchem die Person krankenversichert ist.
/// </summary>
[Serializable]
[JsonObject("insurance")]
[XmlRoot(ElementName = "insurance", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/6")]
public class InsuranceType : FieldValueChecker<InsuranceType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _insuranceName;
    private OrganisationMailAddress _insuranceAddress;

    public InsuranceType()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/6");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="insuranceName">Field is required.</param>
    /// <returns>Insurance.</returns>
    public static InsuranceType Create(string insuranceName)
    {
        return new InsuranceType
        {
            InsuranceName = insuranceName,
            InsuranceAddress = null
        };
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="insuranceAddress">Field is required.</param>
    /// <returns>Insurance.</returns>
    public static InsuranceType Create(OrganisationMailAddress insuranceAddress)
    {
        return new InsuranceType()
        {
            InsuranceName = null,
            InsuranceAddress = insuranceAddress
        };
    }

    [JsonProperty("insuranceName")]
    [XmlElement(ElementName = "insuranceName")]
    public string InsuranceName
    {
        get => _insuranceName;
        set => CheckAndSetValue(ref _insuranceName, value);
    }

    [JsonProperty("insuranceAddress")]
    [XmlElement(ElementName = "insuranceAddress")]
    public OrganisationMailAddress InsuranceAddress
    {
        get => _insuranceAddress;
        set => CheckAndSetValue(ref _insuranceAddress, value);
    }
}
