using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static string[] fruit = new string[7] { "apple", "lichi", "guava", "lemon", "mango" ,"banana","watermelon"};
        static string[] country = new string[10] {"india","pakistan","usa","austrlia","canada","sweden","england","france","brazil","china"};
        static string[] flower = new string[5] {"Rose","Sunflower","Belii","shapla","gadha"};
        static string[] animal = new string[8] {"tiger","monkey","lion","snake","cat","elephant","cow","goat"};

        static string[] food = new string[15] { "burger","pizza","biscuit","chocolate","sweet","pasta","rice","bread","sandwich","cake","soup","polao","coke","meat","fish"};

        static bool play = true;
        static void Main(string[] args)
        {
           while (play == true)
            {
                int i, Life = 6, count = 0,y;
                
                char[] input = new char[30];//to show what inputs are user giving
                Console.WriteLine("Welcome to Hangman");
                Console.WriteLine("Enter 1 for fruit , 2 for Country , 3 for flower ,4 for animal , 5 for food : ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input : "+x);
                string word;
            repeat:
                if (x == 1)
                {
                    Console.WriteLine("You have to guess fruit name !");
                    Random r = new Random();
                     word = fruit[r.Next(0, fruit.Length)];
                }
                else if (x == 2)
                {
                    Console.WriteLine("You have to guess Country !");
                    Random r = new Random();
                    word = country[r.Next(0, country.Length)];
                }
               
                else if (x == 3)
                {
                    Console.WriteLine("You have to guess flower name !");
                    Random r = new Random();
                     word = flower[r.Next(0, flower.Length)];
                }
                else if (x == 4)
                {
                    Console.WriteLine("You have to guess animal name !");
                    Random r = new Random();
                    word = animal[r.Next(0, animal.Length)];
                }
                else if (x == 5)
                {
                    Console.WriteLine("You have to guess food name !");
                    Random r = new Random();
                    word = food[r.Next(0, food.Length)];
                }
                else 
                {
                    Console.WriteLine("Enter valid one\n if you want to continue  press valid 1 to 5 or else game will stop. ");
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x<6 && x >0)
                    {
                        goto repeat;
                    }
                    else
                    {
                        break;
                    }
                    

                }
                
                char[] letter = word.ToCharArray();//converting String to char array
                Console.WriteLine("guess a letter!, You have six gusses");
                 y = word.Length;
                Console.WriteLine("Your guessed word length is : "+y);

                char[] p =new char[y] ;//to store correct values                                                                                             

                for (i = 0; i < letter.Length; i++)
                {
                    Console.WriteLine("Guess character!:");
                    char pp = Convert.ToChar(Console.ReadLine());
                    pp=Char.ToLower(pp);
                    if (input.Contains(pp)) //to check repeated value of input
                    {
                        Console.WriteLine("you have already entered this!Don't waste your Life.Type again");
                      


                    }


                    if (letter.Contains(pp)) //to check if the input belongs to the guessed word
                    {
                        count++;

                        Console.WriteLine("Correct guess....");
                        for (int j = 0; j < letter.Length; j++) // storing correct guesses
                            {
                            if(pp==letter[j]) {
                                p[j] = pp;
                               // Console.WriteLine(p[j]);
                            }

                            }
                        Console.Write("Filling gaps:  ");
                        for (int m = 0; m < word.Length; m++) //printing guessed values
                        {
                            Console.Write("{0}", p[m]);
                        }
                        Console.WriteLine("");
                        string newArray = new string(p);
                        if (word == newArray) //to check win
                        {
                            Console.WriteLine("You won the game,Yes!!the word is {0}", word);
                            Console.WriteLine("word is : "+newArray);
                            Console.WriteLine("If you want to play the game again press 1, to quit press 2");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if (choice == 1)
                            {
                                play = true;
                              
                                break;

                            }
                            else
                            {
                                play = false;
                                break;
                            }


                        }
                       
                    }
                   
                   else  //to check wrong guess
                    {
                        if (input.Contains(pp) == false)

                        {

                            Console.WriteLine("Wrong guess!You have {0} lifes left", Life - 1);
                            Life--;
                            count++;

                        }
                        i = i - 1;
                        
                     
                        
                    }
                    

                    if (Life == 0)//End of Lifes of game
                    {
                        Console.WriteLine("You have lost!!");
                        Console.WriteLine("If you want to play the game again press 1, to quit press 2");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            play = true;

                            break;

                        }
                        else
                        {
                            play = false;
                            break;
                        }

                       
                    }
                    

                   
                        input[count - 1] = pp;
                    Console.WriteLine("Your Inputs: ");
                    // printing input array
                    for (int ii=0;ii<count;ii++) { 
                       
                        Console.WriteLine("{0}", input[ii]);
                    }

                    Console.WriteLine("");

                }
               

            }
        }

       
    }
}
