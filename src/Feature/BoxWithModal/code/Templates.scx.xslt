﻿<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
                xmlns:sc="http://www.sitecore.net/sc" 
                xmlns:g="http://www.sitecore.net/codegeneration" 
                exclude-result-prefixes="sc">
<xsl:output method="text" indent="no" encoding="UTF-8" />
<xsl:template match="*">
// ------------------------------------------------------------------------------
// &lt;auto-generated&gt;
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// &lt;/auto-generated&gt;
// ------------------------------------------------------------------------------

#pragma warning disable 1591

namespace Sitecore.Feature.BoxWithModal.Templates
{
  #region Designer generated code

  using System;
  using Sitecore;
  using Sitecore.Diagnostics;
  using Sitecore.Data.Items;
  using Sitecore.Data.Fields;
  using Sitecore.Data;
  
  <xsl:for-each select="/CodeGeneration/shape/template">    
  /// &lt;summary&gt;Represents the "<xsl:value-of select="@templatename"/>" template.&lt;/summary&gt;
  public partial class <xsl:value-of select="@classname"/> : CustomItem
  {
    public static readonly ID TemplateID = ID.Parse("<xsl:value-of select="@templateid"/>");

    public <xsl:value-of select="@classname"/>(Item item) : base(item) {
    }

    public static class FieldIds {
      <xsl:apply-templates select="section/field" mode="FieldIds" />
    }
    <xsl:apply-templates select="section/field" mode="properties" />
    public static <xsl:value-of select="@classname"/> Create(Item item) 
    {
      return new <xsl:value-of select="@classname"/>(item);
    }

    public static implicit operator Item (<xsl:value-of select="@classname"/> item)
    {
      if (item == null)
      {
        return null;
      }

      return item.InnerItem;
    }

    public static explicit operator <xsl:value-of select="@classname"/>(Item item)
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
  </xsl:for-each>
  #endregion
}

#pragma warning restore 1591
</xsl:template>
  
<xsl:template match="field" mode="FieldIds">
      public static readonly ID <xsl:value-of select="@propertyname"/> = ID.Parse("<xsl:value-of select="@id"/>");
</xsl:template>
  
<xsl:template match="field" mode="properties">
  <xsl:choose>
  <xsl:when test="contains('text,Multi-Line Text,Single-Line Text,Rich Text,Droplist', @type)">
    /// &lt;summary&gt;Gets or sets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public string <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return this.InnerItem[FieldIds.<xsl:value-of select="@propertyname" />];
      }
      set
      {
        this.InnerItem[FieldIds.<xsl:value-of select="@propertyname"/>] = value;
      }
    }
  </xsl:when>
  <xsl:when test="contains('integer,Integer', @type)">
    /// &lt;summary&gt;Gets or sets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public int <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return MainUtil.GetInt(this.InnerItem[FieldIds.<xsl:value-of select="@propertyname" />], 0);
      }
      set
      {
        this.InnerItem[FieldIds.<xsl:value-of select="@propertyname"/>] = value.ToString();
      }
    }
  </xsl:when>
  <xsl:when test="contains('checkbox,Checkbox', @type)">
    /// &lt;summary&gt;Gets or sets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public bool <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return MainUtil.GetBool(this.InnerItem[FieldIds.<xsl:value-of select="@propertyname" />], false);
      }
      set 
      {
        this.InnerItem[FieldIds.<xsl:value-of select="@propertyname"/>] = value ? "1" : string.Empty;
      }
    }
  </xsl:when>
  <xsl:when test="@type = 'Datetime'">
    /// &lt;summary&gt;Gets or sets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public DateTime <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return DateUtil.IsoDateToDateTime(this.InnerItem[FieldIds.<xsl:value-of select="@propertyname" />]);
      }
      set 
      {
        this.InnerItem[FieldIds.<xsl:value-of select="@propertyname"/>] = DateUtil.ToIsoDate(value);
      }
    }
  </xsl:when>
  <xsl:when test="contains('Droptree,reference,tree', @type)">
    /// &lt;summary&gt;Gets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public ReferenceField <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return this.InnerItem.Fields[FieldIds.<xsl:value-of select="@propertyname"/>];
      }
    }
  </xsl:when>
  <xsl:when test="contains('Droplink,lookup', @type)">
    /// &lt;summary&gt;Gets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public LookupField <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return this.InnerItem.Fields[FieldIds.<xsl:value-of select="@propertyname"/>];
      }
    }
  </xsl:when>
  <xsl:when test="@type = 'Thumbnail'">
    /// &lt;summary&gt;Gets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public ThumbnailField <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return this.InnerItem.Fields[FieldIds.<xsl:value-of select="@propertyname"/>];
      }
    }
  </xsl:when>
  <xsl:when test="contains('tree list,Checklist,Multilist,Treelist,TreelistEx', @type)">
    /// &lt;summary&gt;Gets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public MultilistField <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return this.InnerItem.Fields[FieldIds.<xsl:value-of select="@propertyname"/>];
      }
    }
  </xsl:when>
  <xsl:when test="contains('Image', @type)">
    /// &lt;summary&gt;Gets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public ImageField <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return this.InnerItem.Fields[FieldIds.<xsl:value-of select="@propertyname"/>];
      }
    }
  </xsl:when>
  <xsl:when test="contains('Internal Link', @type)">
    /// &lt;summary&gt;Gets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public InternalLinkField <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return this.InnerItem.Fields[FieldIds.<xsl:value-of select="@propertyname"/>];
      }
    }
  </xsl:when>
  <xsl:when test="contains('Datasource', @type)">
    /// &lt;summary&gt;Gets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public DatasourceField <xsl:value-of select="@propertyname"/> 
    {
      get 
      {
        return this.InnerItem.Fields[FieldIds.<xsl:value-of select="@propertyname"/>];
      }
    }
  </xsl:when>
  <xsl:otherwise>
    /// &lt;summary&gt;Gets or sets the "<xsl:value-of select="@name"/>" field.&lt;/summary&gt;
    public string <xsl:value-of select="@propertyname"/> {
      get 
      {
        return this.InnerItem[FieldIds.<xsl:value-of select="@propertyname" />];
      }
      set 
      {
        this.InnerItem[FieldIds.<xsl:value-of select="@propertyname"/>] = value;
      }
    }
  </xsl:otherwise>
  </xsl:choose>
</xsl:template>
  
</xsl:stylesheet>