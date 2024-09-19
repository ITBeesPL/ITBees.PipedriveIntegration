﻿namespace ITBees.PipedriveIntegration.Models;

public class Person
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Owner OwnerId { get; set; }
    public OrgId OrgId { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int OpenDealsCount { get; set; }
    public int RelatedOpenDealsCount { get; set; }
    public int ClosedDealsCount { get; set; }
    public int RelatedClosedDealsCount { get; set; }
    public int ParticipantOpenDealsCount { get; set; }
    public int ParticipantClosedDealsCount { get; set; }
    public int EmailMessagesCount { get; set; }
    public int ActivitiesCount { get; set; }
    public int DoneActivitiesCount { get; set; }
    public int UndoneActivitiesCount { get; set; }
    public int FilesCount { get; set; }
    public int NotesCount { get; set; }
    public int FollowersCount { get; set; }
    public int WonDealsCount { get; set; }
    public int RelatedWonDealsCount { get; set; }
    public int LostDealsCount { get; set; }
    public int RelatedLostDealsCount { get; set; }
    public bool ActiveFlag { get; set; }
    public List<Phone> Phone { get; set; }
    public List<Email> Email { get; set; }
    public string FirstChar { get; set; }
    public string UpdateTime { get; set; }
    public string DeleteTime { get; set; }
    public string AddTime { get; set; }
    public string VisibleTo { get; set; }
    public PictureId PictureId { get; set; }
    public object NextActivityDate { get; set; }
    public object NextActivityTime { get; set; }
    public object NextActivityId { get; set; }
    public object LastActivityId { get; set; }
    public object LastActivityDate { get; set; }
    public object LastIncomingMailTime { get; set; }
    public object LastOutgoingMailTime { get; set; }
    public object Label { get; set; }
    public List<int> LabelIds { get; set; }
    public List<Im> Im { get; set; }
    public object PostalAddress { get; set; }
    public object PostalAddressLat { get; set; }
    public object PostalAddressLong { get; set; }
    public object PostalAddressSubpremise { get; set; }
    public object PostalAddressStreetNumber { get; set; }
    public object PostalAddressRoute { get; set; }
    public object PostalAddressSublocality { get; set; }
    public object PostalAddressLocality { get; set; }
    public object PostalAddressAdminAreaLevel1 { get; set; }
    public object PostalAddressAdminAreaLevel2 { get; set; }
    public object PostalAddressCountry { get; set; }
    public object PostalAddressPostalCode { get; set; }
    public object PostalAddressFormattedAddress { get; set; }
    public object Notes { get; set; }
    public object Birthday { get; set; }
    public object JobTitle { get; set; }
    public string OrgName { get; set; }
    public string OwnerName { get; set; }
    public string PrimaryEmail { get; set; }
    public string CcEmail { get; set; }
}