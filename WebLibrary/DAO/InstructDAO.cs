using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.DAO
{
    public class InstructDAO
    {
        private static InstructDAO instance = null;
        private static readonly object instanceLock = new object();
        public static InstructDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new InstructDAO();

                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Instruct> GetInstructlist()
        {
            var instruct = new List<Instruct>();
            try
            {
                using var context = new DBContext();
                instruct = context.Instructs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

                throw;
            }
            return instruct;
        }

        public Instruct GetInstructByID(int instructID)
        {
            Instruct instruct = null;
            try
            {
                using var context = new DBContext();
                instruct = context.Instructs.SingleOrDefault(c => c.InstructId.Equals(instructID));

            }
            catch (System.Exception)
            {

                throw;
            }
            return instruct;
        }

        public void AddNew(Instruct instruct)
        {
            try
            {
                Instruct existingInstruct = GetInstructByID(instruct.InstructId);
                if (existingInstruct == null)
                {
                    using (var context = new DBContext())
                    {
                        context.Instructs.Add(instruct);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The instruct already exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Instruct instruct)
        {
            try
            {
                Instruct existingInstruct = GetInstructByID(instruct.InstructId);
                if (existingInstruct != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Instructs.Update(instruct);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The instruct does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int instructID)
        {
            try
            {
                Instruct instruct = GetInstructByID(instructID);
                if (instruct != null)
                {
                    using (var context = new DBContext())
                    {
                        context.Instructs.Remove(instruct);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The instruct does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}