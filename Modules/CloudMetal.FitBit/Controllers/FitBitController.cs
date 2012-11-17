using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using CloudMetal.FitBit.Models;
using OAuth.Net.Common;
using OAuth.Net.Components;
using OAuth.Net.Consumer;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Mvc.Extensions;
using EndPoint = OAuth.Net.Consumer.EndPoint;

namespace CloudMetal.FitBit.Controllers
{
    public class FitBitController : Controller
    {
        // API call path to get temporary credentials (request token and secret)
        const string RequestTokenUrl = "https://api.fitbit.com/oauth/request_token";

        // Base path of URL where the user will authorize this application
        const string AuthorizationUrl = "https://www.fitbit.com/oauth/authorize";

        // API call path to get token credentials (access token and secret)
        const string AccessTokenUrl = "https://api.fitbit.com/oauth/access_token";

        // API call path to protected resource
        const string ApiCallUrl = "http://api.fitbit.com/1/user/-/activities/date/2011-01-25.xml";

        private readonly IOrchardServices _orchardServices;

        public FitBitController(IOrchardServices orchardServices) {
            _orchardServices = orchardServices;
        }

        public ActionResult Activities(string returnUrl) {
            // get the OAuth Settings...
            var oauthSettings = _orchardServices.WorkContext.CurrentSite.As<OAuthSettingsPart>();

            // Create OAuthService object, containing oauth consumer configuration
            OAuthService service = OAuthService.Create(
                new EndPoint(RequestTokenUrl, "POST"),         // requestTokenEndPoint
                new Uri(AuthorizationUrl),                     // authorizationUri
                new EndPoint(AccessTokenUrl, "POST"),          // accessTokenEndPoint
                true,                                          // useAuthorizationHeader
                "http://api.fitbit.com",                       // realm
                "HMAC-SHA1",                                   // signatureMethod
                "1.0",                                         // oauthVersion
                new OAuthConsumer(oauthSettings.ClientId, oauthSettings.ClientSecret) // consumer
                );

            try
            {
                // Create OAuthRequest object, providing protected resource URL, consumer configuration,
                // callback URL and current session identifier
                OAuthRequest request = OAuthRequest.Create(
                    new EndPoint(ApiCallUrl, "GET"),
                    service,
                    _orchardServices.WorkContext.HttpContext.Request.Url,
                    _orchardServices.WorkContext.HttpContext.Session.SessionID);

                // Assign verification handler delegate
                request.VerificationHandler = AspNetOAuthRequest.HandleVerification;

                // Call OAuthRequest object GetResource method, which returns OAuthResponse object
                OAuthResponse response = request.GetResource();

                // Check if OAuthResponse object has protected resource
                if (!response.HasProtectedResource)
                {
                    // If not we are not authorized yet, build authorization URL and redirect to it
                    string authorizationUrl = service.BuildAuthorizationUrl(response.Token).AbsoluteUri;
                    Response.Redirect(authorizationUrl);
                }

                // Store the access token in session variable
                Session["access_token"] = response.Token;

                // Initialize the XmlDocument object and OAuthResponse object's protected resource to it
                //this.Doc = new XmlDocument();
                //this.Doc.Load(response.ProtectedResource.GetResponseStream());
            }
            catch (WebException ex)
            {
                Response.Write(ex.Message);
                Response.Close();
            }
            catch (OAuthRequestException ex)
            {
                Response.Write(ex.Message);
                Response.Close();
            }
            return this.RedirectLocal(returnUrl);
        }
    }
}