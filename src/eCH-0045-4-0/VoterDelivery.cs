// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0058_5_0;
using Newtonsoft.Json;

namespace eCH_0045_4_0;

[Serializable]
[JsonObject("voterDelivery")]
[XmlRoot(ElementName = "voterDelivery", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/4")]
public class VoterDelivery
{
    [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
    public string xsiSchemaLocation = "http://www.ech.ch/xmlns/eCH-0045/4 http://www.ech.ch/xmlns/eCH-0045/4/eCH-0045-4-0.xsd";
#pragma warning restore SA1307 // Accessible fields should begin with upper-case letter

    private const string DeliveryHeaderNullValidateExceptionMessage =
        "DeliveryHeader is not valid! DeliveryHeader is a false Type";

    private const string VoterChoiceNullValidateExceptionMessage =
        "VoterChoice is not valid! VoterChoice is required";

    private const string VoterChoiceOutOfRangeValidateExceptionMessage =
        "VoterChoice is not valid! VoterChoice is a false Type";

    [JsonIgnore][XmlIgnore] public VoterChoiceIdentifier ElementTypeName;
    private Header _deliveryHeader;
    private object _voterChoice;
    [JsonIgnore][XmlNamespaceDeclarations] public XmlSerializerNamespaces Xmlns = new();

    public VoterDelivery()
    {
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/4");
    }

    [JsonProperty("deliveryHeader")]
    [XmlElement(ElementName = "deliveryHeader", Order = 1)]
    public Header DeliveryHeader
    {
        get => _deliveryHeader;
        set => _deliveryHeader = value ?? throw new XmlSchemaValidationException(DeliveryHeaderNullValidateExceptionMessage);
    }

    [XmlElement("voterList", typeof(VoterListType), Order = 2)]
    [XmlElement("addVoter", typeof(EventAddVoterType), Order = 2)]
    [XmlElement("changeVotingRights", typeof(EventChangeVotingRightsType), Order = 2)]
    [XmlElement("removeVoter", typeof(EventRemoveVoterType), Order = 2)]
    [XmlChoiceIdentifier("ElementTypeName")]
    public object VoterChoice
    {
        get => _voterChoice;
        set => _voterChoice = VoterChoiceIsValid(value);
    }

    private object VoterChoiceIsValid(object value)
    {
        if (value == null)
        {
            throw new XmlSchemaValidationException(VoterChoiceNullValidateExceptionMessage);
        }

        if (value is VoterListType)
        {
            ElementTypeName = VoterChoiceIdentifier.voterList;
        }
        else if (value is EventAddVoterType)
        {
            ElementTypeName = VoterChoiceIdentifier.addVoter;
        }
        else if (value is EventChangeVotingRightsType)
        {
            ElementTypeName = VoterChoiceIdentifier.changeVotingRights;
        }
        else if (value is EventRemoveVoterType)
        {
            ElementTypeName = VoterChoiceIdentifier.removeVoter;
        }
        else
        {
            throw new XmlSchemaValidationException(VoterChoiceOutOfRangeValidateExceptionMessage);
        }

        return value;
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="deliveryHeader">Field is required.</param>
    /// <param name="voterList">Field is required.</param>
    /// <returns>VoterDelivery.</returns>
    public static VoterDelivery Create(Header deliveryHeader, VoterListType voterList)
    {
        return new VoterDelivery
        {
            DeliveryHeader = deliveryHeader,
            VoterChoice = voterList
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="deliveryHeader">Field is required.</param>
    /// <param name="addVoter">Field is required.</param>
    /// <returns>VoterDelivery.</returns>
    public static VoterDelivery Create(Header deliveryHeader, EventAddVoterType addVoter)
    {
        return new VoterDelivery
        {
            DeliveryHeader = deliveryHeader,
            VoterChoice = addVoter
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="deliveryHeader">Field is required.</param>
    /// <param name="changeVotingRights">Field is required.</param>
    /// <returns>VoterDelivery.</returns>
    public static VoterDelivery Create(Header deliveryHeader, EventChangeVotingRightsType changeVotingRights)
    {
        return new VoterDelivery
        {
            DeliveryHeader = deliveryHeader,
            VoterChoice = changeVotingRights
        };
    }

    /// <summary>
    ///     Statische Methode um das Object zu initialisieren.
    ///     Die Statische Methode stellt sicher, dass das Objekt eCH - Standard valid ist!.
    /// </summary>
    /// <param name="deliveryHeader">Field is required.</param>
    /// <param name="removeVoter">Field is required.</param>
    /// <returns>VoterDelivery.</returns>
    public static VoterDelivery Create(Header deliveryHeader, EventRemoveVoterType removeVoter)
    {
        return new VoterDelivery
        {
            DeliveryHeader = deliveryHeader,
            VoterChoice = removeVoter
        };
    }
}
public enum VoterChoiceIdentifier
{
    voterList,
    addVoter,
    changeVotingRights,
    removeVoter
}
