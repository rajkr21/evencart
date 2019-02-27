﻿using System;
using System.Collections.Generic;
using RoastedMarketplace.Core.Data;
using RoastedMarketplace.Data.Enum;
using RoastedMarketplace.Data.Interfaces;

namespace RoastedMarketplace.Data.Entity.Users
{
    public class User : FoundationEntity, ISoftDeletable, IHasEntityProperties<User>, ISearchFilterSupported
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string MobileNumber { get; set; }

        public Guid Guid { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public PasswordFormat PasswordFormat { get; set; }

        public bool Active { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public bool IsSystemAccount { get; set; }

        public string Remarks { get; set; }

        public string LastLoginIpAddress { get; set; }

        public int ReferrerId { get; set; }

        public bool Deleted { get; set; }

        public bool RequirePasswordChange { get; set; }

        public bool IsTaxExempt { get; set; }

        public bool NewslettersEnabled { get; set; }

        #region Virtual Properties
        public virtual IList<Role> Roles { get; set; }
        #endregion
    }
}