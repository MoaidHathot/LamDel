using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LamDel.Parsers;
using LamDel.Parsers.StateMachine;
using LamDel.Parsers.StateMachine.States;
using LamDel.Shared;
using LamDel.Shared.Types;

namespace LamDelVisualStudio.Test.Concole
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new LamDelParser();

            string input;
            bool stop = false;

            do
            {
                input = Console.ReadLine();

                if ("quit" != input)
                {
                    if (0 < input.Trim().Length)
                    {
                        var watch = new Stopwatch();

                        watch.Start();
                        var parsed = parser.Parse(input).Evaluate();
                        watch.Stop();

                        Console.WriteLine("Input: '{0}', Result: '{1}'. Elapsed: '{2}'", input, parsed, watch.Elapsed.TotalMilliseconds);
                    }
                }
                else
                {
                    stop = true;
                }

            } while (!stop);
        }
    }
}
