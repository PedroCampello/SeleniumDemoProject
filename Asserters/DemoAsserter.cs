using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Asserters
{
    public class DemoAsserter
    {
        //class mainly to make assertions between an element retrieved through an API call and one provided from test data,
        //boilerplate for now.
        //private readonly DemoAPI _demoApi;
        public DemoAsserter(/*DemoAPI demoApi*/)
        {
            //_demoApi = demoApi;
        }

        public DemoAsserter AssertElementFound(string actual, string expected)
        {
            Assert.AreEqual(actual, expected);

            return this;
        }
    }
}
