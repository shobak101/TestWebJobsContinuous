﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector
{
    public interface IDataCollector
    {
        void SetUpListener();

        void StartListening();

        void StopListening();
    }
}
