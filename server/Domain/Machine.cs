﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Machine : BaseEntity
    {
        public string State { get; set; }
        public IEnumerable<MContainer> MContainers { get; set; }

        public Machine()
        {
            MContainers = new List<MContainer>();
        }
    }
}