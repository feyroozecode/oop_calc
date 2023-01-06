// disable nullable var value
#nullable disable

using System;
using System.Text;
using System.Data;
namespace fun {
    class Fun {
        public static void affiche(String s){
            Console.WriteLine(s);
        }

        public static String getInput(){
            return Console.ReadLine();
        }

        public static bool Continuez(){
            String userRes ;

            Console.WriteLine("\n Voulez vous continuez, (OUI: o & NON: sur n'importe quel touche ) ?");
            userRes = Console.ReadLine();

            if(userRes == "o"){
                return true;
            } else {
                Console.WriteLine("\n Fin, au revoir  🥱");
                return false;
            }

        }

        // Evaluate a expression with parathese to a arithemetic valid expression to return result 
        public static string convertExpr(string input){

            StringBuilder expOutput = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '(')
                {
                    int j = i + 1;
                    int parenthesesCount = 1;
                    while (j < input.Length && parenthesesCount > 0)
                    {
                        char d = input[j];
                        if (d == '(')
                        {
                            parenthesesCount++;
                        }
                        else if (d == ')')
                        {
                            parenthesesCount--;
                        }
                        j++;
                    }
                    string subexpression = input.Substring(i + 1, j - i - 2);
                    double subresult = EvaluateExp(subexpression);
                    expOutput.Append(subresult.ToString());
                    i = j - 1;
                }
                else
                {
                    expOutput.Append(c);
                }
            }

            var finalExp = expOutput.ToString();

            return finalExp;
        }

        public static double EvaluateExp(string input)
        {
            // implement a simple expression evaluator here
            // for example, you can use the System.Data.DataTable class to
            // evaluate the expression and return the result
            DataTable table = new DataTable();
            object result = table.Compute(input, "");
            Console.WriteLine("result = "+result);
            return Convert.ToDouble(result);
        }
    }
}