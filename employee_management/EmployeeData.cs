﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace employee_management
{
    class EmployeeData
    {

        public int ID { get; set; }
        public string EmployeeID {  get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Contact {  get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; } 
        public string Status { get; set; }

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\code\wf_employee\employee_management\employee_management\employee.mdf;Integrated Security=True");


        public List<EmployeeData> employeeListData()
        {
            List<EmployeeData> listdata = new List<EmployeeData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM employees WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            EmployeeData ed = new EmployeeData();
                            ed.ID = (int)reader["id"];
                            ed.EmployeeID = reader["employee_id"].ToString();
                            ed.Name = reader["full_name"].ToString();
                            ed.Gender = reader["gender"].ToString();
                            ed.Contact = reader["contact_number"].ToString();
                            ed.Position = reader["position"].ToString();  
                            ed.Image = reader["image"].ToString();
                            ed.Salary = (int)reader["salary"];
                            ed.Status = reader["status"].ToString();

                            listdata.Add(ed);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listdata;
        }
    }
}
