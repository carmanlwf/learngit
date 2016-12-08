using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ims.Pos.BLL
{
    public class ClearString
    {
        public static string InputText(string inputString, int maxLength)
        {
            StringBuilder retVal = new StringBuilder();
            if ((inputString != null) && (inputString != String.Empty))
            {
                inputString = inputString.Trim();
                if (inputString.Length > maxLength)
                    inputString = inputString.Substring(0, maxLength);
                for (int i = 0; i < inputString.Length; i++)
                {
                    switch (inputString[i])
                    {
                        case '\'':
                            retVal.Append("");
                            break;
                        case '<':
                            retVal.Append("&lt;");
                            break;
                        case '>':
                            retVal.Append("&gt;");
                            break;
                        default:
                            retVal.Append(inputString[i]);
                            break;
                    }
                }
                retVal.Replace("'", " ");
            }
            return retVal.ToString();
        }

    }
}
