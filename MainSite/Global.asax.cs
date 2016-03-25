using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MainSite
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //GlobalConfiguration.Configure(App_Start.ApplicationConfig.RegisterSettings);
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);


            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //MapperInit.Init();
            //HttpContext.Current.Cache["IPGCache"] = new PublisherGroupsCache();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            //CommonSettings.MainLog.Info("Application end");
            HttpRuntime runtime = (HttpRuntime)typeof(System.Web.HttpRuntime).
                InvokeMember("_theRuntime",
                BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField,
                null, null, null);

            if (runtime == null)
                return;

            string shutDownMessage = (string)runtime.GetType().
                InvokeMember("_shutDownMessage",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField,
                null, runtime, null);

            string shutDownStack = (string)runtime.GetType().
                InvokeMember("_shutDownStack",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField,
                null, runtime, null);

            string shutDownReason = String.Format("\r\n\r\n_shutDownMessage={0}\r\n\r\n_shutDownStack={1}",
                                         shutDownMessage,
                                         shutDownStack);

            //CommonSettings.MainLog.Info("SHUTDOWN REASON: " + shutDownReason);
        }

        void Application_Error(object sender, EventArgs e)
        {
            var l_context = HttpContext.Current;
            var l_exc = l_context.Server.GetLastError().GetBaseException();
            //string l_loggerMessage = l_exc.FormLogMessage(l_exc.Message);
            //CommonSettings.MainLog.Error(l_loggerMessage, l_exc);
            try
            {
                //NotificationManager.SendExeption(new MailMessageServerException()
                //{
                //    Url = l_context.Request.Url.ToString(),
                //    Message = l_loggerMessage,
                //    CurrenDateTime = DateTime.UtcNow.ToLocalTime(),
                //    Name = l_context.Session != null ? WebSecurityManager.UserName : String.Empty,
                //    UserRole = l_context.Session != null ? (WebSecurityManager.UserIsAdmin ? WebSecurityManager.ROLE_ADMIN : WebSecurityManager.ROLE_PUBLISHER) : String.Empty,
                //    SubmissionSystem = l_context.Session != null ? WebSecurityManager.SubmissionSystemShort : String.Empty,
                //    StackTrace = l_exc.StackTrace,
                //    IsSpuSubmition = l_context.Session != null && WebSecurityManager.IsSPUSubmission
                //});
            }
            catch (Exception ex)
            {
                //CommonSettings.MainLog.Error(ex.InnerException ?? ex);
            }
            //// Handle HTTP errors
            //if (exc.GetType() == typeof(HttpException))
            //{
            //    //Redirect HTTP errors to HttpError page
            //    Server.Transfer("RequestNotAllowed.aspx");
            //}
            //l_context.ClearError();
            Server.Transfer("~/Pages/Errors/Error.aspx");
        }

        void Session_Start(object sender, EventArgs e)
        {

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the session state mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            
        }

        public override string GetVaryByCustomString(HttpContext context, string arg)
        {
            //return arg == "SystemUserId" ? WebSecurityManager.SystemUserId : base.GetVaryByCustomString(context, arg);
            return null;
        }
    }
}








// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionExtensions.cs" company="Eleks">
//   license - 
// </copyright>
// <author>Igor Golovko</author>
// <summary>
//   Defines the ExceptionExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

//namespace Core.Extensions
//{
//    using System;
//    using System.Linq;
//    using Common.Extensions;

//    /// <summary>
//    /// Extensions for exception class.
//    /// </summary>
//    public static class ExceptionExtensions
//    {
//        public static string FormLogMessage(this Exception exception, string logMessage)
//        {
//            return String.Format("{0}\r\n{1}", logMessage, exception.GetExtendedInfo()).Trim();
//        }

//        public static string GetExtendedInfo(this Exception exception)
//        {
//            if (exception is System.Data.Entity.Validation.DbEntityValidationException)
//            {
//                return (exception as System.Data.Entity.Validation.DbEntityValidationException).EntityValidationErrors.Where(m => !m.IsValid)
//                    .SelectMany(m => m.ValidationErrors)
//                    .Select(m => String.Format("{0}: {1}", m.PropertyName, m.ErrorMessage))
//                    .Aggregate((x, y) => x + "\r\n" + y);
//            }
//            if (exception is System.Data.Entity.Validation.DbUnexpectedValidationException)
//            {
//                var l_dbEx = (System.Data.Entity.Validation.DbUnexpectedValidationException)exception;
//                return String.Format("ErrorMessage: {0}\r\nErrorDescription: {0}\r\nErrorContext: {1}\r\nLine: {2}\r\nColumn: {3}",
//                    l_dbEx.Message,
//                    l_dbEx.Description(),
//                    l_dbEx.StackTrace,
//                    l_dbEx.Source);
//            }
//            return exception.StackTrace;
//        }
//    }
//}
