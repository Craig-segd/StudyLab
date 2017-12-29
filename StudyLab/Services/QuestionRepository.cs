using Microsoft.AspNetCore.JsonPatch;
using StudyLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyLab.Services
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;

        public QuestionRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Question> GetQuestions(string tId)
        {
            return _context.Questions.Where(c => c.Type.Name == tId).ToList();
        }

        public Question GetQuestion(int id, string tId)
        {
            return _context.Questions.SingleOrDefault(c => c.Type.Name == tId && c.Id == id);
        }

        public void DeleteQuestion(int id, string tId)
        {
            var questionToRemove = _context.Questions.Single(c => c.Id == id && c.Type.Name == tId); // Possible issue
            _context.Questions.Remove(questionToRemove);
        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void AddQuestion(List<Question> dto)
        {
            foreach (var question in dto)
            {
                _context.Questions.Add(question);
            }

        }

        public void UpdateQuestion(int id, string tId, JsonPatchDocument<Question> dto)
        {
            var apply = GetQuestion(id, tId);
            dto.ApplyTo(apply);

        }
    }
}