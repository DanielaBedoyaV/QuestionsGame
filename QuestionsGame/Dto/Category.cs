using System.Collections.Generic;

namespace Dto
{
    public class Category
    {
        public List<Question> Questions { get; set; }
        
        public string CategoryName { get; set; }

        public int Level { get; set; }
        public string Id { get; set; }
    }
}