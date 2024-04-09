using Models;
using Models.DataAccess;
using Models.Models;
using Controller;

namespace ControllerTests
{
    [TestClass()]
    public class BinaryFileTests
    {
        [TestMethod()]
        public void TestMethod1()
        {
            SaveBinaryFile();

            OpenBinaryFile();            

        }

        private void SaveBinaryFile()
        {
            string Path = Directory.GetCurrentDirectory() + @"\..\..\..\..\Data\Contacts_test.dat";
            if (File.Exists(Path)) File.Delete(Path);

            Contacts contacts = new Contacts();
            contacts.Add(new Contact() { FirstName = "Al", LastName = "One", Email = "hereiam@home.com", DayPhone = 1118675309, EveningPhone = 1118675310, Address = "123 Alphabet Street, Calgary, AB" });
            contacts.Add(new Contact() { FirstName = "Bill", LastName = "Two", Email = "thereiam@work.com", DayPhone = 2228675309, EveningPhone = 2228675310, Address = "786 Soup Avenue, Calgary, AB" });
            contacts.Add(new Contact() { FirstName = "Charles", LastName = "Three", Email = "thereiam@play.com", DayPhone = 3338675309, EveningPhone = 3338675310, Address = "234 Williams Avenue, Calgary, AB" });

            bool actual = Files.SaveFile(contacts, Path);
            Assert.IsTrue(actual);

        }

        private void OpenBinaryFile()
        {
            // Please make sure the save file exists
            string Path = Directory.GetCurrentDirectory() + @"\..\..\..\..\Data\Contacts_test.dat";
            Assert.IsTrue(File.Exists(Path));

            Contacts expected = new Contacts();
            expected.Add(new Contact() { FirstName = "Al", LastName = "One", Email = "hereiam@home.com", DayPhone = 1118675309, EveningPhone = 1118675310, Address = "123 Alphabet Street, Calgary, AB" });
            expected.Add(new Contact() { FirstName = "Bill", LastName = "Two", Email = "thereiam@work.com", DayPhone = 2228675309, EveningPhone = 2228675310, Address = "786 Soup Avenue, Calgary, AB" });
            expected.Add(new Contact() { FirstName = "Charles", LastName = "Three", Email = "thereiam@play.com", DayPhone = 3338675309, EveningPhone = 3338675310, Address = "234 Williams Avenue, Calgary, AB" });

            var actual = Files.OpenFile(Path);
            Assert.IsInstanceOfType(actual, typeof(Contacts));

            Assert.AreEqual(expected.Count, actual?.Count);

        }
        
    }
}