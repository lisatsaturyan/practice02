using practice02.PSS.lisatsaturyan.Practice02;
using static System.Net.Mime.MediaTypeNames;

namespace CollectionUserViewTest
{
  
    [TestClass]
    public class CollectionTests
    {
        [TestMethod]
        public void List_Contains_Finds_User_By_Id()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("2", "User2", "Step2", "Category2", false);
            var userList = new List<UserView> { user1, user2 };

            // Act & Assert
            Assert.IsTrue(userList.Contains(user1));
            Assert.IsTrue(userList.Contains(user2));
        }

        [TestMethod]
        public void List_IndexOf_Finds_User_By_Id()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("2", "User2", "Step2", "Category2", false);
            var userList = new List<UserView> { user1, user2 };

            // Act & Assert
            Assert.AreEqual(0, userList.IndexOf(user1));
            Assert.AreEqual(1, userList.IndexOf(user2));
        }

        [TestMethod]
        public void List_LastIndexOf_Finds_User_By_Id()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("2", "User2", "Step2", "Category2", false);
            var userList = new List<UserView> { user1, user2, user1 };

            // Act & Assert
            Assert.AreEqual(2, userList.LastIndexOf(user1));
            Assert.AreEqual(1, userList.LastIndexOf(user2));
        }

        [TestMethod]
        public void List_Remove_Removes_User_By_Id()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("2", "User2", "Step2", "Category2", false);
            var userList = new List<UserView> { user1, user2 };

            // Act
            bool removed = userList.Remove(user1);

            // Assert
            Assert.IsTrue(removed);
            Assert.IsFalse(userList.Contains(user1));
        }

        [TestMethod]
        public void Dictionary_Get_Id_By_UserView()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("2", "User2", "Step2", "Category2", false);
            var userDictionary = new Dictionary<UserView, string>
            {
                { user1, user1.Id },
                { user2, user2.Id }
            };

            // Act & Assert
            Assert.AreEqual("1", userDictionary[user1]);
            Assert.AreEqual("2", userDictionary[user2]);
        }

        [TestMethod]
        public void Dictionary_Does_Not_Allow_Duplicate_Ids()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var userDuplicate = new UserView("1", "UserDuplicate", "Step2", "Category2", false);
            var userDictionary = new Dictionary<UserView, string>
            {
                { user1, user1.Id }
            };

            // Act
            bool duplicateAdded = false;
            try
            {
                userDictionary.Add(userDuplicate, userDuplicate.Id);
            }
            catch
            {
                duplicateAdded = true;
            }

            // Assert
            Assert.IsTrue(duplicateAdded);
        }
    }
}
