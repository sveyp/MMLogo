using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MentorMate_Logo
{
    public class CanvasGrid
    {
        private const string EmptyText = "-";
        private const string FillText = "*";
        private readonly List<List<string>> logo;

        public CanvasGrid()
        {
            logo = new List<List<string>>();
        }

        public string GetLogo(int width)
        {
            for (int row = 0; row <= width; row++)
            {
                var rowChars = new List<string>();
                //check if it is upper or bottom half of the letter M
                if (row <= (width / 2))
                {
                    int decrementNegativeSpace = DecrementNegativeSpace(width, row);
                    int inc2Pos = IncrementPositiveSpaceBy2(width, row);
                    int dec2Neg = DecrementNegativeSpaceBy2(width, row);

                    string mLetterTopPart = string.Concat(Enumerable.Repeat(EmptyText, decrementNegativeSpace)
                        .Concat(Enumerable.Repeat(FillText, inc2Pos))
                        .Concat(Enumerable.Repeat(EmptyText, dec2Neg))
                        .Concat(Enumerable.Repeat(FillText, inc2Pos))
                        .Concat(Enumerable.Repeat(EmptyText, decrementNegativeSpace)));

                    rowChars.Add(mLetterTopPart);
                    rowChars.Add(mLetterTopPart);
                }
                else
                {
                    int decNeg = DecrementNegativeSpace(width, row);
                    int dec2Neg = DecrementNegativeSpaceBy2(width, row);
                    int dec2Pos = DecrementPositiveSpaceBy2(width, row);
                    int keepPos = KeepPositiveSpace(width);

                    string mLetterBottomPart = string.Concat(Enumerable.Repeat(EmptyText, decNeg)
                        .Concat(Enumerable.Repeat(FillText, keepPos))
                        .Concat(Enumerable.Repeat(EmptyText, dec2Neg))
                        .Concat(Enumerable.Repeat(FillText, dec2Pos))
                        .Concat(Enumerable.Repeat(EmptyText, dec2Neg))
                        .Concat(Enumerable.Repeat(FillText, keepPos))
                        .Concat(Enumerable.Repeat(EmptyText, decNeg)));

                    rowChars.Add(mLetterBottomPart);
                    rowChars.Add(mLetterBottomPart);
                }
                logo.Add(rowChars);
            }
            return this.ToString();
        }

        //decrement negative space per 
        private int DecrementNegativeSpace(int width, int row)
        {
            return width - row;
        }

        private int IncrementPositiveSpaceBy2(int width, int row)
        {
            return width + 2 * row;
        }

        private int DecrementNegativeSpaceBy2(int width, int row)
        {
            return Math.Abs(width - 2 * row);
        }

        private int DecrementPositiveSpaceBy2(int width, int row)
        {
            return width + 2 * (width - row);
        }

        private int KeepPositiveSpace(int width)
        {
            return width;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (List<string> row in logo)
            {
                sb.AppendLine(string.Join(string.Empty, row));
            }

            return sb.ToString();
        }
    }
}
