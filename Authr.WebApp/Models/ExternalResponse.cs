using System.Text.Json.Serialization;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;

namespace Authr.WebApp.Models
{
    // Note:
    // The [BindProperty] attributes are for model binding (used with form and query parameters).
    // The [JsonPropertyName] attributes are for deserialization performed by input formatters
    // when JSON data is posted to API-style methods (whose parameters are annotated with [FromBody]).
    public class ExternalResponse
    {
        [BindProperty(Name = OidcConstants.AuthorizeResponse.State)]
        [JsonPropertyName(OidcConstants.AuthorizeResponse.State)]
        public string State { get; set; }

        [BindProperty(Name = OidcConstants.AuthorizeResponse.Error)]
        [JsonPropertyName(OidcConstants.AuthorizeResponse.Error)]
        public string Error { get; set; }

        [BindProperty(Name = OidcConstants.AuthorizeResponse.ErrorDescription)]
        [JsonPropertyName(OidcConstants.AuthorizeResponse.ErrorDescription)]
        public string ErrorDescription { get; set; }

        [BindProperty(Name = OidcConstants.AuthorizeResponse.Code)]
        [JsonPropertyName(OidcConstants.AuthorizeResponse.Code)]
        public string AuthorizationCode { get; set; }

        [BindProperty(Name = OidcConstants.AuthorizeResponse.IdentityToken)]
        [JsonPropertyName(OidcConstants.AuthorizeResponse.IdentityToken)]
        public string IdToken { get; set; }

        [BindProperty(Name = OidcConstants.AuthorizeResponse.AccessToken)]
        [JsonPropertyName(OidcConstants.AuthorizeResponse.AccessToken)]
        public string AccessToken { get; set; }

        [BindProperty(Name = OidcConstants.AuthorizeResponse.TokenType)]
        [JsonPropertyName(OidcConstants.AuthorizeResponse.TokenType)]
        public string TokenType { get; set; }

        [BindProperty(Name = OidcConstants.AuthorizeResponse.RefreshToken)]
        [JsonPropertyName(OidcConstants.AuthorizeResponse.RefreshToken)]
        public string RefreshToken { get; set; }

        public bool IsEmpty()
        {
            // Check if any of the relevant properties are set, excluding State (as just state without anything else is useless).
            return string.IsNullOrWhiteSpace(this.Error + this.ErrorDescription + this.AuthorizationCode + this.IdToken + this.AccessToken + this.TokenType + this.RefreshToken);
        }
    }
}