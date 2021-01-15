using ConsoleApp1.Model;
using ConsoleApp1.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var possibleMatches = InitData.GetPossibleMatches();
            var timeSlots = InitData.GetTimeSlots();


            var test = from timeslot in timeSlots
                       from match in possibleMatches
                       select new { Group = match, Combination = timeslot };

            var allPossiblePlaydays = GetAllPossibleMatches(possibleMatches, timeSlots);

            var ratedPlayDayList = new List<(double rating, PlaydaySchedule playday)>();
            foreach (var playday in allPossiblePlaydays)
            {
                var firstRating = PlayerWithDefinedTimeSlotRule.GetRatedNumber(playday, possibleMatches.First().FirstPlayer, new int[] { 0, 2 }, 60);
                var secondRating = PlayerWithDefinedTimeSlotRule.GetRatedNumber(playday, possibleMatches.ElementAt(2).SecondPlayer, new int[] { 1, 3 }, 30);

                double overallPlaydayRating = (firstRating + secondRating) / 2.0;
                ratedPlayDayList.Add((overallPlaydayRating, playday));
            }

            var sortedPlayDayList = ratedPlayDayList.OrderByDescending(p => p.rating).ToList();

            for (int i = 1; i < 4; i++)
            {
                var rating = sortedPlayDayList[i].rating;
                var playday = sortedPlayDayList[i].playday;
                Console.WriteLine($"#{i} - with Rating: {rating}%");
                foreach(var match in playday.PlaydayMatches)
                {
                    Console.WriteLine($"{match.Timeslot} - {match.Match}");
                }

                Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine("##### endif #######");
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
                if (NoMatchWithoutABreakRule.IsPlayDayScheduleValid(playdaySchedule))
                {
                    allPossiblePlaydays.Add(playdaySchedule);
                }
                return;
            }
            for (int i = 0; i < timeSlot.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    stack.Add(i);
                    GetCombionations(timeSlot, matches, used, startIndex + 1, stack, ref allPossiblePlaydays);
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

    }
}
