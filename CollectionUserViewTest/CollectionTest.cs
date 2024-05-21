using practice02.PSS.lisatsaturyan.Practice02;
using static System.Net.Mime.MediaTypeNames;

namespace CollectionUserViewTest
{

    [TestClass]
    public class CollectionTests
    {
        [TestMethod]
        public void Sort_ListOfUserViews_OrderedById()
        {
            // Arrange
            var users = new List<UserView>
            {
                new UserView("3", "UserC", "Step1", "Category1", true),
                new UserView("1", "UserA", "Step1", "Category1", true),
                new UserView("2", "UserB", "Step1", "Category1", true)
            };

            // Act
            users.Sort();

            // Assert
            Assert.AreEqual("1", users[0].Id);
            Assert.AreEqual("2", users[1].Id);
            Assert.AreEqual("3", users[2].Id);
        }
    }
}

