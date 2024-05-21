using practice02.PSS.lisatsaturyan.Practice02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace UserTestView
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

        [TestMethod]
        public void UserView_CompareTo_Returns_Zero_For_Equal_Ids()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("1", "User2", "Step2", "Category2", false);

            // Act
            int comparisonResult = user1.CompareTo(user2);

            // Assert
            Assert.AreEqual(0, comparisonResult);
        }

        [TestMethod]
        public void UserView_CompareTo_Returns_Positive_For_Greater_Id()
        {
            // Arrange
            var user1 = new UserView("2", "User1", "Step1", "Category1", true);
            var user2 = new UserView("1", "User2", "Step2", "Category2", false);

            // Act
            int comparisonResult = user1.CompareTo(user2);

            // Assert
            Assert.IsTrue(comparisonResult > 0);
        }

        [TestMethod]
        public void UserView_CompareTo_Returns_Negative_For_Lesser_Id()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("2", "User2", "Step2", "Category2", false);

            // Act
            int comparisonResult = user1.CompareTo(user2);

            // Assert
            Assert.IsTrue(comparisonResult < 0);
        }

        [TestMethod]
        public void UserView_Operators_Work_Correctly()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            var user2 = new UserView("2", "User2", "Step2", "Category2", false);
            var user3 = new UserView("1", "User3", "Step3", "Category3", true);

            // Act & Assert
            Assert.IsTrue(user1 < user2);
            Assert.IsTrue(user2 > user1);
            Assert.IsTrue(user1 <= user3);
            Assert.IsTrue(user1 >= user3);
        }

        [TestMethod]
        public void UserView_CompareTo_Returns_Zero_For_Two_Null_Objects()
        {
            // Arrange
            UserView user1 = null;
            UserView user2 = null;

            // Act
            int comparisonResult = Comparer<UserView>.Default.Compare(user1, user2);

            // Assert
            Assert.AreEqual(0, comparisonResult);
        }

        [TestMethod]
        public void UserView_CompareTo_Returns_Positive_For_NonNull_Compared_To_Null()
        {
            // Arrange
            var user1 = new UserView("1", "User1", "Step1", "Category1", true);
            UserView user2 = null;

            // Act
            int comparisonResult = Comparer<UserView>.Default.Compare(user1, user2);

            // Assert
            Assert.IsTrue(comparisonResult > 0);
        }

        [TestMethod]
        public void UserView_CompareTo_Returns_Negative_For_Null_Compared_To_NonNull()
        {
            // Arrange
            UserView user1 = null;
            var user2 = new UserView("1", "User2", "Step2", "Category2", false);

            // Act
            int comparisonResult = Comparer<UserView>.Default.Compare(user1, user2);

            // Assert
            Assert.IsTrue(comparisonResult < 0);
        }

        [TestMethod]
        public void UserView_CompareTo_A_Case()
        {
            // Arrange
            var userA = new UserView("1", "UserA", "Step1", "Category1", true);

            // Act
            int comparisonResult = userA.CompareTo(userA);

            // Assert
            Assert.AreEqual(0, comparisonResult);
        }

        [TestMethod]
        public void UserView_CompareTo_A_B_Case()
        {
            // Arrange
            var userA = new UserView("1", "UserA", "Step1", "Category1", true);
            var userB = new UserView("1", "UserB", "Step2", "Category2", false);

            // Act
            int comparisonResultAtoB = userA.CompareTo(userB);
            int comparisonResultBtoA = userB.CompareTo(userA);

            // Assert
            Assert.AreEqual(comparisonResultAtoB, comparisonResultBtoA);
            Assert.AreEqual(0, comparisonResultAtoB);
            Assert.AreEqual(0, comparisonResultBtoA);
        }

        [TestMethod]
        public void UserView_CompareTo_A_B_C_Case()
        {
            // Arrange
            var userA = new UserView("1", "UserA", "Step1", "Category1", true);
            var userB = new UserView("1", "UserB", "Step2", "Category2", false);
            var userC = new UserView("1", "UserC", "Step3", "Category3", true);

            // Act
            int comparisonResultAtoB = userA.CompareTo(userB);
            int comparisonResultBtoC = userB.CompareTo(userC);
            int comparisonResultAtoC = userA.CompareTo(userC);

            // Assert
            Assert.AreEqual(comparisonResultAtoB, comparisonResultBtoC);
            Assert.AreEqual(comparisonResultAtoC, comparisonResultBtoC);
            Assert.AreEqual(0, comparisonResultAtoB);
            Assert.AreEqual(0, comparisonResultBtoC);
            Assert.AreEqual(0, comparisonResultAtoC);
        }

        [TestMethod]
        public void UserView_CompareTo_Opposite_Sign()
        {
            // Arrange
            var userA = new UserView("1", "UserA", "Step1", "Category1", true);
            var userB = new UserView("2", "UserB", "Step2", "Category2", false);

            // Act
            int comparisonResultAtoB = userA.CompareTo(userB);
            int comparisonResultBtoA = userB.CompareTo(userA);

            // Assert
            Assert.AreEqual(comparisonResultAtoB, -comparisonResultBtoA);
        }

        [TestMethod]
        public void UserView_CompareTo_Same_Sign()
        {
            // Arrange
            var userA = new UserView("1", "UserA", "Step1", "Category1", true);
            var userB = new UserView("2", "UserB", "Step2", "Category2", false);
            var userC = new UserView("3", "UserC", "Step3", "Category3", true);

            // Act
            int comparisonResultAtoB = userA.CompareTo(userB);
            int comparisonResultBtoC = userB.CompareTo(userC);
            int comparisonResultAtoC = userA.CompareTo(userC);

            // Assert
            Assert.IsTrue(comparisonResultAtoB < 0);
            Assert.IsTrue(comparisonResultBtoC < 0);
            Assert.IsTrue(comparisonResultAtoC < 0);
        }
    }
}
