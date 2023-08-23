// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0006_2_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Ausländerkategorien (eCH-0006).
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "permitRoot", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0044/4")]
public class PermitRoot
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public PermitRoot()
    {
        Xmlns.Add("eCH-0044", "http://www.ech.ch/xmlns/eCH-0044/4");
    }

    [JsonProperty("residencePermitCategory")]
    [XmlElement(ElementName = "residencePermitCategory", Order = 1)]
    public ResidencePermitCategory ResidencePermitCategory { get; set; }

    [JsonProperty("residencePermitRuling")]
    [XmlElement(ElementName = "residencePermitRuling", Order = 2)]
    public ResidencePermitRuling ResidencePermitRuling { get; set; }

    [JsonProperty("residencePermitBorder")]
    [XmlElement(ElementName = "residencePermitBorder", Order = 3)]
    public ResidencePermitBorder ResidencePermitBorder { get; set; }

    [JsonProperty("residencePermitShort")]
    [XmlElement(ElementName = "residencePermitShort", Order = 4)]
    public ResidencePermitShort ResidencePermitShort { get; set; }

    [JsonProperty("residencePermit")]
    [XmlElement(ElementName = "residencePermit", Order = 5)]
    public ResidencePermit ResidencePermit { get; set; }

    [JsonProperty("inhabitantControl")]
    [XmlElement(ElementName = "inhabitantControl", Order = 6)]
    public InhabitantControl InhabitantControl { get; set; }

    [JsonProperty("residencePermitDetailed")]
    [XmlElement(ElementName = "residencePermitDetailed", Order = 7)]
    public ResidencePermitDetailed ResidencePermitDetailed { get; set; }

    [JsonProperty("residencePermitToBeRegistered")]
    [XmlElement(ElementName = "residencePermitToBeRegistered", Order = 8)]
    public ResidencePermitToBeRegistered ResidencePermitToBeRegistered { get; set; }
}
