﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2
{
    internal interface Nguoi
    {
        void TrangThai();
        string HoTen { get; set; }
        string QueQuan { get; set; }
    }
}
