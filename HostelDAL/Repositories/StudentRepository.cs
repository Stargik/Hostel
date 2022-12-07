using System;
using HostelDAL.Data;
using HostelDAL.Entities;
using HostelDAL.Interfaces;

namespace HostelDAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private HostelContext context;

        public StudentRepository(HostelContext context)
        {
            this.context = context;
        }

        public void Create(Student entity)
        {
            context.Students?.Add(entity);
        }

        public void Delete(Student entity)
        {
            Student? student = context.Students?.Find(x => x.Id == entity.Id);

            if (student is not null)
            {
                context.Students?.Remove(student);
            }
        }

        public void DeleteById(Guid id)
        {
            Student? student = context.Students?.Find(x => x.Id == id);

            if (student is not null)
            {
                context.Students?.Remove(student);
            }
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students;
        }

        public Student? GetById(Guid id)
        {
            return context.Students?.Find(x => x.Id == id);
        }

        public void Update(Student entity)
        {
            Student? student = context.Students?.Find(x => x.Id == entity.Id);

            if (student is not null)
            {
                student = entity;
            }
        }
    }
}

