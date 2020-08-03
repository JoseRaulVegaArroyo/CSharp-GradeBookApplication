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
                throw new InvalidOperationException();
            }

            List<double> sortedGrades = Students.OrderByDescending(s => s.AverageGrade).Select(o => o.AverageGrade).ToList();
            var averagePerc = Math.Round((double)20 / 100 * Students.Count);

            if (averageGrade <= sortedGrades[0] && averageGrade > sortedGrades[(int)averagePerc - 1])
            {
                return 'A';
            }
            else if (averageGrade <= sortedGrades[(int)averagePerc] && averageGrade >= sortedGrades[(int)averagePerc * 2 - 1])
            {
                return 'B';
            }
            else if (averageGrade <= sortedGrades[(int)averagePerc * 2] && averageGrade >= sortedGrades[(int)averagePerc * 3 - 1])
            {
                return 'C';
            }
            else if (averageGrade <= sortedGrades[(int)averagePerc * 3] && averageGrade >= sortedGrades[(int)averagePerc * 4 - 1])
            {
                return 'D';
            }

            return 'F';
        }
    }
}
