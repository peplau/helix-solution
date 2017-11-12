using Sitecore.Data.Fields;
using Sitecore.Resources.Media;
using System;

namespace Sitecore.Basis.Extensions.Extensions
{
    public static class FieldExtensions
    {
        /// <summary>
        /// Get the ImageUrl for a given ImageField
        /// </summary>
        /// <param name="imageField"></param>
        /// <returns></returns>
        public static string ImageUrl(this ImageField imageField)
        {
            if (imageField?.MediaItem == null)
            {
                throw new ArgumentNullException(nameof(imageField));
            }

            var options = MediaUrlOptions.Empty;
            int width, height;

            if (int.TryParse(imageField.Width, out width))
            {
                options.Width = width;
            }

            if (int.TryParse(imageField.Height, out height))
            {
                options.Height = height;
            }
            return imageField.ImageUrl(options);
        }

        /// <summary>
        /// Get the ImageUrl for a given ImageField
        /// </summary>
        /// <param name="imageField"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ImageUrl(this ImageField imageField, MediaUrlOptions options)
        {
            if (imageField?.MediaItem == null)
            {
                throw new ArgumentNullException(nameof(imageField));
            }

            return options == null ? imageField.ImageUrl() : HashingUtils.ProtectAssetUrl(MediaManager.GetMediaUrl(imageField.MediaItem, options));
        }

        /// <summary>
        /// Extension to see if a checkbox field is checked
        /// </summary>
        /// <param name="checkboxField"></param>
        /// <returns></returns>
        public static bool IsChecked(this Field checkboxField)
        {
            if (checkboxField == null)
            {
                throw new ArgumentNullException(nameof(checkboxField));
            }
            return MainUtil.GetBool(checkboxField.Value, false);
        }
    }
}