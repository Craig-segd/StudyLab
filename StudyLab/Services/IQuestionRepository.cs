using Microsoft.AspNetCore.JsonPatch;
using StudyLab.Models;
using System.Collections.Generic;

namespace StudyLab.Services
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestions(string tId);
        Question GetQuestion(int id, string tId);
        void DeleteQuestion(int id, string tId);
        bool Save();
        void AddQuestion(List<Question> dto);
        void UpdateQuestion(int id, string tId, JsonPatchDocument<Question> dto);
        IEnumerable<Type> GetTypes();
    }
}
