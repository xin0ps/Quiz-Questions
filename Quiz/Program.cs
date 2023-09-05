using System;

namespace Quiz
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string[] questions = new string[10] {
                "C# dilində dövr əməliyyatlarını həyata keçirmək üçün istifadə olunan açar söz hansıdır?",
                "C#-da dəyişənlər hansı tipli məlumatları saxlaya bilər?",
                "C#-da ifadələr hansı simvollardan sonra bitirilməlidir?",
                "C#-da funksiya necə təyin edilir?",
                "C#-da 'int' tipində bir dəyişəni iki ədəddən bölmək üçün hansı əməliyyat işarəsini istifadə edirik?",
                "C#-da 'Console.WriteLine()' funksiyasının nə iş gördüyünü izah edin.",
                "C#-da 'if' şərt operatoru nə üçün istifadə edilir?",
                "C#-da dövr operatorları hansılardır?",
                "C#-da bir dəyişənin dəyərini ekrana çap etmək üçün hansı əməliyyatı istifadə edirik?",
                "C#-da dövrdə 'break' və 'continue' ifadələrinin fərqi nədir?"
            };

            string[,] answers = new string[10, 3] {
                { "for", "while", "loop" },
                { "Bütün tiplər", "Yalnız 'string'", "Yalnız 'int'" },
                { "Noqtelı vergül (;)", "Nöqtə (.)", "Qoşa vergül (,)" },
                { "void myFunction() { }", "function myFunction() { }", "sub myFunction() { }" },
                { "+", "*", "/", },
                { "Bu funksiya konsola məlumat yazdırır.", "Bu funksiya məlumatı fayla yazdırır.", "Bu funksiya məlumatı ekrana çap etmir." },
                { "Ədəd və şərt müqayisəsi üçün", "Dövrdə iterasiyanın sayını təyin etmək üçün", "Sözlərin təkrarlanmasını təyin etmək üçün" },
                { "for, while, do-while", "if, else, switch", "int, string, double" },
                { "Console.Write()", "Console.Read()", "Console.Print()" },
                { "Console.Write()", "Console.Read()", "Console.Print()" },
            };

            int[] correctAnswers = new int[10] {
                0, 0, 0, 0, 2, 0, 2, 0, 0, 2
            };

            
            ShuffleQuestionsAndAnswers(questions, answers, correctAnswers);

            int score = 0;

            for (int index = 0; index < questions.Length; index++)
            {
                Console.Clear();
                Console.WriteLine($"{index + 1}. {questions[index]}\n");
                Console.WriteLine($"a) {answers[index, 0]}");
                Console.WriteLine($"b) {answers[index, 1]}");
                Console.WriteLine($"c) {answers[index, 2]}\n");

                Console.Write("Zəhmət olmasa doğru variantı seçin (a, b və ya c): ");
                string userChoice = Console.ReadLine();

                if (userChoice.ToLower() == "a" || userChoice.ToLower() == "b" || userChoice.ToLower() == "c")
                {
                    int selectedOption = userChoice.ToLower() switch
                    {
                        "a" => 0,
                        "b" => 1,
                        "c" => 2,
                        _ => -1
                    };

                    if (selectedOption == correctAnswers[index])
                    {
                        score++;

                        Console.WriteLine("\nSiz düzgün cavab verdiniz!");
                    }
                    else
                    {

                        Console.WriteLine("\nSiz yanlış cavab verdiniz!");
                    }

                    Console.WriteLine($"Cavabları gözləyin... (2 saniyə)");

                    System.Threading.Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Yanlış variant daxil etdiniz. Zəhmət olmasa a, b və ya c seçiminizə uyğun düz variantı seçin.");
                    index--;
                }
            }

            Console.Clear();
            Console.WriteLine($"Siz {questions.Length} sualın {score} düzgün cavablandırdınız.");
        }

     
        static void ShuffleQuestionsAndAnswers(string[] questions, string[,] answers, int[] correctAnswers)
        {
            Random random = new Random();
            int n = questions.Length;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

              
                string tempQuestion = questions[i];
                questions[i] = questions[j];
                questions[j] = tempQuestion;

               
                for (int k = 0; k < 3; k++)
                {
                    string tempAnswer = answers[i, k];
                    answers[i, k] = answers[j, k];
                    answers[j, k] = tempAnswer;
                }

               
                int tempCorrectAnswer = correctAnswers[i];
                correctAnswers[i] = correctAnswers[j];
                correctAnswers[j] = tempCorrectAnswer;
            }
        }
    }
}