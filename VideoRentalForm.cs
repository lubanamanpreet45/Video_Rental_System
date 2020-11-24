using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Rental_System
{
    public partial class VideoRentalForm : Form
    {
        Database MyDatabase = new Database();
        Crud MyCrud = new Crud();

        public VideoRentalForm()
        {
            InitializeComponent();
            LoadDB();

            /*var DateandTime = DateTime.Now;
            txtDateRented.Text = DateandTime.ToShortDateString();
            txtDateReturned.Text = DateandTime.ToShortDateString();
            TXTDate.Text = DateandTime.ToShortDateString();*/



        }

        private void LoadDB()
        {
            try
            {
                DGVCustomer.DataSource = MyDatabase.FillDataGridViews("Customer");
                DGVCustomer.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                DGVMovies.DataSource = MyDatabase.FillDataGridViews("Movies");
                DGVMovies.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                DGVRentedMovies.DataSource = MyDatabase.FillDataGridViews("RentedMovies");
                DGVRentedMovies.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                DGVMostPopular.DataSource = MyDatabase.FillPopularDGV("MoviesRented");
                DGVMostPopular.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                DGVCustomerRank.DataSource = MyDatabase.FillPopularDGV("CustomersRentedMovies");
                DGVCustomerRank.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }

            catch (System.Exception ex)
            {

                MessageBox.Show(" Error Something went wrong... " + ex.Message);

            }



        }

        private void DGVCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //get ID field of the customer
                int CustID = (int)DGVCustomer.Rows[e.RowIndex].Cells[0].Value;

                DGVRentedMovies.DataSource = MyDatabase.FillOtherDataGridViews("RentedMovies", "CustIDFK", CustID); // when you click on a customer it shows their rented movies


                string newValue = DGVCustomer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                //this.Text = "Row " + e.RowIndex.ToString() + " Col: " + e.ColumnIndex.ToString() + " Value :" + newValue; 

                CustIDtxt.Text = DGVCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
                TXTFirstName.Text = DGVCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                TXTLastName.Text = DGVCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                TXTAddress.Text = DGVCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                TXTPhoneNumber.Text = DGVCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                TXTDate.Text = DGVCustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch (System.Exception)
            {


            }




        }

        private void DGVMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {      
                //get ID field of the movie
                int MovieID = (int)DGVMovies.Rows[e.RowIndex].Cells[0].Value;

                DGVRentedMovies.DataSource = MyDatabase.FillOtherDataGridViews("RentedMovies", "MovieIDFK", MovieID); // when you click on a customer it shows their rented movies

                MovieIDtxt.Text = DGVMovies.Rows[e.RowIndex].Cells[0].Value.ToString();
                TXTRating.Text = DGVMovies.Rows[e.RowIndex].Cells[1].Value.ToString();
                TXTMovieTitle.Text = DGVMovies.Rows[e.RowIndex].Cells[2].Value.ToString();
                TXTYear.Text = DGVMovies.Rows[e.RowIndex].Cells[3].Value.ToString();
                TXTRentalCost.Text = DGVMovies.Rows[e.RowIndex].Cells[4].Value.ToString();
                TXTCopies.Text = DGVMovies.Rows[e.RowIndex].Cells[5].Value.ToString();
                TXTPlot.Text = DGVMovies.Rows[e.RowIndex].Cells[6].Value.ToString();
                TXTGenre.Text = DGVMovies.Rows[e.RowIndex].Cells[7].Value.ToString();
                TXTMovieDate.Text = DGVMovies.Rows[e.RowIndex].Cells[8].Value.ToString();
                btnUpdatePrice.Enabled = true;

            }
            
            catch (Exception)
            {

             
            }

        }

        private void DGVRentedMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var DateandTime = DateTime.Now;
            txtDateRented.Text = DateandTime.ToShortDateString();
            txtDateRented.Text = DGVRentedMovies.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDateReturned.Text = DGVRentedMovies.Rows[e.RowIndex].Cells[4].Value.ToString();

            lblRMID.Text = DGVRentedMovies.Rows[e.RowIndex].Cells[0].Value.ToString();


        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var DateandTime = DateTime.Now;
            TXTDate.Text = DateandTime.ToShortDateString(); //adds the present date of when the customer joined

            MyCrud.AddCustomer(TXTFirstName.Text, TXTLastName.Text, TXTAddress.Text, TXTPhoneNumber.Text, TXTDate.Text);

            MessageBox.Show("Customer has been added");
            LoadDB(); //refreshes the database 

        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            MyCrud.AddMovie(TXTRating.Text, TXTMovieTitle.Text, TXTYear.Text, TXTRentalCost.Text, TXTCopies.Text, TXTPlot.Text, TXTGenre.Text, TXTMovieDate.Text);

            MessageBox.Show("Movie has been added");
            LoadDB();//refreshes the database 
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            MyCrud.DeleteCustomer(CustIDtxt.Text);

            MessageBox.Show("Customer has been Deleted");
            LoadDB();//refreshes the database 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyCrud.DeleteMovie(MovieIDtxt.Text);

            MessageBox.Show("Movie Has been Deleted");
            LoadDB();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            var DateandTime = DateTime.Now;
            txtDateRented.Text = DateandTime.ToShortDateString(); //adds the present date when they press the issue button

            MyCrud.IssueMovie(MovieIDtxt.Text, CustIDtxt.Text, txtDateRented.Text, txtDateReturned.Text);

            MessageBox.Show("You Have issued a Movie");
            LoadDB();//refreshes the database 

        }

        private void btnRent_Click(object sender, EventArgs e) // name is supposed to be btnreturn
        {
            var DateandTime = DateTime.Now;
            txtDateReturned.Text = DateandTime.ToShortDateString();// adds the present date when they returned the movie

            MyCrud.ReturnMovie(txtDateReturned.Text, lblRMID.Text);
            //MovieIDtxt.Text, CustIDtxt.Text, txtDateRented.Text,
            MessageBox.Show("You Have Returned a Movie");
            LoadDB();//refreshes the database 
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            MyCrud.UpdateCustomer(TXTFirstName.Text, TXTLastName.Text, TXTAddress.Text, TXTPhoneNumber.Text, TXTDate.Text, CustIDtxt.Text);
            MessageBox.Show("You Have Updated a Customer");
            LoadDB();//refreshes the database 

        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            MyCrud.UpdateMovie(TXTRating.Text, TXTMovieTitle.Text, TXTYear.Text, TXTRentalCost.Text, TXTCopies.Text, TXTPlot.Text, TXTGenre.Text, TXTMovieDate.Text, MovieIDtxt.Text);

            MessageBox.Show("You Have Updated a Movie");
            LoadDB();//refreshes the database 
        }

        private void btnUpdatePrice_Click(object sender, EventArgs e) 
        {
            if(Convert.ToInt16(TXTYear.Text)<2015)
            {
                MyCrud.UpdateMovieFee1(Convert.ToInt16(MovieIDtxt.Text));
            }
           else
            {
                MyCrud.UpdateMovieFee2(Convert.ToInt16(MovieIDtxt.Text));
            }
            MessageBox.Show("Prices Have been Adjusted based on the Present Date"); 
            LoadDB();

        }
    }
}
