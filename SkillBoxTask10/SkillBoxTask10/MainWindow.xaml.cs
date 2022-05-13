using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SkillBoxTask10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        #region Инициализация бота
        const string token = "5293507937:AAGyuOGI5-25ztw5_YOmFiSq0z9hqJgyUWM";
        static ITelegramBotClient bot = new TelegramBotClient(token);
        #endregion

        #region Пути к папкам и начальные сообщения
        static string pathToDownloads = "..\\..\\..\\Downloads";
        static string[] directoriesForDownloading = new string[] {
            "..\\..\\..\\Downloads\\Audio",
            "..\\..\\..\\Downloads\\Docs",
            "..\\..\\..\\Downloads\\Pics",
            "..\\..\\..\\Downloads\\Texts" };
        static string ballDirectory = "..\\..\\..\\Magic ball";
        static string[] commands = { "/start", "/help", "/flist", "/fget [имя файла]", "/ask [ваш вопрос]", "/cities" };
        static string startMessage = "";
        static string commandsList = "";

        static string userLastMessageString;
        static Message userLastMessage;
        static List<Message> usersMessages = new List<Message>();

        static bool goroda = false;
        static List<string>[] Cities = new List<string>[33];
        static char lastLetter;
        static string alphabetChar = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        static Dictionary<char, int> alphabetDict;
        static Random rand = new Random();

        static CitiesTheGame citiesGame = new CitiesTheGame();
        #endregion

        #region Методы бота
        /// <summary>
        /// Основная функция бота, обрабатывающая события
        /// </summary>
        /// <param name="botClient"> Бот, который обрабатывает события </param>
        /// <param name="update"> Событие </param>
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                #region Сохраняем сообщения в .json
                usersMessages.Add(update.Message);
                string json = JsonSerializer.Serialize(usersMessages);
                using (var sw = new StreamWriter($"..\\..\\..\\ProgrammFiles\\Сообщения за {DateTime.Now.ToString("g").Replace(':', '-')}.json"))
                {
                    sw.Write(json);
                }
                #endregion

                #region Обработка присланного сообщения
                if (update.Message != null)
                {
                    userLastMessage = update.Message;

                    #region Если прислали команду
                    if (update.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                    {
                        userLastMessageString = userLastMessage.Text;

                        var commandText = userLastMessage.Text.Split(' ').ToList<string>();
                        string command = commandText[0].ToLower();

                        // Команда /start - 0
                        if (command == commands[0])
                        {
                            goroda = false;
                            await botClient.SendTextMessageAsync(userLastMessage.Chat, startMessage);
                            return;
                        }
                        // Команда /help - 1
                        if (command == commands[1])
                        {
                            goroda = false;
                            await botClient.SendTextMessageAsync(userLastMessage.Chat, commandsList);
                            return;
                        }
                        // Команда /files_list - 2
                        if (command == commands[2])
                        {
                            goroda = false;
                            string files = ListToString(DownloadedFiles(pathToDownloads));
                            await botClient.SendTextMessageAsync(userLastMessage.Chat, ListToString(DownloadedFiles(pathToDownloads)));
                            return;
                        }
                        // Команда /get_file - 3
                        if (command == commands[3].Split(' ')[0])
                        {
                            goroda = false;
                            string fileName = "";
                            for (int i = 1; i < commandText.Count; i++)
                            {
                                if (i != commandText.Count - 1)
                                    fileName += commandText[i] + " ";
                                else
                                    fileName += commandText[i];
                            }
                            string fileNameOnly = fileName.Split('.')[0];

                            var dirList = Directory.GetDirectories(pathToDownloads);
                            for (int i = 0; i < dirList.Length; i++)
                            {
                                var files = Directory.GetFiles(dirList[i]);
                                foreach (var file in files)
                                {
                                    if (file.ToLower().Contains(fileNameOnly.ToLower()))
                                    {
                                        switch (i)
                                        {
                                            case 0:
                                                using (var fs = System.IO.File.Open(file, FileMode.Open))
                                                {
                                                    InputOnlineFile audioToSend = new InputOnlineFile(fs, file.Split("\\").Last());
                                                    await botClient.SendAudioAsync(userLastMessage.Chat.Id, audioToSend);
                                                }
                                                break;
                                            case 1:
                                                using (var fs = System.IO.File.Open(file, FileMode.Open))
                                                {
                                                    InputOnlineFile docToSend = new InputOnlineFile(fs, file.Split("\\").Last());
                                                    await botClient.SendDocumentAsync(userLastMessage.Chat.Id, docToSend);
                                                }
                                                break;
                                            case 2:
                                                using (var fs = System.IO.File.Open(file, FileMode.Open))
                                                {
                                                    InputOnlineFile picToSend = new InputOnlineFile(fs, file.Split("\\").Last());
                                                    await botClient.SendPhotoAsync(userLastMessage.Chat.Id, picToSend);
                                                }
                                                break;
                                            case 3:
                                                using (var fs = System.IO.File.Open(file, FileMode.Open))
                                                {
                                                    InputOnlineFile textToSend = new InputOnlineFile(fs, file.Split("\\").Last());
                                                    await botClient.SendDocumentAsync(userLastMessage.Chat.Id, textToSend);
                                                }
                                                break;
                                            default:
                                                return;
                                        }
                                        return;
                                    }

                                }
                            }
                            await botClient.SendTextMessageAsync(userLastMessage.Chat, "Указанного файла не существует. Укажите другой.");
                            return;
                        }
                        // Команда /ask - 4
                        if (command == commands[4].Split(' ')[0])
                        {
                            goroda = false;
                            string[] answers = new string[] {
                            "Ваш вопрос потребовал тщательного обдумывания, но ответ все же был найден:",
                            "Однажды этот вопрос ученик задал Будде, на что тот ответил:",
                            "Кручу-верчу, обма... предсказать хочу:",
                            "Невероятно, но факт, что ответом будет:",
                            "К счастью:",
                            "Посмотрим что скажут картинки:",
                            "Моя бот-душа считает, что ответом будет:",
                            "Получается, что:",
                            "К сожалению:"};

                            await botClient.SendTextMessageAsync(userLastMessage.From.Id, answers[rand.Next(0, answers.Length)]);
                            var files = Directory.GetFiles(ballDirectory);
                            using (var fs = System.IO.File.Open($"{files[rand.Next(0, files.Length)]}", FileMode.Open))
                            {
                                InputOnlineFile picToSend = new InputOnlineFile(fs, "Answer");
                                await botClient.SendPhotoAsync(userLastMessage.Chat.Id, picToSend);
                            }
                            return;
                        }
                        // Команда /города - 5
                        if (command == commands[5])
                        {
                            goroda = true;
                            await botClient.SendTextMessageAsync(userLastMessage.Chat,
                                $"Игра в города начинается, я первый (на правах глупого бота). Мой город: {citiesGame.FindRandomCity()}, вам на {citiesGame.lastLetterU}");
                            return;
                        }
                    }
                    #endregion

                    #region Если прислали картинку
                    if (userLastMessage.Type == Telegram.Bot.Types.Enums.MessageType.Photo)
                    {
                        var file = await bot.GetFileAsync(userLastMessage.Photo[userLastMessage.Photo.Length - 1].FileId);
                        using (var saveImageStream = new FileStream(directoriesForDownloading[2] + "\\" + file.FilePath.Split('/').Last(), FileMode.CreateNew))
                        {
                            await bot.DownloadFileAsync(file.FilePath, saveImageStream);
                        }
                        await bot.SendTextMessageAsync(userLastMessage.Chat, "Image save");
                        return;
                    }
                    #endregion

                    #region Если прислали аудиозапись
                    if (userLastMessage.Type == Telegram.Bot.Types.Enums.MessageType.Voice)
                    {
                        var file = await bot.GetFileAsync(userLastMessage.Voice.FileId);
                        using (var saveImageStream = new FileStream(directoriesForDownloading[0] + "\\" + file.FilePath.Split('/').Last(), FileMode.CreateNew))
                        {
                            await bot.DownloadFileAsync(file.FilePath, saveImageStream);
                        }
                        await bot.SendTextMessageAsync(userLastMessage.Chat, "Voice save");
                        return;
                    }
                    #endregion

                    #region Если прислали документ
                    if (userLastMessage.Type == Telegram.Bot.Types.Enums.MessageType.Document)
                    {
                        var file = await bot.GetFileAsync(userLastMessage.Document.FileId);
                        using (var saveImageStream = new FileStream(directoriesForDownloading[1] + "\\" + file.FilePath.Split('/').Last(), FileMode.CreateNew))
                        {
                            await bot.DownloadFileAsync(file.FilePath, saveImageStream);
                        }
                        await bot.SendTextMessageAsync(userLastMessage.Chat, "Document save");
                        return;
                    }
                    #endregion

                    #region Прочие случаи
                    // Неклассифицируемый текст
                    if (!goroda)
                    {
                        await botClient.SendTextMessageAsync(userLastMessage.Chat, "Я пока не очень умный, поэтому не понимаю Вас. Отправьте /help для получения списка доступных команд.");
                    }
                    #region Играем в города
                    else
                    {
                        string yourCityL = userLastMessage.Text.ToLower();
                        string yourCityU = yourCityL.Substring(0, 1).ToUpper() + yourCityL.Substring(1);

                        // Проверяем город на первую букву
                        if (!citiesGame.FirstCheck(yourCityL))
                        {
                            await botClient.SendTextMessageAsync(userLastMessage.Chat, $"Неправильная буква, вам на {lastLetter.ToString().ToUpper()}");
                        }
                        else
                        {
                            // Проверяем город на нахождение в базе данных
                            if (citiesGame.CityInDatabase(yourCityL))
                            {
                                await botClient.SendTextMessageAsync(userLastMessage.Chat,
                                    $"Принято! Ваш город {yourCityU}, значит мне на {citiesGame.lastLetterU}. " +
                                    $"Дайте подумать...");

                                if (citiesGame.noCities)
                                {
                                    await botClient.SendTextMessageAsync(userLastMessage.Chat,
                                        $"Я проиграл. Больше не знаю городов на букву {citiesGame.lastLetterU}");
                                    goroda = false;
                                    return;
                                }

                                await botClient.SendTextMessageAsync(userLastMessage.Chat,
                                    $"Я загадываю город {citiesGame.FindCity()}, вам на {citiesGame.lastLetterU}");
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(userLastMessage.Chat,
                                    $"Такого города или нет, или я его не знаю. Попробуйте назвать другой город на {citiesGame.lastLetterU}");
                            }
                        }
                    }
                    #endregion
                    #endregion
                }
                #endregion
            }
        }

        /// <summary>
        /// Обработка ошибок
        /// </summary>
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
        #endregion

        #region Методы окна
        public MainWindow()
        {
            InitializeComponent();

            commandsList = "Список доступных команд:\n";
            for (int i = 0; i < commands.Length; i++)
                commandsList += $"{commands[i]}\n";
            startMessage = $"Готов работать день и ночь!\n{commandsList}";
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            #region Запуск бота 
            TextRange tr = new TextRange(ConsoleOut.Document.ContentEnd, ConsoleOut.Document.ContentEnd);
            tr.Text =
            $"Запущен бот {bot.GetMeAsync().Result.FirstName}\n";
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var recieverOptions = new ReceiverOptions();
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                recieverOptions,
                cancellationToken);
            #endregion

            #region Считывание сообщений, которые приходят боту
            while (true)
            {
                await Task.Run(() =>
                {
                    while (String.IsNullOrEmpty(userLastMessageString))
                    {
                        // Типа ждем
                        Thread.Sleep(10);
                    }
                });
                string chatName = userLastMessage.Chat.Username;
                string userName = userLastMessage.From.Username;
                string dateOfMessage = userLastMessage.Date.ToString("G");
                tr = new TextRange(ConsoleOut.Document.ContentEnd, ConsoleOut.Document.ContentEnd);
                tr.Text =
                    $"\n" +
                    $"Получено сообщение: '{userLastMessageString}'.\n" +
                    $"Отправитель: {userName}. " +
                    $"Дата: {dateOfMessage}. ";
                tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
                userLastMessageString = String.Empty;

                MessagesList.Items.Add($"Сообщение #{usersMessages.Count}");
            }
            #endregion
        }

        private static List<string> DownloadedFiles(string path)
        {
            var dirList = Directory.GetDirectories(path);
            foreach (var dirPath in directoriesForDownloading)
            {
                if (!dirList.Contains(dirPath))
                    Directory.CreateDirectory(dirPath);
            }

            List<string> files = new List<string>();
            foreach (var file in Directory.GetFiles(path))
            {
                files.Add(file.Split("..\\").Last());
            }
            foreach (var dir in Directory.GetDirectories(path))
            {
                foreach (var file in Directory.GetFiles(dir))
                {
                    files.Add(file.Split("..\\").Last());
                }
            }
            return files;
        }

        private static string ListToString(List<string> list)
        {
            string to_return = "";
            foreach (var item in list)
            {
                to_return += $"{item}\n";
            }
            return to_return;
        }

        private void MessagesList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var message = usersMessages[int.Parse(MessagesList.SelectedItem.ToString().Split('#')[1]) - 1];
            string chatName = message.Chat.Username;
            string userName = message.From.Username;
            string dateOfMessage = message.Date.ToString("G");
            TextRange tr = new TextRange(ShowSelected.Document.ContentEnd, ShowSelected.Document.ContentEnd);
            tr = new TextRange(ShowSelected.Document.ContentStart, ShowSelected.Document.ContentEnd);
            tr.Text =
                $"Получено сообщение: '{message.Text}'.\n" +
                $"Отправитель: {userName}. " +
                $"Дата: {dateOfMessage}. ";
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
            userLastMessageString = String.Empty;
        }

        private async void SendResponse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var message = usersMessages[int.Parse(MessagesList.SelectedItem.ToString().Split('#')[1]) - 1];
                TextRange textRange = new TextRange(ResponseText.Document.ContentStart, ResponseText.Document.ContentEnd);
                await bot.SendTextMessageAsync(message.Chat, textRange.Text);
            }
            catch
            {
                TextRange textRange = new TextRange(ResponseText.Document.ContentStart, ResponseText.Document.ContentEnd);
                textRange.Text = "Вы не выбрали контакт, которому хотите отправить сообщение.";
            }
        }
        #endregion
    }
}
