using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrenteArpents.Helpers
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        private static Assembly assembly;

        static ImageResourceExtension()
        {
            if (assembly == null)
            {
                assembly = typeof(ImageResourceExtension).GetTypeInfo().Assembly;
            }
        }

        private Dictionary<string, ImageSource> imageSourceCache = new Dictionary<string, ImageSource>();

        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Source))
            {
                return null;
            }

            if (imageSourceCache.ContainsKey(Source))
            {
                return imageSourceCache[Source];
            }

            var imageSource = ImageSource.FromResource(Source, assembly);

            imageSourceCache.Add(Source, imageSource);

            return imageSource;
        }
    }
}
