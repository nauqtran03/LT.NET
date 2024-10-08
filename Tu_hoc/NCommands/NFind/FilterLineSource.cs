﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NFind
{
    internal class FilterLineSource : ILineSource
    {
        private readonly ILineSource  parent;
        private readonly Func<Line, bool>? f;
        public FilterLineSource(ILineSource parent, Func<Line,bool>? f=null) 
        {
            this.parent = parent?? throw new ArgumentNullException(nameof(parent));
            this.f = f;
        }

        public string Name => parent.Name;

        public void Close()
        {
            parent.Close();
        }

        public void Open()
        {
            parent.Open();
        }

        public Line? ReadLine()
        {
            if (f == null) 
            {
                return parent.ReadLine();
            }
            var line = parent.ReadLine();
            if (line == null)
            {
                return line;
            }
            else
            {
                while (line != null && f(line) == false)
                {
                    line = parent.ReadLine();
                }
                return line;
            }
        }
    }
}
