// /* Copyright (C) Pro.Vision - All Rights Reserved
//  * Unauthorized copying of this file, via any medium is strictly prohibited
//  * Proprietary and confidential
//  * Written by Igor Prokofjev <igor.prokofjev@pro-vision.com>, 2016
//  */

using System;
using System.Collections.Generic;
using System.Configuration;

namespace MainSite.Core
{
    /// <summary>
    /// Contains site settings.
    /// </summary>
    public static class SiteSettings
    {        
        #region Constants

        private const string KeyCompanyName = "CompanyName";
        private const string KeyCompanyEmail = "CompanyEmail";
        private const string KeyCompanyStartYear = "CompanyStartYear";

        #endregion

        #region Private members

        private static readonly Dictionary<string, object> dictSettings;

        #endregion

        #region ctor

        static SiteSettings()
        {
            dictSettings = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets name of Company.
        /// </summary>
        public static string CompanyName
        {
            get { return LazyRead<string>(KeyCompanyName); }
        }

        /// <summary>
        /// Gets main e-mail address of the Company.
        /// </summary>
        public static string CompanyEmail
        {
            get { return LazyRead<string>(KeyCompanyEmail); }
        }

        /// <summary>
        /// Gets year when Company was found.
        /// </summary>
        public static int CompanyFoundYear
        {
            get { return LazyRead<int>(KeyCompanyStartYear); }
        }

        #endregion

        #region Private methods

        private static T LazyRead<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            Lazy<T> lazy;
            if (!dictSettings.ContainsKey(key))
            {
                Func<T> func = () => ReadAppSetting<T>(key);
                lazy = new Lazy<T>(func);
                dictSettings.Add(key, lazy);
            }
            else
            {
                lazy = (Lazy<T>)dictSettings[key];
            }

            return lazy.Value;
        }

        private static T ReadAppSetting<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            var value = ConfigurationManager.AppSettings[key];

            if (value == null)
            {
                return default(T);
            }

            T result = (T)Convert.ChangeType(value, typeof(T));
            return result;
        }

        #endregion
    }
}