using System.Text.RegularExpressions;
using System;
using fun;
using Operation;

// interfaces
using Interface.OperInterface;
using Interface.AdvancedOp;
using Util.Checker;

namespace Application{
    class Calculator {
        
        // import all operations and set to protected static for using
        protected static OperInterface addOp = UtilFactory.Factory.CreateInstace<AddOper>();
        protected static OperInterface subOp = UtilFactory.Factory.CreateInstace<SubOper>();
        protected static OperInterface multiOp = UtilFactory.Factory.CreateInstace<Multiple>();
        protected static OperInterface divideOp = UtilFactory.Factory.CreateInstace<DivideOper>();
        protected static OperInterface moduloOp = UtilFactory.Factory.CreateInstace<ModuloOp>();
        protected static OperInterface compareOp = UtilFactory.Factory.CreateInstace<CompareOp>();

        
        // advanced operations 
        protected static AdvancedOpInterface racineOp = UtilFactory.Factory.CreateInstace<RacineOp>();
        protected static AdvancedOpInterface expoOp = UtilFactory.Factory.CreateInstace<ExpoOp>();


        // Regex Checker
        protected static NumberChecker matchChecker = new NumberChecker();

        //Console.WriteLine(op.Calc(5, 7));
        public static void startApp(){
           Fun.affiche("Start");

            mainLoop();
        }

        // parcour general de l'app
        public static void mainLoop(){
            bool parcourir = true;

            while (parcourir)
            {
                Fun.affiche("Faite votre operation ou cliquer sur q pour quitter");

                string userInput = Fun.getInput();

                if(userInput == "q"){
                    parcourir = false;
                } 
                else{
                    launchCalc(userInput);
                }
            }
        }

        public static void launchCalc(String input){
            
            bool inputIsMatch = NumberChecker.checkeAndReturnMatch(input);

            if(inputIsMatch){
                
                // convert and extract matched 
                var match = Regex.Match(input, NumberChecker.PATTERN);

                // Split the input string into separate operations
                var operations = Regex.Split(input, NumberChecker.INPUT_SEPARATE_PATTER);

                // recuperer la valeur à gauche, l'operateur et droite
                double left = double.Parse(operations[0]);

                // ietration à travers les operations, debuter, à l'index 2
                for(int i =1; i < operations.Length; i++){

                    // extraire l'operatu
                }

                double right = double.Parse(match.Groups[4].Value);
                string operand = match.Groups[3].Value;

                double result = 0;

                switch(operand){
                    case "+":
                        result = addOp.Calc(left, right);
                        break;    
                    case "-":
                        result = subOp.Calc(left, right);
                        break;
                    case "*":
                        result = multiOp.Calc(left, right);
                        break;    
                    case "/":
                        result = divideOp.Calc(left, right);
                        break;
                    case "==":
                        result = compareOp.Calc(left, right);
                        break;    
                    case "V":
                        result = racineOp.Calc(left);
                        break;    
                    case "**":
                        result = expoOp.Calc(left);
                        break;
                    case "%":
                        result = moduloOp.Calc(left, right);
                        break;
                    default :
                        throw new InvalidOperationException("Operation Invalide");
                }

                Fun.affiche("Resultat = "+ result);

            }   
        }

        }
}
