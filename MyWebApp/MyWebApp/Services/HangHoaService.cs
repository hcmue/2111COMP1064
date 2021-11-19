using MyWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Services
{
    public class HangHoaService : IHangHoaService
    {
        private readonly eStore20Context _context;

        public HangHoaService(eStore20Context context)
        {
            _context = context;
        }
        public List<HangHoa> Find(string keyword)
        {
            throw new NotImplementedException();
        }

        public HangHoa FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<HangHoa> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
