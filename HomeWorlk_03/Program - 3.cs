using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorlk_03
{
    class Program3
    {
        /// <summary>
        /// Задание 2
        /// </summary>
        /// <param name="args"></param>
        public static void Main3()
        {
            // глобальные переменные
            int userAnswers = 0;
            Random random = new Random();
            int startNum = 12, lastNum = 120;
            int minTry = 1, maxTry = 4;
            bool isRevengeOn = false;
            int lastGame = 0;


            Console.WriteLine("Приветсвую вас в игре Симпл. В этой игре компьютер загадает число от 12 до 120 случайным образом.");
            Console.WriteLine("Правила:");
            Console.WriteLine("1. Игроки ходят по очереди. ");
            Console.WriteLine("2. Можно ввести число от 1 до 4.");
            Console.WriteLine("3. Если будет введено число меньше 1 или больше 4 - будет штраф в виде пропуска хода.");
            Console.WriteLine("4. Число, введенное игроком, будет отниматься от загаданного.");
            Console.WriteLine("Задача игрока: своим ходом сделать так, чтобы загаданное число стало равна 0, а так же помешать сделать это сопернику.");
            Console.WriteLine("Выйграет тот, кто первый обнулит загаданное число.");
            Console.WriteLine();
            Console.WriteLine("Некоторые параметры, которые можно настроить - диапазон загадываего числа и диапазон вводимых значений.");
            Console.Write("Настроить? (1 - да, остальные клавиши - нет): ");
            Int32.TryParse(Console.ReadLine(), out userAnswers);
            if (userAnswers == 1)
            {
                Console.Write($"Введите нижнюю границу для загадываего числа(по умолчанию - {startNum}): ");
                Int32.TryParse(Console.ReadLine(), out startNum);

                Console.Write($"Введите верхнюю границу для загадываего числа(по умолчанию - {lastNum}): ");
                Int32.TryParse(Console.ReadLine(), out lastNum);

                Console.Write($"Введите нижнюю границу для вводимого числа(по умолчанию - {minTry}): ");
                Int32.TryParse(Console.ReadLine(), out minTry);

                Console.Write($"Введите верхнюю границу для вводимого числа(по умолчанию - {maxTry}): ");
                Int32.TryParse(Console.ReadLine(), out maxTry);


            }

            while (true)
            {
                int userAnswer = 0;

                if (isRevengeOn)
                {
                    
                    Console.Write("Провести матч-реванш?!?(1 - да, 2 - нет, выход из игры): ");
                    Int32.TryParse(Console.ReadLine(), out userAnswers);
                    if (userAnswers == 1)
                    {
                        userAnswer = lastGame;
                    }
                    else
                    {
                        userAnswer = 3;
                    }
                }
                else
                {
                    Console.Write("Начать игру?(1 - два игрока; 2 - один игрок, один комп; 3 - выход из игры): ");
                    Int32.TryParse(Console.ReadLine(), out userAnswer);
                    
                }

                if (userAnswer == 1)
                // игра началась :PVP mode
                {
                    lastGame = userAnswer;
                    Console.Clear();
                    string str = "* * * * * * * * * * * Player VS Player MODE * * * * * * * * * * *";
                    Console.SetCursorPosition(Console.WindowWidth / 2 - str.Length / 2, 0);
                    Console.WriteLine(str);
                    string userName1 = "Player1", userName2 = "Player2", lastStepUser = "";
                    string temp = "";
                    int gameNumber = random.Next(startNum, lastNum);
                    int stepCount = 0;
                    int playersCount = 2;
                    int userTry = 0;

                    Console.WriteLine("Для начала игры необходимо представиться. Если хотите оставить имена по умолчанию - нажмите кнопку ввода.");

                    Console.Write($"Первый игрок вводит свое имя(по умолчанию {userName1}): ");
                    temp = Console.ReadLine();
                    if (temp != "")
                    {
                        userName1 = temp;
                    }

                    Console.Write($"Второй игрок вводит свое имя(по умолчанию {userName2}): ");
                    temp = Console.ReadLine();
                    if (temp != "")
                    {
                        userName2 = temp;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("* * * * * * * * * * * * * * * * *");
                    Console.WriteLine($"Было загадано число {gameNumber}");
                    Console.WriteLine("* * * * * * * * * * * * * * * * *");
                    Console.WriteLine("");


                    while (gameNumber > 0)
                    {
                        if (gameNumber < maxTry && gameNumber >= minTry)
                        {
                            Console.WriteLine();
                            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                            Console.WriteLine("Игроки, будьте внимательны! Нельзя вводить число больше, чем последний результат!");
                            Console.WriteLine("При вводе такого числа будет штраф - пропуск хода.");
                            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");

                        }
                        stepCount++;
                        if (stepCount % playersCount == 1)
                        {
                            Console.Write($"Игрок {userName1} ходит: ");
                            Int32.TryParse(Console.ReadLine(), out userTry);
                            if (userTry < minTry || userTry > maxTry || userTry > gameNumber)
                            {
                                Console.WriteLine("Некорректный ввод! Пропуск хода");
                                Console.WriteLine("!---------------------------------!");
                                continue;
                            }
                            lastStepUser = userName1;
                        }
                        else
                        {
                            Console.Write($"Игрок {userName2} ходит: ");
                            Int32.TryParse(Console.ReadLine(), out userTry);
                            if (userTry < minTry || userTry > maxTry || userTry > gameNumber)
                            {
                                Console.WriteLine("Некорректный ввод! Пропуск хода");
                                Console.WriteLine("!---------------------------------!");
                                continue;
                            }
                            lastStepUser = userName2;
                        }

                        gameNumber -= userTry;

                        if (gameNumber > 0)
                        {
                            Console.WriteLine($"Результат хода: {gameNumber}");
                            Console.WriteLine("----------------------------------");
                        }
                        else if (gameNumber == 0)
                        {
                            Console.WriteLine($"Победа! Игра окончена. Победитель - {lastStepUser}");
                            isRevengeOn = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Результат хода: {gameNumber}");
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("Странное завешение игры...");
                        }
                    }

                }

                // игра началась : PvPC MODE
                else if (userAnswer == 2)
                {
                    lastGame = userAnswer;
                    Console.Clear();
                    string str = "* * * * * * * * * * * Player VS PC MODE * * * * * * * * * * *";
                    Console.SetCursorPosition(Console.WindowWidth / 2 - str.Length / 2, 0);
                    Console.WriteLine(str);
                    string userName1 = "Player1", userName2 = "PC", lastStepUser = "";
                    string temp = "";
                    string lvl = "";
                    int tempo = 0;
                    int gameNumber = random.Next(startNum, lastNum);
                    int stepCount = 0;
                    int playersCount = 2;
                    int userTry = 0;

                    Console.WriteLine("Для начала игры необходимо представиться. Если хотите оставить имя по умолчанию - нажмите кнопку ввода.");

                    Console.Write($"Первый игрок вводит свое имя(по умолчанию {userName1}): ");
                    temp = Console.ReadLine();
                    if (temp != "")
                    {
                        userName1 = temp;
                    }

                    Console.Write("Выберите уровень сложности для ПК: легкий - 1, тяжелый - 2): ");
                    Int32.TryParse(Console.ReadLine(), out tempo);
                    while (true)
                    {
                        if (tempo == 1) // easy level
                        {
                            lvl = "easy";
                            break;
                        }
                        else if (tempo == 2)// hard level!
                        {
                            lvl = "hard";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод!");
                            continue;
                        }
                    }

                    Console.WriteLine("");
                    Console.WriteLine("* * * * * * * * * * * * * * * * *");
                    Console.WriteLine($"Было загадано число {gameNumber}");
                    Console.WriteLine("* * * * * * * * * * * * * * * * *");
                    Console.WriteLine("");


                    while (gameNumber > 0)
                    {
                        if (gameNumber < maxTry && gameNumber >= minTry)
                        {
                            Console.WriteLine();
                            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");
                            Console.WriteLine("Игрок, будьте внимателен! Нельзя вводить число больше, чем последний результат!");
                            Console.WriteLine("При вводе такого числа будет штраф - пропуск хода.");
                            Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *");

                        }
                        stepCount++;
                        if (stepCount % playersCount == 1)
                        {
                            Console.Write($"Игрок {userName1} ходит: ");
                            Int32.TryParse(Console.ReadLine(), out userTry);
                            if (userTry < minTry || userTry > maxTry || userTry > gameNumber)
                            {
                                Console.WriteLine("Некорректный ввод! Пропуск хода");
                                Console.WriteLine("!---------------------------------!");
                                continue;
                            }
                            lastStepUser = userName1;
                        }
                        else
                        {
                            Console.Write($"Игрок {userName2} ходит: ");
                            if(lvl == "easy")
                            {
                                userTry = random.Next(minTry, maxTry);
                                Console.WriteLine(userTry);
                            }
                            else
                            {
                                for (int i = minTry; i < maxTry + 1; i++)
                                {
                                    if ((gameNumber - i) % (maxTry + 1) == 0)
                                    {
                                        userTry = i;
                                        break;
                                    }
                                    else
                                    {
                                        userTry = random.Next(0,2);
                                        continue;
                                    }

                                }
                            }
                            
                            Console.WriteLine(userTry);
                            if (userTry == 0)
                                Console.WriteLine("PC пропускает ход!");

                            lastStepUser = userName2;
                        }

                        gameNumber -= userTry;

                        if (gameNumber > 0)
                        {
                            Console.WriteLine($"Результат хода: {gameNumber}");
                            Console.WriteLine("----------------------------------");
                        }
                        else if (gameNumber == 0)
                        {
                            Console.WriteLine($"Победа! Игра окончена. Победитель - {lastStepUser}");
                            isRevengeOn = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Результат хода: {gameNumber}");
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("Странное завешение игры...");
                        }
                    }
                }
                else if (userAnswer == 3)
                // выход из игры
                {
                    Console.WriteLine("До свидания!");
                    break;
                }
                else
                // неправильный ввод
                {
                    Console.WriteLine("Некорректный ввод, попробуйте еще раз!");
                    continue;
                }

            }
            Console.ReadLine();
        }
    }
}
