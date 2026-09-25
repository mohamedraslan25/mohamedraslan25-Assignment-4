using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sessionNames = {"C# Basics", "Arrays", "Functions", "Date and Time", "Exception Handling"};

            DateTime[] sessionDates = {new DateTime(2026, 9, 10, 18, 0, 0), new DateTime(2026, 9, 13, 18, 0, 0), new DateTime(2026, 9, 17, 18, 0, 0), new DateTime(2026, 9, 20, 18, 0, 0), new DateTime(2026, 9, 24, 18, 0, 0)};

            int[] sessionDurations = {180, 240, 180, 240, 180};

            while (true)
            {
                Console.Clear();

                Console.WriteLine("==========================================");
                Console.WriteLine("       SESSION SCHEDULE SYSTEM");
                Console.WriteLine("==========================================");

                Console.WriteLine();
                Console.WriteLine("1. Display All Sessions");
                Console.WriteLine("2. Search For a Session");
                Console.WriteLine("3. Display Session Details");
                Console.WriteLine("4. Duration Analysis");
                Console.WriteLine("5. Get Session End Time");
                Console.WriteLine("6. Read Session Date");
                Console.WriteLine("7. Calculate Date Difference");
                Console.WriteLine("8. Display Session Status");
                Console.WriteLine("9. Find Next Session");
                Console.WriteLine("10. Display Formatted Date");
                Console.WriteLine("11. Read and Validate Date");
                Console.WriteLine("12. ref Example");
                Console.WriteLine("13. out Example");
                Console.WriteLine("14. Reference Type Example");
                Console.WriteLine("15. params Example");
                Console.WriteLine("16. Select Session By Index");
                Console.WriteLine("17. Validate Session Duration");
                Console.WriteLine("18. Build Report Using string");
                Console.WriteLine("19. Build Report Using StringBuilder");
                Console.WriteLine("20. Run BenchmarkDotNet");

                Console.WriteLine("0. Exit");

                Console.WriteLine();

                int choice = ReadMenuOption();

                switch (choice)
                {
                    case 1:

                        Console.Clear();

                        DisplayASessions(
                            sessionNames,
                            sessionDates,
                            sessionDurations);

                        break;

                    case 2:

                        Console.Clear();

                        SearchForSession(
                            sessionNames,
                            sessionDates,
                            sessionDurations);

                        break;

                    case 3:

                        Console.Clear();

                        Console.Write("Enter session name: ");
                        string sessionName = Console.ReadLine();

                        int sessionIndex =
                            Array.IndexOf(sessionNames, sessionName);

                        if (sessionIndex != -1)
                        {
                            DisplaySessionDetails(
                                sessionNames[sessionIndex],
                                sessionDates[sessionIndex],
                                sessionDurations[sessionIndex]);
                        }
                        else
                        {
                            Console.WriteLine("Session not found.");
                        }

                        break;

                    case 4:

                        Console.Clear();

                        int total =
                            GetTotalDuration(sessionDurations);

                        double average =
                            GetAverageDuration(sessionDurations);

                        int shortest =
                            GetShortestDuration(sessionDurations);

                        int longest =
                            GetLongestDuration(sessionDurations);

                        Console.WriteLine(
                            $"Total Duration: {total} minutes");

                        Console.WriteLine(
                            $"Average Duration: {average} minutes");

                        Console.WriteLine(
                            $"Shortest Duration: {shortest} minutes");

                        Console.WriteLine(
                            $"Longest Duration: {longest} minutes");

                        break;

                    case 5:

                        Console.Clear();

                        Console.Write("Enter session name: ");
                        string endTimeSession =
                            Console.ReadLine();

                        int endTimeIndex =
                            Array.IndexOf(
                                sessionNames,
                                endTimeSession);

                        if (endTimeIndex != -1)
                        {
                            DateTime endTime =
                                GetSessionEndTime(
                                    sessionDates[endTimeIndex],
                                    sessionDurations[endTimeIndex]);

                            Console.WriteLine(
                                $"Session: {sessionNames[endTimeIndex]}");

                            Console.WriteLine(
                                $"Start Time: " +
                                $"{sessionDates[endTimeIndex]:hh:mm tt}");

                            Console.WriteLine(
                                $"End Time: {endTime:hh:mm tt}");
                        }
                        else
                        {
                            Console.WriteLine("Session not found.");
                        }

                        break;

                    case 6:

                        Console.Clear();

                        DateTime enteredDate =
                            ReadSessionDate();

                        Console.WriteLine();
                        Console.WriteLine(
                            $"Entered Date: {enteredDate:dd MMMM yyyy}");

                        break;

                    case 7:

                        Console.Clear();

                        CalculateDateDifference(
                            sessionNames,
                            sessionDates);

                        break;

                    case 8:

                        Console.Clear();

                        DisplaySessionStatus(
                            sessionNames,
                            sessionDates);

                        break;

                    case 9:

                        Console.Clear();

                        FindNextSession(
                            sessionNames,
                            sessionDates);

                        break;

                    case 10:

                        Console.Clear();

                        DisplayFormattedDate(
                            sessionNames,
                            sessionDates);

                        break;

                    case 11:

                        Console.Clear();

                        DateTime validDate =
                            ReadAndValidateDate();

                        Console.WriteLine();
                        Console.WriteLine(
                            $"Valid Date: " +
                            $"{validDate:yyyy-MM-dd HH:mm}");

                        break;

                    case 12:

                        Console.Clear();

                        int number = 20;

                        Console.WriteLine(
                            $"Before: {number}");

                        ChangeValue(ref number);

                        Console.WriteLine(
                            $"After: {number}");

                        break;

                    case 13:

                        Console.Clear();

                        Console.Write("Enter session name: ");
                        string outSession =
                            Console.ReadLine();

                        int outIndex;
                        int outDuration;

                        bool found =
                            FindSessionUsingOut(
                                outSession,
                                sessionNames,
                                sessionDurations,
                                out outIndex,
                                out outDuration);

                        if (found)
                        {
                            Console.WriteLine(
                                $"Index: {outIndex}");

                            Console.WriteLine(
                                $"Duration: {outDuration} minutes");
                        }
                        else
                        {
                            Console.WriteLine(
                                "Session not found.");
                        }

                        break;

                    case 14:

                        Console.Clear();

                        /*
                         * We create a copy so that the original
                         * sessionNames array is not permanently
                         * changed for the rest of the program.
                         */

                        string[] namesCopy =
                            new string[sessionNames.Length];

                        Array.Copy(
                            sessionNames,
                            namesCopy,
                            sessionNames.Length);

                        Console.WriteLine("Before:");

                        for (int i = 0; i < namesCopy.Length; i++)
                        {
                            Console.WriteLine(namesCopy[i]);
                        }

                        ChangeArrayElement(namesCopy);

                        Console.WriteLine();
                        Console.WriteLine("After:");

                        for (int i = 0; i < namesCopy.Length; i++)
                        {
                            Console.WriteLine(namesCopy[i]);
                        }

                        break;

                    case 15:

                        Console.Clear();

                        int total1 =
                            CalculateTotalDuration(
                                120,
                                180);

                        int total2 =
                            CalculateTotalDuration(
                                120,
                                180,
                                240);

                        int total3 =
                            CalculateTotalDuration(
                                60,
                                90,
                                120,
                                180,
                                240);

                        Console.WriteLine(
                            $"Total 1: {total1} minutes");

                        Console.WriteLine(
                            $"Total 2: {total2} minutes");

                        Console.WriteLine(
                            $"Total 3: {total3} minutes");

                        break;

                    case 16:

                        Console.Clear();

                        SelectSessionByIndex(
                            sessionNames);

                        break;

                    case 17:

                        Console.Clear();

                        Console.Write("Enter duration: ");

                        int duration =
                            int.Parse(
                                Console.ReadLine());

                        try
                        {
                            ValidateSessionDuration(
                                duration);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(
                                ex.Message);
                        }

                        break;

                    case 18:

                        Console.Clear();

                        string report =
                            BuildReportUsingString(
                                sessionNames,
                                sessionDates,
                                sessionDurations);

                        Console.WriteLine(report);

                        break;

                    case 19:

                        Console.Clear();

                        string stringBuilderReport =
                            BuildReportUsingStringBuilder(
                                sessionNames,
                                sessionDates,
                                sessionDurations);

                        Console.WriteLine(
                            stringBuilderReport);

                        break;

                    case 20:

                        Console.Clear();

                        Console.WriteLine(
                            "Starting BenchmarkDotNet...");

                        Console.WriteLine(
                            "This may take some time.");

                        Console.WriteLine();

                        BenchmarkRunner.Run<StringBenchmark>();

                        return;

                    case 0:

                        Console.WriteLine(
                            "Goodbye!");

                        return;

                    default:

                        Console.WriteLine(
                            "Invalid option.");

                        break;
                }


                Console.WriteLine();
                Console.WriteLine(
                    "Press any key to return to the menu...");

                Console.ReadKey();
            }
        }



        /// <summary>
        /// Displays all sessions with their details.
        /// </summary>
        /// <param name="sessionNames"></param>
        /// <param name="sessionDates"></param>
        /// <param name="sessionDurations"></param>
        static void DisplayASessions(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            for (int i = 0; i < sessionNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {sessionNames[i]}");
                Console.WriteLine($"Date: {sessionDates[i]:dd MMMM yyyy}");
                Console.WriteLine($"Start Time: {sessionDates[i]:hh:mm tt}");
                Console.WriteLine($"Duration: {sessionDurations[i]} minutes");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Searches for a session by name and displays its details if found.
        /// </summary>
        /// <param name="sessionNames"></param>
        /// <param name="sessionDates"></param>
        /// <param name="sessionDurations"></param>
        static void SearchForSession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            Console.Write("Enter session name: ");
            string searchName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchName))
            {
                Console.WriteLine("Session name cannot be empty.");
                return;
            }

            int index = Array.IndexOf(sessionNames, searchName);

            if (index != -1)
            {
                Console.WriteLine($"{sessionNames[index]}");
                Console.WriteLine($"Date: {sessionDates[index]:dd MMMM yyyy}");
                Console.WriteLine($"Start Time: {sessionDates[index]:hh:mm tt}");
                Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
            }
            else
            {
                Console.WriteLine("Session not found.");
            }

            DisplaySessionDateDetails(sessionNames, sessionDates, sessionDurations);
        }

        /// <summary>
        /// Displays the details of a single session.
        /// </summary>
        /// <param name="sessionName"></param>
        /// <param name="sessionDate"></param>
        /// <param name="sessionDuration"></param>
        static void DisplaySessionDetails(
    string sessionName,
    DateTime sessionDate,
    int sessionDuration)
        {
            Console.WriteLine($"Name: {sessionName}");
            Console.WriteLine($"Date: {sessionDate:dd MMMM yyyy}");
            Console.WriteLine($"Start Time: {sessionDate:hh:mm tt}");
            Console.WriteLine($"Duration: {sessionDuration} minutes");
        }

        /// <summary>
        /// Calculates the total duration of all sessions.
        /// </summary>
        /// <param name="sessionDurations"></param>
        /// <returns></returns>

        static int GetTotalDuration(int[] sessionDurations)
        {
            int total = 0;

            for (int i = 0; i < sessionDurations.Length; i++)
            {
                total += sessionDurations[i];
            }

            return total;
        }

        /// <summary>
        /// Calculates the average duration of all sessions.
        /// </summary>
        /// <param name="sessionDurations"></param>
        /// <returns></returns>

        static double GetAverageDuration(int[] sessionDurations)
        {
            int total = GetTotalDuration(sessionDurations);

            return (double)total / sessionDurations.Length;
        }


        /// <summary>
        /// Calculates the shortest duration among all sessions.
        /// </summary>
        /// <param name="sessionDurations"></param>
        /// <returns></returns>
        static int GetShortestDuration(int[] sessionDurations)
        {
            int shortest = sessionDurations[0];

            for (int i = 1; i < sessionDurations.Length; i++)
            {
                if (sessionDurations[i] < shortest)
                {
                    shortest = sessionDurations[i];
                }
            }

            return shortest;
        }

        /// <summary>
        /// Calculates the longest duration among all sessions.
        /// </summary>
        /// <param name="sessionDurations"></param>
        /// <returns></returns>
        static int GetLongestDuration(int[] sessionDurations)
        {
            int longest = sessionDurations[0];

            for (int i = 1; i < sessionDurations.Length; i++)
            {
                if (sessionDurations[i] > longest)
                {
                    longest = sessionDurations[i];
                }
            }

            return longest;
        }

        /// <summary>
        /// Calculates the end time of a session based on its start time and duration.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="durationMinutes"></param>
        /// <returns></returns>
        static DateTime GetSessionEndTime(
    DateTime startTime,
    int durationMinutes)
        {
            return startTime.AddMinutes(durationMinutes);
        }

        /// <summary>
        /// Reads a session date from user input and returns it as a DateTime object.
        /// </summary>
        /// <returns></returns>
        static DateTime ReadSessionDate()
        {
            Console.Write("Enter session date (yyyy-MM-dd): ");

            DateTime date = DateTime.Parse(
                Console.ReadLine());

            return date;
        }

        /// <summary>
        /// Builds a report of all sessions using string concatenation.
        /// </summary>
        /// <param name="sessionNames"></param>
        /// <param name="sessionDates"></param>
        /// <param name="sessionDurations"></param>
        /// <returns></returns>
        static string BuildReportUsingString(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            string result = "";

            for (int i = 0; i < sessionNames.Length; i++)
            {
                result += $"{sessionNames[i]} - ";
                result += $"{sessionDates[i]:dd/MM/yyyy hh:mm tt} - ";
                result += $"{sessionDurations[i]} minutes\n";
            }

            return result;
        }

        /// <summary>
        /// Builds a report of all sessions using StringBuilder for better performance.
        /// </summary>
        /// <param name="sessionNames"></param>
        /// <param name="sessionDates"></param>
        /// <param name="sessionDurations"></param>
        /// <returns></returns>
        static string BuildReportUsingStringBuilder(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < sessionNames.Length; i++)
            {
                result.Append($"{sessionNames[i]} - ");
                result.Append($"{sessionDates[i]:dd/MM/yyyy hh:mm tt} - ");
                result.Append($"{sessionDurations[i]} minutes\n");
            }

            return result.ToString();
        }

        /// <summary>
        /// Changes the value of an integer by adding 10 to it using the ref keyword.
        /// </summary>
        /// <param name="number"></param>
        static void ChangeValue(ref int number)
        {
            number = number + 10;
        }

        /// <summary>
        /// Finds a session by name and returns its index and duration using the out keyword.
        /// </summary>
        /// <param name="sessionName"></param>
        /// <param name="sessionNames"></param>
        /// <param name="sessionDurations"></param>
        /// <param name="index"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        static bool FindSessionUsingOut(string sessionName, string[] sessionNames, int[] sessionDurations, out int index, out int duration)
        {
            index = Array.IndexOf(sessionNames, sessionName);

            if (index != -1)
            {
                duration = sessionDurations[index];
                return true;
            }

            duration = 0;
            return false;
        }

        /// <summary>
        /// Changes the first element of the session names array to "Modified Session".
        /// </summary>
        /// <param name="names"></param>
        static void ChangeArrayElement(string[] names)
        {
            names[0] = "Modified Session";
        }

        /// <summary>
        /// Calculates the total duration of all sessions using the params keyword to accept a variable number of arguments.
        /// </summary>
        /// <param name="durations"></param>
        /// <returns></returns>
        static int CalculateTotalDuration(params int[] durations)
        {
            int total = 0;

            for (int i = 0; i < durations.Length; i++)
            {
                total += durations[i];
            }

            return total;
        }

        /// <summary>
        /// Displays detailed information about a session, including its date, day of the week, year, month, day number, start time, duration, and end time.
        /// </summary>
        /// <param name="sessionNames"></param>
        /// <param name="sessionDates"></param>
        /// <param name="sessionDurations"></param>
        static void DisplaySessionDateDetails(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
        {
            Console.Write("Enter session name: ");
            string searchName = Console.ReadLine();

            int index = Array.IndexOf(sessionNames, searchName);

            if (index != -1)
            {
                DateTime sessionDate = sessionDates[index];
                int duration = sessionDurations[index];

                DateTime endTime = sessionDate.AddMinutes(duration);

                Console.WriteLine();
                Console.WriteLine($"Session: {sessionNames[index]}");
                Console.WriteLine($"Date: {sessionDate:dd MMMM yyyy}");
                Console.WriteLine($"Day: {sessionDate.DayOfWeek}");
                Console.WriteLine($"Year: {sessionDate.Year}");
                Console.WriteLine($"Month: {sessionDate.Month}");
                Console.WriteLine($"Day Number: {sessionDate.Day}");
                Console.WriteLine($"Start Time: {sessionDate:hh:mm tt}");
                Console.WriteLine($"Duration: {duration} minutes");
                Console.WriteLine($"End Time: {endTime:hh:mm tt}");
            }
            else
            {
                Console.WriteLine("Session not found.");
            }
        }

        /// <summary>
        /// Calculates the difference in days and hours between two sessions based on their names and displays the result.
        /// </summary>
        /// <param name="sessionNames"></param>
        /// <param name="sessionDates"></param>
        static void CalculateDateDifference(string[] sessionNames, DateTime[] sessionDates)
        {
            Console.Write("Enter first session name: ");
            string firstSession = Console.ReadLine();

            Console.Write("Enter second session name: ");
            string secondSession = Console.ReadLine();

            int firstIndex = Array.IndexOf(sessionNames, firstSession);
            int secondIndex = Array.IndexOf(sessionNames, secondSession);

            if (firstIndex != -1 && secondIndex != -1)
            {
                DateTime firstDate = sessionDates[firstIndex];
                DateTime secondDate = sessionDates[secondIndex];

                TimeSpan difference = secondDate - firstDate;

                Console.WriteLine();
                Console.WriteLine($"First Session: {firstSession}");
                Console.WriteLine($"Second Session: {secondSession}");
                Console.WriteLine($"Difference: {difference.TotalDays} days");
                Console.WriteLine($"Difference: {difference.TotalHours} hours");
            }
            else
            {
                Console.WriteLine("One or both sessions were not found.");
            }
        }

        /// <summary>
        /// Displays the status of each session as either "Past" or "Upcoming" based on the current date and time.
        /// </summary>
        /// <param name="sessionNames"></param>
        /// <param name="sessionDates"></param>
        static void DisplaySessionStatus(string[] sessionNames, DateTime[] sessionDates)
        {
            DateTime now = DateTime.Now;

            for (int i = 0; i < sessionNames.Length; i++)
            {
                if (sessionDates[i] < now)
                {
                    Console.WriteLine($"{sessionNames[i]} - Past");
                }
                else
                {
                    Console.WriteLine($"{sessionNames[i]} - Upcoming");
                }
            }
        }

        /// <summary>
        /// Finds the next upcoming session based on the current date and time and displays its details, including the time remaining until it starts.
        /// </summary>
        /// <param name="sessionNames"></param>
        /// <param name="sessionDates"></param>
        static void FindNextSession(
    string[] sessionNames,
    DateTime[] sessionDates)
        {
            DateTime now = DateTime.Now;

            int nextIndex = -1;
            DateTime nearestDate = DateTime.MaxValue;

            for (int i = 0; i < sessionDates.Length; i++)
            {
                if (sessionDates[i] > now &&
                    sessionDates[i] < nearestDate)
                {
                    nearestDate = sessionDates[i];
                    nextIndex = i;
                }
            }

            if (nextIndex != -1)
            {
                TimeSpan remainingTime = nearestDate - now;

                Console.WriteLine($"Next Session: {sessionNames[nextIndex]}");
                Console.WriteLine($"Date: {nearestDate:dd MMMM yyyy}");
                Console.WriteLine($"Start Time: {nearestDate:hh:mm tt}");
                Console.WriteLine(
                    $"Time Remaining: {remainingTime.Days} days " +
                    $"{remainingTime.Hours} hours");
            }
            else
            {
                Console.WriteLine("There are no upcoming sessions.");
            }
        }

        /// <summary>
        /// Displays the date of a session in various formats based on the session name provided by the user.
        /// </summary>
        /// <param name="sessionNames"></param>
        /// <param name="sessionDates"></param>
        static void DisplayFormattedDate(
    string[] sessionNames,
    DateTime[] sessionDates)
        {
            Console.Write("Enter session name: ");
            string searchName = Console.ReadLine();

            int index = Array.IndexOf(sessionNames, searchName);

            if (index != -1)
            {
                DateTime sessionDate = sessionDates[index];

                Console.WriteLine();
                Console.WriteLine($"Session: {sessionNames[index]}");

                Console.WriteLine(
                    $"Format 1: {sessionDate.ToString("yyyy-MM-dd")}");

                Console.WriteLine(
                    $"Format 2: {sessionDate.ToString("dd/MM/yyyy")}");

                Console.WriteLine(
                    $"Format 3: {sessionDate.ToString("dd MMMM yyyy")}");

                Console.WriteLine(
                    $"Format 4: {sessionDate.ToString("dddd, dd MMMM yyyy")}");

                Console.WriteLine(
                    $"Format 5: {sessionDate.ToString("hh:mm tt")}");
            }
            else
            {
                Console.WriteLine("Session not found.");
            }
        }

        /// <summary>
        /// Reads a date and time input from the user in the format "yyyy-MM-dd HH:mm" and validates it. If the input is valid, it returns the corresponding DateTime object; otherwise, it prompts the user to try again until a valid date is entered.
        /// </summary>
        /// <returns></returns>
        static DateTime ReadAndValidateDate()
        {
            while (true)
            {
                Console.Write("Enter date (yyyy-MM-dd HH:mm): ");
                string input = Console.ReadLine();

                DateTime result;

                bool isValid = DateTime.TryParseExact(
                    input,
                    "yyyy-MM-dd HH:mm",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out result);

                if (isValid)
                {
                    return result;
                }

                Console.WriteLine("Invalid date. Please try again.");
            }
        }

        /// <summary>
        /// Reads a menu option input from the user and validates it. If the input is a valid integer, it returns the corresponding option; otherwise, it prompts the user to try again until a valid option is entered.
        /// </summary>
        /// <returns></returns>
        static int ReadMenuOption()
        {
            while (true)
            {
                Console.Write("Choose an option: ");

                try
                {
                    string input = Console.ReadLine();
                    int option = int.Parse(input);

                    return option;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid menu option. Enter a number.");
                }
                finally
                {
                    Console.WriteLine("Input operation finished.");
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter a session index and displays the corresponding session name. If the index is out of range, it catches the exception and informs the user.
        /// </summary>
        /// <param name="sessionNames"></param>
        static void SelectSessionByIndex(string[] sessionNames)
        {
            Console.Write("Enter session index: ");
            int index = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine($"Session: {sessionNames[index]}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(
                    "The selected session index is out of range.");
            }
        }

        /// <summary>
        /// Validates the session duration to ensure it is greater than zero. If the duration is invalid, it throws an ArgumentException; otherwise, it confirms that the duration is accepted.
        /// </summary>
        /// <param name="duration"></param>
        /// <exception cref="ArgumentException"></exception>
        static void ValidateSessionDuration(int duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentException(
                    "Duration must be greater than zero.");
            }

            Console.WriteLine("Duration accepted.");
        }

   


    }


    }
