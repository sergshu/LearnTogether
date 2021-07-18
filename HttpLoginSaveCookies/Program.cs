using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLoginSaveCookies
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new Client();
            client.LoadCookies();
            if (await client.GetLoginPage() && await client.LoginValidationtrack())
            {
                if (await client.Login())
                {
                    client.SaveCookies();
                }
            }
        }
    }
}
