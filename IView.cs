﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IView
    {
        void ShowErrors(List<string> errors);
    }
}
