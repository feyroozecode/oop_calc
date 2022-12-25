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

        // Regex
        private static readonly string pattern = @"^(\d+(\.\d+)?)\s*([\+\-\*\/])\s*(\d+(\.\d+)?)$";
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


            if(!Regex.IsMatch(input, pattern)){

            }    
                
            
        }
}
