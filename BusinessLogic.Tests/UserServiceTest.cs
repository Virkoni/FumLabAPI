using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Linq.Expressions;
using System.Numerics;

namespace BuisnessLogic.Tests
{
    public class UserServiceTest
    {

        public readonly UserService service;
        private readonly Mock<IUserRepository> repMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            repMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User)
                .Returns(repMoq.Object);

            service = new UserService(repositoryWrapperMoq.Object);
        }


        public static IEnumerable<object[]> GetIncorrectUser()
        {
            return new List<object[]>
            {
                new object[] {new User { Email = "", PasswordHash = "", Username = "" } },
                new object[] {new User { Email = "email@email.com", PasswordHash = "", Username = "Man" } },
                new object[] {new User { Email = "", PasswordHash = "12345", Username = "Man" } },
                new object[] {new User { Email = "email@email.com", PasswordHash = "12345", Username = "" } },
            };
        }


        [Fact]
        public async void CreateAsync_NullUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }


        [Fact]
        public async void CreateAsync_NewUser_ShouldCreateNewUser()
        {
            var example = new User()
            {
                Email = "email@email.com",
                PasswordHash = "12345",
                Username = "Man"
            };

            await service.Create(example);

            repMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }


        [Theory]
        [MemberData(nameof(GetIncorrectUser))]
        public async Task CreateAsync_NewUser_ShouldNotCreateNewUser(User model)
        {
            var example = model;


            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(example));

            Assert.IsType<ArgumentException>(ex);
            repMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);

            Assert.IsType<ArgumentException>(ex);
        }


        public static IEnumerable<object[]> UpdateIncorrectUser()
        {
            return new List<object[]>
            {
                new object[] {new User { UserId = 1, Email = "", PasswordHash = "Password", Username = "Man", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = null} },
                new object[] {new User { UserId = 1, Email = "email", PasswordHash = "Password", Username = "", CreatedAt = DateTime.Now,  UpdatedAt = DateTime.Now, IsDeleted = null} },
                new object[] {new User { UserId = 1, Email = "email", PasswordHash = "Password", Username = "Man", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = true} },
                new object[] {new User { UserId = 1, Email = "email", PasswordHash = "Password", Username = "Man",  CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsDeleted = null} },
            };
        }


        [Fact]
        public async void UpdateAsync_NullUser_ShullThrowNullArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Update(null));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Never);
        }


        [Fact]
        public async void UpdateAsync_NewUser_ShouldCreateNewUser()
        {
            var example = new User()
            {
                UserId = 1,
                Username = "Man",
                PasswordHash = "12345",
                Email = "email@email.com",
                CreatedAt = DateTime.ParseExact("25-12-2023", "dd-MM-yyyy", null),
                UpdatedAt = DateTime.Now,
                IsDeleted = false,
            };

            repMoq.Setup(x => x.FindByCondition(It.IsAny<Expression<Func<User, bool>>>()))
                  .ReturnsAsync(new List<User> { example });

            await service.Update(example);

            repMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        }



        [Theory]
        [MemberData(nameof(UpdateIncorrectUser))]
        public async Task UpdateAsync_NewUser_ShouldNotCreateNewUser(User model)
        {
            var example = model;

            var ex = await Assert.ThrowsAnyAsync<Exception>(() => service.Update(example));


            Assert.True(ex is ArgumentException || ex is ArgumentNullException);


            repMoq.Verify(x => x.Update(It.IsAny<User>()), Times.Never);
        }


        [Fact]
        public async void GetByIdAsync_NullUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.GetById(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.FindByCondition(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }


        [Fact]
        public async void DeleteAsync_NullUser_ShullThrowArgumentExpression()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Delete(-1));

            Assert.IsType<ArgumentNullException>(ex);
            repMoq.Verify(x => x.Delete(It.IsAny<User>()), Times.Never);
        }



    }
}