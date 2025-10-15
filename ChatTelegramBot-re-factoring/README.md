# ChatTelegramBot-re-factored

---

- Simple Project - https://github.com/russianowner/ChatTelegramBot-simple

---

- Телеграмм бот который общается с пользователем и может выполнять различные задачи, такие как предоставление информации, ответы на вопросы и помощь в выполнении задач или просто общение.
- Используем только Telegram.Bot.

---

- Telegram bot that communicates with the user and can perform various tasks, such as providing information, answering questions and helping with tasks, or just communicating.
- We only use Telegram.Bot.

---

# Что в этом боте?

- Он отвечает на любые текстовые сообщения пользователя
- Использует Together API для генерации ответов
- Хорошо парсит, ибо есть обработка битых JSON

---

# What's in this bot?

- It responds to any text messages of the user
- Uses the Together API to generate responses
- It parses well because there is a processing of broken JSON

---

## NugetPacket
- dotnet add package Telegram.Bot
- dotnet add package Microsoft.Extensions.Configuration
- dotnet add package Microsoft.Extensions.Configuration.Json

---

# Как пользоваться ботом?

- Копируем репозиторий
- Открываем файл appsettings.json
- Вписываем в "BotToken" - токен от нашего телеграмм бота
- Вписываем в "ApiKey" - токен от Together API (https://api.together.ai)
- Также сразу в файле можем изменить модель нейронной сети, температуру и макс. количество слов в ответе
- После как поменяли запускаем проект и пишем боту в телеграмме /start
- Пользуемся ботом

---

# How to use the bot?

- Copying the repository
- Open the appsettings file.json
- We enter it in the "BotToken" - a token from our telegram bot
- Enter the "ApiKey" token from the Together API (https://api.together.ai )
- We can also immediately change the neural network model, temperature, and the maximum number of words in the response in the file.
- After the change, we launch the project and write to the bot in telegram / start
- We use the bot
---
