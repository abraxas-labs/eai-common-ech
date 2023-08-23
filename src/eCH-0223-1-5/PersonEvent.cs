// (c) Copyright 2023 by Abraxas Informatik AG
// For license information see LICENSE file

using System.Xml.Serialization;

namespace eCH_0223_1_5;

[XmlType(TypeName = "personEventType", Namespace = "http://www.ech.ch/xmlns/eCH-0223/1")]
public enum PersonEvent
{
    moveOut,
    changeNationality,
    undoSwiss,
    naturalizeForeigner,
    changeResidenceType,
    birth,
    changeName,
    undoPartnership,
    partnership,
    divorce,
    death,
    marriage,
    undoSeperation,
    separation,
    move,
    undoMarriage,
    undoMissing,
    missing,
    maritalStatusPartner,
    deletedinRegister,
    moveIn,
    correctParentalrelationship,
    correctReporting,
    correctName,
    correctNationality,
    correctOccupation,
    correctMaritalInfo,
    correctBirthInfo,
    correctDeathData,
    correctPersonAddionalData,
    prolongationB,
    prolongationC,
    prolongationL,
    conversionBtoC,
    laggardOfFamily,
    duplicateOfPermit,
    othercaseOfMigration,
    declarationOfCommitment
}
