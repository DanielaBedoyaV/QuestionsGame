using Domain.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Services
{
   public class CategoryServices
    {
        public CategoryServices()
        {

        }
        public Dto.Category SetNewCategory(Dto.Category categoryDto)
        {
            List<Question> questions = this.MapQuestions(categoryDto.Questions);

            var category = new Category(questions, categoryDto.CategoryName, categoryDto.Level);
            this.ValidateCategory(category);
            this.SaveCategory(category);
            categoryDto.Id = category.Id;
            return categoryDto;
        }

        public List<Category> GetCategories()
        {
            List<string> nameFiles = this.GetFilesName();
            List<Category> categories = new List<Category>();
            foreach (var nameFile in nameFiles)
            {
                categories.Add( this.GetCategory(nameFile));
            }
            return categories;
        }

        private List<string> GetFilesName()
        {
            DirectoryInfo d = new DirectoryInfo(@"./files");

            FileInfo[] Files = d.GetFiles("*.json");
            List<string> str = new List<string>();

            foreach (FileInfo file in Files)
            {
                str.Add(file.Name);
            }
            return str;
        }

        private void ValidateCategory(Category category)
        {
            if (category.Questions.Count<5)
            {
                 throw new InvalidOperationException("The category must have at least 5 questions");
            }
        }

        private List<Question> MapQuestions(List<Dto.Question> questionsDto)
        {
            List<Question> questions = new List<Question>();
            var questionServices = new QuestionServices();
            foreach (var question in questionsDto)
            {
                questions.Add(questionServices.MapQuestion(question));
            }
            return questions;
        }

        private void SaveCategory(Category category)
        {

            var path = @"./files/" + category.Id + ".json";

            string json = System.Text.Json.JsonSerializer.Serialize(category);
            File.WriteAllText(path, json);
        }

        private Category GetCategory(string categoryId)
        {

            var path = @"./files/" + categoryId;

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                Category item = JsonConvert.DeserializeObject<Category>(json);
                return item;
            }

           
        }

    }
}
