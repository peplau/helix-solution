﻿using Sitecore.Data.Items;

namespace Sitecore.Basis.Dictionary.Repositories
{
    public interface IDictionaryPhraseRepository
    {
        string Get(string relativePath, string defaultValue = "");
        Item GetItem(string relativePath, string defaultValue = "");
    }
}
