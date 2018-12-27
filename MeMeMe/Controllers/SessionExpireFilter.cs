using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MeMeMe.Controllers
{
   /// <summary>
    /// Executes when Session exipre, and redirects to login page.
    /// </summary>
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// User is redirected.
        /// </summary>
        private static bool userIsRedirected;

        /// <summary>
        /// Called by the MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextBase ctx = filterContext.HttpContext;
            
            // check if session is supported
            if (ctx.Session != null)
            {

                // check if a new session id was generated
                if (ctx.Session.IsNewSession)
                {

                    //// If it says it is a new session, but an existing cookie exists, then it must
                    //// have timed out
                    //string sessionCookie = ctx.Request.Headers["Cookie"];
                    //if ((null != sessionCookie) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                    //{

                    // I don't like this Hack but don't know better right now!!!
                    if (ctx.Request.Cookies["ASP.NET_SessionId"] != null && !userIsRedirected)
                    {
                        ctx.Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddYears(-30);
                        userIsRedirected = true;
                        filterContext.Result = OnSessionExpiryRedirectResult(filterContext);   
                    }
                    //ctx.Session.Abandon();
                        
                    // }

                }
            }

            base.OnActionExecuting(filterContext);
        }


        /// <summary>
        /// When session expiry redirect result <see cref="FormsAuthentication"/> login URL>.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns><see cref="ActionResult"/></returns>
        public virtual ActionResult OnSessionExpiryRedirectResult(ActionExecutingContext filterContext)
        {
            return new RedirectResult(FormsAuthentication.LoginUrl);
        }
    }
}