using System;
using System.Collections.Generic;

namespace PlanYourHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            int bankDifficultyLevel = 100;
            int skillSum = 0;

            Console.WriteLine("Plan Your Heist!");

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

            

            Console.WriteLine("How many trial runs would you like to do?");
            int trialRuns = int.Parse(Console.ReadLine());

            for (int i = 0; i < trialRuns; i++)
            {
                foreach (TeamMember member in memberList)
                {
                    skillSum += member.SkillLevel;
                }
                
                int heistLuck = new Random().Next(-10, 10);
                bankDifficultyLevel += heistLuck;

                Console.WriteLine($"Your crew's skill level: {skillSum}");
                Console.WriteLine($"The bank's difficulty level: {bankDifficultyLevel}");

                if(skillSum >= bankDifficultyLevel)
                {
                    Console.WriteLine("Let's rob a bank!!!");
                }
                else
                {
                    Console.WriteLine("Nah dude, not with that crew, buncha jabronis");
                }

                Console.WriteLine("-------------------------------------------");
                skillSum = 0;
            }
        }
    }
}
