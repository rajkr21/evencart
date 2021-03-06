﻿#region License
// Copyright (c) Sojatia Infocrafts Private Limited.
// The following code is part of EvenCart eCommerce Software (https://evencart.co) Dual Licensed under the terms of
// 
// 1. GNU GPLv3 with additional terms (available to read at https://evencart.co/license)
// 2. EvenCart Proprietary License (available to read at https://evencart.co/license/commercial-license).
// 
// You can select one of the above two licenses according to your requirements. The usage of this code is
// subject to the terms of the license chosen by you.
#endregion

using EvenCart.Core.Config;
using EvenCart.Data.Enum;

namespace EvenCart.Data.Entity.Settings
{
    public class SecuritySettings : ISettingGroup
    {
        /// <summary>
        /// Default password format
        /// </summary>
        public PasswordFormat DefaultPasswordStorageFormat { get; set; }
        /// <summary>
        /// Specifies the number of days after last change, that user must change password
        /// </summary>
        public int ExpirePasswordDays { get; set; }
        /// <summary>
        /// The number of hours after which email verification link should expire. Set to 0 for no expiration.
        /// </summary>
        public int EmailVerificationLinkExpirationHours { get; set; }
        /// <summary>
        /// The number of hours after which password reset link should expire. Set to 0 for no expiration.
        /// </summary>
        public int PasswordResetLinkExpirationHours { get; set; }
        /// <summary>
        /// The number of hours after which invite link should expire. Set to 0 for no expiration.
        /// </summary>
        public int InviteLinkExpirationHours { get; set; }
        /// <summary>
        /// The number of minutes after which email verification code should expire. Set to 0 for no expiration
        /// </summary>
        public int EmailVerificationCodeExpirationMinutes { get; set; }
        /// <summary>
        /// If captcha should be enabled
        /// </summary>
        public bool EnableCaptcha { get; set; }
        /// <summary>
        /// The site key for Google Captcha
        /// </summary>
        public string SiteKey { get; set; }
        /// <summary>
        /// The site secret for Google captcha
        /// </summary>
        public string SiteSecret { get; set; }
        /// <summary>
        /// The IP Address which are banned from accessing the site. Leave empty to allow all IP addresses.
        /// </summary>
        public string BannedIps { get; set; }
        /// <summary>
        /// The IP Addresses which are allowed to access admin area. Leave empty to allow all IP addresses.
        /// </summary>
        public string AdminRestrictedIps { get; set; }
        /// <summary>
        /// The private key that'll be required for POST requests if no verification token is passed
        /// </summary>
        public string SharedVerificationKey { get; set; }
        /// <summary>
        /// The name of honeypot field to prevent bot submissions
        /// </summary>
        public string HoneypotFieldName { get; set; } 
    }
}