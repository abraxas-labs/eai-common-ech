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
/// Der vorliegende Standard definiert, zusammen mit den Datenstandards 0044 Personeniden-tifikation
/// und 0045 Stimm- und Wahlrecht, das Format und die erlaubten Werte zum elektronischen Austausch von
/// Personen-, Aufenthalts- und Niederlassungsinformationen zwischen den Behörden der Schweiz.
/// </summary>
[Serializable]
[JsonObject("personRoot")]
[XmlRoot(ElementName = "personRoot", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/8")]
public class PersonRoot
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private const string ReportedPersonNullValidateExceptionMessage = "ReportedPerson is not valid! ReportedPerson is required";

    private ReportedPerson _reportedPerson;

    public PersonRoot()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/8");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportedPerson">Field is requried.</param>
    /// <returns>ForeignerName.</returns>
    public static PersonRoot Create(ReportedPerson reportedPerson)
    {
        return new PersonRoot()
        {
            ReportedPerson = reportedPerson
        };
    }

    [JsonProperty("reportedPerson")]
    [XmlElement(ElementName = "reportedPerson", Order = 1)]
    public ReportedPerson ReportedPerson
    {
        get { return _reportedPerson; }

        set
        {
            _reportedPerson = value ?? throw new XmlSchemaValidationException(ReportedPersonNullValidateExceptionMessage);
        }
    }
}
