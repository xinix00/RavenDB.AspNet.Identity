using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace RavenDB.AspNetCore.Identity
{
    public class IdentityUser
    {
        public class UserLogin : 
            IEquatable<UserLogin>, 
            IEquatable<UserLoginInfo>
        {
            public UserLogin(UserLoginInfo loginInfo)
            {
                if (loginInfo == null)
                {
                    throw new ArgumentNullException(nameof(loginInfo));
                }

                LoginProvider = loginInfo.LoginProvider;
                ProviderKey = loginInfo.ProviderKey;
                ProviderDisplayName = loginInfo.ProviderDisplayName;
            }

            public string LoginProvider { get; private set; }
            public string ProviderKey { get; private set; }
            public string ProviderDisplayName { get; private set; }

            public bool Equals(UserLogin other)
            {
                return other.LoginProvider.Equals(LoginProvider)
                    && other.ProviderKey.Equals(ProviderKey);
            }

            public bool Equals(UserLoginInfo other)
            {
                return other.LoginProvider.Equals(LoginProvider)
                    && other.ProviderKey.Equals(ProviderKey);
            }
        }

        public class UserClaim : IEquatable<UserClaim>, IEquatable<Claim>
        {
            public UserClaim(Claim claim)
            {
                if (claim == null)
                {
                    throw new ArgumentNullException(nameof(claim));
                }

                ClaimType = claim.Type;
                ClaimValue = claim.Value;
            }

            public UserClaim(string claimType, string claimValue)
            {
                if (claimType == null)
                {
                    throw new ArgumentNullException(nameof(claimType));
                }
                if (claimValue == null)
                {
                    throw new ArgumentNullException(nameof(claimValue));
                }

                ClaimType = claimType;
                ClaimValue = claimValue;
            }

            public string ClaimType { get; private set; }
            public string ClaimValue { get; private set; }

            public bool Equals(UserClaim other)
            {
                return other.ClaimType.Equals(ClaimType)
                    && other.ClaimValue.Equals(ClaimValue);
            }

            public bool Equals(Claim other)
            {
                return other.Type.Equals(ClaimType)
                    && other.Value.Equals(ClaimValue);
            }
        }

        public abstract class UserContactRecord : IEquatable<UserEmail>
        {
            protected UserContactRecord(string value)
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                Value = value;
            }

            public string Value { get; private set; }
            public ConfirmationOccurrence ConfirmationRecord { get; private set; }

            public bool IsConfirmed()
            {
                return ConfirmationRecord != null;
            }

            public void SetConfirmed()
            {
                SetConfirmed(new ConfirmationOccurrence());
            }

            public void SetConfirmed(ConfirmationOccurrence confirmationRecord)
            {
                if (ConfirmationRecord == null)
                {
                    ConfirmationRecord = confirmationRecord;
                }
            }

            public void SetUnconfirmed()
            {
                ConfirmationRecord = null;
            }

            public bool Equals(UserEmail other)
            {
                return other.Value.Equals(Value);
            }
        }

        public class UserPhoneNumber : 
            UserContactRecord
        {
            public UserPhoneNumber(string phoneNumber) : 
                base(phoneNumber)
            {
            }
        }

        public class UserEmail : 
            UserContactRecord
        {
            public UserEmail(string email) : 
                base(email)
            {
            }

            public string NormalizedValue { get; set; }
        }

        public IdentityUser()
        {

        }

        public IdentityUser(string userName, string email) 
            : this(userName)
        {
            if (email != null)
            {
                Email = new UserEmail(email);
            }
        }

        public IdentityUser(string userName, UserEmail email) 
            : this(userName)
        {
            if (email != null)
            {
                Email = email;
            }
        }

        public IdentityUser(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            Id = GenerateId(userName);
            UserName = userName;
            CreatedOn = new Occurrence();

            Claims = new List<UserClaim>();
            Logins = new List<UserLogin>();
            Roles = new List<string>();
        }

        public string Id { get; private set; }

        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public UserEmail Email { get; set; }

        public UserPhoneNumber PhoneNumber { get; set; }
        public bool IsTwoFactorEnabled { get; set; }

        public List<UserClaim> Claims { get; set; }
        public List<UserLogin> Logins { get; set; }
        public List<string> Roles { get; set; }

        public int AccessFailedCount { get; set; }
        public bool IsLockoutEnabled { get; set; }

        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }

        public FutureOccurrence LockoutEndDate { get; private set; }
        public Occurrence CreatedOn { get; private set; }

        public virtual void ResetAccessFailedCount()
        {
            AccessFailedCount = 0;
        }

        public virtual void LockUntil(DateTime lockoutEndDate)
        {
            LockoutEndDate = new FutureOccurrence(lockoutEndDate);
        }

        private static string GenerateId(string userName)
        {
            return "IdentityUsers/" + userName.ToLower();
        }
    }
}
