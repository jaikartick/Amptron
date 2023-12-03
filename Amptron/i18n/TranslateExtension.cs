using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Amptron.i18n
{
    [ContentProperty(nameof(Text))]
    public class TranslateExtension : IMarkupExtension
    {
        private const string ResourceId = "Amptron.Resources.Raw.AppResources";
        private static readonly Lazy<ResourceManager> resmgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var serializedCulture = "en";

            try
            {
                var ci = new CultureInfo(serializedCulture);
                var translation = resmgr.Value.GetString(Text, ci).Replace("\\n", Environment.NewLine);

                if (translation == null)
                {
#if DEBUG
                    throw new ArgumentException($"Key '{Text}' was not found in resources '{ResourceId}' for culture '{ci.Name}'.", nameof(Text));
#else
                translation = Text; // returns the key, which GETS DISPLAYED TO THE USER
#endif
                }
                return translation;
            }
            catch (Exception ex)
            {
                return Text;
            }
        }
    }
}

