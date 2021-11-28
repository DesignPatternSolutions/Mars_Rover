using System;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using MarsRover.Models;

namespace MarsRover
{
    class Program
    {
        public static readonly string input;

        public static readonly string output;

        public static readonly string searchPattern;

        private static int maxCommands;

        static Program()
        {
            maxCommands = 5;
            input = "/Inputs";
            output = "/Outputs";
            searchPattern = "*.txt";
        }
        static void Main(string[] args)
        {
            string inputPath = Directory.GetCurrentDirectory() + input;
            string outputPath = Directory.GetCurrentDirectory() + output;
            string[] files = Directory.GetFiles(inputPath, searchPattern);

            MarsSpaceRover marsRover = new MarsSpaceRover(100, 0);
            User usr = new User(marsRover);

            Task operateTask = Task.Run(async () => await OperateCommandsAsync(files, usr));
            operateTask.Wait();
            Task logLocationTask = operateTask.ContinueWith((task) =>
            {
               if (task.IsCompleted)
               {
                   Task logTask = Task.Run(async () => {
                       string log = await usr.LogLocationAsync(outputPath);
                       Task.WaitAll();
                       Console.WriteLine(log);
                   });
                   logTask.Wait();
               }
            });
            logLocationTask.Wait();
            usr.ClearAll();
        }

        ///<summary>
        /// Operate on the list of input commands.
        ///</summary>
        ///<param name="files">List of input files.</param>
        ///<param name="usr">The Invoker class.</param>
        private static async Task OperateCommandsAsync(string[] files, User usr)
        {
            bool isHalted = false;
            foreach (string input in files)
            {
                string[] cmdList = await File.ReadAllLinesAsync(input);
                Task.WaitAll();
                int max = cmdList.Length < maxCommands ? cmdList.Length : maxCommands;
                string[] text = cmdList.Take<string>(max).ToArray<string>();
                foreach (string txtInput in text)
                {
                    usr.Operate(txtInput);
                }
                isHalted = !usr.Execute();
                if (isHalted)
                {
                    usr.UndoOperation();
                    break;
                }
                usr.ClearAll();
            }
        }
    }
}
