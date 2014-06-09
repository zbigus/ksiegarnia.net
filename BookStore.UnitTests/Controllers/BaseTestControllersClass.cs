using BookStore.Logic.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.UnitTests.Controllers
{
    public class BaseTestControllersClass
    {
        public static Mock<IRepository> _mockUserRepo = new Mock<IRepository>();

    }
}
