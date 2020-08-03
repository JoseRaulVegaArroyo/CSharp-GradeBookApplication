using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("You must have at least 5 students to do ranked grading.");
            }

            List<double> sortedGrades = Students.OrderByDescending(s => s.AverageGrade).Select(o => o.AverageGrade).ToList();
            var averagePerc = (int)Math.Ceiling(Students.Count * 0.2);

            if (averageGrade >= sortedGrades[averagePerc - 1])
            {
                return 'A';
            }
            else if (averageGrade >= sortedGrades[(averagePerc * 2) - 1])
            {
                return 'B';
            }
            else if (averageGrade >= sortedGrades[(averagePerc * 3) - 1])
            {
                return 'C';
            }
            else if (averageGrade >= sortedGrades[(averagePerc * 4) - 1])
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5 && Students.Exists(s => s.Grades.Count == 0))
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5 && Students.Exists(s => s.Grades.Count == 0))
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
