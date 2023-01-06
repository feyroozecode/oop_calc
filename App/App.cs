using NCalc;
using System.Text.RegularExpressions;
using fun;
using Operation;
using Fs;

// interfaces
using Interface.OperInterface;
using Interface.AdvancedOp;
using Util.Checker;

namespace Application{
    class Calculator {
        
        // import all operations and set to protected static for using
        protected static OperInterface addOp = 
            UtilFactory.Factory.CreateInstace<AddOper>();
        protected static OperInterface subOp = 
            UtilFactory.Factory.CreateInstace<SubOper>();
        protected static OperInterface multiOp = 
            UtilFactory.Factory.CreateInstace<Multiple>();
        protected static OperInterface divideOp = 
            UtilFactory.Factory.CreateInstace<DivideOper>();
        protected static OperInterface moduloOp =   
        UtilFactory.Factory.CreateInstace<ModuloOp>();
        protected static OperInterface compareOp = 
            UtilFactory.Factory.CreateInstace<CompareOp>();

        // advanced operations 
        protected static AdvancedOpInterface racineOp = UtilFactory.Factory.CreateInstace<RacineOp>();
        protected static AdvancedOpInterface expoOp = UtilFactory.Factory.CreateInstace<ExpoOp>();
        // Regex Checker
        protected static NumberChecker matchChecker = new NumberChecker();

        static WriteFile writeFile ;
        static ReadFile readFile;

        // Regex
        //private static readonly string pattern = @"^(\d+(\.\d+)?)\s*([\+\-\*\/])\s*(\d+(\.\d+)?)$";
        //private static readonly string pattern = @"^([0-9+-/=%*V])$";

        private static readonly string pattern2 = @"\d+\.\d+|[+-/*]|[()]|h|help";
        private static readonly string split_pattern = @"\s*([\+\-\*\/\=])\s*";

        private static string HISTORY_FILE_PATH = "/home/ibrahim/dev/dotNetProjects/gabBootCamp/training/calcs/oop_calc/history/history.csv";

        public static void startApp(){
           Fun.affiche("Start");

            mainLoop();
        }

        // parcour general de l'app
        public static void mainLoop(){
            bool parcourir = true;

            while (parcourir)
            {
                Fun.affiche(
                @"Ahmad calc v.1.0 , 
                Entrer des insctruction pour calculer 
                Entrer [h] pour voir l'historique \n Entrer [aide] pour aide, Entrer [q] pour quitter .
                ");
                string userInput = Fun.getInput();

                if(userInput == "q"){
                    parcourir = false;
                    Fun.Continuez();
                }
                if(userInput == "h")
                    readFile = new ReadFile("/home/ibrahim/dev/dotNetProjects/gabBootCamp/training/calcs/oop_calc/history/history.csv");
                    
                if(!Regex.IsMatch(userInput, pattern2))
                    Fun.affiche("Valeur non prise en charge");

                    
                launchCalc(userInput);
            }
        }

        static double result = 0;
        public static void launchCalc(String input){
                // Effecer les sapces separant les nombres des instructions 
                var operations = Regex.Split(input, split_pattern);

                if(input.All(c => c == '(' && c == ')' )){
                    if(double.TryParse(operations[0], out double op)){
                        double result = double.Parse(operations[0]);
                    
                    // itration à travers les operations, debuter, à l'index 2
                    for(int i = 1; i < operations.Length; i += 2){
                    
                        result = double.Parse(operations[i-1]);

                        //extraire le second operande de la liste d'insctruction
                        double right = double.Parse(operations[i + 1]);
                    
                        //extraire l'operateur
                        string operateur = operations[i];
                
                        switch(operateur){
                                case "+":
                                    result += right; 
                                    break;    
                                case "-":
                                    result = subOp.Calc(result, right);
                                    break;
                                case "*":
                                    result = multiOp.Calc(result, right);
                                    break;    
                                case "/":
                                    result = divideOp.Calc(result, right);
                                    break;
                                case "%":
                                    result = moduloOp.Calc(result, right);
                                    break;
                                default :
                                    Fun.affiche("Veuillez entrer des valleurs comprise entre 0 à 9 et des intruction comme +");
                                    return;
                                
                            }
                        Fun.affiche("> "+ result);
                    }  

                    
        
                    /*var expression = String.Join(" ", operations);
                    var res = Fun.convertExpr(expression);
                    result = Fun.EvaluateExp(res);*/
                }
            }
                
         try
                {
                     result = evalExpress(input);
                    string[][] data = new string[][]{
                        //new string[] {      "Number 1",        operations[2],            "Number 2"      ,    "Resultat " },
                        new string[] {    input ,  result.ToString()}
                    };
                    writeFile = new WriteFile(
                      HISTORY_FILE_PATH,
                      data
                    );
                    
                    // Afficher le resultat
                    Fun.affiche("> "+ result); 

                }
                catch (System.Exception ex)
                {
                     new Exception(ex.ToString());
                }
               
            }
        
    static double evalExpress(String input){
        
                 Expression expression1 = new Expression(input);

                int intVal = (Int32)expression1.Evaluate();       

                double res = Convert.ToDouble(intVal);
                
                //Fun.affiche("res = "+ res);

                return res;
        }
    }
            
}

/*
* 
*/


/*

        static double evaluateWithParanthese(String input, Regex regex){

            MatchCollection matches = regex.Matches(input);

            Stack<double> stack = new Stack<double>();
            double result = 0;
            double value1 = 0;
            double value2 = 0;
            string op = "";

            foreach (Match match in matches)
            {
                string token = match.Value;
                if (double.TryParse(token, out double number))
                {
                    // token is a number
                    if (op == "")
                    {
                        // this is the first operand
                        value1 = number;
                    }
                    else
                    {
                        // this is the second operand
                        value2 = number;
                        switch (op)
                        {
                            case "+":
                                result = value1 + value2;
                                break;
                            case "-":
                                result = value1 - value2;
                                break;
                            case "*":
                                result = value1 * value2;
                                break;
                            case "/":
                                result = value1 / value2;
                                break;
                        }
                        value1 = result;
                        op = "";
                    }
                }
                else if (token == "(")
                {
                    // push the current result onto the stack
                    stack.Push(result);
                    result = 0;
                }
                else if (token == ")")
                {
                    // pop the top value from the stack and use it as the first operand
                    value1 = stack.Pop();
                }
                else
                {
                    // token is an operator
                    op = token;
                }

               if(double.TryParse(token, out double d)){
                 // save to history 
                string[][] data = new string[][]{
                        //new string[] {      "Number 1",        operations[2],            "Number 2"      ,    "Resultat " },
                    new string[] {  input , result.ToString()}
                };
                writeFile = new WriteFile(
                    HISTORY_FILE_PATH,
                    data
                );
               }    
            }

            
            return result;

        }

    
*/
