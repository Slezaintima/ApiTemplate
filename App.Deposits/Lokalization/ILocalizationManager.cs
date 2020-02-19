﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace App.Deposits.Localization
{
    public interface ILocalizationManager
    {
        string GetResource(string key);
        string GetResource(string key, CultureInfo culture);
    }
}
