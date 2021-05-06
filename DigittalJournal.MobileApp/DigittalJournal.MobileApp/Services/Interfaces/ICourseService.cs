using DigitalJournal.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigittalJournal.MobileApp.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCourses();
    }
}
