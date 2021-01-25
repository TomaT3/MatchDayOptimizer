using ConsoleApp1.Data;
using ConsoleApp1.Extensions;
using ConsoleApp1.Model;
using ConsoleApp1.Rules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public static int NUMBER_OF_COURTS = 6;
        public static int NUMBER_OF_TIMESLOTS = 7;

        static void Main(string[] args)
        {
            var playersRepository = new PlayersRepository();
            var possibleMatches = InitData.GetPossibleMatches(playersRepository.Players);
            //var timeSlots = InitData.GetTimeSlots();


            //var test = from timeslot in timeSlots
            //           from match in possibleMatches
            //           select new { Group = match, Combination = timeslot };

            var stopwatchForGetPossiblePlaydays = Stopwatch.StartNew();
            var allPossiblePlaydays = GetAllPossibleMatches(possibleMatches);
            stopwatchForGetPossiblePlaydays.Stop();
            Console.WriteLine($"Time needed to calculate all possible playdays: {stopwatchForGetPossiblePlaydays.Elapsed}");

            var stopwatchForApplyingRules = Stopwatch.StartNew();
            List<(double rating, PlaydaySchedule playday)> ratedPlayDayList = ApplyRules(playersRepository, allPossiblePlaydays);
            var sortedPlayDayList = ratedPlayDayList.OrderByDescending(p => p.rating).ToList();
            stopwatchForApplyingRules.Stop();

           
            Console.WriteLine($"Time needed to apply rules to all possible playdays: {stopwatchForApplyingRules.Elapsed}");
            Console.WriteLine(Environment.NewLine);
            for (int i = 1; i < 4; i++)
            {
                var rating = sortedPlayDayList[i].rating;
                var playday = sortedPlayDayList[i].playday;
                Console.WriteLine($"#{i} - with Rating: {rating}%");
                foreach (var match in playday.PlaydayMatches)
                {
                    Console.WriteLine($"Timeslot {match.Key}");
                    foreach(var m in match.Value)
                    Console.WriteLine($"     {m}");
                }

                Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine("##### end #######");
        }

        private static List<(double rating, PlaydaySchedule playday)> ApplyRules(PlayersRepository playersRepository, List<PlaydaySchedule> allPossiblePlaydays)
        {
            var ratedPlayDayList = new List<(double rating, PlaydaySchedule playday)>();
            foreach (var playday in allPossiblePlaydays)
            {
                var firstRating = PlayerHasToPlayInDefinedTimeSlotRule.GetRatedNumber(playday, playersRepository.Players.GetPlayer(1), new int[] { 0, 2 }, 80);
                var secondRating = PlayerHasToPlayInDefinedTimeSlotRule.GetRatedNumber(playday, playersRepository.Players.GetPlayer(4), new int[] { 1, 3 }, 30);
                var thirdRating = PlayerShouldPlayInGivenTimeslotsRule.GetRatedNumber(playday, playersRepository.Players.GetPlayer(1), new int[] { 0, 1, 2, 3 }, 60);

                double overallPlaydayRating = (firstRating + secondRating+ thirdRating) / 3.0;
                ratedPlayDayList.Add((overallPlaydayRating, playday));
            }

            return ratedPlayDayList;
        }

        public static List<PlaydaySchedule> GetAllPossibleMatches(List<Match> possibleMatches)
        {
            var maxPossibleMatches = NUMBER_OF_TIMESLOTS * NUMBER_OF_COURTS;
            var allPossiblePlaydays = new List<PlaydaySchedule>();
            var used = new bool[maxPossibleMatches];
            Array.Fill(used, false);
            GetCombionations(maxPossibleMatches, possibleMatches.ToArray(), used, 0, new List<int>(), ref allPossiblePlaydays);
            return allPossiblePlaydays;
        }

        public static void GetCombionations(int maxPossibleMatches, Match[] matches, bool[] used, int startIndex, List<int> stack, ref List<PlaydaySchedule> allPossiblePlaydays)
        {

            if (stack.Count >= maxPossibleMatches)
            {
                //Debug.WriteLine(string.Join(",", stack.ToArray()));
                var playdaySchedule = GetPlaydaySchedule(stack.ToArray(), matches);
                allPossiblePlaydays.Add(playdaySchedule);
                return;
            }
            for (int i = 0; i < maxPossibleMatches; i++)
            {
                if (!used[i])
                {
                    stack.Add(i);
                    var isOk = matches.IsOk(stack.ToArray(), NUMBER_OF_COURTS);

                    if (!isOk)
                    {
                        stack.RemoveAt(stack.Count - 1);
                        continue;
                    }
                        

                    //if (stack.Count > 0)
                    //{
                    //    var match1 = GetMatchAt(matches, stack.Last());
                    //    var match2 = GetMatchAt(matches, i);
                    //    if (IsOnePlayerIn2Matches(match1, match2))
                    //        continue;
                    //}

                    used[i] = true;
                    //stack.Add(i);
                    GetCombionations(maxPossibleMatches, matches, used, i, stack, ref allPossiblePlaydays);
                    stack.RemoveAt(stack.Count-1);
                    used[i] = false;
                }
            }
        }

        public static PlaydaySchedule GetPlaydaySchedule(int[] matchNumbersStack, Match[] possibleMatches)
        {
            var scheduledMatches = new Dictionary<int, Match[]>();
            int j = 0;
            for (int i = 0; i < NUMBER_OF_TIMESLOTS; i++)
            {

                int toArrayNumber;
                if (j + NUMBER_OF_COURTS >= matchNumbersStack.Length)
                {
                    toArrayNumber = matchNumbersStack.Length;
                }
                else
                {
                    toArrayNumber = j + NUMBER_OF_COURTS;
                }
                var matchNumbersAtSameTime = matchNumbersStack[j..toArrayNumber];
                var matchesAtSameTime = matchNumbersAtSameTime.Select((m) => possibleMatches.ElementAt(m)).ToArray();
                scheduledMatches.Add(i, matchesAtSameTime);

                j = toArrayNumber;
            }

            return new PlaydaySchedule(scheduledMatches);
        }

        public static Match GetMatchAt(Match[] matches, int i)
        {
            var match = i >= matches.Length ? new Match(null, null) : matches[i];
            return match;
        }

        public static bool IsOnePlayerIn2Matches(Match match1, Match match2)
        {
            if ((match1.FirstPlayer != null &&
                 (match1.FirstPlayer == match2.FirstPlayer ||
                  match1.FirstPlayer == match2.SecondPlayer)) ||
                 (match1.SecondPlayer != null &&
                  (match1.SecondPlayer == match2.FirstPlayer ||
                   match1.SecondPlayer == match2.SecondPlayer)))
            {
                return true;
            }

            return false;
        }
    }
}
