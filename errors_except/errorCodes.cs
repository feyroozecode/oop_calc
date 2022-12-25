
/*
 Code utilisé pour les different erreurs 
*/


namespace Error{
    enum ErrorCode : ushort {
    invalidOperation = 0, // Ne pas un nombre
    ErrorInResult = 1,
    UnknownOperation = 100, // inconnue
     notInRange = 200,  // ne pas dans la liste 
    emptyOperation = 300, // pas d'operande entrer
}
}