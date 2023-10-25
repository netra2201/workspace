
using Microsoft.AspNetCore.Mvc;
using EmpMvc.Models;
using System.Data;
using System.Data.SqlClient;

namespace EmpMvc.Controllers;

public class mytableController : Controller
{

    public IActionResult Display(int id)
    {

        string constr="User ID=sa; password=examlyMssql@123; server=localhost;Database=NetDb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand command = new SqlCommand("Find", con);
        command.CommandType=CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@id",id);
        con.Open();
        SqlDataReader reader = command.ExecuteReader();
        DataTable prodTable=new DataTable();
        prodTable.Load(reader);
        return View(prodTable);
    }


    public IActionResult List()
    {
        string constr = "User ID=sa; password=examlyMssql@123; server=localhost;Database=NetDb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
        SqlConnection con = new SqlConnection(constr);
        SqlCommand command = new SqlCommand("Select * from mytable", con);
        con.Open();
        SqlDataReader reader = command.ExecuteReader();
        DataTable prodTable = new DataTable();
        prodTable.Load(reader);
        return View(prodTable);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(int id, string name, int salary)
    {
        if(ModelState.IsValid)
        {

        
            string constr = "User ID=sa; password=examlyMssql@123; server=localhost;Database=NetDb;trusted_connection=false;Persist Security Info=False;Encrypt=False";


            SqlConnection con = new SqlConnection(constr);
            SqlCommand command = new SqlCommand("AddProduct",con);
            command.CommandType=CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@salary", salary);
            
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            return RedirectToAction("List");

            
        }
        return View();
    }

}

