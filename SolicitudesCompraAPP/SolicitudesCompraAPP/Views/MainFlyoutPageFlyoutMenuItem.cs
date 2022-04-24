﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolicitudesCompraAPP.Views
{
    public class MainFlyoutPageFlyoutMenuItem
    {
        public MainFlyoutPageFlyoutMenuItem()
        {
            TargetType = typeof(MainFlyoutPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }
}