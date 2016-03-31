﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagSensorLibrary_PCL
{
    public class Validator
    {
        private Validator()
        {

        }

        public static void Requires<TException>(bool predicate)
            where TException : Exception, new()
        {
            if (!predicate)
                throw new TException();
        }

        public static void RequiresArgument(bool predicate, string reason)
        {
            if (!predicate)
                throw new ArgumentException(reason);
        }

        public static void RequiresNotNull(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
        }

        public static void RequiresNotNull(object obj, string argumentName)
        {
            if (obj == null)
                throw new ArgumentNullException(argumentName);
        }

        public static void RequiresNotNullOrEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException();
        }

        public static void RequiresNotNullOrEmpty(string value, string argumentName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(argumentName);
        }
    }

}
