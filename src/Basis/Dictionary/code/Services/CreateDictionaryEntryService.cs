using Sitecore.Basis.Dictionary.Templates;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using System;
using System.Linq;

namespace Sitecore.Basis.Dictionary.Services
{
    internal static class CreateDictionaryEntryService
    {
        public static Item CreateDictionaryEntry(Models.Dictionary dictionary, string relativePath, string defaultValue)
        {
            lock (dictionary)
            {
                var parts = relativePath.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var root = dictionary.Root;
                for (var i = 0; i < parts.Length - 1; i++)
                {
                    root = CreateDictionaryFolder(parts[i], root);
                }
                return CreateDictionaryEntry(parts.Last(), root, defaultValue);
            }
        }

        private static Item CreateDictionaryEntry(string name, Item root, string defaultValue)
        {
            using (new SecurityDisabler())
            {
                var item = GetOrCreateDictionaryItem(name, root, Templates.DictionaryEntry.TemplateID);
                using (new EditContext(item))
                {
                    item[DictionaryEntry.FieldIds.Phrase] = defaultValue;
                }
                return item;
            }
        }

        private static Item CreateDictionaryFolder(string name, Item parent)
        {
            using (new SecurityDisabler())
            {
                return GetOrCreateDictionaryItem(name, parent, Templates.DictionaryFolder.TemplateID);
            }
        }

        private static Item GetOrCreateDictionaryItem(string name, Item parent, ID templateID)
        {
            var item = parent.Axes.GetChild(name);
            if (item != null)
                return item;

            try
            {
                return parent.Add(name, new TemplateID(templateID));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Could not create item {name} under {parent.Name}", ex);
            }
        }
    }
}