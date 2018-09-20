using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Validation
{
    public static class Functions
    {
        #region Функция для правильного правописания
        public static string FirstUpper(string str)
        {
            string[] s = str.Split(' ');

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > 1)
                    s[i] = s[i].Substring(0, 1).ToUpper() + s[i].Substring(1, s[i].Length - 1).ToLower();
                else s[i] = s[i].ToUpper();
            }
            return String.Join(" ", s);
        }
        #endregion
        
        #region Функция для удаления всех пробелов из строки 
        public static string RemoveSpaces(string inputString)
        {
            inputString = inputString.Replace("  ", String.Empty);
            inputString = inputString.Trim().Replace(" ", String.Empty);

            return inputString;
        }
        #endregion

        #region Функция для проверки символов 
        public static bool valid(string str)
        {
            bool f = false;
            char[] charsArr = new char[] { '!', '@', '#', '$', '%', '^', '&', '*','\'',
                '(', ')', '_', '+', '-', '=', ':', ';','|',
                '"', '?', '/', '.', ',', '<', '>', '!','№','\\'};

            str.ToCharArray();

            for (int i = 0; i < str.Length; i++)
            {
                if (f) break;
                for (int j = 0; j < charsArr.Length; j++)
                {
                    if (f) break;
                    if (str[i] == charsArr[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Проврка зарплаты
        public static bool valids(string str)
        {
            char r = '0';

            str.ToCharArray();

            if (str[0] == r)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
