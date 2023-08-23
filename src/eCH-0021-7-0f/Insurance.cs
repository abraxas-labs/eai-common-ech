﻿// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0010_5_1f;
using Newtonsoft.Json;

namespace eCH_0021_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zum Institut bei welchem die Person krankenversichert ist.
/// </summary>
[Serializable]
[JsonObject("insurance")]
[XmlRoot(ElementName = "insurance", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021-f/7")]
public class Insurance
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();
    private const string InsuranceNameValidateExceptionMessage = "InsuranceName InsuranceName not valid! InsuranceName has to be maximum length of 100";
    private string _insuranceName;

    public Insurance()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="insuranceName">Field is required.</param>
    /// <returns>Insurance.</returns>
    public static Insurance Create(string insuranceName)
    {
        return new Insurance()
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
    public static Insurance Create(OrganisationMailAddress insuranceAddress)
    {
        return new Insurance()
        {
            InsuranceName = null,
            InsuranceAddress = insuranceAddress
        };
    }

    [JsonProperty("insuranceName")]
    [XmlElement(ElementName = "insuranceName")]
    public string InsuranceName
    {
        get { return _insuranceName; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(InsuranceNameValidateExceptionMessage);
            }
            _insuranceName = value;
        }
    }

    [JsonIgnore]
    [XmlIgnore]
    public bool InsuranceNameSpecified => InsuranceName != null;

    [JsonProperty("insuranceAddress")]
    [XmlElement(ElementName = "insuranceAddress")]
    public OrganisationMailAddress InsuranceAddress { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool InsuranceAddressSpecified => InsuranceAddress != null;
}
