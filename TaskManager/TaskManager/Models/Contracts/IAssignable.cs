﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Contracts
{
    public interface IAssignable
    {
        bool IsAssigned { get; }
    }
}

