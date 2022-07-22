namespace AddressBookDbConsole
{
    class Program
    {
        public static void Main(String[] args)
        {
            EmployeeRepositoey res=new EmployeeRepositoey();

            EmployeeModel model=new EmployeeModel();
//            model.Name = "Atul";
          //  model.EmployeeId = 27;
            // model.Salary = 3353;

          //  model.Gender = "M";
          //  model.Address = "NEB";
            //model.PhoneNumber = 998392291;
            // res.AddEmployee(model);
            //  res.UpdateEmployee(model);
            //  res.DeleteEmployee(model);
          //  res.InsertIntoTwoTable(model);
         //   res.InsertIntoTwoTablesWithTranactions();
            res.GetAllEmployees();
        }
    }
}