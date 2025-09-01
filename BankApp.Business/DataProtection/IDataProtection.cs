﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Business.DataProtection
{
    public interface IDataProtection
    {
        string protect(string text);
        string Unprotect(string text);
    } // end of interface IDataProtection
}
