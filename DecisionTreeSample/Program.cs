using System;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;

namespace DecisionTreeSample {
	internal class Program {
		private static void Main(string[] args) {
			var vs = new[] {
				new DecisionVariable("outlook", DecisionVariableKind.Discrete),
				new DecisionVariable("temperature", DecisionVariableKind.Discrete),
				new DecisionVariable("humidity", DecisionVariableKind.Discrete),
				new DecisionVariable("windy", DecisionVariableKind.Discrete),
			};
			var sunny = 0;
			var overcast = 1;
			var rain = 2;
			var tree = new DecisionTree(vs, 2);
			var learning = new C45Learning(tree);
			learning.Run(new[] {
				new double[] { sunny, 85, 85, 0 },
				new double[] { sunny, 80, 90, 1 },
				new double[] { overcast, 83, 78, 0 },
			}, new[] { 0, 0, 1 });

			Console.WriteLine(tree.Compute(new[] { sunny, 85, 85, 0 }));
			Console.WriteLine(tree.Compute(new[] { sunny, 80, 90, 1 }));
			Console.WriteLine(tree.Compute(new[] { overcast, 83, 78, 0 }));
		}
	}
}