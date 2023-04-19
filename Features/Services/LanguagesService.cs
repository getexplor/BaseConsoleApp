using Features.Interfaces;
using Features.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Features.Services
{
    public class LanguagesService : ILanguageService
    {
        private readonly ILogger _log;

        public LanguagesService(ILogger<LanguagesService> log)
        {
            _log = log;
        }

        public string Greeting(string language)
        {
            string query = LookUpLanguage("Greeting", language);

            return query;
        }

        private string LookUpLanguage(string key, string language)
        {
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                List<Languages>? languages = JsonSerializer.Deserialize<List<Languages>>
                (
                    File.ReadAllText("MockData/Languages.json"), options
                );

                var data = languages.Where(x => x.Language == language).FirstOrDefault();

                if (data == null)
                {
                    throw new NullReferenceException("language is not found !");
                }

                return data.Translations[key];

            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                throw;
            }
        }
    }
}
