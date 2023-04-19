using Features.Interfaces;

namespace Main
{
    public class App
    {
        private readonly ILanguageService _languageService;
        private readonly IUserService _userService;

        public App(ILanguageService languageService, IUserService userService)
        {
            _languageService = languageService;
            _userService = userService;
        }

        public void Run(string[] args)
        {
            var lang = "en";

            var message = _languageService.Greeting(lang);

            Console.WriteLine(message);
            Console.WriteLine();

            _userService.GetAllUser();

            var id = Guid.Parse("6e737597-f3cd-4069-b3ff-5f937d74c896");
            var result = _userService.GetUserById(id);
            Console.WriteLine(result);
        }

    }
}
