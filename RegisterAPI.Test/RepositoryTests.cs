using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RepositoryLayer.Repository;
using FakeItEasy;
using RepositoryLayer;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RegisterAPI.Test
{
    public class RepositoryTests
    {

        [Fact]
        public async Task Get_List_Of_Clients_Model()
        {
            // Arrange
            var fakeDbContext = A.Fake<ApplicationDbContext>();
            var fakeDbSet = A.Fake<DbSet<Client>>();

            var fakeClients = A.CollectionOfFake<Client>(4);
            fakeDbSet.AddRange(fakeClients);


            //A.CallTo(() => fakeDbContext.Set<Client>()).Returns(fakeDbSet);

            var repo = new Repository<Client>(fakeDbContext);

            // Act
            var result = await repo.GetAll();

            // Assert
            Assert.NotNull(result);
        }
    }
}
