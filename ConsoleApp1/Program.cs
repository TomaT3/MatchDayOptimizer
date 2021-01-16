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
        static void Main(string[] args)
        {
            var playersRepository = new PlayersRepository();
            var possibleMatches = InitData.GetPossibleMatches(playersRepository.Players);
            var timeSlots = InitData.GetTimeSlots();


            var test = from timeslot in timeSlots
                       from match in possibleMatches
                       select new { Group = match, Combination = timeslot };

            var stopwatchForGetPossiblePlaydays = Stopwatch.StartNew();
            var allPossiblePlaydays = GetAllPossibleMatches(possibleMatches, timeSlots);
            stopwatchForGetPossiblePlaydays.Stop();

            var stopwatchForApplyingRules = Stopwatch.StartNew();
            List<(double rating, PlaydaySchedule playday)> ratedPlayDayList = ApplyRules(playersRepository, allPossiblePlaydays);
            var sortedPlayDayList = ratedPlayDayList.OrderByDescending(p => p.rating).ToList();
            stopwatchForApplyingRules.Stop();

            Console.WriteLine($"Time needed to calculate all possible playdays: {stopwatchForGetPossiblePlaydays.Elapsed}");
            Console.WriteLine($"Time needed to apply rules to all possible playdays: {stopwatchForApplyingRules.Elapsed}");
            Console.WriteLine(Environment.NewLine);
            for (int i = 1; i < 4; i++)
            {
                var rating = sortedPlayDayList[i].rating;
                var playday = sortedPlayDayList[i].playday;
                Console.WriteLine($"#{i} - with Rating: {rating}%");
                foreach (var match in playday.PlaydayMatches)
                {
                    Console.WriteLine($"{match.Timeslot} - {match.Match}");
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
                var firstRating = PlayerHasToPlayInDefinedTimeSlotRule.GetRatedNumber(playday, playersRepository.Players.GetPlayer(1), new int[] { 1, 3 }, 80);
                var asd = PlayerShouldPlayInGivenTimeslotsRule.GetRatedNumber(playday, playersRepository.Players.GetPlayer(1), new int[] { 1, 2, 3, 4 }, 60);
                var secondRating = PlayerHasToPlayInDefinedTimeSlotRule.GetRatedNumber(playday, playersRepository.Players.GetPlayer(4), new int[] { 2, 4 }, 30);

                double overallPlaydayRating = (firstRating + secondRating) / 2.0;
                ratedPlayDayList.Add((overallPlaydayRating, playday));
            }

            return ratedPlayDayList;
        }

        public static List<PlaydaySchedule> GetAllPossibleMatches(List<Match> possibleMatches, List<TimeSlot> timeSlots)
        {
           
            var allPossiblePlaydays = new List<PlaydaySchedule>();
            var used = new bool[timeSlots.Count];
            Array.Fill(used, false);
            GetCombionations(timeSlots.ToArray(), possibleMatches.ToArray(), used, 0, new List<int>(), ref allPossiblePlaydays);
            return allPossiblePlaydays;
        }

        public static void GetCombionations(TimeSlot[] timeSlot, Match[] matches, bool[] used, int startIndex, List<int> stack, ref List<PlaydaySchedule> allPossiblePlaydays)
        {

            if (stack.Count >= timeSlot.Length)
            {
                var playdaySchedule = GetPlaydaySchedule(stack, timeSlot, matches);
                allPossiblePlaydays.Add(playdaySchedule);
                return;
            }
            for (int i = 0; i < timeSlot.Length; i++)
            {
                if (!used[i])
                {

                    if (stack.Count > 0)
                    {
                        var match1 = GetMatchAt(matches, stack.Last());
                        var match2 = GetMatchAt(matches, i);
                        if (IsOnePlayerIn2Matches(match1, match2))
                            continue;
                    }

                    used[i] = true;
                    stack.Add(i);
                    GetCombionations(timeSlot, matches, used, i, stack, ref allPossiblePlaydays);
                    stack.RemoveAt(stack.Count-1);
                    used[i] = false;
                }
            }
        }

        public static PlaydaySchedule GetPlaydaySchedule(List<int> stack, TimeSlot[] timeSlot, Match[] possibleMatches)
        {
            var scheduledMatches = new List<ScheduledMatch>();
            for (int i = 0; i < timeSlot.Length; i++)
            {
                var timeslot = timeSlot[i];
                var match = stack.ElementAt(i) >= possibleMatches.Length ? new Match(null, null) : possibleMatches[stack.ElementAt(i)];
                var scheduledMatch = new ScheduledMatch(timeslot, match);
                scheduledMatches.Add(scheduledMatch);
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
