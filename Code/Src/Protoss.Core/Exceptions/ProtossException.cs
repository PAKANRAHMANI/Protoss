﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Protoss.Core.Exceptions
{
    public class ProtossException: Exception
    {
        public long Code { get; private set; }
        public string ExceptionMessage { get; private set; }
        protected ProtossException() { }
        public ProtossException(long code, string message)
        {
            this.Code = code;
            this.ExceptionMessage = message;
        }
        public ProtossException(Enum errorCode, string errorMessage)
        {
            this.Code = Convert.ToInt32(errorCode);
            this.ExceptionMessage = errorMessage;
        }
    }
}
