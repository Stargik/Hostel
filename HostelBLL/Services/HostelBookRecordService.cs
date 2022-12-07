using System;
using HostelBLL.Interfaces;
using HostelBLL.Models;
using HostelDAL.Entities;
using HostelDAL.Interfaces;

namespace HostelBLL.Services
{
    public class HostelBookRecordService : IHostelBookRecordService
    {
        private IUnitOfWork unitOfWork;
        private IStudentRepository studentRepository;
        private IHostelAddressRepository hostelAddressRepository;
        private IHostelBookRecordRepository hostelBookRecordRepository;
        public HostelBookRecordService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.studentRepository = unitOfWork.StudentRepository;
            this.hostelAddressRepository = unitOfWork.HostelAddressRepository;
            this.hostelBookRecordRepository = unitOfWork.HostelBookRecordRepository;
        }

        public void AddRecord(HostelBookRecordModel hostelBookRecordModel)
        {
            if (hostelBookRecordModel.Student is null)
            {
                throw new Exception();
            }
            var newStudent = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = hostelBookRecordModel.Student.FirstName,
                LastName = hostelBookRecordModel.Student.LastName,
                SurName = hostelBookRecordModel.Student.SurName,
                Email = hostelBookRecordModel.Student.Email,
                Department = hostelBookRecordModel.Student.Department,
                Course = hostelBookRecordModel.Student.Course
            };
            if (hostelBookRecordModel.HostelAddress is null)
            {
                throw new Exception();
            }
            var newAddress = new HostelAddress
            {
                Id = Guid.NewGuid(),
                Address = hostelBookRecordModel.HostelAddress.Address,
                RoomNumber = hostelBookRecordModel.HostelAddress.RoomNumber
            };
            var newRecord = new HostelBookRecord
            {
                Id = hostelBookRecordModel.Id,
                RoomId = newAddress.Id,
                StudentId = newStudent.Id,
                FromDate = hostelBookRecordModel.FromDate,
                ToDate = hostelBookRecordModel.ToDate,
                HostelAddress = newAddress,
                Student = newStudent
            };
            hostelBookRecordRepository.Create(newRecord);
            studentRepository.Create(newStudent);
            hostelAddressRepository.Create(newAddress);
            unitOfWork.Save();
        }

        public List<HostelBookRecordModel> GetAll()
        {
            return hostelBookRecordRepository.GetAll()
                .Select(x => new HostelBookRecordModel
                {
                    Id = x.Id,
                    FromDate = x.FromDate,
                    ToDate = x.ToDate,
                    HostelAddress = new HostelAddressModel { Address = x.HostelAddress?.Address, RoomNumber = x.HostelAddress.RoomNumber },
                    Student = new StudentModel
                    {
                        FirstName = x.Student?.FirstName,
                        LastName = x.Student?.LastName,
                        SurName = x.Student?.SurName,
                        Course = x.Student.Course,
                        Department = x.Student.Department,
                        Email = x.Student.Email
                    }
                }).ToList();
        }

        public List<HostelBookRecordModel> GetByAddress(HostelAddressModel hostelAddressModel)
        {
            return hostelBookRecordRepository.GetAll()
                .Where(x => x.HostelAddress.Address == hostelAddressModel.Address && x.HostelAddress.RoomNumber == hostelAddressModel.RoomNumber)
                .Select(x => new HostelBookRecordModel
                {
                    Id = x.Id,
                    FromDate = x.FromDate,
                    ToDate = x.ToDate,
                    HostelAddress = new HostelAddressModel { Address = x.HostelAddress?.Address, RoomNumber = x.HostelAddress.RoomNumber },
                    Student = new StudentModel
                    {
                        FirstName = x.Student?.FirstName,
                        LastName = x.Student?.LastName,
                        SurName = x.Student?.SurName,
                        Course = x.Student.Course,
                        Department = x.Student.Department,
                        Email = x.Student.Email
                    }
                }).ToList();
        }

        public List<HostelBookRecordModel> GetByDate(FilterDateModel filterDateModel)
        {
            var result = hostelBookRecordRepository.GetAll();
            if (filterDateModel.FromDate is not null && filterDateModel.ToDate is null)
            {
                result = result.Where(x => x.FromDate >= filterDateModel.FromDate);
            }else if (filterDateModel.FromDate is null && filterDateModel.ToDate is not null)
            {
                result = result.Where(x => x.ToDate <= filterDateModel.ToDate);
            }
            else if (filterDateModel.FromDate is not null && filterDateModel.ToDate is not null)
            {
                result = result.Where(x => x.FromDate >= filterDateModel.FromDate || x.ToDate <= filterDateModel.ToDate);
            }
            return result.Select(x => new HostelBookRecordModel
                 {
                     Id = x.Id,
                     FromDate = x.FromDate,
                     ToDate = x.ToDate,
                     HostelAddress = new HostelAddressModel { Address = x.HostelAddress?.Address, RoomNumber = x.HostelAddress.RoomNumber },
                     Student = new StudentModel
                     {
                         FirstName = x.Student?.FirstName,
                         LastName = x.Student?.LastName,
                         SurName = x.Student?.SurName,
                         Course = x.Student.Course,
                         Department = x.Student.Department,
                         Email = x.Student.Email
                     }
                 }).ToList();
        }

        public HostelBookRecordModel GetById(Guid id)
        {
            var hostelBookRecord = hostelBookRecordRepository.GetById(id);

            if (hostelBookRecord is null)
            {
                throw new Exception();
            }
            var result = new HostelBookRecordModel
            {
                Id = hostelBookRecord.Id,
                FromDate = hostelBookRecord.FromDate,
                ToDate = hostelBookRecord.ToDate,
                HostelAddress = new HostelAddressModel { Address = hostelBookRecord.HostelAddress?.Address, RoomNumber = hostelBookRecord.HostelAddress.RoomNumber },
                Student = new StudentModel
                {
                    FirstName = hostelBookRecord.Student?.FirstName,
                    LastName = hostelBookRecord.Student?.LastName,
                    SurName = hostelBookRecord.Student?.SurName,
                    Course = hostelBookRecord.Student.Course,
                    Department = hostelBookRecord.Student.Department,
                    Email = hostelBookRecord.Student.Email
                }
            };
            return result;
        }

        public List<HostelBookRecordModel> GetByStudent(StudentModel studentModel)
        {

            if (studentModel is null)
            {
                throw new Exception();
            }
            var students = studentRepository.GetAll()
                .Where(x => ((studentModel.FirstName is null || x.FirstName.Contains(studentModel.FirstName)) &&
                                    (studentModel.LastName is null || x.LastName.Contains(studentModel.LastName)) &&
                                    (studentModel.SurName is null || x.SurName.Contains(studentModel.SurName)) &&
                                    (studentModel.Email is null || x.Email == studentModel.Email) &&
                                    (studentModel.Department is null || x.Department.Contains(studentModel.Department)) &&
                                    (studentModel.Course is null || x.Course == x.Course)));
            if (students is null)
            {
                throw new Exception();
            }
            var hostelBookRecords = hostelBookRecordRepository.GetAll();
            if (hostelBookRecords is null)
            {
                throw new Exception();
            }
            return hostelBookRecords.Where(x => students.Contains(x.Student)).Select(x => new HostelBookRecordModel
            {
                Id = x.Id,
                FromDate = x.FromDate,
                ToDate = x.ToDate,
                HostelAddress = new HostelAddressModel { Address = x.HostelAddress?.Address, RoomNumber = x.HostelAddress.RoomNumber },
                Student = new StudentModel
                {
                    FirstName = x.Student?.FirstName,
                    LastName = x.Student?.LastName,
                    SurName = x.Student?.SurName,
                    Course = x.Student.Course,
                    Department = x.Student.Department,
                    Email = x.Student.Email
                }
            }).ToList();

        }

        public void Remove(Guid id)
        {
            var record = hostelBookRecordRepository.GetById(id);
            if (record is not null)
            {
                hostelBookRecordRepository.Delete(record);
            }
        }

        public void Update(Guid id, HostelBookRecordModel hostelBookRecordModel)
        {
            var record = hostelBookRecordRepository.GetById(id);

            if (record is null)
            {
                throw new Exception();
            }

            if (hostelBookRecordModel.Student is null)
            {
                throw new Exception();
            }
            var newStudent = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = hostelBookRecordModel.Student.FirstName,
                LastName = hostelBookRecordModel.Student.LastName,
                SurName = hostelBookRecordModel.Student.SurName,
                Email = hostelBookRecordModel.Student.Email,
                Department = hostelBookRecordModel.Student.Department,
                Course = hostelBookRecordModel.Student.Course
            };
            if (hostelBookRecordModel.HostelAddress is null)
            {
                throw new Exception();
            }
            var newAddress = new HostelAddress
            {
                Id = Guid.NewGuid(),
                Address = hostelBookRecordModel.HostelAddress.Address,
                RoomNumber = hostelBookRecordModel.HostelAddress.RoomNumber
            };
            var newRecord = new HostelBookRecord
            {
                Id = hostelBookRecordModel.Id,
                RoomId = newAddress.Id,
                StudentId = newStudent.Id,
                FromDate = hostelBookRecordModel.FromDate,
                ToDate = hostelBookRecordModel.ToDate,
                HostelAddress = newAddress,
                Student = newStudent
            };
            hostelBookRecordRepository.Update(newRecord);
            studentRepository.Create(newStudent);
            hostelAddressRepository.Create(newAddress);
            unitOfWork.Save();
        }
    }
}

