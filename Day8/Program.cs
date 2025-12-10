using Day8;
using Infrastructure;

const string fileName = "input.txt";
var input = FileHelpers.GetFileContent(fileName).ToList();

const int howManyShortestConnections = 1000;
var decoration = new ChristmasDecoration();
decoration.InitializeJunctionBoxes(input);
var junctionDistances = decoration.CalculateDistanceBetweenJunctionBoxes();
var shortestConnections = decoration.GetCircuitsAfterNConnections(junctionDistances, howManyShortestConnections);
var orderedShortestConnections = shortestConnections.OrderByDescending(e => e.Count);
var threeLargestCircuits = orderedShortestConnections.Take(3).ToList();
var result = threeLargestCircuits.Select(e=> e.Count).Aggregate((a, b) => a * b);

Console.WriteLine($"Results of Day8, Part1 : {result}");

var lastConnection = decoration.GetLastConnection(junctionDistances);
var result1 = (long)lastConnection.Junction1.X * (long)lastConnection.Junction2.X;

Console.WriteLine($"Results of Day8, Part2 : {result1}");


