// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0155_4_0;
using Newtonsoft.Json;

namespace eCH_0228;

/// <summary>
///     eCH eGovernment - Standards
///     Datenstandard Druckdatenaustausch Stimmrechtsausweis  (eCH-0228).
/// </summary>
[Serializable]
[JsonObject("delivery")]
[XmlRoot(ElementName = "delivery", IsNullable = true, Namespace = "http://www.ech.ch/xmlns/eCH-0228/1")]
public class VotingCardDelivery : FieldValueChecker<VotingCardDelivery>
{
    private ContestDataType _contestDataField;
    private List<votingCardDataType> _votingCardDataField;
    private List<namedCodeType> _logisticCodeField;
    private ExtensionType _extension;

    [JsonIgnore]
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces Xmlns = new();

    public VotingCardDelivery()
    {
        Xmlns.Add("eCH-0228", "http://www.ech.ch/xmlns/eCH-0228/1");
    }

    [FieldRequired]
    [JsonProperty("contestData")]
    [XmlElement(ElementName = "contestData")]
    public ContestDataType ContestData
    {
        get => _contestDataField;
        set => CheckAndSetValue(ref _contestDataField, value);
    }

    [FieldRequired]
    [JsonProperty("votingCardData")]
    [XmlElement(ElementName = "votingCardData")]
    public List<votingCardDataType> VotingCardData
    {
        get => _votingCardDataField;
        set => CheckAndSetValue(ref _votingCardDataField, value);
    }

    [FieldRequired]
    [JsonProperty("logisticCode")]
    [XmlElement(ElementName = "logisticCode")]
    public List<namedCodeType> LogisticCode
    {
        get => _logisticCodeField;
        set => CheckAndSetValue(ref _logisticCodeField, value);
    }

    [JsonProperty("extension")]
    [XmlElement(ElementName = "extension")]
    public ExtensionType Extension
    {
        get => _extension;
        set => CheckAndSetValue(ref _extension, value);
    }

    [XmlIgnore]
    [JsonIgnore]
    public bool ExtensionSpecified => Extension != null;
}
