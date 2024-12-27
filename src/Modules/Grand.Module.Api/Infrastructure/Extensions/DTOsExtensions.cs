using Grand.Module.Api.DTOs.Common;
using Grand.Module.Api.DTOs.Shipping;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Grand.Module.Api.Infrastructure.Extensions
{
    public static class DTOsExtensions
    {
        /// <summary>
        /// Return Host with scheme with an trailing slash like https://www.mysite.com/
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        public static string GetHost(HttpRequest httpRequest)
        {
            var host = $"{httpRequest.Scheme}://{httpRequest.Host.Value}/";
            return host;
        }

        /// <summary>
        /// Generate Unique store urls for clinics on this pattern https://safeclinicname.host.com/
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="clinicName"></param>
        /// <returns></returns>
        public static StoreDto Bind(this StoreDto store, HttpRequest httpRequest)
        {

            // Ensure the clinic name is valid for a subdomain
            var safeClinicName = GetSafeName(store.Name);
            store.Shortcut = safeClinicName;
            store.Url = $"{httpRequest.Scheme}://{safeClinicName}.{httpRequest.Host.Value}/";
            if (httpRequest.Scheme == "https")
            {
                store.SslEnabled = true;
            }
            else
            {
                store.SslEnabled = false;
            }
            return store;
        }

        public static WarehouseDto Bind(this WarehouseDto warehouse)
        {
            var safeName = GetSafeName(warehouse.Name);
            warehouse.Name = $"{safeName}-warehouse";
            warehouse.Code = $"{safeName.ToUpper()}-WH";
            return warehouse;
        }

        /// <summary>
        /// Ensures the provided string is a valid subdomain
        /// </summary>
        /// <param name="subdomain"></param>
        /// <returns></returns>
        private static string GetSafeName(string subdomain)
        {
            // Convert to lowercase
            subdomain = subdomain.ToLowerInvariant();

            // Remove invalid characters
            subdomain = Regex.Replace(subdomain, @"[^a-z0-9-]", "");

            // Remove leading and trailing hyphens
            subdomain = subdomain.Trim('-');

            // Ensure the subdomain is not empty
            if (string.IsNullOrEmpty(subdomain))
            {
                throw new ArgumentException("Invalid subdomain");
            }

            return subdomain;
        }
    }
}
