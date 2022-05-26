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
                    Console.WriteLine("Please enter your team member's skill level.");
                    int memberSkillLevel = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Please enter your team member's courage factor.");
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

            foreach (TeamMember member in memberList)
            {
                skillSum += member.SkillLevel;
            }

            if(skillSum >= bankDifficultyLevel)
            {
                Console.WriteLine("Let's rob a bank!!!");
            }
            else
            {
                Console.WriteLine("Nah dude, not with that crew, buncha jabronis");
            }
        }
    }
}
