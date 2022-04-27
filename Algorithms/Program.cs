using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.files();
        }

        int[] Quicksort(int[] UnsortedArray, int LeftPointer, int RightPointer)
        {
            int pivot = UnsortedArray[LeftPointer];
            int left = LeftPointer;
            int right = RightPointer;

            if (LeftPointer < RightPointer)
            {
                while (UnsortedArray[RightPointer] > pivot)
                {
                    RightPointer--;
                }

                while (UnsortedArray[LeftPointer] < pivot)
                {
                    LeftPointer++;
                }

                if (RightPointer > LeftPointer)
                {
                    int temp = UnsortedArray[LeftPointer];
                    UnsortedArray[LeftPointer] = UnsortedArray[RightPointer];
                    UnsortedArray[RightPointer] = temp;
                }
            }

            if(LeftPointer > left)
            {
                Quicksort(UnsortedArray, left, LeftPointer);
            }

            if(RightPointer < right)
            {
                Quicksort(UnsortedArray,RightPointer, right);
            }

            return UnsortedArray;
        }

        bool InterpolationSearch(int[] SortedArray, int item)
        {
                int start = 0;
                int end = SortedArray.Length - 1;
                bool ItemFound = false;
                int i = 0;
                int BestValue = 0;
                bool MultipleBestValues = false;
                int[] BestValues = { };

                while (ItemFound == false)
                {
                    int index = start + Convert.ToInt32((end - start) * (item - (SortedArray[start]) / (SortedArray[end] - SortedArray[start])));
                    if (SortedArray[index] == item)
                    {
                        Console.WriteLine("item found");
                        return true;
                    }
                    else
                    {
                        int CloseValue = (int)SortedArray[index];

                        if ((int)SortedArray[index] - CloseValue < (int)SortedArray[index] - BestValue)
                        {
                            BestValue = CloseValue;
                        }

                        else
                        {
                            if ((int)SortedArray[index] - CloseValue == (int)SortedArray[index] - BestValue)
                            {
                                MultipleBestValues = true;
                                BestValues.Append(BestValue);
                                BestValues.Append(CloseValue);
                            }
                            if (start == end)
                            {
                                Console.WriteLine("Item not found");
                                if (MultipleBestValues)
                                {
                                    Console.WriteLine("Closest values to", item, ":", BestValues);
                                }
                                else
                                {
                                    Console.WriteLine("Closest value to", item, ":", BestValue);
                                }
                                break;
                            }

                            if (SortedArray[index] > item)
                            {
                                end = index - 1;
                            }
                            else
                            {
                                start = index + 1;
                            }
                        }
                    }
                }

                return false;
        }

        void CountIndexes(int[] SortedArray, bool option)
        {
                if (option == true)
                {
                    for (int i = 10; i < SortedArray.Length; i = i + 10)
                    {
                        Console.WriteLine(SortedArray[i]);
                    }
                }
                else
                {
                    for (int i = 50; i < SortedArray.Length; i = i + 50)
                    {
                        Console.WriteLine(SortedArray[i]);
                    }
                }
        }

        void files()
        {
                string[] file_1_256 = File.ReadAllLines("Share_1_256.txt");
                int[] file1 = Array.ConvertAll<string, int>(file_1_256, s => int.Parse(s));

                string[] file_2_256 = File.ReadAllLines("Share_2_256.txt");
                int[] file2 = Array.ConvertAll<string, int>(file_2_256, s => int.Parse(s));

                string[] file_3_256 = File.ReadAllLines("Share_3_256.txt");
                int[] file3 = Array.ConvertAll<string, int>(file_3_256, s => int.Parse(s));

                file1 = Quicksort(file1, 0, file1.Length - 1);
                file2 = Quicksort(file2, 0, file2.Length - 1);
                file3 = Quicksort(file3, 0, file3.Length - 1);

                Console.WriteLine("Every 10: indexes of Share_1_256:");
                CountIndexes(file1, true);
                Console.WriteLine("\n Every 10: indexes of Share_2_256:");
                CountIndexes(file2, true);
                Console.WriteLine("\n Every 10: indexes of Share_3_256:");
                CountIndexes(file3, true);

                Console.WriteLine("Search for a value in Share_1_256: ");
                string input1 = Console.ReadLine();
                InterpolationSearch(file1, int.Parse(input1));

                Console.WriteLine("Search for a value in Share_2_256: ");
                string input2 = Console.ReadLine();
                InterpolationSearch(file2, int.Parse(input2));

                Console.WriteLine("Search for a value in Share_3_256: ");
                string input3 = Console.ReadLine();
                InterpolationSearch(file3, int.Parse(input3));



                string[] file_1_2048 = File.ReadAllLines("Share_1_2048.txt");
                int[] file1_2 = Array.ConvertAll<string, int>(file_1_2048, s => int.Parse(s));

                string[] file_2_2048 = File.ReadAllLines("Share_2_2048.txt");
                int[] file2_2 = Array.ConvertAll<string, int>(file_2_2048, s => int.Parse(s));

                string[] file_3_2048 = File.ReadAllLines("Share_3_2048.txt");
                int[] file3_2 = Array.ConvertAll<string, int>(file_3_2048, s => int.Parse(s));

                file1_2 = Quicksort(file1_2, 0, file1_2.Length - 1);
                file2_2 = Quicksort(file2_2, 0, file2_2.Length - 1);
                file3_2 = Quicksort(file3_2, 0, file3_2.Length - 1);

                Console.WriteLine("Every 50: indexes of Share_1_2048:");
                CountIndexes(file1_2, false);
                Console.WriteLine("\n Every 50: indexes of Share_2_2048:");
                CountIndexes(file2_2, false);
                Console.WriteLine("\n Every 50: indexes of Share_3_2048:");
                CountIndexes(file3_2, false);

                Console.WriteLine("Search for a value in Share_1_2048: ");
                string input1_2 = Console.ReadLine();
                InterpolationSearch(file1_2, int.Parse(input1_2));

                Console.WriteLine("Search for a value in Share_2_2048: ");
                string input2_2 = Console.ReadLine();
                InterpolationSearch(file2_2, int.Parse(input2_2));

                Console.WriteLine("Search for a value in Share_3_2048: ");
                string input3_2 = Console.ReadLine();
                InterpolationSearch(file3_2, int.Parse(input3_2));



                int[] newFile_256 = file1.Union(file3).ToArray();

                newFile_256 = Quicksort(newFile_256, 0, newFile_256.Length - 1);

                Console.WriteLine("Every 10: indexes of Merged file:");
                CountIndexes(newFile_256, true);

                Console.WriteLine("Search for a value in merged file: ");
                string newInput = Console.ReadLine();
                InterpolationSearch(newFile_256, int.Parse(newInput));



                int[] newFile_2048 = file1.Union(file3).ToArray();

                newFile_2048 = Quicksort(newFile_2048, 0, newFile_2048.Length - 1);

                Console.WriteLine("Every 50: indexes of Merged file (2048):");
                CountIndexes(newFile_2048, false);

                Console.WriteLine("Search for a value in Merged file (2048): ");
                string newInput2 = Console.ReadLine();
                InterpolationSearch(newFile_2048, int.Parse(newInput2));


        }
    }
    
}