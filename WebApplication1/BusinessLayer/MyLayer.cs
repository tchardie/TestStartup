using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.BusinessLayer
{
    public interface IMyLayer
    {
        static IList<string> GetStringList();
    }

    public class MyLayer : IMyLayer
    {
        public static IList<string> GetStringList()
        {
            return new List<string> { "String", "String", "String" };
        }
    }
}