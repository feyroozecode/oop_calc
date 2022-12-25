
namespace UtilFactory{

    /*  
       Class generic, utilisé pour créer une instance
       de la class correspondant à l'operation voulue
       e.g: OperInterface op = Factory.CreateInterface<AddOper>();
       et enfin on test avec { Console.WriteLine(op.Calc(7,6)) } // = 13
    */
    class Factory{
        public static T CreateInstace<T>() where T : new(){
            return new T();
        }
    } 
}