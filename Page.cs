using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    public readonly struct Page
    {
        public readonly string Text;
        public readonly DateOnly Date;

        public Page(string Text, DateOnly Date) 
        {
            this.Text = Text;
            this.Date = Date;
        }
    }
}
