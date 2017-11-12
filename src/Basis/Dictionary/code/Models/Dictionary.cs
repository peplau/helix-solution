﻿using Sitecore.Data.Items;
using Sitecore.Sites;

namespace Sitecore.Basis.Dictionary.Models
{
    public class Dictionary
    {
        public Item Root { get; set; }
        public bool AutoCreate { get; set; }
        public SiteContext Site { get; set; }
    }
}