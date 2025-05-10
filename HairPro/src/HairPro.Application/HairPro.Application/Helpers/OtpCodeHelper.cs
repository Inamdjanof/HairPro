using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.Application.Helpers
{
    public static class OtpCodeHelper
    {

        public static string GenerateOptCode(int length = 6)
        {
            char[] randomCharacterList = new char[length];
            string character = "0123456789";

            for(int i = 0; i < length; i++)
            {
                int randomCharacterIndex = Random.Shared.Next(0, character.Length);
                randomCharacterList[i] = character[randomCharacterIndex];
            }

            return new string(randomCharacterList); 
        }





    }
}
