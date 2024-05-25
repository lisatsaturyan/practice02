using Microsoft.VisualStudio.TestTools.UnitTesting;
using practice02.PSS.lisatsaturyan.Practice02;
using practice02;
using System.Collections.Generic;

namespace SequenceTest

{
        [TestClass]
        public class TestSequenceWalk
        {
            public class UsuarioView
            {
                public string Name { get; set; }
                public int Age { get; set; }

                public override bool Equals(object obj)
                {
                    return obj is UsuarioView view &&
                           Name == view.Name &&
                           Age == view.Age;
                }

                public override int GetHashCode()
                {
                    return System.HashCode.Combine(Name, Age);
                }
            }

            [TestMethod]
            public void TestDefaultTraversal()
            {
            var sequence = new Sequence<UsuarioView>();
            var user1 = new UsuarioView { Name = "Alice", Age = 30 };
            var user2 = new UsuarioView { Name = "Bob", Age = 25 };
            var user3 = new UsuarioView { Name = "Charlie", Age = 35 };

                sequence.Add(user1);
                sequence.Add(user2);
                sequence.Add(user3);

            var expected = new List<UsuarioView> { user3, user2, user1 };
            CollectionAssert.AreEqual(expected, new List<UsuarioView>(sequence));
        }

        [TestMethod]
            public void TestRecordoAdelante()
            {
            var sequence = new Sequence<UsuarioView>();
            var user1 = new UsuarioView { Name = "Alice", Age = 30 };
            var user2 = new UsuarioView { Name = "Bob", Age = 25 };
            var user3 = new UsuarioView { Name = "Charlie", Age = 35 };

            sequence.Add(user1);
                sequence.Add(user2);
                sequence.Add(user3);

            var expected = new List<UsuarioView> { user3, user2, user1 };
            CollectionAssert.AreEqual(expected, new List<UsuarioView>(sequence.RecordoAdelante));
        }

        [TestMethod]
        public void TestBackTravel()
        {
            var sequence = new Sequence<UsuarioView>();
            var user1 = new UsuarioView { Name = "Alice", Age = 30 };
            var user2 = new UsuarioView { Name = "Bob", Age = 25 };
            var user3 = new UsuarioView { Name = "Charlie", Age = 35 };

            sequence.Add(user1);
            sequence.Add(user2);
            sequence.Add(user3);

            var expected = new List<UsuarioView> { user3, user2, user1 };
            CollectionAssert.AreEqual(expected, new List<UsuarioView>(sequence.BackTravel));
        }


        [TestMethod]
            public void TestUpPath()
            {
                var sequence = new Sequence<UsuarioView>();
                var user1 = new UsuarioView { Name = "Alice", Age = 30 };
                var user2 = new UsuarioView { Name = "Bob", Age = 25 };
                var user3 = new UsuarioView { Name = "Charlie", Age = 35 };

                sequence.Add(user1);
                sequence.Add(user2);
                sequence.Add(user3);

                var expected = new List<UsuarioView> { user2, user1, user3 };
                CollectionAssert.AreEqual(expected, new List<UsuarioView>(sequence.UpPath));
            }

            [TestMethod]
            public void TestDescendingPath()
            {
                var sequence = new Sequence<UsuarioView>();
                var user1 = new UsuarioView { Name = "Alice", Age = 30 };
                var user2 = new UsuarioView { Name = "Bob", Age = 25 };
                var user3 = new UsuarioView { Name = "Charlie", Age = 35 };

                sequence.Add(user1);
                sequence.Add(user2);
                sequence.Add(user3);

                var expected = new List<UsuarioView> { user3, user1, user2 };
                CollectionAssert.AreEqual(expected, new List<UsuarioView>(sequence.DescendingPath));
            }
        }
    }

