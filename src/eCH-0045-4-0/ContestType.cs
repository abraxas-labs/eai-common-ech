// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_4_0;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("contestType")]
[XmlRoot(ElementName = "contestType", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class ContestType : FieldValueChecker<ContestType>
{
    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    private DateTime _contestDate;
    private ContestDescriptionInformation _contestDescription;

    public ContestType()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    /// <summary>
    /// Statische Methode um das Object zu initialisieren.
    /// Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!
    /// Diese Methode befüllt alle möglichen Werte.
    /// </summary>
    /// <param name="contestDate">Field is reqired.</param>
    /// <param name="contestDescription">Field is optional.</param>
    /// <returns>ContestType.</returns>
    public static ContestType Create(DateTime contestDate, ContestDescriptionInformation contestDescription)
    {
        return new ContestType
        {
            ContestDate = contestDate,
            ContestDescription = contestDescription
        };
    }

    [FieldRequired]
    [JsonProperty("contestDate")]
    [XmlElement(DataType = "date", ElementName = "contestDate", Order = 1)]
    public DateTime ContestDate
    {
        get => _contestDate;
        set => CheckAndSetValue(ref _contestDate, value);
    }

    [FieldRequired]
    [JsonProperty("contestDescription")]
    [XmlElement(ElementName = "contestDescription", Order = 2)]
    public ContestDescriptionInformation ContestDescription
    {
        get => _contestDescription;
        set => CheckAndSetValue(ref _contestDescription, value);
    }
}
