using System.Collections.Generic;

namespace Dane {
    public class CircleList {
        private List<Circle> circles;

        public CircleList() {
            circles = new List<Circle>();
        }

        public int CountCircles() {
            return circles.Count;
        }

        public void AddCircle(Circle circle) {
            circles.Add(circle);
        }

        public void Clear() {
            circles.Clear();
        }

        public Circle GetCircle(int index) {
            return circles[index];
        }


    }
}
