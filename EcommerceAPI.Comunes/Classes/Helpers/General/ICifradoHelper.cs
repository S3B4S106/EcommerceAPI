using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAPI.Comunes.Classes.Helpers.General
{
    public interface ICifradoHelper
    {
        public string EncryptString(string plainText);
        public string DecryptString(string cipherText);
    }
}
