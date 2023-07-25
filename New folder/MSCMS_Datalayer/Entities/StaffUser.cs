using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSCMS_Datalayer.Entities
{
    public partial class StaffUser
    {
        public StaffUser()
        {
            AssetsAssetmeasurements = new HashSet<AssetsAssetmeasurement>();
            AssetsAssets = new HashSet<AssetsAsset>();
            AssetsAssetstatuschanges = new HashSet<AssetsAssetstatuschange>();
            AssetsCouponmeasurements = new HashSet<AssetsCouponmeasurement>();
            AssetsCoupons = new HashSet<AssetsCoupon>();
            AssetsCouponstatuschanges = new HashSet<AssetsCouponstatuschange>();
            AssetsDevices = new HashSet<AssetsDevice>();
            AssetsMimicdiagrams = new HashSet<AssetsMimicdiagram>();
            DjangoAdminLogs = new HashSet<DjangoAdminLog>();
            InverseLastModifiedUser = new HashSet<StaffUser>();
            Oauth2ProviderAccesstokens = new HashSet<Oauth2ProviderAccesstoken>();
            Oauth2ProviderApplications = new HashSet<Oauth2ProviderApplication>();
            Oauth2ProviderGrants = new HashSet<Oauth2ProviderGrant>();
            Oauth2ProviderRefreshtokens = new HashSet<Oauth2ProviderRefreshtoken>();
            StaffApplicationconfigLastModifiedUsers = new HashSet<StaffApplicationconfig>();
            StaffApplicationconfigUsers = new HashSet<StaffApplicationconfig>();
            StaffApplicationlogs = new HashSet<StaffApplicationlog>();
            StaffUserGroups = new HashSet<StaffUserGroup>();
            StaffUserUserPermissions = new HashSet<StaffUserUserPermission>();
            StaffUsernotifications = new HashSet<StaffUsernotification>();
            SystemSystemconfigurations = new HashSet<SystemSystemconfiguration>();
        }

        [Key]
        public int Id { get; set; }
        public string Password { get; set; } = null!;
        public DateTime? LastLogin { get; set; }
        public bool IsSuperuser { get; set; }
        public string? Username { get; set; } 
        public string? Email { get; set; } 
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsStaff { get; set; }
        public bool IsCollector { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }
        public int? LastModifiedUserId { get; set; }
        public bool? Notify { get; set; }
        public bool? IsLockedOut { get; set; }
        public int? InvalidLoginAttempts { get; set; }
        public DateTime? LockedTimestamp { get; set; }
        public DateTime? ExpiredTimestamp { get; set; }

        public virtual StaffUser? LastModifiedUser { get; set; }
        public virtual ICollection<AssetsAssetmeasurement> AssetsAssetmeasurements { get; set; }
        public virtual ICollection<AssetsAsset> AssetsAssets { get; set; }
        public virtual ICollection<AssetsAssetstatuschange> AssetsAssetstatuschanges { get; set; }
        public virtual ICollection<AssetsCouponmeasurement> AssetsCouponmeasurements { get; set; }
        public virtual ICollection<AssetsCoupon> AssetsCoupons { get; set; }
        public virtual ICollection<AssetsCouponstatuschange> AssetsCouponstatuschanges { get; set; }
        public virtual ICollection<AssetsDevice> AssetsDevices { get; set; }
        public virtual ICollection<AssetsMimicdiagram> AssetsMimicdiagrams { get; set; }
        public virtual ICollection<DjangoAdminLog> DjangoAdminLogs { get; set; }
        public virtual ICollection<StaffUser> InverseLastModifiedUser { get; set; }
        public virtual ICollection<Oauth2ProviderAccesstoken> Oauth2ProviderAccesstokens { get; set; }
        public virtual ICollection<Oauth2ProviderApplication> Oauth2ProviderApplications { get; set; }
        public virtual ICollection<Oauth2ProviderGrant> Oauth2ProviderGrants { get; set; }
        public virtual ICollection<Oauth2ProviderRefreshtoken> Oauth2ProviderRefreshtokens { get; set; }
        public virtual ICollection<StaffApplicationconfig> StaffApplicationconfigLastModifiedUsers { get; set; }
        public virtual ICollection<StaffApplicationconfig> StaffApplicationconfigUsers { get; set; }
        public virtual ICollection<StaffApplicationlog> StaffApplicationlogs { get; set; }
        public virtual ICollection<StaffUserGroup> StaffUserGroups { get; set; }
        public virtual ICollection<StaffUserUserPermission> StaffUserUserPermissions { get; set; }
        public virtual ICollection<StaffUsernotification> StaffUsernotifications { get; set; }
        public virtual ICollection<SystemSystemconfiguration> SystemSystemconfigurations { get; set; }
    }
}
