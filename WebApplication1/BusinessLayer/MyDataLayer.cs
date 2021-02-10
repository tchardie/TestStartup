using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.BusinessLayer
{
    public interface IMyDataLayer
    {
        IList<string> GetListItems();

        string GetSpecificItem(int id);
    }

    public class MyDataLayer : IMyDataLayer
    {
        public static IList<string> GetListItemsStatic()
        {
            return new List<string>
            {
                "Real 1", "Real 2", "Real 3"
            };
        }

        public IList<string> GetListItems()
        {
            return new List<string>
            {
                "Real 1", "Real 2", "Real 3"
            };
        }

        public static string GetSpecificItemStatic(int id)
        {
            switch (id)
            {
                case 0:
                    return "blah-0";
                case 1:
                    return "blah-1";
                default:
                    return "Item Not Found";
            }
        }

        public string GetSpecificItem(int id)
        {
            switch(id)
            {
                case 0:
                    return "blah-0";
                case 1:
                    return "blah-1";
                default:
                    return "Item Not Found";
            }

        }
    }
}