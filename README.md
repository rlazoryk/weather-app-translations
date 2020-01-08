# weather-app-translations
5. Multi-language application
- As a user I want to have an ability to manage translations for any static text shown in an application.
Flow described:
-This should be an extension to existing WeatherApp that is already done.
-New page should be added called ‘Translations’. Application should have a link leading there somewhere and it should be opened by a proper route (“{host}/{translations}”)
-On this page on a top I can select a language. Dropdown with languages as an example of UI control.
-List of languages can be limited to two – EN and UA.
-On this page I can see a list of all ‘keys’ and translations set to them. For example ‘PAGE_TITLE’: ‘Заголовок сторінки’
-I can modify text of any of keys and click ‘SAVE’ button somewhere on page.
-Data with translations page should be sent to a backend side and saved to database
-Outside of translations page on the top of application I expect to have a dropdown(or country flags per each language etc) where I can select a language
-Translations should be loaded from backend.

Acceptance criteria:
-All static text should be replaced by a proper translation
-Translations should be loaded from backend
-Languages available for users on a main page should have an equivalent on a Translations administration page thus it’s impossible to have a language without a translations

Required technical stack: .NET Core 3, WEB API, Angular 8+
Advanced level requirements:
Integrate application with MongoDB and save Translations as a single JSON file there
