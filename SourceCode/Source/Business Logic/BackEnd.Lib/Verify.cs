using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.Lib
{
    public static class Verify
    {
        public static void ArgumentNotNull(
            object parameter)
        {
            ArgumentNotNull(parameter, null, null);
        }

        public static void ArgumentNotNull(
            object parameter,
            string paramName)
        {
            ArgumentNotNull(parameter, paramName, null);
        }

        public static void ArgumentNotNull(
            object parameter,
            string paramName,
            string message)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(paramName, message);
            }
        }

        public static void ArgumentNotSpecified(
            bool throwError,
            string paramName)
        {
            if (throwError)
            {
                throw new ArgumentException(
                    paramName,
                    string.Format("No {0} specified.", paramName));
            }
        }

        public static void ListNotEmpty<T>(
            IList<T> list,
            string listName)
        {
            ArgumentNotNull(list, listName);

            if (list.Count == 0)
            {
                throw new ArgumentException(
                    string.Format("List {0} is empty (but shouldn\'t be)",
                    listName),
                    listName);
            }
        }
    }
}
