using practice02.PSS.lisatsaturyan.Practice02;

namespace UserViewTest
{
    [TestClass]
    public class UserViewTests
    {
        [TestMethod]
        public void UserView_Equality_True_When_Ids_Are_Equal()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("1", "User2", "Step2", "Category2", false);

            // Act & Assert
            Assert.AreEqual(user1, user2);
            Assert.IsTrue(user1 == user2);
        }

        [TestMethod]
        public void UserView_Equality_False_When_Ids_Are_Different()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("2", "User2", "Step2", "Category2", false);

            // Act & Assert
            Assert.AreNotEqual(user1, user2);
            Assert.IsTrue(user1 != user2);
        }

        [TestMethod]
        public void UserView_GetHashCode_Same_For_Equal_Objects()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("1", "User2", "Step2", "Category2", false);

            // Act & Assert
            Assert.AreEqual(user1.GetHashCode(), user2.GetHashCode());
        }

        [TestMethod]
        public void UserView_GetHashCode_Different_For_Unequal_Objects()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("2", "User2", "Step2", "Category2", false);

            // Act & Assert
            Assert.AreNotEqual(user1.GetHashCode(), user2.GetHashCode());
        }
    }
}