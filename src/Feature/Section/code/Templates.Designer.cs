
// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

#pragma warning disable 1591

namespace Sitecore.Feature.Section.Templates
{
  #region Designer generated code

  using System;
  using Sitecore;
  using Sitecore.Diagnostics;
  using Sitecore.Data.Items;
  using Sitecore.Data.Fields;
  using Sitecore.Data;
  
      
  /// <summary>Represents the "ParametersTemplate_SectionProperties" template.</summary>
  public partial class ParametersTemplate_SectionProperties : CustomItem
  {
    public static readonly ID TemplateID = ID.Parse("{F72A2770-006D-49AD-83DA-569D18571F7A}");

    public ParametersTemplate_SectionProperties(Item item) : base(item) {
    }

    public static class FieldIds {
      
      public static readonly ID Identifier = ID.Parse("{1071C06B-DF67-4C4E-A420-75190007B662}");

      public static readonly ID Heading = ID.Parse("{7D2D6787-2BE4-4C4A-B8FB-DAAE2E5D7B89}");

      public static readonly ID Subheading = ID.Parse("{0441FB38-A035-4665-BA88-0809EF6ADA81}");

      public static readonly ID CSSClass = ID.Parse("{46FB0910-D994-4386-9582-F25BC87AE8FE}");

      public static readonly ID PlaceholderClass = ID.Parse("{92278792-4E3A-47BF-9DD4-F216986997AD}");

      public static readonly ID FooterText = ID.Parse("{B91928A6-D26B-4271-9D36-B9F23B447852}");

    }
    public static class FieldNames {
    
      public static readonly string Identifier = "Identifier";

      public static readonly string Heading = "Heading";

      public static readonly string Subheading = "Subheading";

      public static readonly string CSSClass = "CSSClass";

      public static readonly string PlaceholderClass = "PlaceholderClass";

      public static readonly string FooterText = "Footer Text";

    }
    
    /// <summary>Gets or sets the "Identifier" field.</summary>
    public string Identifier 
    {
      get 
      {
        return this.InnerItem[FieldIds.Identifier];
      }
      set
      {
        this.InnerItem[FieldIds.Identifier] = value;
      }
    }
  
    /// <summary>Gets or sets the "Heading" field.</summary>
    public string Heading 
    {
      get 
      {
        return this.InnerItem[FieldIds.Heading];
      }
      set
      {
        this.InnerItem[FieldIds.Heading] = value;
      }
    }
  
    /// <summary>Gets or sets the "Subheading" field.</summary>
    public string Subheading 
    {
      get 
      {
        return this.InnerItem[FieldIds.Subheading];
      }
      set
      {
        this.InnerItem[FieldIds.Subheading] = value;
      }
    }
  
    /// <summary>Gets or sets the "CSSClass" field.</summary>
    public string CSSClass 
    {
      get 
      {
        return this.InnerItem[FieldIds.CSSClass];
      }
      set
      {
        this.InnerItem[FieldIds.CSSClass] = value;
      }
    }
  
    /// <summary>Gets or sets the "PlaceholderClass" field.</summary>
    public string PlaceholderClass 
    {
      get 
      {
        return this.InnerItem[FieldIds.PlaceholderClass];
      }
      set
      {
        this.InnerItem[FieldIds.PlaceholderClass] = value;
      }
    }
  
    /// <summary>Gets or sets the "Footer Text" field.</summary>
    public string FooterText 
    {
      get 
      {
        return this.InnerItem[FieldIds.FooterText];
      }
      set
      {
        this.InnerItem[FieldIds.FooterText] = value;
      }
    }
  
    public static ParametersTemplate_SectionProperties Create(Item item) 
    {
      return new ParametersTemplate_SectionProperties(item);
    }

    public static implicit operator Item (ParametersTemplate_SectionProperties item)
    {
      if (item == null)
      {
        return null;
      }

      return item.InnerItem;
    }

    public static explicit operator ParametersTemplate_SectionProperties(Item item)
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
