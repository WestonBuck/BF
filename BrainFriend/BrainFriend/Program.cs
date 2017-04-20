using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFriend
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string inputFile;
           
            Console.WriteLine("Please enter your BF code:");
            inputFile = Console.ReadLine();
            Console.Clear();
            interpret(inputFile);
            
        }

        static void interpret(string s)
        {
            //string myName = "+[--->++<]>+.++[->++++<]>+.[--->+<]>----.+.-----.-.-[->+++++<]>-.+[->++<]>.++[----->+<]>+.+[->+++<]>+.++++++++.";
            char[] code;
            code = s.ToCharArray();
            int[] tape = new int[100000];
            int memoryPointer = 0, instructionPointer = 0;

            while (instructionPointer < code.Length)
            {
                switch (code[instructionPointer])
                {
                    case '>':
                        memoryPointer++;
                        if (memoryPointer == 256)
                        {
                            memoryPointer = 0;
                        }
                        break;
                    case '<':
                        memoryPointer--;
                        if (memoryPointer <= 0)
                        {
                            memoryPointer = 255;
                        }
                        break;
                    case '+':
                        tape[memoryPointer]++;
                        break;
                    case '-':
                        tape[memoryPointer]--;
                        break;
                        
                    // check for new loops and increment counter or decrement if needed.
                    case '[':
                        if (tape[memoryPointer]==0)
                        {
                            int LoopCount = 0;
                            int tempPointer = instructionPointer + 1;
                            while (code[tempPointer] != ']' || LoopCount >0)
                            {
                                if (code[tempPointer] == '[')
                                {
                                    LoopCount++;
                                }
                                else if (code[tempPointer] == ']')
                                {
                                    LoopCount--;
                                }

                                tempPointer++;
                                instructionPointer = tempPointer;
                            }
                            break;
                        }
                        break;

                    case ']':
                        if (tape[memoryPointer] != 0)
                        {
                            int LoopCount = 0;
                            int tempPointer = instructionPointer - 1;
                            while (code[tempPointer] != '[' || LoopCount > 0)
                            {
                                if (code[tempPointer] == ']')
                                {
                                    LoopCount++;
                                }
                                else if (code[tempPointer] == '[')
                                {
                                    LoopCount--;
                                }

                                tempPointer--;
                                instructionPointer = tempPointer;
                            }
                            break;
                        }
                        break;
                    case ',':
                        tape[memoryPointer] = Console.Read();
                        break;
                    case '.':
                        Console.Write((char)tape[memoryPointer]);
                        break;
                }


                instructionPointer++;
            }
            Console.WriteLine();
        }
    }
}
