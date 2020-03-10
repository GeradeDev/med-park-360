using Markdig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedPark.EmailTemplates.Service
{
    public class EmailTemplateingService : IEmailTemplateingService
    {
        public async Task<string> LoadTemplate(string name)
        {
            string markupHtml = String.Empty;

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{Assembly.GetExecutingAssembly().GetName().Name}.{name}"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    markupHtml = reader.ReadToEnd();
                }
            }

            return Markdown.ToHtml(markupHtml);
        }
    }
}
