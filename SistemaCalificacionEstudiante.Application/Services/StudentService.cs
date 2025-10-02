using SistemaCalificacionEstudiante.Application.DTOs;
using SistemaCalificacionEstudiante.Application.Interfaces;
using SistemaCalificacionEstudiante.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCalificacionEstudiante.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task AddStudentAsync(StudentDto studentDto)
        {
            var student = new Student
            {
                FullName = studentDto.FullName,
                Age = studentDto.Age,
                Carrera = studentDto.Carrera
            };
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(int id, StudentDto studentDto)
        {
            var studentToUpdate = await _studentRepository.GetByIdAsync(id);
            if (studentToUpdate != null)
            {
                studentToUpdate.FullName = studentDto.FullName;
                studentToUpdate.Age = studentDto.Age;
                studentToUpdate.Carrera = studentDto.Carrera;
                await _studentRepository.UpdateAsync(studentToUpdate);
            }
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }
}