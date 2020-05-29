using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Bussiness.Concrete
{
    public class RandomPassword
    {
        public string password()
        {
            Random Rnd = new Random();
            StringBuilder StrBuild = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int ASCII = Rnd.Next(32, 127);
                char Karakter = Convert.ToChar(ASCII);
                StrBuild.Append(Karakter);
            }
            return StrBuild.ToString();
        }
    }
}
