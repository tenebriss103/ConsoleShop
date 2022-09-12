using System;
using System.Collections.Generic;
using System.Text;



namespace ClassLibrary1.MyException
{

    public class ShopException : Exception
    {
        public ShopException(string message)
            : base(message) { }
    }
}
