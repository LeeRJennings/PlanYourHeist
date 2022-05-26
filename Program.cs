using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");
            Console.WriteLine("What is the bank's difficulty level?");
            int bankDifficultyLevel = int.Parse(Console.ReadLine());
            int bankLevelCheck = bankDifficultyLevel;

            List<TeamMember> memberList = new List<TeamMember>();
            addMember();

            void addMember()
            {
                Console.WriteLine("Please enter your team member's name.");
                string memberName = Console.ReadLine();
                
                if (memberName != "")
                {
                    Console.WriteLine("Please enter your team member's skill level (0 - 100)");
                    int memberSkillLevel = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Please enter your team member's courage factor (0.0 - 0.2)");
                    decimal memberCourageFactor = decimal.Parse(Console.ReadLine());

                    TeamMember newGuy = new TeamMember(memberName, memberSkillLevel, memberCourageFactor);
                    memberList.Add(newGuy);

                    addMember();
                }
                else 
                {
                    return;
                }
            }
            
            Console.WriteLine($"Number of team members: {memberList.Count}");

            int skillSum = 0;
            foreach (TeamMember member in memberList)
            {
                skillSum += member.SkillLevel;
            }

            Console.WriteLine("How many trial runs would you like to do?");
            int trialRuns = int.Parse(Console.ReadLine());

            int successfulTrials = 0;
            int failedTrials = 0;

            for (int i = 0; i < trialRuns; i++)
            {
                int heistLuck = new Random().Next(-10, 10);
                bankDifficultyLevel += heistLuck;

                Console.WriteLine($"Your crew's skill level: {skillSum}");
                Console.WriteLine($"The bank's difficulty level: {bankDifficultyLevel}");

                if(skillSum >= bankDifficultyLevel)
                {
                    Console.WriteLine("Let's rob a bank!!!");
                    successfulTrials++;
                }
                else
                {
                    Console.WriteLine("Nah dude, not with that crew, buncha jabronis");
                    failedTrials++;
                }

                Console.WriteLine("-------------------------------------------");
                bankDifficultyLevel = bankLevelCheck;
            }

            Console.WriteLine($"Successful runs: {successfulTrials}");
            Console.WriteLine($"Failed runs: {failedTrials}");
        }
    }
}
