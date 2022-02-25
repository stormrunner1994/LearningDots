using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDots
{
    public class Setting
    {
        public  Point zielPos;
        public  Point startPos;
        public  int populationsGröße;
        public  bool zuschauen;
        public  int maxSteps;
        public  bool erlaubeDiagonaleZüge;
        public  List<Hindernis> hindernisse;

        public Setting(Point zielPos, Point startPos, int populationsGröße, bool zuschauen, int maxSteps, bool erlaubeDiagonaleZüge
            , List<Hindernis> hindernisse)
        {
            this.zielPos = zielPos;
            this.startPos = startPos;
            this.populationsGröße = populationsGröße;
            this.zuschauen = zuschauen;
            this.maxSteps = maxSteps;
            this.erlaubeDiagonaleZüge = erlaubeDiagonaleZüge;
            this.hindernisse = hindernisse;
        }
    }
}
