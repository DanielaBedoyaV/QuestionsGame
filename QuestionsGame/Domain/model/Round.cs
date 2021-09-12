using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.model
{
    public class Round


    {
        public Round(Category category, Prize prize)
        {
            this.Category = category;
            this.Prize = prize;
        }
        public Category Category { get; private set; }
        public Prize Prize { get; private set; }
    }
}
