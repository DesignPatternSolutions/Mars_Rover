# Mars_Rover
Mars Rover Command Solution in C#. I have used Command Design Pattern to encapsulate request send to Mars Rover. Built using .NET Framework 5.0 and Xunit Test Framework.

Framework:

.NET 5.0.

Test FrameWork:

Xunit Version="2.4.1"

Executing the Application:

	•	Go to the folder location MarsRover in the CLI.
	•	The sample input files are located in the Inputs folder.
	•	Run the application using .NET CLI Command: “dotnet run”.
	•	The output will get logged in output.txt file.

Sample Input/Output:

Input1.txt 50m, Left, 23m, Left, 4m
  
Input2.txt Left, Left, 4m, Left, Left

Input3.txt Right, 76m, Right, Right, 16m
  
Output.txt
  Current location of Mars Rover: 5084 west

Executing the Application Test Cases:

	•	Go to the folder location MarsRoverTest in the CLI.
	•	Run the test cases using the .NET CLI Command: “dotnet test”.
	•	Passed!  - Failed:     0, Passed:    16, Skipped:     0, Total:    16.

