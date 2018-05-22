﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLVLXD.Common
{
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[CommonConstants.USER_SESSION];
            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.UserID);

            if (privilegeLevels.Contains(this.RoleID))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            var values = new RouteValueDictionary(new
            {
                action = "Err403",
                controller = "Home"
            });
            filterContext.Result = new RedirectToRouteResult(values);
        }
        private List<string> GetCredentialByLoggedInUser(long username)
        {
            var credentials = (List<string>)HttpContext.Current.Session[CommonConstants.SESSION_CREDENTIAL];
            return credentials;
        }
    }
}