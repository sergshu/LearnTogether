using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBotModerator.BO
{
    static class TelegramHelper
    {
        private static TelegramBotClient _client;
        private static bool _inProgress;
        private static bool _cancel;
        private static int _offset;

        internal async static Task<bool> Start()
        {
            _cancel = false;
            try
            {
                _client = new Telegram.Bot.TelegramBotClient(Properties.Settings.Default.TelgeramToken);
                var me = await _client.GetMeAsync();
                if (me != null && !string.IsNullOrEmpty(me.Username))
                {
                    GetUpdates();

                    return true;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return false;
        }

        private async static void GetUpdates()
        {
            _inProgress = true;

            while (!_cancel)
            {
                try
                {
                    var updates = await _client.GetUpdatesAsync(_offset);
                    if (updates != null && updates.Count() > 0)
                    {
                        foreach (var u in updates)
                        {
                            await processUpdate(u);
                            _offset = u.Id + 1;
                        }
                    }

                    Thread.Sleep(1000);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            _inProgress = false;
        }

        private async static Task processUpdate(Telegram.Bot.Types.Update u)
        {
            switch (u.Type)
            {
                case Telegram.Bot.Types.Enums.UpdateType.Message:
                case Telegram.Bot.Types.Enums.UpdateType.EditedMessage:
                    var msg = u.Type == Telegram.Bot.Types.Enums.UpdateType.Message ? u.Message : u.EditedMessage;
                    if (!string.IsNullOrWhiteSpace(msg.Text))
                    {
                        var words = msg.Text.Split(" \"';:.,?/\\!(){}[]|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        foreach (var w in words)
                        {
                            if (WordsHelper.WordsList.Any(i => i.Equals(w, StringComparison.OrdinalIgnoreCase)))
                            {
                                await _client.DeleteMessageAsync(msg.Chat.Id, msg.MessageId);
                                return;
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine($"Type {u.Type} is not implemnted");
                    break;
            }
        }

        internal async static Task Stop()
        {
            _cancel = true;
            while (_inProgress)
            {
                Thread.Sleep(100);
            }
        }
    }
}
