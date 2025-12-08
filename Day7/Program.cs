using Day7;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();

var beamSimulator = new BeamSimulator(input);
var result = beamSimulator.Run();

Console.WriteLine($"Results of Day7, Part1 : {result}");