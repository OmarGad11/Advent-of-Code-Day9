using NUnit.Framework;
using LavaTube;

namespace LavaTube.Tests
{
    [TestFixture]
     public class PuzzleSolutionTests
    {
        private List<List<int>> _height_map;
        private PuzzleSolution _solution;

        [SetUp]
        public void SetUp()
        {
            _height_map = new List<List<int>>
            {
                new List<int> { 2, 1, 9, 9, 9, 4, 3, 2, 1, 0 },
                new List<int> { 3, 9, 8, 7, 8, 9, 4, 9, 2, 1 },
                new List<int> { 9, 8, 5, 6, 7, 8, 9, 8, 9, 2 },
                new List<int> { 8, 7, 6, 7, 8, 9, 6, 7, 8, 9 },
                new List<int> { 9, 8, 9, 9, 9, 6, 5, 6, 7, 8 },
            };

            _solution = new PuzzleSolution(_height_map);           
        }

        [Test]
        public void TestIsValid_ValidRowAndCol_ReturnsTrue()
        {
            int valid_row = 2;
            int valid_col = 3;

            bool result = _solution.IsValid(valid_row, valid_col);

            Assert.IsTrue(result);
        }

        [Test]
        public void TestIsValid_InvalidRow_ReturnsFalse()
        {
            int invalid_row = -1;
            int valid_col = 3;
            bool result = _solution.IsValid(invalid_row, valid_col);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestIsValid_InvalidCol_ReturnsFalse()
        {
            int valid_row = 2;
            int invalid_col = -1;
            bool result = _solution.IsValid(valid_row, invalid_col);

            Assert.IsFalse(result);
        }

        [Test]
        public void TestGetRiskLevelSum()
        {
            int result = _solution.GetRiskLevelSum();
            int expected_result = 15;

            Assert.AreEqual(expected_result, result);
        }

        [Test]
        public void TestBasinsProduct()
        {
            int result = _solution.BasinsProduct(3);
            int expected_result = 1134;

            Assert.AreEqual(expected_result, result);
        } 

        [Test]
        public void TestNeighbours()
        {   
            int row = 1;
            int col = 1;
            List<int> result = _solution.GetNeighbors(row,col);
            List<int> expected_output = new List<int> {1,3,8,8};
            CollectionAssert.AreEquivalent(expected_output, result);
        } 
    }
}
