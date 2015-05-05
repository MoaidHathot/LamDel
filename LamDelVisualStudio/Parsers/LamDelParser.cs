using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LamDel.Shared;
using LamDel.Shared.Types;
using LamDel.Parsers.StateMachine;

namespace LamDel.Parsers
{
    public class LamDelParser : IParser
    {
        public IEvaluatable Parse(string expression)
        {
            var machine = new LamDelStateMachine(expression);

            var list = new LinkedList<IEvaluatable>();
            var highStack = new Stack<LinkedListNode<IEvaluatable>>();
            var lowQueue = new Queue<LinkedListNode<IEvaluatable>>();

            ArrangePriorites(machine.States, list, highStack, lowQueue);

            ProcessOperator(list, highStack);
            ProcessOperator(list, lowQueue);

            return list.Single();
        }

        private void ArrangePriorites(IEnumerable<IEvaluatable> states, LinkedList<IEvaluatable> list, Stack<LinkedListNode<IEvaluatable>> highStack, Queue<LinkedListNode<IEvaluatable>> lowQueue)
        {
            foreach (var state in states)
            {
                var node = list.AddLast(state);

                var op = state as Operator;

                if (null != op)
                {
                    if (OperatorPriority.High == op.Priority)
                    {
                        highStack.Push(node);
                    }
                    else
                    {
                        lowQueue.Enqueue(node);
                    }
                }
            }
        }


        private void ProcessOperator(LinkedList<IEvaluatable> list, IEnumerable<LinkedListNode<IEvaluatable>> items)
        {
            foreach (var item in items)
            {
                var before = item.Previous;
                var after = item.Next;

                list.Remove(before);
                list.Remove(after);

                var value = item.Value as BinaryOperator;
                //var result = new Constant(item.Value.Evaluate(before.Value.Evaluate(), after.Value.Evaluate()));
                var result = new BinaryOperator(value.Priority, before.Value, after.Value, value.RawFunction);

                item.Value = result;
            }
        }
    }
}
