using My_Contacts_DB.Models.DataLayer;

namespace My_Contacts_DB
{
    public partial class frmDB_Viewer : Form
    {
        public frmDB_Viewer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ContactsContext context = new ContactsContext();
            contactsDG.DataSource = context.Contacts.ToList();
            
        }
    }
}