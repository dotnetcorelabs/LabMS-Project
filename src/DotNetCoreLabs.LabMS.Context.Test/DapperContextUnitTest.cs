using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DotNetCoreLabs.LabMS.Context.Test
{
    public class DapperContextUnitTest
    {
        public DapperContextUnitTest()
        {
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, 4);
        }
    }
}
