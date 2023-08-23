// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0021_7_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personenzusatzdaten (eCH-0021)
/// Angaben zur Massnahme.
/// </summary>
[Serializable]
[JsonObject("guardianMeasureInfo")]
[XmlRoot(ElementName = "guardianMeasureInfo", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0021/7")]
public class GuardianMeasureInfo
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string BasedOnLawAddOnValidateExceptionMessage = "BasedOnLawAddOn is not valid! BasedOnLawAddOn has to be maximum length 100";

    private string _basedOnLawAddOn;

    public GuardianMeasureInfo()
    {
        Xmlns.Add("eCH-0021", "http://www.ech.ch/xmlns/eCH-0021/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="guardianMeasureValidFrom">Field is required.</param>
    /// <param name="basedOnLaws">Field is optional.</param>
    /// <param name="basedOnLawAddOn">Field is optional.</param>
    /// <returns>GuardianMeasureInfo.</returns>
    public static GuardianMeasureInfo Create(DateTime guardianMeasureValidFrom, List<BasedOnLaw> basedOnLaws = null, string basedOnLawAddOn = null)
    {
        return new GuardianMeasureInfo()
        {
            BasedOnLaws = basedOnLaws,
            BasedOnLawAddOn = basedOnLawAddOn,
            GuardianMeasureValidFrom = guardianMeasureValidFrom
        };
    }

    [JsonProperty("basedOnLaw")]
    [XmlElement(ElementName = "basedOnLaw", Order = 1)]
    public List<BasedOnLaw> BasedOnLaws { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public bool BasedOnLawsSpecified => BasedOnLaws != null && BasedOnLaws.Any();

    [JsonProperty("basedOnLawAddOn")]
    [XmlElement(ElementName = "basedOnLawAddOn", Order = 2)]
    public string BasedOnLawAddOn
    {
        get { return _basedOnLawAddOn; }

        set
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 100)
            {
                throw new XmlSchemaValidationException(BasedOnLawAddOnValidateExceptionMessage);
            }
            _basedOnLawAddOn = value;
        }
    }

    [JsonProperty("guardianMeasureValidFrom")]
    [XmlElement(DataType = "date", ElementName = "guardianMeasureValidFrom", Order = 3)]
    public DateTime GuardianMeasureValidFrom { get; set; }
}
