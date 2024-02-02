using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApp5
{
    class Race
    {
        private Cockroach[] cockroachs;
        private Line[] fieldLines;
        private int[] timesOfFinish, finalResults;
        private int countOfCockroachs, currentRaceTime, countOfFinishers, distanceYbetween;

        public Race(int countOfCockroachs)
        {
            this.countOfCockroachs = countOfCockroachs;
            timesOfFinish = new int[countOfCockroachs];
            cockroachs = new Cockroach[countOfCockroachs];
            fieldLines = new Line[countOfCockroachs + 7];
            currentRaceTime = 0;
            countOfFinishers = 0;
            finalResults = new int[countOfCockroachs];
            distanceYbetween = 0;
        }
        public int CountOfCockroachs { get { return countOfCockroachs; } set { countOfCockroachs = value; } }
        public void Fill_Race_Field()
        {
            int y = 100;
            for(int i = 0; i < cockroachs.Length; i++)
            {
                cockroachs[i] = new Cockroach(100, y + 20, 900);
                y += 40;
            }
            y = 85;
            for (int i = 0; i < countOfCockroachs + 1; i++)
            {
                fieldLines[i] = new Line(0, y, 1150, y);
                y += 40;
            }
            fieldLines[countOfCockroachs + 1] = new Line(1, fieldLines[0].Y1, 1, fieldLines[countOfCockroachs].Y2);
            fieldLines[countOfCockroachs + 2] = new Line(20, fieldLines[0].Y1, 20, fieldLines[countOfCockroachs].Y2);
            fieldLines[countOfCockroachs + 3] = new Line(1000, fieldLines[0].Y1, 1000, fieldLines[countOfCockroachs].Y2);
            fieldLines[countOfCockroachs + 4] = new Line(65, fieldLines[0].Y1, 65, fieldLines[countOfCockroachs].Y2);
            fieldLines[countOfCockroachs + 5] = new Line(1100, fieldLines[0].Y1, 1100, fieldLines[countOfCockroachs].Y2);
            fieldLines[countOfCockroachs + 6] = new Line(1150, fieldLines[0].Y1, 1150, fieldLines[countOfCockroachs].Y2);
        }
        public Graphics Draw(Graphics graf)
        {
            for (int i = 0; i < cockroachs.Length; i++)
            {
                cockroachs[i].Draw(graf);
            }
            for (int i = 0; i < fieldLines.Length; i++)
            {
                fieldLines[i].Draw(graf);
            }
            return graf;
        }
        public void Start()
        {
            currentRaceTime++;
            for (int i = 0; i < cockroachs.Length; i++)
            {
                cockroachs[i].Move(currentRaceTime);
                if(cockroachs[i]._Time_of_Finish == 0)
                {
                    timesOfFinish[i] = currentRaceTime;
                }
            }
        }
        public int Stop()
        {
            countOfFinishers = 0;
            for (int i = 0; i < cockroachs.Length; i++)
            {
                if(cockroachs[i]._Time_of_Finish > 0)
                {
                    countOfFinishers++;
                }    
            }
            return countOfFinishers;
        }
        public void Result()
        {
            for(int i = 0; i< finalResults.Length; i++)
            {
                finalResults[Array.IndexOf(timesOfFinish, timesOfFinish.Min())] = i + 1;
                timesOfFinish[Array.IndexOf(timesOfFinish, timesOfFinish.Min())] = timesOfFinish.Max() + 1;
            }
        }
        public Label[] SetArrayOfNumbers(Label[] array_of_numbers)
        {
            distanceYbetween = 0;
            for (int i = 0; i < array_of_numbers.Length; i++)
            {
                array_of_numbers[i] = new Label
                {
                    Text = Convert.ToString(i + 1),
                    Left = 2,
                    Top = 100 + distanceYbetween,
                    AutoSize = true
                };
                distanceYbetween += 40;
            }
            return array_of_numbers;
        }
        public Label[] SetArrayofTimes(Label[] array_of_time)
        {
            distanceYbetween = 0;
            for (int i = 0; i < array_of_time.Length; i++)
            {
                array_of_time[i] = new Label
                {
                    Text = Convert.ToString(timesOfFinish[i]),
                    Left = 25,
                    Top = 100 + distanceYbetween,
                    AutoSize = true
                };
                distanceYbetween += 40;
            }
            return array_of_time;
        }
        public Label[] SetArrayOfFinalPlaces(Label[] array_of_final_places)
        {
            distanceYbetween = 0;
            for (int i = 0; i < array_of_final_places.Length; i++)
            {
                array_of_final_places[i] = new Label
                {
                    Text = Convert.ToString(finalResults[i]),
                    Left = 1120,
                    Top = 100 + distanceYbetween,
                    AutoSize = true
                };
                distanceYbetween += 40;
            }
            return array_of_final_places;
        }
        public void ChangeArrayOfTimes(Label[] array_of_times)
        {
            for(int i = 0; i < array_of_times.Length; i++)
            {
                array_of_times[i].Text = Convert.ToString(timesOfFinish[i]);
            }
        }
    }
}
