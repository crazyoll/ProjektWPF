using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class TestView : TestModel
    {

        //singleton
        public static TestView Instance => new TestView();

        public TestView()
        {
            TitleTest = "Testowanie";
        }
    }
}
