# RavenDB.AspNetCore.Identity #
An ASP.NET Core Identity provider for RavenDB
Based on: https://github.com/tugberkugurlu/AspNetCore.Identity.MongoDB

## Purpose ##

ASP.NET MVC Core shipped with a new Identity system (in the Microsoft.AspNetCore.Identity package) in order to support both local login and remote logins via OpenID/OAuth, but only ships with an Entity Framework provider (Microsoft.AspNetCore.Identity.EntityFramework).

## Features ##
* Drop-in replacement ASP.NET Core Identity with RavenDB as the backing store.
* Provides UserStore<TUser> implementation that implements the same interfaces as the EntityFramework version:
    * IUserStore<TUser>,
    * IUserLoginStore<TUser>,
    * IUserClaimStore<TUser>,
    * IUserPasswordStore<TUser>,
    * IUserSecurityStampStore<TUser>,
    * IUserTwoFactorStore<TUser>,
    * IUserEmailStore<TUser>,
    * IUserLockoutStore<TUser>,
    * IUserPhoneNumberStore<TUser>,
    * IUserRoleStore<TUser>
