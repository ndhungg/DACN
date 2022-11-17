using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUngTuyenViecLamIT
{
    public class Untils
    {
        public static bool IsValidToExtension(string fileName)
        {
            Boolean isValid = false;
            String[] fileExtension = { ".jpg", ".png", ".jepg" };
            for (int i = 0; i <= fileExtension.Length - 1; i++)
            {
                if (fileName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }

        public static bool IsValidToExtensionResume(string fileName)
        {
            Boolean isValid = false;
            String[] fileExtension = { ".doc", ".docx", ".pdf" };
            for (int i = 0; i <= fileExtension.Length - 1; i++)
            {
                if (fileName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
    }
}