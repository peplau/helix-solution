
// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

#pragma warning disable 1591

namespace Sitecore.Feature.IntroText.Templates
{
  #region Designer generated code

  using System;
  using Sitecore;
  using Sitecore.Diagnostics;
  using Sitecore.Data.Items;
  using Sitecore.Data.Fields;
  using Sitecore.Data;
  
      
  /// <summary>Represents the "_IntroText" template.</summary>
  public partial class __IntroText : CustomItem
  {
    public static readonly ID TemplateID = ID.Parse("{0D57E125-3F49-49A7-97FC-22F6E4CD51DF}");

    public __IntroText(Item item) : base(item) {
    }

    public static class FieldIds {
      
      public static readonly ID Lead = ID.Parse("{A4093708-F95D-40D4-89CF-289A3823C784}");

      public static readonly ID Heading = ID.Parse("{AD0914C6-B6A3-480B-9062-6639D78C9C68}");

      public static readonly ID ButtonText = ID.Parse("{CF30E1B5-8BCF-44B0-9B35-CFE21A11811C}");

      public static readonly ID ButtonLink = ID.Parse("{7591D6A7-B239-4A9B-8A7B-AE6FCF1159B1}");

      public static readonly ID BackgroundImage = ID.Parse("{C68C7128-FF53-46FD-BB90-0470D08E48E6}");

    }
    
    /// <summary>Gets or sets the "Lead" field.</summary>
    public string Lead 
    {
      get 
      {
        return this.InnerItem[FieldIds.Lead];
      }
      set
      {
        this.InnerItem[FieldIds.Lead] = value;
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
  
    /// <summary>Gets or sets the "Button text" field.</summary>
    public string ButtonText 
    {
      get 
      {
        return this.InnerItem[FieldIds.ButtonText];
      }
      set
      {
        this.InnerItem[FieldIds.ButtonText] = value;
      }
    }
  
    /// <summary>Gets or sets the "Button link" field.</summary>
    public string ButtonLink {
      get 
      {
        return this.InnerItem[FieldIds.ButtonLink];
      }
      set 
      {
        this.InnerItem[FieldIds.ButtonLink] = value;
      }
    }
  
    /// <summary>Gets the "Background image" field.</summary>
    public ImageField BackgroundImage 
    {
      get 
      {
        return this.InnerItem.Fields[FieldIds.BackgroundImage];
      }
    }
  
    public static __IntroText Create(Item item) 
    {
      return new __IntroText(item);
    }

    public static implicit operator Item (__IntroText item)
    {
      if (item == null)
      {
        return null;
      }

      return item.InnerItem;
    }

    public static explicit operator __IntroText(Item item)
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