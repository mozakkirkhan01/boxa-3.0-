using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxa
{
    public enum Month
    {
        Jan = 1,
        Feb = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        Sept = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12
    }
    public enum DvvType
    {
        ExtendedProfile = 1,
        Metrices = 2
    }
    public enum Course
    {
        BEd = 1,
        DElEd = 2
    }
    public enum Relation
    {
        Spouse = 1,
        Children = 2
    }
    public enum IdProofType
    {
        Aadhar = 1,
        VoterId = 2
    }
    public enum States
    {
        AndhraPradesh = 1,
        ArunachalPradesh = 2,
        Assam = 3,
        Bihar = 4,
        Chhattisgarh = 5,
        Delhi = 6,
        Goa = 7,
        Gujarat = 8,
        Haryana = 9,
        HimachalPradesh = 10,
        JammuKashmir = 11,
        Jharkhand = 12,
        Karnataka = 13,
        Kerala = 14,
        MadhyaPradesh = 15,
        Maharashtra = 16,
        Manipur = 17,
        Meghalaya = 18,
        Mizoram = 19,
        Nagaland = 20,
        Orissa = 21,
        Punjab = 22,
        Rajasthan = 23,
        Sikkim = 24,
        TamilNadu = 25,
        Tripura = 26,
        Uttarakhand = 27,
        UttarPradesh = 28,
        WestBengal = 29,
        AndamanNicobar = 30,
        Chandigarh = 31,
        DadraAndNagarHaveli = 32,
        DamanDiu = 33,
        Lakshadweep = 34,
        Pondicherry = 35,
        Others = 100
    }
    public enum TransferStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum EcontentStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum VideoStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum ScrollingStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum ResultStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum SubjectStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum SessionStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum AchievementStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum RegistrationHeadStatus
    {
        Active = 1,
        Inactive = 2
    }

    public enum LoginResult
    {
        Successful = 1,
        Failed = 2,
        Error = 3,
        AccountNotActive = 4
    }
    public enum UserType
    {
        Admin = 1,
        Students = 2,
        RegisteredStudent = 3
    }
    public enum AssignmentStatus
    {
        Visible = 1, Invisible = 2
    }
    public enum NewsAndEventStatus
    {
        Visible = 1, Invisible = 2
    }
    public enum PlacementPartnerStatus
    {
        Visible = 1, Invisible = 2

    }
    public enum PlacementRecordStatus
    {
        Visible = 1, Invisible = 2

    }
    public enum SliderStatus
    {
        Visible = 1,
        Invisible = 2
    }
    public enum NewsStatus
    {
        Visible = 1,
        Invisible = 2
    }
    public enum SyllabusStatus
    {
        Visible = 1,
        Invisible = 2
    }
    public enum ActivitiesNoticeStatus
    {
        Visible = 1,
        Invisible = 2
    }
    public enum FacultyStatus
    {
        Visible = 1,
        Invisible = 2
    }
    public enum HODMessageStatus
    {
        Visible = 1,
        Invisible = 2
    }
    public enum GalleryStatus
    {
        Visible = 1,
        Invisible = 2
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other=3
    }
    public enum MaritalStatus
    {
        Single = 1,
        Married = 2,
        Other = 3
    }
    public enum RegistrationStatus
    {
        PendingPayment = 1,
        Paid = 2,
        Enrolled = 3
    }
    public enum PaymentMode
    {
        Online = 1,
        DemandDraft = 2
    }
    //public enum AchievementStatus
    //{
    //    Active = 1,
    //    Inactive = 2
    //}
    public enum RecentUpdateStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum VideoGalleryStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum MediaStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum EventStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum Status
    {
        Active = 1,
        Inactive = 2
    }
    public enum TestimonialStatus
    {
        Active = 1,
        Inactive = 2
    }
    public enum FacultyType
    {
        Permanent = 1,
        Guest = 2
    }
}
