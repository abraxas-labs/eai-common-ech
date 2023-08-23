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
[JsonObject("reportHeader")]
[XmlType("reportHeaderType", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T0/1")]
[XmlRoot("reportHeader", Namespace = "http://www.ech.ch/xmlns/eCH-0147/T1/1", IsNullable = false)]
public class ReportHeader : FieldValueChecker<ReportHeader>
{
    private string _senderId;
    private string _messageId;
    private int? _messageType;
    private MessageGroup _messageGroup;
    private SendingApplication _sendingApplication;
    private ReportAction? _action;
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

    [JsonProperty("object")]
    [XmlElement("object")]
    public object Object { get; set; }

    [JsonProperty("initialMessageDate")]
    [XmlElement("initialMessageDate")]
    public DateTime? InitialMessageDate { get; set; }

    [FieldRequired]
    [JsonProperty("action")]
    [XmlElement("action")]
    public ReportAction? Action
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
