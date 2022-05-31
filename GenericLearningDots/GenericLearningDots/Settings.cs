using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace LearningDots
{
    public class Setting
    {
        public enum AbbruchBedingung { Time, NextGen, FoundGoal, Generations }
        public Dictionary<AbbruchBedingung, int> abbruchBedingungen;
        public Window zielPos;
        public Point startPos;
        public int populationsGröße;
        public bool zuschauen;
        public int maxSteps;
        public bool erlaubeDiagonaleZüge;
        public List<Hindernis> hindernisse;
        public int speed;

        public Setting(Point zielPos, Point startPos, int populationsGröße, bool zuschauen, int maxSteps, bool erlaubeDiagonaleZüge
            , List<Hindernis> hindernisse, int speed,
           Dictionary<AbbruchBedingung, int> abbruchBedingungen)
        {
            this.abbruchBedingungen = abbruchBedingungen;
            this.zielPos = zielPos;
            this.startPos = startPos;
            this.populationsGröße = populationsGröße;
            this.zuschauen = zuschauen;
            this.maxSteps = maxSteps;
            this.erlaubeDiagonaleZüge = erlaubeDiagonaleZüge;
            this.hindernisse = hindernisse;
            this.speed = speed;
        }

        public static int GetTimeInSecs(string time)
        {
            int secs = 0;
            string number = "";
            int iout;
            int index = 0;
            try
            {
                while (Int32.TryParse(time[index].ToString(), out iout))
                    number += time[index++];

                string text = time.Substring(index, time.Length - index).Trim();

                secs = Convert.ToInt32(number);

                if (text == "min")
                    secs *= 60;
                else if (text == "h")
                    secs *= 3600;
            }
            catch (Exception)
            {
                return 0;
            }

            return secs;
        }

        public static bool SafeObstaclesInFile(List<Hindernis> hindernisse, string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine("PosX,PosY;Width;Height;Type;Color");
            foreach (Hindernis h in hindernisse)
                sw.WriteLine(h.GetHindernis());
            sw.Close();
            return true;
        }

        public bool SafeObstaclesInFile(string filename)
        {
            return SafeObstaclesInFile(hindernisse, filename);
        }
    }
}
