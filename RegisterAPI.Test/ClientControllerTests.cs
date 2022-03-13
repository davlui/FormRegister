using Xunit;
using RegisterAPI.Controllers;
using ServiceLayer.ClientService;
using FakeItEasy;
using ServiceLayer.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RegisterAPI.Test
{
    public class ClientControllerTests
    {
        #region GetAllClients
        [Fact]
        public void GetAllClients_Returns_Simplefied_List_Of_Clients()
        {
            // Arrange
            var clients = A.CollectionOfDummy<ClientDto>(2).AsEnumerable();

            var fakeService = A.Fake<IClientService>();
            A.CallTo(() => fakeService.GetAllClients()).Returns(clients); 

            var controller = new ClientController(fakeService);

            // Act
            var actionResult = controller.GetAllClients();

            // Assert
            var result = actionResult as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }


        [Fact]
        public void GetAllClients_Returns_Simplefied_No_List_Of_Clients()
        {
            // Arrange
            var clients = A.CollectionOfDummy<ClientDto>(0).AsEnumerable();

            var fakeService = A.Fake<IClientService>();
            A.CallTo(() => fakeService.GetAllClients()).Returns(clients);

            var controller = new ClientController(fakeService);

            // Act
            var actionResult = controller.GetAllClients();

            // Assert
            var result = actionResult as NoContentResult;

            Assert.Equal(204,result.StatusCode);
        }


        [Fact]
        public void GetAllClients_Where_Null_Service()
        {
            // Arrange

            var fakeService = A.Fake<IClientService>();
            A.CallTo(() => fakeService.GetAllClients()).Returns(null);

            var controller = new ClientController(fakeService);

            // Act
            var actionResult = controller.GetAllClients();

            // Assert
            var result = actionResult as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
        }

        #endregion

        #region GetClient
        [Fact]
        public void GetClient_Returns_Detaild_Client()
        {
            // Arrange
            var client = A.Dummy<ClientDetailsDto>();

            var fakeService = A.Fake<IClientService>();
            A.CallTo(() => fakeService.GetClientById(client.Id)).Returns(client);

            var controller = new ClientController(fakeService);

            // Act
            var actionResult = controller.GetClient(client.Id);

            // Assert
            var result = actionResult as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetClient_Not_Found_Detaild_Client()
        {
            // Arrange

            var fakeService = A.Fake<IClientService>();
            A.CallTo(() => fakeService.GetClientById(1)).Returns(null);

            var controller = new ClientController(fakeService);

            // Act
            var actionResult = controller.GetClient(1);

            // Assert
            var result = actionResult as NotFoundObjectResult;

            Assert.Equal(404, result.StatusCode);
        }

        #endregion
    }
}