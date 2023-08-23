// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace eCH_0011_8_1;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Konfessionsangaben.
/// </summary>
[Serializable]
[JsonObject("otherResidence")]
[XmlRoot(ElementName = "otherResidence", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class OtherResidenceType
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string SecondaryResidenceNullValidateExceptionMessage = "SecondaryResidence is not valid! SecondaryResidence is required";

    private ResidenceData _secondaryResidence;

    public OtherResidenceType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="secondaryResidence">Field is required.</param>
    /// <returns>ForeignerName.</returns>
    public static OtherResidenceType Create(SecondaryResidenceData secondaryResidence = null)
    {
        return new OtherResidenceType()
        {
            SecondaryResidence = secondaryResidence
        };
    }

    [JsonProperty("secondaryResidence")]
    [XmlElement(ElementName = "secondaryResidence", Order = 1)]
    public ResidenceData SecondaryResidence
    {
        get { return _secondaryResidence; }

        set
        {
            _secondaryResidence = value ?? throw new XmlSchemaValidationException(SecondaryResidenceNullValidateExceptionMessage);
        }
    }
}
