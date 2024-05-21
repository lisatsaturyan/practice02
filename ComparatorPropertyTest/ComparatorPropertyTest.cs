using practice02.PSS.lisatsaturyan.Practice02;

namespace ComparatorPropertyTest
{
    [TestClass]
    public class ComparatorPropertyTests
    {
        [TestMethod]
        public void ComparatorProperty_SortsUserViewsById()
        {
            // Arrange
            var users = new List<UserView>
            {
                new UserView("3", "UserC", "Step1", "Category1", true),
                new UserView("1", "UserA", "Step1", "Category1", true),
                new UserView("2", "UserB", "Step1", "Category1", true)
            };

            var comparator = new ComparatorProperty<UserView>("Id");

            // Act
            users.Sort(comparator);

            // Assert
            Assert.AreEqual("1", users[0].Id);
            Assert.AreEqual("2", users[1].Id);
            Assert.AreEqual("3", users[2].Id);
        }

        [TestMethod]
        public void ComparatorProperty_SortsUserViewsByName()
        {
            // Arrange
            var users = new List<UserView>
            {
                new UserView("3", "UserC", "Step1", "Category1", true),
                new UserView("1", "UserA", "Step1", "Category1", true),
                new UserView("2", "UserB", "Step1", "Category1", true)
            };

            var comparator = new ComparatorProperty<UserView>("Name");

            // Act
            users.Sort(comparator);

            // Assert
            Assert.AreEqual("UserA", users[0].Name);
            Assert.AreEqual("UserB", users[1].Name);
            Assert.AreEqual("UserC", users[2].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ComparatorProperty_ThrowsException_WhenComparingNulls()
        {
            // Arrange
            var comparator = new ComparatorProperty<UserView>("Id");

            // Act
            comparator.Compare(null, null);
        }

        [TestMethod]
        public void ComparatorProperty_ThrowsException_WhenPropertyNotFound()
        {
            // Arrange
            var users = new List<UserView>
            {
                new UserView("3", "UserC", "Step1", "Category1", true),
                new UserView("1", "UserA", "Step1", "Category1", true),
                new UserView("2", "UserB", "Step1", "Category1", true)
            };

            var comparator = new ComparatorProperty<UserView>("NonExistentProperty");

            // Act & Assert
            try
            {
                users.Sort(comparator);
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, "Property 'NonExistentProperty' not found in type UserView");
            }
        }
    }
}
