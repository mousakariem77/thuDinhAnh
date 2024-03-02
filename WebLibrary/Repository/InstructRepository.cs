using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.DAO;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public class InstructRepository : IInstructRepository
    {
        public Instruct GetInstructByID(int instructId) => InstructDAO.Instance.GetInstructByID(instructId);
        public IEnumerable<Instruct> GetInstructs() => InstructDAO.Instance.GetInstructlist();
        public void InsertInstruct(Instruct instruct) => InstructDAO.Instance.AddNew(instruct);
        public void DeleteInstruct(int instructId) => InstructDAO.Instance.Remove(instructId);
        public void UpdateInstruct(Instruct instruct) => InstructDAO.Instance.Update(instruct); 
    }
}