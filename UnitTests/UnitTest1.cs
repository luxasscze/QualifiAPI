using Microsoft.EntityFrameworkCore;
using Moq;
using QualifiAPI.Data;
using QualifiAPI.Models;
using QualifiAPI.Services;
using QualifiAPI.Services.Interfaces;
using System.Reflection.Metadata;

namespace UnitTests
{
    public class PrequalificationTests
    {
        private Mock<ApplicationContext> mockContext;       
        
        [SetUp]
        public void Setup()
        {
            var creditCards = new List<CreditCard>
            {
                new CreditCard { AnnualFee = 12.99M, CardName = "Credit Card 1", Features = "None",Id = 1, Issuer = "Lukas", MinSalary = 1 },
                new CreditCard { AnnualFee = 15.99M, CardName = "Credit Card 2", Features = "None",Id = 2, Issuer = "Lukas", MinSalary = 1299.99M },
                new CreditCard { AnnualFee = 17.99M, CardName = "Credit Card 3", Features = "None",Id = 3, Issuer = "Lukas", MinSalary = 1399.99M },
                new CreditCard { AnnualFee = 19.99M, CardName = "Credit Card 4", Features = "None",Id = 4, Issuer = "Lukas", MinSalary = 1499.99M },
                new CreditCard { AnnualFee = 21.99M, CardName = "Credit Card 5", Features = "None",Id = 5, Issuer = "Lukas", MinSalary = 1599.99M },

            }.AsQueryable();

            var requests = new List<PrequalificationRequest>
            {
                new PrequalificationRequest 
                { Address = "Some Address", 
                    Created = DateTime.Now,                     
                    Dob = DateTime.Now.AddYears(-36),
                    Id = 1,
                    Name = "Some Name",
                    Salary = 1699.99M
                },                

            }.AsQueryable();

            var mockSet = new Mock<DbSet<CreditCard>>();
            var requestsMockSet = new Mock<DbSet<PrequalificationRequest>>();
            mockSet.As<IQueryable<CreditCard>>().Setup(m => m.Provider).Returns(creditCards.Provider);
            mockSet.As<IQueryable<CreditCard>>().Setup(m => m.Expression).Returns(creditCards.Expression);
            mockSet.As<IQueryable<CreditCard>>().Setup(m => m.ElementType).Returns(creditCards.ElementType);
            mockSet.As<IQueryable<CreditCard>>().Setup(m => m.GetEnumerator()).Returns(() => creditCards.GetEnumerator());

            requestsMockSet.As<IQueryable<PrequalificationRequest>>().Setup(m => m.Provider).Returns(requests.Provider);
            requestsMockSet.As<IQueryable<PrequalificationRequest>>().Setup(m => m.Expression).Returns(requests.Expression);
            requestsMockSet.As<IQueryable<PrequalificationRequest>>().Setup(m => m.ElementType).Returns(requests.ElementType);
            requestsMockSet.As<IQueryable<PrequalificationRequest>>().Setup(m => m.GetEnumerator()).Returns(() => requests.GetEnumerator());

            mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(c => c.CreditCards).Returns(mockSet.Object);
            mockContext.Setup(s => s.Requests).Returns(requestsMockSet.Object);
        }

        [Test]
        public async Task PrequalifyApplicant_Salary1_Returns1CCOffer()
        {
            //Arrange
            PrequalificationService service = new PrequalificationService(mockContext.Object);
            Application application = new()
            {
                Address = "Some address",
                Dob = DateTime.Now.AddYears(-36),
                Name = "Some Customer",
                Salary = 1
            };

            //Act
            var result = await service.PrequalifyApplicant(application);

            //Assert
            Assert.That(result.Count == 1);
        }

        [Test]
        public async Task PrequalifyApplicant_Salary1300_Returns2CCOffers()
        {
            //Arrange
            PrequalificationService service = new PrequalificationService(mockContext.Object);
            Application application = new()
            {
                Address = "Some address",
                Dob = DateTime.Now.AddYears(-36),
                Name = "Some Customer",
                Salary = 1300
            };

            //Act
            var result = await service.PrequalifyApplicant(application);

            //Assert
            Assert.That(result.Count == 2);
        }

        [Test]
        public async Task PrequalifyApplicant_Salary1400_Returns3CCOffers()
        {
            //Arrange
            PrequalificationService service = new PrequalificationService(mockContext.Object);
            Application application = new()
            {
                Address = "Some address",
                Dob = DateTime.Now.AddYears(-36),
                Name = "Some Customer",
                Salary = 1400
            };

            //Act
            var result = await service.PrequalifyApplicant(application);

            //Assert
            Assert.That(result.Count == 3);
        }

        [Test]
        public async Task PrequalifyApplicant_Salary1500_Returns4CCOffers()
        {
            //Arrange
            PrequalificationService service = new PrequalificationService(mockContext.Object);
            Application application = new()
            {
                Address = "Some address",
                Dob = DateTime.Now.AddYears(-36),
                Name = "Some Customer",
                Salary = 1500
            };

            //Act
            var result = await service.PrequalifyApplicant(application);

            //Assert
            Assert.That(result.Count == 4);
        }

        [Test]
        public async Task PrequalifyApplicant_Salary1600_Returns5CCOffers()
        {
            //Arrange
            PrequalificationService service = new PrequalificationService(mockContext.Object);
            Application application = new()
            {
                Address = "Some address",
                Dob = DateTime.Now.AddYears(-36),
                Name = "Some Customer",
                Salary = 1600
            };

            //Act
            var result = await service.PrequalifyApplicant(application);

            //Assert
            Assert.That(result.Count == 5);
        }
    }
}