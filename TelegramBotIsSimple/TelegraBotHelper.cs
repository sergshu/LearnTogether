using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        private const string TEXT_MUSIC = "Music";
        private const string TEXT_BACK = "Назад";
        private readonly string TEXT_AUTORS_ADELE = "Adele";
        private readonly string TEXT_AUTORS_OTHER = "Other";
        private readonly string TXT_SONG_SET_FIRE = "Set Fire to the Rain";
        private string _token;
        Telegram.Bot.TelegramBotClient _client;
        private Dictionary<long, UserState> _clientStates = new Dictionary<long, UserState>();

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
                    var state = _clientStates.ContainsKey(update.Message.Chat.Id) ? _clientStates[update.Message.Chat.Id] : null;
                    if (state != null)
                    {
                        switch (state.State)
                        {
                            case State.SearchMusic:
                                if (text.Equals(TEXT_BACK))
                                {
                                    _client.SendTextMessageAsync(update.Message.Chat.Id, "Выберите:", replyMarkup: GetButtons());
                                    _clientStates[update.Message.Chat.Id] = null;
                                }
                                else
                                {
                                    var songs = GetSongsByAuthor(author: text);

                                    if (songs?.Item2 != null && songs.Item2.Count > 0)
                                    {
                                        state.State = State.SearchSong;
                                        state.Author = text;
                                        imagePath = Path.Combine(Environment.CurrentDirectory, songs.Item1);
                                        using (var stream = File.OpenRead(imagePath))
                                        {
                                            var r = _client.SendPhotoAsync(update.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream), caption: state.Author).Result;
                                        }
                                        _client.SendTextMessageAsync(update.Message.Chat.Id, "Введите название песни:", replyMarkup: getSongsButtons(songs.Item2));
                                    }
                                    else
                                    {
                                        _client.SendTextMessageAsync(update.Message.Chat.Id, "Ничего не найдено\nВведите автора:", replyMarkup: getAuthors());
                                    }
                                }
                                break;
                            case State.SearchSong:
                                if (text.Equals(TEXT_BACK))
                                {
                                    state.State = State.SearchMusic;
                                    _client.SendTextMessageAsync(update.Message.Chat.Id, "Введите автора:", replyMarkup: getAuthors());
                                }
                                else
                                {
                                    var songPath = getSongPath(text);
                                    var songs2 = GetSongsByAuthor(author: state.Author);
                                    if (!string.IsNullOrEmpty(songPath) && File.Exists(songPath))
                                    {
                                        _client.SendTextMessageAsync(update.Message.Chat.Id, "Песня загружается...");

                                        using (var stream = File.OpenRead(songPath))
                                        {
                                            var r = _client.SendAudioAsync(update.Message.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream), replyMarkup: getSongsButtons(songs2.Item2)).Result;
                                        }
                                    }
                                    else
                                    {
                                        _client.SendTextMessageAsync(update.Message.Chat.Id, "Ничего не найдено\nВведите название песни:", replyMarkup: getSongsButtons(songs2.Item2));
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (text)
                        {
                            case TEXT_MUSIC:
                                _clientStates[update.Message.Chat.Id] = new UserState { State = State.SearchMusic };
                                _client.SendTextMessageAsync(update.Message.Chat.Id, "Введите автора:", replyMarkup: getAuthors());
                                break;
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

        private string getSongPath(string text)
        {
            //TODO: Get song path from DB
            if (text.Equals(TXT_SONG_SET_FIRE))
            {
                return Path.Combine(Environment.CurrentDirectory, "Adele-Set Fire to the Rain.mp3");
            }
            else
            {
                return null;
            }
        }

        private IReplyMarkup getSongsButtons(List<string> songs)
        {
            var Keyboard = new List<List<KeyboardButton>>();
            songs.ForEach(s => Keyboard.Add(new List<KeyboardButton> { new KeyboardButton { Text = s } }));
            Keyboard.Add(new List<KeyboardButton> { new KeyboardButton { Text = TEXT_BACK } });
            return new ReplyKeyboardMarkup
            {
                Keyboard = Keyboard,
                ResizeKeyboard = true
            };
        }

        private Tuple<string, List<string>> GetSongsByAuthor(string author)
        {
            //TODO: Get songs from DB
            if (author.Equals(TEXT_AUTORS_ADELE))
            {
                return new Tuple<string, List<string>>(Path.Combine(Environment.CurrentDirectory, "adele.png"), new List<string> { TXT_SONG_SET_FIRE });
            }

            return null;
        }

        private IReplyMarkup getAuthors()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                    {
                    new List<KeyboardButton>{ new KeyboardButton { Text = TEXT_AUTORS_ADELE }, new KeyboardButton { Text = TEXT_AUTORS_OTHER } },
                    new List<KeyboardButton> { new KeyboardButton { Text = TEXT_BACK }}
                    },
                ResizeKeyboard = true
            };
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
                    new List<KeyboardButton>{ new KeyboardButton { Text = TEXT_MUSIC }, new KeyboardButton { Text = TEXT_1 }, new KeyboardButton {  Text = TEXT_2},  },
                    new List<KeyboardButton>{  new KeyboardButton {  Text = TEXT_3}, new KeyboardButton {  Text = TEXT_4},  }
                    },
                ResizeKeyboard = true
            };
        }
    }
}