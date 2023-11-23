using System;

namespace Diary
{
    
    public struct Page
    {
        public string Text;
        public DateOnly Date;

        public Page(string Text, DateOnly Date) 
        {
            this.Text = Text;
            this.Date = Date;
        }
    }
}
