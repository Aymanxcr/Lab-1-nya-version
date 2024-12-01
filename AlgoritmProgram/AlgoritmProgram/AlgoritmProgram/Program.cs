//Detta kodprogram ska läsa delsträngar utan bokstäver som börjar och slutar med samma nummer.
//Dessutom måste den märkas med blått. Därefter måste siffrorna läggas ihop och summeras.

using System;  //möjliggör tillämpning av många tekniker och slag

// Begär en textsträng från användaren. En standardsträng används om användaren trycker på Enter utan att skriva något
Console.WriteLine("Ange en textsträng (tryck Enter för att använda standardsträngen): ");
string input = Console.ReadLine();
if (string.IsNullOrEmpty(input)) // Standardsträngen nedan används om användaren inte anger något
{
    input = "29535123p48723487597645723645";
}
MarkeraSekvenser(input); // funktionen som lägger ihop sekvenserna anropas och markerar dem
Console.Write("\n\nTryck på en tangent för att stänga fönstret");
Console.ReadKey();
void MarkeraSekvenser(string input)
{
    long totalSum = 0; // För att övervaka summan av alla siffror som matchar
    for (int i = 0; i < input.Length; i++) // varje tecken i strängen loops igenom
    {
        if (char.IsDigit(input[i])) // checkar om tecknet är en siffra
        {
            for (int j = i + 1; j < input.Length; j++) // för att hitta en matchande slutsiffra så Startar jag en inre loop
            {
                if (!char.IsDigit(input[j])) // inner loopen ska brytas om tecknet inte är ett tal
                {
                    break;
                }
                if (input[i] == input[j]) // verifiera sekvensen om siffrorna I och J är samma.
                {
                    // Kontrollera att i och j inte har samma nummer imellan.
                    bool korrektSekvens = true; // Tills motsatsen visas, anta att sekvensen är korrekt.
                    for (int m = i + 1; m < j; m++) // går igenom talen från I till J i loop
                    {
                        if (input[m] == input[i]) // Markera sekvensen som fel om samma siffra visas mellan i och j.
                        {
                            korrektSekvens = false;
                            break; // Om sekvensen är felaktig, avbryt loopen
                        }
                    }
                    if (korrektSekvens)
                    {
                        // Skriver ut hela strängen med den grönmarkerade matchande sekvensen
                        for (int k = 0; k < input.Length; k++) // Skriv ut tecknen genom att loopa genom hela strängen
                        {
                            if (k >= i && k <= j) // Om platsen faller inom den sekvens som matchar
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen; // Den valda sekvensens färg 

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray; // gör andra övriga karaktärers färger gråtecken
                            }
                            Console.Write(input[k]);
                        }
                        Console.WriteLine();
                        // Ta ut ett nummer ur sekvensen och lägg till det till summan
                        string tal = input.Substring(i, j - i + 1); // hämtar motsvarande sekvens som en substring

                        totalSum += long.Parse(tal); // lägger till sekvensen till totalsumma efter att ha konverterat den till ett tal
                        break; // För att återuppta sökningen från nästa plats, stäng den inre loopen
                    }
                }
            }
        }
    }
    // Återställ färgen till dess ursprungliga konfiguration.
    Console.ResetColor();
    // Skriv ut summan av alla siffror som matchar
    Console.WriteLine($"\nSumma = {totalSum}"); // Skriv ut totalsumman av alla sekvenser som matchar
}