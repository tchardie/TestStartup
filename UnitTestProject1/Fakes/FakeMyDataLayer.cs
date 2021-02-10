using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BusinessLayer;

namespace UnitTestProject1.Fakes
{
    public class FakeMyDataLayer : IMyDataLayer
    {
        public IList<string> GetListItems()
        {
            return new List<string>
            {
                "Fake 1", "Fake 2", "Fake 3"
            };
        }

        public string GetSpecificItem(int id)
        {
            return "FakeItem" + id;
        }
    }
}
