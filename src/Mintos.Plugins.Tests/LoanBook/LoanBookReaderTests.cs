using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mintos.Plugins.LoanBook;
using System.Linq;

namespace Mintos.Plugins.Tests.LoanBook
{
    [TestClass]
    public class LoanBookReaderTests
    {
        private readonly LoanBookReader _sut = new LoanBookReader();

        [TestMethod]
        public void Read_Returns_CorrectAmountOfRecords()
        {
            // Arrange

            // Act
            var result = _sut.Read("LoanBook\\1-500000_loan_book.xlsx");

            // Assert
            Assert.AreEqual(500000, result.ToList().Count);
        }
    }
}
