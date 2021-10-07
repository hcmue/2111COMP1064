using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo03.Models
{
    public class Demo
    {
        public int Test01()
        {
            Thread.Sleep(2000);
            return new Random().Next(10, 1000);
        }

        public string Test02()
        {
            Thread.Sleep(5000);
            return "Hello Test SYNC";
        }

        public void Test03()
        {
            Thread.Sleep(3000);
        }


        public async Task<int> Test01Async()
        {
            await Task.Delay(2000);
            return new Random().Next(10, 1000);
        }

        public async Task<string> Test02Async()
        {
            await Task.Delay(5000);
            return "Hello Test SYNC";
        }

        public async Task Test03Async()
        {
            await Task.Delay(3000);
        }
    }
}
