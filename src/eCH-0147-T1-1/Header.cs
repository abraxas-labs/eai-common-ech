// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System;
using System.Xml.Serialization;
using Eai.Common.eCH.AttributeChecker;
using eCH_0039_2_0;
using eCH_0058_3_0;
using Newtonsoft.Json;

namespace eCH_0147_T1_1;

[Serializable]
[JsonObject("header")]
[XmlType("headerType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
[XmlRoot("header", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T1/1", IsNullable = false)]
public class Header : FieldValueChecker<Header>
{
    private string _senderId;
    private string _messageId;
    private int? _messageType;
    private MessageGroup _messageGroup;
    private SendingApplication _sendingApplication;
    private DateTime? _messageDate;
    private ActionType? _action;
    private bool? _testDeliveryFlag;

    [FieldRequired]
    [JsonProperty("senderId")]
    [XmlElement("senderId", DataType = "token")]
    public string SenderId
    {
        get => _senderId;
        set => CheckAndSetValue(ref _senderId, value);
    }

    [JsonProperty("recipientId")]
    [XmlElement("recipientId", DataType = "token")]
    public string[] RecipientIds { get; set; }

    [JsonProperty("originalSenderId")]
    [XmlElement("originalSenderId", DataType = "token")]
    public string OriginalSenderId { get; set; }

    [JsonProperty("declarationLocalReference")]
    [XmlElement("declarationLocalReference", DataType = "token")]
    public string DeclarationLocalReference { get; set; }

    [FieldRequired]
    [JsonProperty("messageId")]
    [XmlElement("messageId", DataType = "token")]
    public string MessageId
    {
        get => _messageId;
        set => CheckAndSetValue(ref _messageId, value);
    }

    [JsonProperty("referenceMessageId")]
    [XmlElement("referenceMessageId", DataType = "token")]
    public string ReferenceMessageId { get; set; }

    [JsonProperty("uniqueBusinessTransactionId")]
    [XmlElement("uniqueBusinessTransactionId", DataType = "token")]
    public string UniqueBusinessTransactionId { get; set; }

    [JsonProperty("ourBusinessReferenceId")]
    [XmlElement("ourBusinessReferenceId", DataType = "token")]
    public string OurBusinessReferenceId { get; set; }

    [JsonProperty("yourBusinessReferenceId")]
    [XmlElement("yourBusinessReferenceId", DataType = "token")]
    public string YourBusinessReferenceId { get; set; }

    [FieldRequired]
    [JsonProperty("messageType")]
    [XmlElement("messageType")]
    public int? MessageType
    {
        get => _messageType;
        set => CheckAndSetValue(ref _messageType, value);
    }

    [JsonProperty("subMessageType")]
    [XmlElement("subMessageType", DataType = "token")]
    public string SubMessageType { get; set; }

    [FieldRequired]
    [JsonProperty("messageGroup")]
    [XmlElement("messageGroup")]
    public MessageGroup MessageGroup
    {
        get => _messageGroup;
        set => CheckAndSetValue(ref _messageGroup, value);
    }

    [FieldRequired]
    [JsonProperty("sendingApplication")]
    [XmlElement("sendingApplication")]
    public SendingApplication SendingApplication
    {
        get => _sendingApplication;
        set => CheckAndSetValue(ref _sendingApplication, value);
    }

    [JsonProperty("subjects")]
    [XmlArray("subjects")]
    [XmlArrayItem("subject", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Subject[] Subjects { get; set; }

    [JsonProperty("object")]
    [XmlElement("object")]
    public object Object { get; set; }

    [JsonProperty("comments")]
    [XmlArray("comments")]
    [XmlArrayItem("comment", Namespace = "http://www.ech.ch/xmlns/eCH-0039/2", IsNullable = false)]
    public Comment[] Comments { get; set; }

    [FieldRequired]
    [JsonProperty("messageDate")]
    [XmlElement("messageDate")]
    public DateTime? MessageDate
    {
        get => _messageDate;
        set => CheckAndSetValue(ref _messageDate, value);
    }

    [JsonProperty("initialMessageDate")]
    [XmlElement("initialMessageDate")]
    public DateTime? InitialMessageDate { get; set; }

    [JsonProperty("eventDate")]
    [XmlElement("eventDate")]
    public DateTime? EventDate { get; set; }

    [JsonProperty("eventPeriod")]
    [XmlElement("eventPeriod", DataType = "token")]
    public string EventPeriod { get; set; }

    [JsonProperty("modificationDate")]
    [XmlElement("modificationDate")]
    public DateTime? ModificationDate { get; set; }

    [FieldRequired]
    [JsonProperty("action")]
    [XmlElement("action")]
    public ActionType? Action
    {
        get => _action;
        set => CheckAndSetValue(ref _action, value);
    }

    [FieldRequired]
    [JsonProperty("testDeliveryFlag")]
    [XmlElement("testDeliveryFlag")]
    public bool? TestDeliveryFlag
    {
        get => _testDeliveryFlag;
        set => CheckAndSetValue(ref _testDeliveryFlag, value);
    }

    [FieldRequired]
    [JsonProperty("reference")]
    [XmlElement("reference")]
    public Reference Reference { get; set; }
}
