using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models.DataAccess;



namespace ModelsTests.DataAccess
{
    [TestClass()]
    public class BinaryFileTesting
    {
        [TestMethod()]
        public void SaveContactsTest()
        {
            // Arrange
            string testPath = System.IO.Directory.GetCurrentDirectory() + @"..\..\..\..\Data\Contacts_test.dat";
            // Delete and previous test files
            if (System.IO.File.Exists(testPath)) System.IO.File.Delete(testPath);

            List<Contact> contacts = new List<Contact>();
            contacts.Add(new Contact() { firstName = "Al", lastName = "One", email = "hereiam@home.com", dayPhone = 1118675309, eveningPhone = 1118675310, Address = "123 Alphabet Street, Calgary, AB" });
            contacts.Add(new Contact() { firstName = "Bill", lastName = "Two", email = "thereiam@work.com", dayPhone = 2228675309, eveningPhone = 2228675310, Address = "786 Soup Avenue, Calgary, AB" });
            contacts.Add(new Contact() { firstName = "Charles", lastName = "Three", email = "thereiam@play.com", dayPhone = 3338675309, eveningPhone = 3338675310, Address = "234 Williams Avenue, Calgary, AB" });
            contacts.Add(new Contact() { firstName = "Dan", lastName = "Four", email = "thereiam@night.com", dayPhone = 4448675309, eveningPhone = 4448675310, Address = "576 Seasame Street, Calgary, AB" });
            // Act
            bool actual = BinaryFile.SaveContacts(contacts, testPath);
            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void GetContactsTest()
        {
            // Arrange
            string testPath = System.IO.Directory.GetCurrentDirectory() + @"..\..\..\..\Data\Contacts_test.dat";
            Assert.IsTrue(System.IO.File.Exists(testPath));
            List<Contact> expected = new List<Contact>();
            expected.Add(new Contact() { firstName = "Al", lastName = "One", email = "hereiam@home.com", dayPhone = 1118675309, eveningPhone = 1118675310, address = "123 Alphabet Street, Calgary, AB" });
            expected.Add(new Contact() { firstName = "Bill", lastName = "Two", email = "thereiam@work.com", dayPhone = 2228675309, eveningPhone = 2228675310, address = "786 Soup Avenue, Calgary, AB" });
            expected.Add(new Contact() { firstName = "Charles", lastName = "Three", email = "thereiam@play.com", dayPhone = 3338675309, eveningPhone = 3338675310, address = "234 Williams Avenue, Calgary, AB" });
            expected.Add(new Contact() { firstName = "Dan", lastName = "Four", email = "thereiam@night.com", dayPhone = 4448675309, eveningPhone = 4448675310, address = "576 Seasame Street, Calgary, AB" });

            // Act
            var actual = BinaryFileTesting.GetContacts(testPath);

            // Assert
            Assert.IsInstanceOfType(actual, typeof(List<Contact>));
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].firstName, actual.firstName);
            Assert.AreEqual(expected[1].firstName, actual.firstName);
            Assert.AreEqual(expected[2].firstName, actual.firstName);
            Assert.AreEqual(expected[3].firstName, actual.firstName);
            Assert.AreEqual(expected[0].lastName, actual.lastName);
            Assert.AreEqual(expected[1].lastName, actual.lastName);
            Assert.AreEqual(expected[2].lastName, actual.lastName);
            Assert.AreEqual(expected[3].lastName, actual.lastName);
            Assert.AreEqual(expected[0].email, actual.email);
            Assert.AreEqual(expected[1].email, actual.email);
            Assert.AreEqual(expected[2].email, actual.email);
            Assert.AreEqual(expected[3].email, actual.email);
            Assert.AreEqual(expected[0].dayPhone, actual.dayPhone);
            Assert.AreEqual(expected[1].dayPhone, actual.dayPhone);
            Assert.AreEqual(expected[2].dayPhone, actual.dayPhone);
            Assert.AreEqual(expected[3].dayPhone, actual.dayPhone);
            Assert.AreEqual(expected[0].eveningPhone, actual.eveningPhone);
            Assert.AreEqual(expected[1].eveningPhone, actual.eveningPhone);
            Assert.AreEqual(expected[2].eveningPhone, actual.eveningPhone);
            Assert.AreEqual(expected[3].eveningPhone, actual.eveningPhone);
            Assert.AreEqual(expected[0].address, actual.address);
            Assert.AreEqual(expected[1].address, actual.address);
            Assert.AreEqual(expected[2].address, actual.address);
            Assert.AreEqual(expected[3].address, actual.address);

        }
    }
}
