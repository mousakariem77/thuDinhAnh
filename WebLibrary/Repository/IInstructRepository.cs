using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Repository
{
    public interface IInstructRepository
    {
        IEnumerable<Instruct> GetInstructs();
        Instruct GetInstructByID(int instructId);
        void InsertInstruct(Instruct instruct);
        void DeleteInstruct(int instructId);
        void UpdateInstruct(Instruct instruct);
    }
}