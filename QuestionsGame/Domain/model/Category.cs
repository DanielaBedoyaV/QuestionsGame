using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.model
{
    public class Category
    {
        public Category(List<Question> questions, string categoryName, int level, string id = null)
        {
            if (id == null)
            {
                this.Id = Guid.NewGuid().ToString();
            }
            else
            {
                this.Id = id;
            }
            this.CategoryName = categoryName;
            this.Level = level;
            this.Questions = questions;
              
        }
        public List<Question> Questions { get; private set; }

        public string CategoryName { get; private set; }

        public int Level { get; private set; }
        public string Id { get; private set; }
    }
}
