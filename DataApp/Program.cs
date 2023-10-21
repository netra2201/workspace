using System.Data.SqlClient;
using System;
using System.Data;
// AddRecord();
// show();

AddDisconnect();
ShowDisconnect();

void AddDisconnect()
{
    string connectionString = "User ID=sa; password=examlyMssql@123; server=localhost; Database=NetDb;trusted_connection=false; Persist Security Info=False;Encrypt=False";

    System.Console.WriteLine("Enter ID");
    int id = Convert.ToInt32(Console.ReadLine());
    System.Console.WriteLine("Enter Name");
    string name = Console.ReadLine ();
    System.Console.WriteLine("Enter Salary");
    int salary = Convert.ToInt32(Console.ReadLine());

    SqlConnection connection=null;
    SqlDataAdapter adapter = null;
    DataSet ds = null;
    DataTable prodTable = null;

    try
    {
        ds = new DataSet();
        connection = new SqlConnection(connectionString);
        adapter = new SqlDataAdapter("select * from mytable ",connection);
        adapter.Fill(ds,"Prods");
        prodTable = ds.Tables["Prods"];
        DataRow prodrow= prodTable.NewRow();
        prodrow["id"]=id;
        prodrow["name"]=name;
        prodrow["salary"]=salary;
        prodTable.Rows.Add(prodrow);
        SqlCommandBuilder scb = new SqlCommandBuilder(adapter);
    Console.WriteLine(scb.GetInsertCommand().CommandText);

        adapter.Update(prodTable);
        Console.WriteLine("Row added");

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    


}
void ShowDisconnect()
{
    string connectionString = "User ID=sa; password=examlyMssql@123; server=localhost;Database=NetDb;trusted_connection=false; Persist Security Info=False;Encrypt=False";
   // string cmdtext = "insert into mytable values(@id, @name,@salary)";
    SqlConnection connection=null;
    SqlDataAdapter adapter = null;
    DataSet ds = null;
    DataTable prodTable = null;

    try
    {
        ds = new DataSet();
        connection = new SqlConnection(connectionString);
        adapter = new SqlDataAdapter("select * from mytable ",connection);
        adapter.Fill(ds,"Prods");
        prodTable = ds.Tables["Prods"];
        
        Console.WriteLine($"Rows = {prodTable.Columns.Count}");
        Console.WriteLine($"Columns = {prodTable.Columns.Count}");

        foreach(DataRow row in prodTable.Rows)
        {
            Console.WriteLine($"{row["id"]} --- {row["name"]} --- {row["salary"]}");
        }


    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void AddRecord()
{
    string connectionString = "User ID=sa; password=examlyMssql@123; server=localhost; Database=NetDb;trusted_connection=false; Persist Security Info=False;Encrypt=False";

    string cmdtext = "insert into mytable values(@id, @name,@salary)";
    System.Console.WriteLine("Enter ID");
    int id = Convert.ToInt32(Console.ReadLine());
    System.Console.WriteLine("Enter Name");
    string name = Console.ReadLine();
    System.Console.WriteLine("Enter Salary");
    int salary = Convert.ToInt32(Console.ReadLine());

    SqlConnection con = null;
    SqlCommand command = null;
    try
    {
        con = new (connectionString);
        command=new SqlCommand(cmdtext, con);
        command.Parameters.AddWithValue("@id",id);
        command.Parameters.AddWithValue("@name",name);
        command.Parameters.AddWithValue("@salary",salary);
        con.Open();
        command.ExecuteNonQuery();
        System.Console.WriteLine("Record Added");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        con.Close();

    }
}
void show()
    {
        string connectionString = "User ID=sa; password=examlyMssql@123; server=localhost;Database=NetDb;trusted_connection=false; Persist Security Info=False;Encrypt=False";

        string cmdtext = "select * from mytable";
    try
    {
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        System.Console.WriteLine("Connection Opened Successfully");

        SqlCommand command = new SqlCommand(cmdtext,con);
        SqlDataReader reader=command.ExecuteReader();

        while(reader.Read())
        {
            System.Console.WriteLine($"{reader["id"]} --- {reader["Name"]} --- {reader["salary"]} ");
        
        }
        con.Close();
    }

    catch(Exception ex)
    {
        System.Console.WriteLine(ex.Message);
    }

}

