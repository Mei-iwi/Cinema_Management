using Cinema_Management;
using Common;
using TheaterRoomForm;
namespace TicketTypeForm
{
    public partial class Form1 : Form
    {
        string str = ConnectionHelper.CreateConnectionString(Login.DataSource, Login.InitialCatalog, "sqlserver", "123456789");



        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ticket;


            //Thêm ảnh vào button

            foreach (Button btn in grpChucnag.Controls.OfType<Button>())
            {
                btn.TextAlign = ContentAlignment.MiddleRight;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
            }

            btnClose.TextAlign = ContentAlignment.MiddleRight;

            btnClose.ImageAlign = ContentAlignment.MiddleLeft;


            btnAdd.Image = new Bitmap(Properties.Resources.addnew.ToBitmap(), new Size(40, 40));

            btnDelete.Image = new Bitmap(Properties.Resources.delete.ToBitmap(), new Size(40, 40));

            btnUpdate.Image = new Bitmap(Properties.Resources.change.ToBitmap(), new Size(40, 40));

            btnSave.Image = new Bitmap(Properties.Resources.save.ToBitmap(), new Size(40, 40));

            btnClose.Image = new Bitmap(Properties.Resources.close.ToBitmap(), new Size(35, 35));
        }
    }
}
