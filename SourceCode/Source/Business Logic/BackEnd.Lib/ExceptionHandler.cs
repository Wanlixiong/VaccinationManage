using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Lib
{
    public static class ExceptionHandler
    {
        public static void DealWithException(Exception ex)
        {
            switch (ex.GetType().FullName)
            {
                case "System.ArgumentNullException":
                    {
                        throw new ArgumentNullException(ex.Message);
                    }
                case "System.ArgumentException":
                    {
                        throw new ArgumentException(ex.Message);
                    }
                default:
                    throw new Exception(ex.Message);
            }
        }
    }
}
