using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalCalenderBooking.Entities;

namespace TalCalenderBooking.Abstractions
{
    internal interface IRepository<T>
    {
        T GetValue(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        Task<IEnumerable<T>> GetAllBookingAsync();

    }
}
