using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Code_Examples
{
    class CaeserCipher
    {
        //Authors: Zi Xiang Wang
        //Implementation of a Caeser Cipher in C#
        public static void run()
        {
            while (true)
            {
                Console.Write("Enter the message >>> "); //Message to be encrypted or decrypted
                string message = Console.ReadLine();

                int choice;
                while (true) // Input validation to only allow 0 or 1 to be entered
                {
                    Console.Write("Enter 0 or 1 \n0.Encryption \n1.Decryption \n>>> "); //0 or 1 for encryption or decryption
                    string choiceInput = Console.ReadLine();
                    if (int.TryParse(choiceInput, out choice) && (choice == 0 || choice == 1))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter either 0 for encryption or 1 for decryption");
                }

                int key;
                while (true)  // Input validation to only allow integer to be entered
                {
                    Console.Write("Enter number to shift by >>> "); //Shifting the message by what number is entered
                    string keyInput = Console.ReadLine();
                    if (int.TryParse(keyInput, out key))
                    {
                        key = key % 26; //Used to wrap around if the number > 26;
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a integer to be used for encryption or decryption");
                }

                char[] result = message.ToCharArray(); //Converts message from string to character

                // Loops through each character in the message
                for (int i = 0; i < result.Length; i++)
                {
                    char x = result[i];

                    if (char.IsLower(x)) //For lowercase character
                    {
                        result[i] = (char)((((x - 'a') + (choice == 0 ? key : 26 - key)) % 26) + 'a'); //Shifts the character + or - the key depending on the encryption or decryption using lowercase 'a' as a reference
                    }
                    else if (char.IsUpper(x)) //For uppercase character
                    {
                        result[i] = (char)((((x - 'A') + (choice == 0 ? key : 26 - key)) % 26) + 'A'); //Same logic as the lowercase one but using 'A' as reference instead
                    }
                }

                //Outputs message depending on choice made
                if (choice == 0)
                    Console.WriteLine("This is the encrypted message: " + new string(result));
                else
                    Console.WriteLine("This is the decrypted message: " + new string(result));

                //Try again
                while (true)
                {
                    Console.Write("Would you like to try again? \n0.Yes \n1.No \n>>> "); //Allowing the class to be looped
                    string retryInput = Console.ReadLine();
                    if (int.TryParse(retryInput, out int retry) && (retry == 0 || retry == 1))
                    {
                        if (retry == 0) break;
                        if (retry == 1) return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter either 0 for yes or 1 for no");
                    }
                }
               
            }
        }
    }
}
