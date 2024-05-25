using Microsoft.VisualStudio.TestTools.UnitTesting;
using practice02.PSS.lisatsaturyan.Practice02;
using practice02;
using System.Collections.Generic;

namespace SequenceTest

{
        [TestClass]
        public class SequenceTests
        {
            [TestMethod]
            public void Add_AddsItemToSequence()
            {
                // Arrange
                var sequence = new Sequence<int>();

                // Act
                sequence.Add(1);

                // Assert
                Assert.AreEqual(1, sequence.Count);
                Assert.IsTrue(sequence.Contains(1));
            }

            [TestMethod]
            public void Remove_RemovesItemFromSequence()
            {
                // Arrange
                var sequence = new Sequence<int>();
                sequence.Add(1);

                // Act
                var removed = sequence.Remove(1);

                // Assert
                Assert.IsTrue(removed);
                Assert.AreEqual(0, sequence.Count);
                Assert.IsFalse(sequence.Contains(1));
            }

            [TestMethod]
            public void Clear_RemovesAllItemsFromSequence()
            {
                // Arrange
                var sequence = new Sequence<int>();
                sequence.Add(1);
                sequence.Add(2);

                // Act
                sequence.Clear();

                // Assert
                Assert.AreEqual(0, sequence.Count);
            }

            [TestMethod]
            public void Indexer_GetsAndSetsItems()
            {
                // Arrange
                var sequence = new Sequence<int>();
                sequence.Add(1);
                sequence.Add(2);

                // Act
                sequence[1] = 3;

                // Assert
                Assert.AreEqual(3, sequence[1]);
            }

            [TestMethod]
            public void Sort_SortsItemsUsingComparer()
            {
                // Arrange
                var sequence = new Sequence<int>();
                sequence.Add(3);
                sequence.Add(1);
                sequence.Add(2);

                // Act
                sequence.Sort(Comparer<int>.Default);

                // Assert
                Assert.AreEqual(1, sequence[0]);
                Assert.AreEqual(2, sequence[1]);
                Assert.AreEqual(3, sequence[2]);
            }

            [TestMethod]
            public void DefaultEnumerator_IteratesInReverseOrder()
            {
                // Arrange
                var sequence = new Sequence<int>();
                sequence.Add(1);
                sequence.Add(2);
                sequence.Add(3);

                // Act
                var result = new List<int>();
                foreach (var item in sequence)
                {
                    result.Add(item);
                }

                // Assert
                CollectionAssert.AreEqual(new List<int> { 3, 2, 1 }, result);
            }

            [TestMethod]
            public void RecordoAdelante_IteratesInForwardOrder()
            {
                // Arrange
                var sequence = new Sequence<int>();
                sequence.Add(1);
                sequence.Add(2);
                sequence.Add(3);

                // Act
                var result = new List<int>();
                foreach (var item in sequence.RecordoAdelante)
                {
                    result.Add(item);
                }

                // Assert
                CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, result);
            }

            [TestMethod]
            public void BackTravel_IteratesInReverseOrder()
            {
                // Arrange
                var sequence = new Sequence<int>();
                sequence.Add(1);
                sequence.Add(2);
                sequence.Add(3);

                // Act
                var result = new List<int>();
                foreach (var item in sequence.BackTravel)
                {
                    result.Add(item);
                }

                // Assert
                CollectionAssert.AreEqual(new List<int> { 3, 2, 1 }, result);
            }

            [TestMethod]
            public void UpPath_IteratesInAscendingOrder()
            {
                // Arrange
                var sequence = new Sequence<int>();
                sequence.Add(3);
                sequence.Add(1);
                sequence.Add(2);

                // Act
                var result = new List<int>();
                foreach (var item in sequence.UpPath)
                {
                    result.Add(item);
                }

                // Assert
                CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, result);
            }

            [TestMethod]
            public void DescendingPath_IteratesInDescendingOrder()
            {
                // Arrange
                var sequence = new Sequence<int>();
                sequence.Add(1);
                sequence.Add(3);
                sequence.Add(2);

                // Act
                var result = new List<int>();
                foreach (var item in sequence.DescendingPath)
                {
                    result.Add(item);
                }

                // Assert
                CollectionAssert.AreEqual(new List<int> { 3, 2, 1 }, result);
            }
        }
    }

