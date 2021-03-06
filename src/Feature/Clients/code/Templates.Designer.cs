
// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

#pragma warning disable 1591

namespace Sitecore.Feature.Clients.Templates
{
  #region Designer generated code

  using System;
  using Sitecore;
  using Sitecore.Diagnostics;
  using Sitecore.Data.Items;
  using Sitecore.Data.Fields;
  using Sitecore.Data;
  
      
  /// <summary>Represents the "_Client" template.</summary>
  public partial class __Client : CustomItem
  {
    public static readonly ID TemplateID = ID.Parse("{6084076C-A965-4E9D-9B3E-0AC0948C9A5C}");

    public __Client(Item item) : base(item) {
    }

    public static class FieldIds {
      
      public static readonly ID Image = ID.Parse("{F2A54998-9D1D-4291-A7C7-19869C588A41}");

      public static readonly ID Link = ID.Parse("{AE6C0D9D-5BDD-4D47-BB3A-2F7AD40FE43E}");

    }
    
    /// <summary>Gets the "Image" field.</summary>
    public ImageField Image 
    {
      get 
      {
        return this.InnerItem.Fields[FieldIds.Image];
      }
    }
  
    /// <summary>Gets or sets the "Link" field.</summary>
    public string Link {
      get 
      {
        return this.InnerItem[FieldIds.Link];
      }
      set 
      {
        this.InnerItem[FieldIds.Link] = value;
      }
    }
  
    public static __Client Create(Item item) 
    {
      return new __Client(item);
    }

    public static implicit operator Item (__Client item)
    {
      if (item == null)
      {
        return null;
      }

      return item.InnerItem;
    }

    public static explicit operator __Client(Item item)
    {
      if (item == null)
      {
        return null;
      }

      if (item.TemplateID != TemplateID)
      {
        return null;
      }

      return Create(item);
    }
  }
      
  /// <summary>Represents the "_Clients" template.</summary>
  public partial class __Clients : CustomItem
  {
    public static readonly ID TemplateID = ID.Parse("{ED87068F-59FA-409F-82E3-5BC021A638DC}");

    public __Clients(Item item) : base(item) {
    }

    public static class FieldIds {
      
    }
    
    public static __Clients Create(Item item) 
    {
      return new __Clients(item);
    }

    public static implicit operator Item (__Clients item)
    {
      if (item == null)
      {
        return null;
      }

      return item.InnerItem;
    }

    public static explicit operator __Clients(Item item)
    {
      if (item == null)
      {
        return null;
      }

      if (item.TemplateID != TemplateID)
      {
        return null;
      }

      return Create(item);
    }
  }
  
  #endregion
}

#pragma warning restore 1591
