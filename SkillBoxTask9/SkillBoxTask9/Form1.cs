using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using System.Threading;
using System.IO;
using Telegram.Bot.Types.InputFiles;

namespace SkillBoxTask9
{
    public partial class Form1 : Form
    {
        const string token = "5293507937:AAGyuOGI5-25ztw5_YOmFiSq0z9hqJgyUWM";
        static ITelegramBotClient bot = new TelegramBotClient(token);

        static List<string> commands;

        static string startMessage;
        static string commandsList;
        static string pathToDownloads = "..\\..\\..\\Downloads";
        static string[] directoriesForDownloading = new string[] {
            "..\\..\\..\\Downloads\\Audio",
            "..\\..\\..\\Downloads\\Docs",
            "..\\..\\..\\Downloads\\Pics",
            "..\\..\\..\\Downloads\\Texts" };
        static string ballDirectory = "..\\..\\..\\Magic ball";

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                if (message != null)
                {
                    #region Если прислали команду
                    if (update.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                    {
                        var commandText = message.Text.Split(' ').ToList<string>();
                        string command = commandText[0].ToLower();

                        // /start
                        if (command == commands[0])
                        {
                            await botClient.SendTextMessageAsync(message.Chat, startMessage);
                            return;
                        }
                        // /help
                        if (command == commands[1])
                        {
                            await botClient.SendTextMessageAsync(message.Chat, commandsList);
                            return;
                        }
                        // /files_list
                        if (command == commands[2])
                        {
                            string files = listToString(getFiles(pathToDownloads));
                            await botClient.SendTextMessageAsync(message.Chat, listToString(getFiles(pathToDownloads)));
                            return;
                        }
                        // /get_file
                        if (command == commands[3].Split(' ')[0])
                        {
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
                                                    await botClient.SendAudioAsync(message.Chat.Id, audioToSend);
                                                }
                                                break;
                                            case 1:
                                                using (var fs = System.IO.File.Open(file, FileMode.Open))
                                                {
                                                    InputOnlineFile docToSend = new InputOnlineFile(fs, file.Split("\\").Last());
                                                    await botClient.SendDocumentAsync(message.Chat.Id, docToSend);
                                                }
                                                break;
                                            case 2:
                                                using (var fs = System.IO.File.Open(file, FileMode.Open))
                                                {
                                                    InputOnlineFile picToSend = new InputOnlineFile(fs, file.Split("\\").Last());
                                                    await botClient.SendPhotoAsync(message.Chat.Id, picToSend);
                                                }
                                                break;
                                            case 3:
                                                using (var fs = System.IO.File.Open(file, FileMode.Open))
                                                {
                                                    InputOnlineFile textToSend = new InputOnlineFile(fs, file.Split("\\").Last());
                                                    await botClient.SendDocumentAsync(message.Chat.Id, textToSend);
                                                }
                                                break;
                                            default:
                                                return;
                                        }
                                        return;
                                    }

                                }
                            }
                            await botClient.SendTextMessageAsync(message.Chat, "Указанного файла не существует. Укажите другой.");
                            return;
                        }
                        // /ask
                        if (command == commands[4].Split(' ')[0])
                        {
                            string[] answers = new string[] {
                            "Ваш вопрос потребовал тщательного обдумывания, но ответ все же был найден:",
                            "Однажды этот вопрос ученик задал Будде, на что тот ответил:",
                            "Кручу-верчу, обма... предсказать хочу:",
                            "Невероятно, но факт, что ответом будет:"};

                            Random rand = new Random();
                            await botClient.SendTextMessageAsync(message.From.Id, answers[rand.Next(0, answers.Length)]);
                            var files = Directory.GetFiles(ballDirectory);
                            using (var fs = System.IO.File.Open($"{files[rand.Next(0, files.Length)]}", FileMode.Open))
                            {
                                InputOnlineFile picToSend = new InputOnlineFile(fs, "Answer");
                                await botClient.SendPhotoAsync(message.Chat.Id, picToSend);
                            }
                            return;
                        }
                    }
                    #endregion

                    #region Если прислали картинку
                    if (message.Type == Telegram.Bot.Types.Enums.MessageType.Photo)
                    {
                        var file = await bot.GetFileAsync(message.Photo[message.Photo.Length - 1].FileId);
                        using (var saveImageStream = new FileStream(directoriesForDownloading[2] + "\\" + file.FilePath.Split('/').Last(), FileMode.CreateNew))
                        {
                            await bot.DownloadFileAsync(file.FilePath, saveImageStream);
                        }
                        await bot.SendTextMessageAsync(message.Chat, "Image save");
                        return;
                    }
                    #endregion

                    #region Если прислали аудиозапись
                    if (message.Type == Telegram.Bot.Types.Enums.MessageType.Voice)
                    {
                        var file = await bot.GetFileAsync(message.Voice.FileId);
                        using (var saveImageStream = new FileStream(directoriesForDownloading[0] + "\\" + file.FilePath.Split('/').Last(), FileMode.CreateNew))
                        {
                            await bot.DownloadFileAsync(file.FilePath, saveImageStream);
                        }
                        await bot.SendTextMessageAsync(message.Chat, "Voice save");
                        return;
                    }
                    #endregion

                    #region Если прислали документ
                    if (message.Type == Telegram.Bot.Types.Enums.MessageType.Document)
                    {
                        var file = await bot.GetFileAsync(message.Document.FileId);
                        using (var saveImageStream = new FileStream(directoriesForDownloading[1] + "\\" + file.FilePath.Split('/').Last(), FileMode.CreateNew))
                        {
                            await bot.DownloadFileAsync(file.FilePath, saveImageStream);
                        }
                        await bot.SendTextMessageAsync(message.Chat, "Document save");
                        return;
                    }
                    #endregion

                    // Все остальные случаи
                    await botClient.SendTextMessageAsync(message.Chat, "Я пока не очень умный, поэтому не понимаю Вас. Отправьте /help для получения списка доступных команд.");
                }
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        public Form1()
        {
            InitializeComponent();

            commands = new List<string>() { "/start", "/help", "/flist", "/fget [имя файла]", "/ask [ваш вопрос]" };
            commandsList = "Список доступных команд:\n";
            for (int i = 0; i < commands.Count; i++)
                commandsList += $"{commands[i]}\n";
            startMessage = $"Готов работать день и ночь! Список доступных команд:\n{commandsList}";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ConsoleTB.Text += $"Запущен бот {bot.GetMeAsync().Result.FirstName}\n";

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var recieverOptions = new ReceiverOptions();
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                recieverOptions,
                cancellationToken);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsoleTB.Text = listToString(getFiles(pathToDownloads));
        }

        private static List<string> getFiles(string path)
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

        private static string listToString(List<string> list)
        {
            string to_return = "";
            foreach (var item in list)
            {
                to_return += $"{item}\n";
            }
            return to_return;
        }
    }
}

