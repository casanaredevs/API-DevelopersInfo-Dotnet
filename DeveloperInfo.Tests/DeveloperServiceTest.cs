using DeveloperInfo.Infrastructure.DataAccess;
using DeveloperInfo.Models;
using DeveloperInfo.ServiceImplementations;
using Moq;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DeveloperInfo.Tests
{
    public class DeveloperServiceTest
    {
        Mock<IRepository<Developer, Guid>> DevRepoMock;
        Mock<IRepository<Technology, Guid>> TecnologyRepoMock;
        Mock<IRepository<SocialNetwork, Guid>> SocialNetworkRepoMock;

        public DeveloperServiceTest()
        {
            IList<Developer> devs = new List<Developer>()
            {
                new Developer { Name = "TEST", LastName = "TEST", Description = "TEST" },
                new Developer{ Name = "TEST2", LastName = "TEST2", Description = "TEST2" }
            };

            IList<Technology> technologies = new List<Technology>()
            {
                new Technology { Name ="TEST"}
            };
            IList<SocialNetwork> socialNetworks = new List<SocialNetwork>()
            {
                new SocialNetwork { Name ="TEST"}
            };


            var queryableProviderMock = new Mock<IQueryProvider>();
            queryableProviderMock.As<INhQueryProvider>()
                                 .Setup(x => x.ExecuteAsync<IEnumerable<Developer>>(It.IsAny<Expression>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(devs);

            var queryableMock = new Mock<IQueryable<Developer>>();
            queryableMock.Setup(x => x.Provider).Returns(queryableProviderMock.Object);


            DevRepoMock = new();
            DevRepoMock.Setup(x => x.GetAsync(It.IsAny<Guid>())).Returns(Task.FromResult(devs.FirstOrDefault()));
            DevRepoMock.Setup(x => x.Add(It.IsAny<Developer>())).Returns(Task.FromResult(devs.FirstOrDefault()));
            DevRepoMock.Setup(x => x.GetAll()).Returns(Task.FromResult(devs));


            TecnologyRepoMock = new();
            TecnologyRepoMock.Setup(x => x.GetAll()).Returns(Task.FromResult(technologies));
            SocialNetworkRepoMock = new();
            SocialNetworkRepoMock.Setup(x => x.GetAll()).Returns(Task.FromResult(socialNetworks));
        }
        [Fact]
        public async Task GetAsyncTest()
        {
            DeveloperService service = new(DevRepoMock.Object, TecnologyRepoMock.Object, SocialNetworkRepoMock.Object);
            var res = await service.AddAsync(new Models.Web.DeveloperData { Name = "TEST", SocialNetworks = new List<Models.Web.SocialNetworkData>(), Technologies = new string[1] { "TEST" } });
            Assert.Equal("TEST", res.Name);
        }
    }
}