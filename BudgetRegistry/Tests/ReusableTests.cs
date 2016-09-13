using BudgetRegistry.Model;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BudgetRegistry.Model.Reusable;

namespace BudgetRegistry.Tests
{
    [TestFixture]
    public class ReusableTests
    {
        private Mock<IContext> _myContext;
        private Mock<DbSet<CategoryModel>> _categorySet;
        private Mock<DbSet<UserModel>> _userSet;
        private Mock<DbSet<SpendingItemModel>> _spendingItemSet;
        private Mock<DbSet<IncomeItemModel>> _incomeItemSet;

        [SetUp]
        public void Setup()
        {
            _myContext = new Mock<IContext>();
            _categorySet = new Mock<DbSet<CategoryModel>>();
            _userSet = new Mock<DbSet<UserModel>>();
            _spendingItemSet = new Mock<DbSet<SpendingItemModel>>();
            _incomeItemSet = new Mock<DbSet<IncomeItemModel>>();
            var userData = new List<UserModel> {
                new UserModel { Id = 1, UserName = "test", Password = "asd" } }.AsQueryable();
            _userSet.As<IQueryable<UserModel>>().Setup(m => m.Provider).Returns(userData.Provider);
            _userSet.As<IQueryable<UserModel>>().Setup(m => m.Expression).Returns(userData.Expression);
            _userSet.As<IQueryable<UserModel>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            _userSet.As<IQueryable<UserModel>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());
            _myContext.Setup(m => m.Users).Returns(_userSet.Object);

            var categoryData = new List<CategoryModel>
            {
                new CategoryModel { Id = 1, Name = "alma" }
            }.AsQueryable();
            _categorySet.As<IQueryable<CategoryModel>>().Setup(m => m.Provider).Returns(categoryData.Provider);
            _categorySet.As<IQueryable<CategoryModel>>().Setup(m => m.Expression).Returns(categoryData.Expression);
            _categorySet.As<IQueryable<CategoryModel>>().Setup(m => m.ElementType).Returns(categoryData.ElementType);
            _categorySet.As<IQueryable<CategoryModel>>().Setup(m => m.GetEnumerator()).Returns(categoryData.GetEnumerator());
            _myContext.Setup(m => m.Categroies).Returns(_categorySet.Object);

            var spendingData = new List<SpendingItemModel>
            {
                new SpendingItemModel { Id = 1, CategoryId = 1, LastValue = 0, Name = "kutya" }
            }.AsQueryable();
            _spendingItemSet.As<IQueryable<SpendingItemModel>>().Setup(m => m.Provider).Returns(spendingData.Provider);
            _spendingItemSet.As<IQueryable<SpendingItemModel>>().Setup(m => m.Expression).Returns(spendingData.Expression);
            _spendingItemSet.As<IQueryable<SpendingItemModel>>().Setup(m => m.ElementType).Returns(spendingData.ElementType);
            _spendingItemSet.As<IQueryable<SpendingItemModel>>().Setup(m => m.GetEnumerator()).Returns(spendingData.GetEnumerator());
            _myContext.Setup(m => m.SpendingItems).Returns(_spendingItemSet.Object);

            var incomeData = new List<IncomeItemModel>
            {
                new IncomeItemModel { Id = 1, CategoryId = 1, LastValue = 0, Name = "fizetes" },
                new IncomeItemModel { Id = 2, CategoryId = 1, LastValue = 0, Name = "eloleg" }
            }.AsQueryable();
            _incomeItemSet.As<IQueryable<IncomeItemModel>>().Setup(m => m.Provider).Returns(incomeData.Provider);
            _incomeItemSet.As<IQueryable<IncomeItemModel>>().Setup(m => m.Expression).Returns(incomeData.Expression);
            _incomeItemSet.As<IQueryable<IncomeItemModel>>().Setup(m => m.ElementType).Returns(incomeData.ElementType);
            _incomeItemSet.As<IQueryable<IncomeItemModel>>().Setup(m => m.GetEnumerator()).Returns(incomeData.GetEnumerator());
            _myContext.Setup(m => m.IncomeItems).Returns(_incomeItemSet.Object);
        }

        [Test]
        public void CheckUser_ShouldReturnUser()
        {
            //Arrange


            //Act
            var user = Reusable.CheckUserModel(_myContext.Object, "test");
            //Assert
            user.Should().NotBeNull();            
        }
        
        [Test]
        public void CheckCategory_ShouldReturnCategory()
        {
            //Arrange

            //Act
            var category = Reusable.CheckCategory(_myContext.Object, "alma");
            //
            category.Should().NotBeNull();
        }

        [Test]
        public void CheckSpendingItem_ShouldReturnSpendingItem()
        {
            //Arrange

            //Act
            var item = Reusable.CheckSpendingItem(_myContext.Object, "kutya");
            //
            item.Should().NotBeNull();
        }

        [Test]
        public void CheckIncomeItem_ShouldReturnIncomeItem()
        {
            //Arrange

            //Act
            var income = Reusable.CheckIncomeItem(_myContext.Object, "fizetes");
            //
            income.Should().NotBeNull();
        }

        [Test]
        public void GetForm_ShouldReturnNull()
        {
            var form = (MainForm)Reusable.GetForm("BudgetRegistry.MainForm");

            form.Should().BeNull();           
        }

        [Test]
        public void TotalSpendingIncome_ShouldUpdateStats()
        {
            //Arrange
            var stats = new List<Stats> {
                new Stats {Id = DateTime.Now.Month },                
            };
            var spending = new List<SpendingModel>
            {
                new SpendingModel {Id = 0, CreatedTime = DateTime.Now, SpendingItemId = 1, UserId = 1, Value = 30 }
            }.AsQueryable();
            var income = new List<IncomeModel>
            {
                new IncomeModel {Id = 0, CreatedTime = DateTime.Now, IncomeItemId = 1, UserId = 1, Value = 30 }
            }.AsQueryable();
            //Act
            Reusable.TotalSpendingIncome(stats, spending, income, false);

            //Assert
            stats[0].Difference.Should().Be(0);
            stats[0].TotalIncome.Should().Be(30);
            stats[0].TotalSpending.Should().Be(30);
            stats[0].Difference.Should().Be(0);

        }

        [Test]
        public void CategoryStats_ShouldReturnStatsPerCategory()
        {
            //Arrange
            var spending = new List<SpendingModel>
            {
                new SpendingModel {Id = 0, CreatedTime = DateTime.Now, SpendingItemId = 1, UserId = 1, Value = 30 }
            };
            var income = new List<IncomeModel>
            {
                new IncomeModel {Id = 0, CreatedTime = DateTime.Now, IncomeItemId = 1, UserId = 1, Value = 30 }
            };            
            //Act
            var stats = Reusable.CategoryStats(_myContext.Object, spending, income);
            //Assert
            stats.Should().NotBeNull();
        }

        [Test]
        public void PercentStats_ShouldUpdateRows()
        {
            //Arrange
            var grid = new DataGridView();
            List<Stats> stats = new List<Stats>
            {
                new Stats { Id = 1, Name = "alma", TotalIncome = 3, TotalSpending = 2, Difference = 1 },
                new Stats { Id = 2, Name = "korte", TotalIncome = 5, TotalSpending = 2, Difference = 2 },
                new Stats { Id = 3, Name = "eper", TotalIncome = 7, TotalSpending = 2, Difference = 5 }
            };
            grid.DataSource = stats;
            //Act
            Reusable.PercentStats(grid);
            //Assert
            foreach(DataGridViewRow row in grid.Rows)
            {
                row.Cells[5].Should().NotBeNull();
                row.Cells[6].Should().NotBeNull();
            }

        }
    }
}
