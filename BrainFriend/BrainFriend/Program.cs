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
            //string myName = "";
            char[] code;
            code = s.ToCharArray();
            int[] tape = new int[100000];
            int memoryPointer = 0, instructionPointer = 0;

            while (instructionPointer < s.Length)
            {
                switch (s[instructionPointer])
                {
                    case '>':
                        memoryPointer++;
                        if (memoryPointer == 100001)
                        {
                            memoryPointer = 0;
                        }
                        break;
                    case '<':
                        memoryPointer--;
                        if (memoryPointer < 0)
                        {
                            memoryPointer = 100000;
                        }
                        break;
                    case '+':
                        tape[memoryPointer]++;
                        break;
                    case '-':
                        tape[memoryPointer]--;
                        break;


                    case '[':
                        if (tape[memoryPointer] == 0)
                        {
                            int LoopCount = 1;
                            while (LoopCount > 0)
                            {
                                instructionPointer++;
                                char c = s[instructionPointer];
                                if (c == '[')
                                {
                                    LoopCount++;
                                }
                                else if (c == ']')
                                {
                                    LoopCount--;
                                }
                            }
                        }
                        break;
                    case ']':
                        { 
                            int LoopCount = 1;
                            while (LoopCount > 0)
                            {
                                instructionPointer--;
                                char c = s[instructionPointer];
                                if (c == '[')
                                {
                                    LoopCount--;
                                }
                                else if (c == ']')
                                {
                                    LoopCount++;
                                }
                            }
                            instructionPointer--;
                            break;
                        }
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
