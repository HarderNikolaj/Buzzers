using Application.DbCommunicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace Tests
{
    public class DbCommunicatorTests
    {
        private Mock<IDbCommunicator> _db;
        public DbCommunicatorTests()
        {
            _db = new Mock<IDbCommunicator>();
            _db.Setup(a => a.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(8);
        }

        [Fact]
        public void LoginShouldReturnCorrectUser() 
        {
            var user = _db.Object.Login("pimp@mail.com", "asdf");
            Assert.Equal(8, user);
        }
    }
}
