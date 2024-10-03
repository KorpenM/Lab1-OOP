using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Addition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "29535123p48723487597645723645";
            long sum = 0; // Lagrar summan av alla giltliga substrings som hittas i input string

            Console.WriteLine();
            Console.WriteLine("Det här programmet räknar ut alla giltliga talföljder " +
                "och markerar sedan dessa i färg.");
            Console.WriteLine("Till slut adderas alla tal till den totala summan.");
            Console.WriteLine();


            // Använder en lista som sparar alla korrekta substrings från input
            List<string> validNumbers = new List<string>();

            // Loopar igenom varje siffra i input från start till slut, index 'i'
            // startar från noll till strängens längd, minus ett 
            for (int i = 0; i < input.Length; i++)
            {
                // if statement Char.IsDigit kontrollerar att det enskilda
                // tecknet i den aktuella indexen är en siffra
                if (Char.IsDigit(input[i])) // Är det OK så fortsätter det tills en likadan siffra hittats
                {
                    // En inre loop som bygger talföljder
                    for (int n = i + 1; n < input.Length; n++)
                    {
                        // Den inre loopen letar efter talföljd som börjar på i och
                        // sträcker sig till n - Allt däremellan kontrolleras för att få rätt talföljd
                        if (Char.IsDigit(input[n]))
                        {
                            // Med denna metod skapas en substring talföljd från i - n
                            string number = input.Substring(i, n - i + 1);

                            // if statement att kontrollera substringen så den är giltlig
                            // dvs att första och sista siffran är lika
                            // Mer om metod "ValidNumber" längre ner i koden
                            if (number[0] == number[number.Length - 1] && ValidNumber(number))
                            {
                                // Är substringen OK anropas funktionen PrintStringColor
                                // för att skriva ut strängen markerad i angiven färg
                                PrintStringColor(input, number, i);
                                // Giltliga substrings läggs till i listan validNumbers
                                // som behövs för användning av summering och addition
                                validNumbers.Add(number);
                                // Konverterar med long.Parse och adderar ihop talen till totalen
                                sum += long.Parse(number);
                            }
                        }
                        else
                        {
                            // Avbryter process vid möte av felaktigt/inget siffertecken
                            break;
                        }
                    }
                }
            }

            Console.WriteLine();
            // Alla giltliga tal summeras och skrivs ut enligt input string
            Console.WriteLine($"Den totala summan blir = ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sum); // Skriver ut summan i färg
            Console.ResetColor();



            // EXTRA
            Console.WriteLine();
            Console.WriteLine("Tryck på valfri tangent för att se alla giltliga kombinationer.");
            Console.ReadKey();

            // Ett extra tillägg för konsollen att skriva ut varje
            // giltligt nummer från listan
            Console.WriteLine("\nGiltliga kombinationer: ");
            Console.WriteLine();
            foreach (var number in validNumbers) // foreach loop som går
            // igenom listan och skriver ut varje giltlig nummerkombination
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(number);
                Console.ResetColor();
            }

            Console.WriteLine("\nTryck på enter för att stänga programmet...");
            Console.ReadKey();
        }

        // Funktion att kontrollera så inga/resterande siffror
        // mellan talen är samma som första och sista
        static bool ValidNumber(string number)
        {
            // Kontrollerar så att ingen siffra förutom första & sista är samma
            for (int i = 1; i < number.Length - 1; i++)
            {
                // Om någon siffra i mitten är samma som första & sista
                // så är den ogiltig och returnerar i false
                if (number[i] == number[0])
                {
                    return false;
                }
            }
            // Är talföljden däremot korrekt så returnerar den i true
            return true;
        }

        // Funktion för att skriva ut talen markerad i färg
        // Hela stringen skrivs ut men markerar endast giltliga talföljder
        static void PrintStringColor(string input, string number, int startIndex)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (i == startIndex) // Vi har nått den plats där vi ska börja markera
                {
                    // Korrekta strings markeras med grön text
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(number); // Skriver ut det giltliga numret
                    Console.ResetColor(); // Färgen återställs tills nästa kombination

                    i += number.Length - 1; // Hoppar fram till slutet av det giltiga
                                            // numret för att förhindra loop av samma tecken
                }
                else
                {
                    Console.Write(input[i]); // Skriver ut omarkerade tecken

                }
            }
            Console.WriteLine(); // Ny rad efter varje utskrift
        }
    }
}