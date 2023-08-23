// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0011_7_0f;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Der vorliegende Standard definiert, zusammen mit den Datenstandards 0044 Personeniden-tifikation
/// und 0045 Stimm- und Wahlrecht, das Format und die erlaubten Werte zum elektronischen Austausch von
/// Personen-, Aufenthalts- und Niederlassungsinformationen zwischen den Behörden der Schweiz.
/// </summary>
[Serializable]
[JsonObject("personRoot")]
[XmlRoot(ElementName = "personRoot", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011-f/7")]
public class PersonRoot : FieldValueChecker<PersonRoot>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private ReportedPersonType _reportedPerson;

    public PersonRoot()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011-f/7");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="reportedPerson">Field is requried.</param>
    /// <returns>ForeignerName.</returns>
    public static PersonRoot Create(ReportedPersonType reportedPerson)
    {
        return new PersonRoot
        {
            ReportedPerson = reportedPerson
        };
    }

    [FieldRequired]
    [JsonProperty("reportedPerson")]
    [XmlElement(ElementName = "reportedPerson")]
    public ReportedPersonType ReportedPerson
    {
        get => _reportedPerson;
        set => CheckAndSetValue(ref _reportedPerson, value);
    }
}
