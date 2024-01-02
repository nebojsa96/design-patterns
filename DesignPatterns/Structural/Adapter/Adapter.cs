using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Adapter
{
    interface IRoundPeg
    {
        float GetRadius();
    }
    class RoundHole
    {
        float radius;

        public RoundHole(float radius)
        {
            this.radius = radius;
        }

        public bool Fits(IRoundPeg peg)
        {
            return peg.GetRadius() <= radius;
        }
    }

    class RoundPeg : IRoundPeg
    {
        float radius;

        public RoundPeg(float radius)
        {
            this.radius = radius;
        }

        public float GetRadius()
        {
            return radius;
        }
    }

    class SquarePeg
    {
        float width;

        public SquarePeg(float width)
        {
            this.width = width;
        }

        public float GetWidth()
        {
            return width;
        }
    }

    class SquarePegAdapter : IRoundPeg
    {

        SquarePeg peg;
        public SquarePegAdapter(SquarePeg peg)
        {
            this.peg = peg;
        }

        public float GetRadius()
        {
            return (float)(peg.GetWidth() * Math.Sqrt(2) / 2);
        }
    }

    public class Adapter : IPattern
    {
        public static void RunExample()
        {
            Console.WriteLine("*** Adatper ***");

            RoundHole hole = new RoundHole(5);
            RoundPeg rpeg = new RoundPeg(5);
            
            Console.WriteLine(hole.Fits(rpeg)); // true

            SquarePeg small_sqpeg = new SquarePeg(5);
            SquarePeg large_sqpeg = new SquarePeg(10);
            //Console.WriteLine(hole.Fits(small_sqpeg)); // this won't compile (incompatible types)

            SquarePegAdapter sspeg_adapter = new SquarePegAdapter(small_sqpeg);
            SquarePegAdapter lspeg_adapter = new SquarePegAdapter(large_sqpeg);

            Console.WriteLine(hole.Fits(sspeg_adapter)); // true
            Console.WriteLine(hole.Fits(lspeg_adapter)); // false
        }
    }
}
