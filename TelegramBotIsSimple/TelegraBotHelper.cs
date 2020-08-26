using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotIsSimple
{
    internal class TelegraBotHelper
    {
        private const string TEXT_1 = "Один";
        private const string TEXT_2 = "Два";
        private const string TEXT_3 = "Три";
        private const string TEXT_4 = "Четыре";

        private string _token;
        Telegram.Bot.TelegramBotClient _client;

        public TelegraBotHelper(string token)
        {
            this._token = token;
        }

        internal void GetUpdates()
        {
            _client = new Telegram.Bot.TelegramBotClient(_token);
            var me = _client.GetMeAsync().Result;
            if (me != null && !string.IsNullOrEmpty(me.Username))
            {
                int offset = 0;
                while (true)
                {
                    try
                    {
                        var updates = _client.GetUpdatesAsync(offset).Result;
                        if (updates != null && updates.Count() > 0)
                        {
                            foreach (var update in updates)
                            {
                                processUpdate(update);
                                offset = update.Id + 1;
                            }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }

                    Thread.Sleep(1000);
                }
            }
        }

        private void processUpdate(Telegram.Bot.Types.Update update)
        {
            switch (update.Type)
            {
                case Telegram.Bot.Types.Enums.UpdateType.Message:
                    var text = update.Message.Text;
                    string imagePath = null;
                    switch (text)
                    {
                        case TEXT_1:
                            imagePath = Path.Combine(Environment.CurrentDirectory, "1.png");
                            using (var stream = File.OpenRead(imagePath))
                            {
                                var r = _client.SendPhotoAsync(update.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream), caption: "1", replyMarkup: GetInlineButton(1)).Result;
                            }
                            break;
                        case TEXT_2:
                            imagePath = Path.Combine(Environment.CurrentDirectory, "2.png");
                            using (var stream = File.OpenRead(imagePath))
                            {
                                var r = _client.SendPhotoAsync(update.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream), caption: "2", replyMarkup: GetInlineButton(2)).Result;
                            }
                            break;
                        case TEXT_3:
                            imagePath = Path.Combine(Environment.CurrentDirectory, "3.png");
                            using (var stream = File.OpenRead(imagePath))
                            {
                                var r = _client.SendPhotoAsync(update.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream), caption: "3", replyMarkup: GetInlineButton(3)).Result;
                            }
                            break;
                        case TEXT_4:
                            imagePath = Path.Combine(Environment.CurrentDirectory, "4.png");
                            using (var stream = File.OpenRead(imagePath))
                            {
                                var r = _client.SendPhotoAsync(update.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream), caption: "4", replyMarkup: GetInlineButton(4)).Result;
                            }
                            break;
                        default:
                            _client.SendTextMessageAsync(update.Message.Chat.Id, "Receive text :" + text, replyMarkup: GetButtons());
                            break;
                    }
                    break;
                case Telegram.Bot.Types.Enums.UpdateType.CallbackQuery:
                    switch (update.CallbackQuery.Data)
                    {
                        case "1":
                            var msg1 = _client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, $"Заказ `{update.CallbackQuery.Data}` принят", replyMarkup: GetButtons()).Result;
                            break;
                        case "2":
                            var msg2 = _client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, $"Заказ `{update.CallbackQuery.Data}` принят", replyMarkup: GetButtons()).Result;
                            break;
                        case "3":
                            var msg3 = _client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, $"Заказ `{update.CallbackQuery.Data}` принят", replyMarkup: GetButtons()).Result;
                            break;
                        case "4":
                            var msg4 = _client.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, $"Заказ `{update.CallbackQuery.Data}` принят", replyMarkup: GetButtons()).Result;
                            break;
                    }
                    break;
                default:
                    Console.WriteLine(update.Type + " Not ipmlemented!");
                    break;
            }
        }

        private IReplyMarkup GetInlineButton(int id)
        {
            return new InlineKeyboardMarkup(new InlineKeyboardButton { Text = "Заказать", CallbackData = id.ToString() });
        }

        private IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                    {
                    new List<KeyboardButton>{ new KeyboardButton {  Text = TEXT_1}, new KeyboardButton {  Text = TEXT_2},  },
                    new List<KeyboardButton>{  new KeyboardButton {  Text = TEXT_3}, new KeyboardButton {  Text = TEXT_4},  }
                    },
                ResizeKeyboard = true
            };
        }
    }
}