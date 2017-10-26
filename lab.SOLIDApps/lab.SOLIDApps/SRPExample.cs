using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab.SOLIDApps
{
    /*Now see this tool is a combination of so many different tools like knife, nail cutter, screw driver, etc. So will you want to buy this tool? I don’t think so. Because there is a problem with this tool, if you want to add any other tool to it, then you need to change the base and that is not good. This is a bad architecture to introduce into any system. It will be better if nail cutter can only be used to cut the nail or knife can only be used to cut vegetables.*/

    public class Employee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        /// <summary>
        /// This method used to insert into employee table
        /// </summary>
        /// <param name="em">Employee object</param>
        /// <returns>Successfully inserted or not</returns>
        public bool InsertIntoEmployeeTable(Employee em)
        {
            // Insert into employee table.
            return true;
        }
        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(Employee em)
        {
            // Report generation with employee data using crystal report.
        }
    }

    /*‘Employee’ class is taking 2 responsibilities, one is to take responsibility of employee database operation and another one is to generate employee report. Employee class should not take the report generation responsibility because suppose some days after your customer asked you to give a facility to generate the report in Excel or any other reporting format, then this class will need to be changed and that is not good.

      So according to SRP, one class should take one responsibility so we should write one different class for report generation, so that any change in report generation should not affect the ‘Employee’ class.*/

    public class ReportGeneration
    {
        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(Employee em)
        {
            // Report reneration with employee data.
        }
    }

}
