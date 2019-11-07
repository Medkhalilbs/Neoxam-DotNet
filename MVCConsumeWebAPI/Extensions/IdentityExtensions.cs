using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace MVCConsumeWebAPI.Extensions
{
    public static class IdentityExtensions
    {
        public static int GetID(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Id");
            // Test for null to avoid issues during local testing
            if (claim == null)
                return 0;
            else
                return int.Parse(claim.Value);
        }
        public static int GetJeeUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("jeeUserId");
            // Test for null to avoid issues during local testing

            if (claim == null)
                return 0;
            else
                return int.Parse(claim.Value);
        }

        public static string GetRole(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("role");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetPhone_number(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("phone_number");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetRegistration_date(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("registration_date");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetStatus(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("status");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetCIN(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("cin");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetFirst_name(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("first_name");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetLast_name(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("last_name");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetPicture(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("picture");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
        public static string GetBirthdate(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("birthdate");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetEmail(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Email");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }



    }
}