// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Schema;
using System.Xml.Serialization;
using eCH_0058_4_0;
using Newtonsoft.Json;

namespace eCH_0045_3_0;

[Serializable]
[JsonObject("voterDelivery")]
[XmlRoot(ElementName = "voterDelivery", IsNullable = false, Namespace = "http://www.ech.ch/xmlns/eCH-0045/3")]
public class VoterDelivery
{
    [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
    public string xsiSchemaLocation = "http://www.ech.ch/xmlns/eCH-0045/3 http://www.ech.ch/xmlns/eCH-0045/3/eCH-0045-3-0.xsd";
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
        Xmlns.Add("eCH-0045", "http://www.ech.ch/xmlns/eCH-0045/3");
    }

    [JsonProperty("deliveryHeader")]
    [XmlElement(ElementName = "deliveryHeader")]
    public Header DeliveryHeader
    {
        get => _deliveryHeader;
        set => _deliveryHeader = value ?? throw new XmlSchemaValidationException(DeliveryHeaderNullValidateExceptionMessage);
    }

    [XmlElement("voterList", typeof(VoterList))]
    [XmlElement("addVoter", typeof(EventAddVoter))]
    [XmlElement("changeVotingRights", typeof(EventChangeVotingRights))]
    [XmlElement("removeVoter", typeof(EventRemoveVoter))]
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

        if (value is VoterList)
        {
            ElementTypeName = VoterChoiceIdentifier.voterList;
        }
        else if (value is EventAddVoter)
        {
            ElementTypeName = VoterChoiceIdentifier.addVoter;
        }
        else if (value is EventChangeVotingRights)
        {
            ElementTypeName = VoterChoiceIdentifier.changeVotingRights;
        }
        else if (value is EventRemoveVoter)
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
    public static VoterDelivery Create(Header deliveryHeader, VoterList voterList)
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
    public static VoterDelivery Create(Header deliveryHeader, EventAddVoter addVoter)
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
    public static VoterDelivery Create(Header deliveryHeader, EventChangeVotingRights changeVotingRights)
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
    public static VoterDelivery Create(Header deliveryHeader, EventRemoveVoter removeVoter)
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
