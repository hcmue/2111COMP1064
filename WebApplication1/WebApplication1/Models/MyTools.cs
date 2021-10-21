using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MyTools
    {
        public static string PhatSinhNgauNhien(int length = 5)
        {
            var pattern = "zaqwsxedcrfvtgbyhnujmiklop[]1234567890<>?";
            var random = new Random();
            var sb = new StringBuilder();
            for(var i = 0; i < length; i++)
            {
                sb.Append(pattern[random.Next(0, pattern.Length)]);
            }

            return sb.ToString();
        }
    }
}
