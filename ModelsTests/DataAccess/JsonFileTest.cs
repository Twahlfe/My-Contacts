using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DataAccess;
using Models.Models;

namespace ModelsTests.DataAccess
{
    [TestClass()]
    public class JsonFileTesting
    {
        [TestMethod()]
        public void JsonFileTest()
        {
            AssertSaveContacts();

            AssertGetContacts();
        }

        private void AssertSaveContacts()
        {
            // Arrange
            string Path = Directory.GetCurrentDirectory() + @"\..\..\..\..\Data\Contacts_test.json";
            // Delete previous test files
            if (File.Exists(Path)) File.Delete(Path);
            Contacts contacts = new Contacts();
            contacts.Add(new Contact() { FirstName = "Al", LastName = "One", Email = "hereiam@home.com", DayPhone = 1118675309, EveningPhone = 1118675310, Address = "123 Alphabet Street, Calgary, AB" });
            contacts.Add(new Contact() { FirstName = "Bill", LastName = "Two", Email = "thereiam@work.com", DayPhone = 2228675309, EveningPhone = 2228675310, Address = "786 Soup Avenue, Calgary, AB" });
            contacts.Add(new Contact() { FirstName = "Charles", LastName = "Three", Email = "thereiam@play.com", DayPhone = 3338675309, EveningPhone = 3338675310, Address = "234 Williams Avenue, Calgary, AB" });
            contacts.Add(new Contact() { FirstName = "Dan", LastName = "Four", Email = "thereiam@night.com", DayPhone = 4448675309, EveningPhone = 4448675310, Address = "576 Seasame Street, Calgary, AB" });
            // Act
            bool actual = JsonFile.SaveContacts(contacts, Path);
            // Assert
            Assert.IsTrue(actual);
        }

        private void AssertGetContacts()
        {
            // Arrange
            string Path = Directory.GetCurrentDirectory() + @"\..\..\..\..\Data\Contacts_test.json";
            Assert.IsTrue(File.Exists(Path));
            Contacts expected = new Contacts();
            expected.Add(new Contact() { FirstName = "Al", LastName = "One", Email = "hereiam@home.com", DayPhone = 1118675309, EveningPhone = 1118675310, Address = "123 Alphabet Street, Calgary, AB" });
            expected.Add(new Contact() { FirstName = "Bill", LastName = "Two", Email = "thereiam@work.com", DayPhone = 2228675309, EveningPhone = 2228675310, Address = "786 Soup Avenue, Calgary, AB" });
            expected.Add(new Contact() { FirstName = "Charles", LastName = "Three", Email = "thereiam@play.com", DayPhone = 3338675309, EveningPhone = 3338675310, Address = "234 Williams Avenue, Calgary, AB" });
            expected.Add(new Contact() { FirstName = "Dan", LastName = "Four", Email = "thereiam@night.com", DayPhone = 4448675309, EveningPhone = 4448675310, Address = "576 Seasame Street, Calgary, AB" });

            // Act
            var actual = JsonFile.GetContacts(Path);

            // Assert
            Assert.IsInstanceOfType(actual, typeof(Contacts));
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].FirstName, actual[0].FirstName);
            Assert.AreEqual(expected[1].FirstName, actual[1].FirstName);
            Assert.AreEqual(expected[2].FirstName, actual[2].FirstName);
            Assert.AreEqual(expected[3].FirstName, actual[3].FirstName);
            Assert.AreEqual(expected[0].LastName, actual[0].LastName);
            Assert.AreEqual(expected[1].LastName, actual[1].LastName);
            Assert.AreEqual(expected[2].LastName, actual[2].LastName);
            Assert.AreEqual(expected[3].LastName, actual[3].LastName);
            Assert.AreEqual(expected[0].Email, actual[0].Email);
            Assert.AreEqual(expected[1].Email, actual[1].Email);
            Assert.AreEqual(expected[2].Email, actual[2].Email);
            Assert.AreEqual(expected[3].Email, actual[3].Email);
            Assert.AreEqual(expected[0].DayPhone, actual[0].DayPhone);
            Assert.AreEqual(expected[1].DayPhone, actual[1].DayPhone);
            Assert.AreEqual(expected[2].DayPhone, actual[2].DayPhone);
            Assert.AreEqual(expected[3].DayPhone, actual[3].DayPhone);
            Assert.AreEqual(expected[0].EveningPhone, actual[0].EveningPhone);
            Assert.AreEqual(expected[1].EveningPhone, actual[1].EveningPhone);
            Assert.AreEqual(expected[2].EveningPhone, actual[2].EveningPhone);
            Assert.AreEqual(expected[3].EveningPhone, actual[3].EveningPhone);
            Assert.AreEqual(expected[0].Address, actual[0].Address);
            Assert.AreEqual(expected[1].Address, actual[1].Address);
            Assert.AreEqual(expected[2].Address, actual[2].Address);
            Assert.AreEqual(expected[3].Address, actual[3].Address);

        }
    }


}
