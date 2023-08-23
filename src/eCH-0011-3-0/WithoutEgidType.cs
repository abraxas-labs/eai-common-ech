// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using Newtonsoft.Json;

namespace eCH_0011_3_0;

/// <summary>
/// eCH eGovernment - Standards
/// Datenstandard Personendaten (eCH-0011)
/// Konfessionsangaben.
/// </summary>
[Serializable]
[JsonObject("withoutEgid")]
[XmlRoot(ElementName = "withoutEgid", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0011/3")]
public class WithoutEgidType : FieldValueChecker<WithoutEgidType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private string _householdId;

    public WithoutEgidType()
    {
        Xmlns.Add("eCH-0011", "http://www.ech.ch/xmlns/eCH-0011/3");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="householdId">Field is required.</param>
    /// <returns>WithoutEgidType.</returns>
    public static WithoutEgidType Create(string householdId)
    {
        return new WithoutEgidType
        {
            HouseholdId = householdId
        };
    }

    [FieldRequired]
    [JsonProperty("householdID")]
    [XmlElement(ElementName = "householdID")]
    public string HouseholdId
    {
        get => _householdId;
        set => CheckAndSetValue(ref _householdId, value);
    }
}
