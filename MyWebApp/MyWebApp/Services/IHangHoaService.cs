using MyWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Services
{
    public interface IHangHoaService
    {
        List<HangHoa> GetAll();
        List<HangHoa> Find(string keyword);
        HangHoa FindById(int id);
    }
}
