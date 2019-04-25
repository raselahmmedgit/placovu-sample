using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.ConsoleApps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Student> list = new List<Student>() {
                new Student { Id=1, Name="A", Delay=0 }
                ,new Student { Id=2, Name="B", Delay=1 }
                ,new Student { Id=3, Name="C", Delay=2 }
            };

            int firstIndex = list.IndexOf(list.FirstOrDefault());
            int nextIndex = firstIndex;
            int lastIndex = list.IndexOf(list.LastOrDefault());

            foreach (var item in list)
            {
                nextIndex = nextIndex + 1;
                Student nextStudent = new Student();
                if (nextIndex <= lastIndex) {
                    nextStudent = list[nextIndex];
                }

                Task task = DoAsyncTask(item, nextStudent);
                task.Wait();
            }

            //var a = MyMethodAsync(); //Task started for Execution and immediately goes to Line 19 of the code. Cursor will come back as soon as await operator is met		
            //Console.WriteLine("Cursor Moved to Next Line Without Waiting for MyMethodAsync() completion");
            //Console.WriteLine("Now Waiting for Task to be Finished");
            //Task.WaitAll(a); //Now Waiting		
            //Console.WriteLine("Exiting CommandLine");

            Console.ReadLine();
        }

        private static async Task DoAsyncTask(Student student, Student nextStudent)
        {
            try
            {
                int delay = 0;

                if (nextStudent.Delay > 0)
                {
                    //Task Delay for Next Send Email
                    delay += Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToInt32(nextStudent.Delay)).TotalMilliseconds); //from db
                }

                //delay += Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToInt32(1)).TotalMilliseconds); //from db

                Console.WriteLine("Before - Student: id {" + student.Id + "}, name {" + student.Name + "}, delay {" + student.Delay + "}, datetime {" + DateTime.Now.ToString() + "}");

                //Task taskDelay = Task.Delay(delay);
                Task taskDelay = Task.Delay(delay);
                
                //Send Email
                Console.WriteLine("After - Student: id {" + student.Id + "}, name {" + student.Name + "}, delay {" + student.Delay + "}, datetime {" + DateTime.Now.ToString() + "}");

                await taskDelay;

                Console.WriteLine("Done - Student: id {" + student.Id + "}, name {" + student.Name + "}, delay {" + student.Delay + "}, datetime {" + DateTime.Now.ToString() + "}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static async Task MyMethodAsync()
        {
            Task<int> longRunningTask = LongRunningOperation();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here
            Console.WriteLine("Independent Works of now executes in MyMethodAsync()");
            //and now we call await on the task 
            int result = await longRunningTask;
            //use the result 
            Console.WriteLine("Result of LongRunningOperation() is " + result);
        }

        public static async Task<int> LongRunningOperation() // assume we return an int from this long running operation 
        {
            Console.WriteLine("LongRunningOperation() Started");
            await Task.Delay(2000); // 2 second delay
            Console.WriteLine("LongRunningOperation() Finished after 2 Seconds");
            return 1;
        }
    }
}
