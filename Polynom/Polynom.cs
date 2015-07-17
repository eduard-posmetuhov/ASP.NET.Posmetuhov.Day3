using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom
{
    public sealed class Polynom : ICloneable,IEquatable<Polynom>
    {
        private readonly double value;
        private readonly int degree;
        private readonly double[] coefficient;

        public Polynom(/*double value,*/ double[]coefficient)
        {
            this.coefficient = new double[coefficient.Length];
            Array.Copy(coefficient, this.coefficient, coefficient.Length);
            this.degree=coefficient.Length-1;
        }
        //public double Value
        //{
        //    get { return value; }
        //}

        public int Degree
        {
            get { return degree; }
        }

        public double [] Coefficient
        {
            get {
                double[] returnCoefficient = new double[coefficient.Length];
                Array.Copy(coefficient, returnCoefficient, coefficient.Length);
                return returnCoefficient;
                }
        }
        public Polynom SetCoefficient(double coefficientValue,int degree)
        {
            double[] newCoefficient;
            if(degree>this.Degree)
            newCoefficient = new double[degree+1];
            else newCoefficient = new double[this.Coefficient.Length];
            Array.Copy(this.Coefficient,newCoefficient,this.Coefficient.Length);
            newCoefficient[degree]=coefficientValue;
            return new Polynom(newCoefficient);
        }

        public double GetCoefficient(int degree)
        {            
            return this.Coefficient[degree];
        }

        public static Polynom Add(Polynom first, Polynom second)
        {
            int maxDegree = Math.Max(first.Degree, second.Degree);
            double[] newCoefficient = new double[maxDegree+1];
            for (int i = 0; i < maxDegree+1; i++)
                if (first.Coefficient.Length - 1 < i)
                    newCoefficient[i] = second.Coefficient[i];
                else
                   if (second.Coefficient.Length - 1 < i)
                    newCoefficient[i] = first.Coefficient[i];
                   else newCoefficient[i] =first.Coefficient[i] + second.Coefficient[i];
            return new Polynom(newCoefficient);
        }
        public static Polynom operator +(Polynom a, Polynom b)
        {
            return Add(a, b);
        }

         public static Polynom Subtract (Polynom first, Polynom second) //оптимизировать если старшая степень =0
        {
            int maxDegree = Math.Max(first.Degree, second.Degree);
            double[] newCoefficient = new double[maxDegree + 1];
            for (int i = 0; i < maxDegree + 1; i++)
                if (first.Coefficient.Length - 1 < i)
                    newCoefficient[i] = -second.Coefficient[i];
                else
                    if (second.Coefficient.Length - 1 < i)
                        newCoefficient[i] = first.Coefficient[i];
                    else newCoefficient[i] = first.Coefficient[i] - second.Coefficient[i];
            return OptimizationByZero( new Polynom(newCoefficient));
        }

         public static Polynom operator -(Polynom a, Polynom b)
         {
             return Subtract(a, b);
         }
         public static Polynom MultiplicationOnNumber(Polynom first, double value) 
         {
             double[] newCoefficient=new double[first.Coefficient.Length];
             Array.Copy(first.Coefficient, newCoefficient, first.Coefficient.Length); 
             for (int i = 0; i <= first.Degree; i++)
                 newCoefficient[i] = first.Coefficient[i] * value;
             return OptimizationByZero(new Polynom(newCoefficient));
         }

         public static Polynom operator *(Polynom a, double value)
         {
             return MultiplicationOnNumber(a, value);
         }

         public static Polynom operator *(double value, Polynom a)
         {
             return MultiplicationOnNumber(a, value);
         }
        
        public Object Clone()
         {
             double[] newCoefficient=new double[this.Coefficient.Length];
             Array.Copy(this.Coefficient, newCoefficient, this.Coefficient.Length);
             return new Polynom(newCoefficient);
         }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Coefficient.Length==1)
            {
                sb.AppendFormat("{0}", Coefficient[0]);
                return sb.ToString();
            }
            sb.AppendFormat("{0}*x^{1}", Coefficient[Coefficient.Length - 1], Coefficient.Length - 1);
            
            for (int i = Coefficient.Length - 2; i > 0; i--)
                if (Coefficient[i]>0)
                sb.AppendFormat("+{0}*x^{1}", Coefficient[i], i);
                else 
                    if (Coefficient[i]<0)
                sb.AppendFormat("{0}*x^{1}", Coefficient[i], i);
            if (Coefficient[0]!=0)
                if (Coefficient[0]>0)
                sb.AppendFormat("+{0}", Coefficient[0]);
                else sb.AppendFormat("{0}", Coefficient[0]);
                return sb.ToString();
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Polynom p = obj as Polynom;
            return this.Coefficient.SequenceEqual(p.Coefficient);
        }

        public bool Equals(Polynom other)
        {
            if (other == null)
                return false;
               return this.Coefficient.SequenceEqual(other.Coefficient);            
        }
       
        private static Polynom OptimizationByZero(Polynom polynomForOptimize)
        {

            while (polynomForOptimize.Coefficient.Length-1>0&polynomForOptimize.Coefficient[polynomForOptimize.Coefficient.Length - 1] == 0)
            {
                double[] arr = new double[polynomForOptimize.Coefficient.Length - 1];
                Array.Copy(polynomForOptimize.Coefficient,arr,polynomForOptimize.Coefficient.Length-1);
                polynomForOptimize=new Polynom(arr);
            }
            return polynomForOptimize;
        }
    }
}
