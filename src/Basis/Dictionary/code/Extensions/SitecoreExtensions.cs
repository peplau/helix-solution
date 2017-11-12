﻿using Sitecore.Basis.Dictionary.Repositories;
using Sitecore.Mvc.Helpers;
using System.Web;

namespace Sitecore.Basis.Dictionary.Extensions
{
    /// <summary>
    /// Extension to render dictionary items
    /// </summary>
    public static class SitecoreExtensions
    {
        public static string Dictionary(this SitecoreHelper helper, string relativePath, string defaultValue = "")
        {
            return DictionaryPhraseRepository.Current.Get(relativePath, defaultValue);
        }

        public static HtmlString DictionaryField(this SitecoreHelper helper, string relativePath, string defaultValue = "")
        {
            var item = DictionaryPhraseRepository.Current.GetItem(relativePath, defaultValue);
            if (item == null)
                return new HtmlString(defaultValue);
            return helper.Field(Templates.DictionaryEntry.FieldIds.Phrase.ToString(), item);
        }
    }
}