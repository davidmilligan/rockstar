using System;
using System.IO;
using System.Linq;

namespace rockstar
{
    public static class Program
    {
        /// <summary>
        /// Generate the actual quine from the quine template
        /// </summary>
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("quine.template.rock");
            using var output = new StreamWriter(File.Open("quine.rock", FileMode.Create));
            output.WriteLine(lines[0]);
            foreach (var line in lines.Skip(1))
            {
                if (!line.StartsWith("(")) //remove comments
                {
                    output.Write("Rock your world with ");
                    foreach (var ch in line.Trim())
                    {
                        output.Write((int)ch + ", ");
                    }
                    output.WriteLine("10");
                }
            }
            foreach (var line in lines.Skip(1))
            {
                if (!line.StartsWith("("))
                {
                    output.WriteLine(line.Trim());
                }
            }
        }
    }
}
