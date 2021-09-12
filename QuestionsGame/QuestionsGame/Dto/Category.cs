using System.Collections.Generic;

namespace QuestionsGame.Dto
{
    public class Category
    {
        public List<Question> Questions { get; set; }
        
        public string CategoryName { get; set; }

        public int Level { get; set; }
    }
}