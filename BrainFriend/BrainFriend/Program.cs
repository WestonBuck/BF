﻿// Weston Buck
// 04/20/17

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BrainFriend
{
    class Program
    {
        
        //get args so we can use a text file, if not using args, ask for input. Once we have either a text file or user input, start to interpret the BF code.
        static void Main(string[] args)
        {
            
            string inputFile;

            if (args.Length == 0)
            {
                Console.WriteLine("no command line arguments found...");
                Console.WriteLine("Please enter your BF code  here instead:");
                inputFile = Console.ReadLine();
            }
            else
            {
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    
                    inputFile = sr.ReadToEnd();
                }
            }
            Console.Clear();
            interpret(inputFile);
            
        }

        static void interpret(string s)
        {
            /*string myName = "+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++>+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++<<<<<<<<<<.>.>.>.>.>.>.>.>.>.>.";*/
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

                        // When hitting a ] character, go back and decerement the pointer until you get to the original [
                        // and then decrement spot in memory.
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
