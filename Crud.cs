using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Video_Rental_System
{
    public class Crud
    {
        Database MyDatabase = new Database();


        public void AddCustomer(string txtFirstName, string txtLastName, string txtAddress, string txtPhoneNO, string txtDate)
        {
            // puts paremeters into the code so that data in the text boxes is added to the database

            string NewEntry = "INSERT INTO Customer (FirstName, LastName, Address, Phone, Date) VALUES(@FirstName, @LastName, @Address, @Phone, @Date)";

            SqlConnection connection = new SqlConnection(MyDatabase.connection);

            using (SqlCommand newdata = new SqlCommand(NewEntry, connection))
            {
                newdata.Parameters.AddWithValue("@FirstName", txtFirstName);
                newdata.Parameters.AddWithValue("@LastName", txtLastName);
                newdata.Parameters.AddWithValue("@Address", txtAddress);
                newdata.Parameters.AddWithValue("@Phone", txtPhoneNO);
                newdata.Parameters.AddWithValue("@Date", txtDate);

                connection.Open(); //open a connection to the database
                                   //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery(); //Run the Query
                connection.Close(); //Close a connection to the database
                                    //a happy message box


            }
        }


        public void UpdateCustomer(string txtFirstName, string txtLastName, string txtAddress, string txtPhoneNO, string txtDate, string ID)
        {
            string NewEntry = "Update Customer set FirstName=@FirstName, LastName=@LastName, Address=@Address, Phone=@Phone, Date=@Date where CustID = @ID";

            SqlConnection connection = new SqlConnection(MyDatabase.connection);

            using (SqlCommand newdata = new SqlCommand(NewEntry, connection))
            {

                newdata.Parameters.AddWithValue("@FirstName", txtFirstName);
                newdata.Parameters.AddWithValue("@LastName", txtLastName);
                newdata.Parameters.AddWithValue("@Address", txtAddress);
                newdata.Parameters.AddWithValue("@Phone", txtPhoneNO);
                newdata.Parameters.AddWithValue("@Date", txtDate);
                newdata.Parameters.AddWithValue("@ID", ID);

                connection.Open(); //open a connection to the database
                                   //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery(); //Run the Query
                connection.Close(); //Close a connection to the database
                                    //a happy message box


            }

        }




        public void AddMovie(string txtRating, string txtTitle, string txtYear, string txtRental, string txtCopies, string txtPlot, string txtGenre, string txtDate)
         {
            // puts paremeters into the code so that data in the text boxes is added to the database

            string NewEntry = "INSERT INTO Movies (Rating, Title, Year, Rental_Cost, Copies, Plot, Genre, Date) VALUES(@Rating, @Title, @Year, @Rental_Cost, @Copies, @Plot, @Genre, @Date)";

            SqlConnection connection = new SqlConnection(MyDatabase.connection);

            using (SqlCommand newdata = new SqlCommand(NewEntry, connection))
            {
                newdata.Parameters.AddWithValue("@Rating", txtRating);
                newdata.Parameters.AddWithValue("@Title", txtTitle);
                newdata.Parameters.AddWithValue("@Year", txtYear);
                newdata.Parameters.AddWithValue("@Rental_Cost", txtRental);
                newdata.Parameters.AddWithValue("@Copies", txtCopies);
                newdata.Parameters.AddWithValue("@Plot", txtPlot);
                newdata.Parameters.AddWithValue("@Genre", txtGenre);
                newdata.Parameters.AddWithValue("@Date", txtDate);

                connection.Open(); //open a connection to the database
                                       //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery(); //Run the Query
                connection.Close(); //Close a connection to the database
                                        //a happy message box


            }

        }

        public void UpdateMovie(string txtRating, string txtTitle, string txtYear, string txtRental, string txtCopies, string txtPlot, string txtGenre, string txtDate, string MovieID)
        {
            string NewEntry = "Update Movies set Rating=@Rating, Title=@Title, Year=@Year, Rental_Cost=@Rental_Cost, Copies=@Copies, Plot=@Plot, Genre=@Genre, Date=@Date where MovieID = @ID";

            SqlConnection connection = new SqlConnection(MyDatabase.connection);

            using (SqlCommand newdata = new SqlCommand(NewEntry, connection))
            {
                newdata.Parameters.AddWithValue("@Rating", txtRating);
                newdata.Parameters.AddWithValue("@Title", txtTitle);
                newdata.Parameters.AddWithValue("@Year", txtYear);
                newdata.Parameters.AddWithValue("@Rental_Cost", txtRental);
                newdata.Parameters.AddWithValue("@Copies", txtCopies);
                newdata.Parameters.AddWithValue("@Plot", txtPlot);
                newdata.Parameters.AddWithValue("@Genre", txtGenre);
                newdata.Parameters.AddWithValue("@Date", txtDate);
                newdata.Parameters.AddWithValue("@ID", MovieID);

                connection.Open(); //open a connection to the database
                                   //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery(); //Run the Query
                connection.Close(); //Close a connection to the database
                                    //a happy message box
            }
        }



        public void DeleteCustomer(string ID)
        {
            string NewEntry = "Delete FROM Customer where CustID = @ID";
            SqlConnection connection = new SqlConnection(MyDatabase.connection);
            using (SqlCommand newdata = new SqlCommand(NewEntry, connection))
            {
                newdata.Parameters.AddWithValue("ID", ID);

                connection.Open(); //open a connection to the database
                                   //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery(); //Run the Query
                connection.Close(); //Close a connection to the database
                                    //a happy message box
            }

        }
        public void DeleteMovie(string ID)
        {
            string NewEntry = "Delete FROM Movies where MovieID = @ID";
            SqlConnection connection = new SqlConnection(MyDatabase.connection);
            using (SqlCommand newdata = new SqlCommand(NewEntry, connection))
            {
                newdata.Parameters.AddWithValue("ID", ID);

                connection.Open(); //open a connection to the database
                                   //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery(); //Run the Query
                connection.Close(); //Close a connection to the database
                                    //a happy message box
            }

        }


        public void IssueMovie(string MovieID, string CustID, string txtDateRented, string txtDateReturned)
        {
            string NewEntry = "INSERT INTO RentedMovies (MovieIDFK, CustIDFK, DateRented, DateReturned) VALUES (@MovieIDFK, @CustIDFK, @DateRented, @DateReturned)";

            SqlConnection connection = new SqlConnection(MyDatabase.connection);

            using (SqlCommand newdata = new SqlCommand(NewEntry, connection))
            {
                newdata.Parameters.AddWithValue("@MovieIDFK", MovieID);
                newdata.Parameters.AddWithValue("@CustIDFK", CustID);
                newdata.Parameters.AddWithValue("@DateRented", txtDateRented);
                newdata.Parameters.AddWithValue("@DateReturned", txtDateReturned);

                connection.Open(); //open a connection to the database
                                   //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery(); //Run the Query
                connection.Close(); //Close a connection to the database
                                    //a happy message box


            }

        }
        public void ReturnMovie(string txtDateReturned, string ID)
        {
            string NewEntry = "Update RentedMovies set DateReturned=@DateReturned where RMID = @ID";
            SqlConnection connection = new SqlConnection(MyDatabase.connection);
            using (SqlCommand newdata = new SqlCommand(NewEntry, connection))
            {
                newdata.Parameters.AddWithValue("@DateReturned", txtDateReturned);
                newdata.Parameters.AddWithValue("@ID", ID);
                connection.Open(); //open a connection to the database
                                   //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery(); //Run the Query
                connection.Close(); //Close a connection to the database
                                    //a happy message box
            }
        }
        public void UpdateMovieFee1(int Movie_id)
        {
            SqlConnection connection = new SqlConnection(MyDatabase.connection);
            string NewEntry = "UPDATE Movies SET Rental_Cost = 2 WHERE MovieID = @ID";
            using (SqlCommand newdata = new SqlCommand(NewEntry, connection))
            {
                newdata.Parameters.AddWithValue("@ID", Movie_id);
                connection.Open(); //open a connection to the database
                                   //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery(); //Run the Query
                connection.Close(); //Close a connection to the database
                                    //a happy message box
            }
        }
        public void UpdateMovieFee2(int Movie_id)
        {
            SqlConnection connection = new SqlConnection(MyDatabase.connection);
            string NewEntry = "UPDATE Movies SET Rental_Cost = 5 WHERE MovieID = @ID";
            using (SqlCommand newdata = new SqlCommand(NewEntry, connection))
            {
                newdata.Parameters.AddWithValue("@ID", Movie_id);
                connection.Open(); //open a connection to the database
                                   //its a NONQuery as it doesn't return any data its only going up to the server
                newdata.ExecuteNonQuery(); //Run the Query
                connection.Close(); //Close a connection to the database
                                    //a happy message box
            }
        }
    }
}
