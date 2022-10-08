namespace Biklas_API_V2.Helpers
{
    public static class BkConfigurationExtensions
    {
        /// <summary>
        /// Shorthand for GetSection("ServicesCredentials")[name].
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="name">The credential string key.</param>
        /// <returns>The service credential.</returns>
        public static string GetServCredentialString(this IConfiguration configuration, string name)
        {
            return configuration.GetSection("ServicesCredentials")[name];
        }
    }
}
