using System.Collections.Generic;
using TranslationsApi.Core.Abstractions;
using System.Linq;
namespace TranslationsApi.DAL
{
    public static class SeedData
    {
        public static void Initialize(IUnitOfWork unitOfWork)
        {
            if(!unitOfWork.LanguageRepository.GetAll().Any())
            {
                unitOfWork.LanguageRepository.Add(new Core.Models.Language
                {
                    LangCode = "eng",
                    Keys = new List<Core.Models.Key>
                    {
                        new Core.Models.Key { KeyName = "PAGE_TITLE", KeyValue = "Weather App"},
                        new Core.Models.Key { KeyName = "FORM_TITLE", KeyValue = "Enter the City:"},
                        new Core.Models.Key { KeyName = "BACK_BTN", KeyValue = "Back"},
                        new Core.Models.Key { KeyName = "SEARCH_BTN", KeyValue = "Show Weather"},
                        new Core.Models.Key { KeyName = "GENERAL", KeyValue = "Today is "},
                        new Core.Models.Key { KeyName = "PRESSURE", KeyValue = "Pressure: "},
                        new Core.Models.Key { KeyName = "HUMIDITY", KeyValue = "Humidity: "},
                        new Core.Models.Key { KeyName = "CLOUDS", KeyValue = "Clouds: "},
                        new Core.Models.Key { KeyName = "LOADING", KeyValue = "Loading..."},
                        new Core.Models.Key { KeyName = "OKAY", KeyValue = "Okay"},
                        new Core.Models.Key { KeyName = "CLEAR", KeyValue = "Clear"},
                        new Core.Models.Key { KeyName = "ERROR", KeyValue = "An error occured!"},
                        new Core.Models.Key { KeyName = "WELCOME", KeyValue = "Welcome to weather app!"},
                        new Core.Models.Key { KeyName = "START", KeyValue = "Press here to start"},
                        new Core.Models.Key { KeyName = "CHANGE_TRANSLATION_BTN", KeyValue = "Change translations"},
                        new Core.Models.Key { KeyName = "NO_CITY", KeyValue = "There is no such city!"},
                        new Core.Models.Key { KeyName = "INVALID_DATA", KeyValue = "Please, enter a valid city name"}
                    }
                });
                unitOfWork.LanguageRepository.Add(new Core.Models.Language
                {
                    LangCode = "ukr",
                    Keys = new List<Core.Models.Key>
                    {
                        new Core.Models.Key { KeyName = "PAGE_TITLE", KeyValue = "Погода"},
                        new Core.Models.Key { KeyName = "FORM_TITLE", KeyValue = "Введіть місто:"},
                        new Core.Models.Key { KeyName = "BACK_BTN", KeyValue = "Назад"},
                        new Core.Models.Key { KeyName = "SEARCH_BTN", KeyValue = "Показати погоду"},
                        new Core.Models.Key { KeyName = "GENERAL", KeyValue = "Сьогодні "},
                        new Core.Models.Key { KeyName = "PRESSURE", KeyValue = "Тиск: "},
                        new Core.Models.Key { KeyName = "HUMIDITY", KeyValue = "Вологість: "},
                        new Core.Models.Key { KeyName = "CLOUDS", KeyValue = "Хмарність: "},
                        new Core.Models.Key { KeyName = "LOADING", KeyValue = "Завантаження..."},
                        new Core.Models.Key { KeyName = "OKAY", KeyValue = "Гаразд"},
                        new Core.Models.Key { KeyName = "CLEAR", KeyValue = "Очистити"},
                        new Core.Models.Key { KeyName = "ERROR", KeyValue = "Виникла помилка!"},
                        new Core.Models.Key { KeyName = "WELCOME", KeyValue = "Вітаємо в погодному помічнику!"},
                        new Core.Models.Key { KeyName = "START", KeyValue = "Нажміть тут щоб почати"},
                        new Core.Models.Key { KeyName = "CHANGE_TRANSLATION_BTN", KeyValue = "Змінити переклад"},
                        new Core.Models.Key { KeyName = "NO_CITY", KeyValue = "Такого міста не існує!"},
                        new Core.Models.Key { KeyName = "INVALID_DATA", KeyValue = "Будь ласка, введіть правильну назву міста"}
                    }
                });
                unitOfWork.SaveChanges();
            }
        }
    }
}
