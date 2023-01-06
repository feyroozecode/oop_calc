
using Interface.OperInterface;
using Interface.AdvancedOp;
using Error;

namespace Operation {

    // tous les operation hérite de la class operation interface
    class AddOper : OperInterface {
        public AddOper() { }

        public double Calc(double n1, double n2){

            return n1 + n2;
        }
    }

    // Soustraction 
    class SubOper : OperInterface {
        public SubOper(){ }

        public double Calc(double num1, double num2){
            return num1 - num2;
        }
    }

    class Multiple: OperInterface {
        public Multiple(){ }

        public double Calc(double num1, double num2){

            return num1*num2;
        }
    }

    // diviser
     class DivideOper: OperInterface {
        public DivideOper(){ }

        public double Calc(double num1, double num2){
            
            try
            {
                double result = num1 / num2;    
            
                return result;
            }
            catch (DivideByZeroException)
            {   
                
                Console.WriteLine("Division par 0 impossible");
            }

            return (double)Error.ErrorCode.ErrorInResult;
        }

    }

     // return a rest of division
     class ModuloOp : OperInterface {
        public ModuloOp(){}

        public double Calc(double number1, double number2){

            double result = 0;
            try
            {
                result = number1 % number2;
                
                if(Double.IsNaN(number1) && Double.IsNaN(number2))
                    throw new Exception("Impossible de calculer le modulo de la valeur vue que ce n'est pas un nombre ");
            
                return result;
            }
            catch(Exception e)
            {   
                fun.Fun.affiche(e.ToString());
            }
            
            return (double)ErrorCode.ErrorInResult; // ERREUR 
        }
    }

      class CompareOp : OperInterface {
        public CompareOp(){}

        public double Calc(double number1, double number2){

            double result = 0;
            try
            {
                if(number1.Equals(number2)){
                    result = 0;
                    fun.Fun.affiche("Les 2 Nombres sont égaux ");
                } 
                if(number1 > number2)
                    result = 1;
                    fun.Fun.affiche("1er Nombre "+ number1 + " est plus grand que "+ number2);
                
                if(number2 > number1)
                    result = 3;
                    fun.Fun.affiche("2er Nombre "+ number2 + " est plus grand que "+ number1);


                if(Double.IsNaN(number1) && Double.IsNaN(number2))
                    throw new Exception("Impossible de calculer le modulo de la valeur vue que ce n'est pas un nombre ");
            
                return result;
            }
            catch(Exception e)
            {   
                fun.Fun.affiche(e.ToString());
            }
            
            return (double)ErrorCode.ErrorInResult; // ERREUR 
        }
    }



    /*******   ADVANCE  ************/

    // Racine carré
    class RacineOp : AdvancedOpInterface {
        public RacineOp(){}

        public double Calc(double number){

            double result = 0;
            try
            {
                result = Math.Sqrt(number);
                
                if(Double.IsNaN(number))
                    throw new Exception("Impossible de calculer la racine carré de la valeur " + number + " vue que ce n'est pas un nombre ");
            
                return result;
            }
            catch(Exception e)
            {   
                fun.Fun.affiche(e.ToString());
            }

            return (double) ErrorCode.ErrorInResult;
        }
    }

    // exponential
    class ExpoOp : AdvancedOpInterface {
        public ExpoOp(){}

        public double Calc(double number){

            double result = 0;
            try
            {
                result = Math.Exp(number);
                
                if(Double.IsNaN(number))
                    throw new Exception("Impossible de calculer l'exponantiel de la valeur "  + number + " vue que ce n'est pas un nombre ");
            
                return result;
            }
            catch(Exception e)
            {   
                fun.Fun.affiche(e.ToString());
            }
            
            return (double)ErrorCode.ErrorInResult; // ERREUR 
        }
    }


}