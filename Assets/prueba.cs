using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class prueba : MonoBehaviour
{
    public InputField  palabraInput ;
    public TMP_Text cargado;
    public TMP_Text descifrado;

    string obtenerCodigoMorce(string letra){
        switch(letra){
            case "A":return  ".-";
            break;
            case "B":return "-...";
            break;
            case "C":return "-.-.";
            break;
            case "D":return "-..";
            break;
            case "E":return ".";
            break;
            case "F":return "..-.";
            break;
            case "G":return "--.";
            break;
            case "H":return "....";
            break;
            case "I":return "..";
            break;
            case "J":return ".---";
            break;
            case "K":return "-.-";
            break;
            case "L":return ".-..";
            break;
            case "M":return "--";
            break;
            case "N":return "-.";
            break;
            case "O":return "---";
            break;
            case "P":return ".--.";
            break;
            case "Q":return "--.-";
            break;
            case "R":return ".-.";
            break;
            case "S":return "...";
            break;
            case "T":return "-";
            break;
            case "U":return "..-";
            break;
            case "V":return "...-";
            break;
            case "W":return ".--";
            break;
            case "X":return "-..-";
            break;
            case "Y":return "-.--";
            break;
            case "Z":return "--..";
            break;
            case "_":return "..--";
            break;
            case ".":return "---.";
            break;
            case ",":return ".-.-";
            break;
            case "?":return "----";
            break;
        }
        return "";
    }
    string obtenerLetra(string codigo){
        switch(codigo){
            case ".-":return  "A";
            break;
            case "-...":return  "B";
            break;
            case "-.-.":return  "C";
            break;
            case "-..":return  "D";
            break;
            case ".":return  "E";
            break;
            case "..-.":return  "F";
            break;
            case "--.":return  "G";
            break;
            case "....":return  "H";
            break;
            case "..":return  "I";
            break;
            case ".---":return  "J";
            break;
            case "-.-":return  "K";
            break;
            case ".-..":return  "L";
            break;
            case "--":return  "M";
            break;
            case "-.":return  "N";
            break;
            case "---":return  "O";
            break;
            case ".--.":return  "P";
            break;
            case "--.-":return  "Q";
            break;
            case ".-.":return  "R";
            break;
            case "...":return  "S";
            break;
            case "-":return  "T";
            break;
            case "..-":return  "U";
            break;
            case "...-":return  "V";
            break;
            case ".--":return  "W";
            break;
            case "-..-":return  "X";
            break;
            case "-.--":return  "Y";
            break;
            case "--..":return  "Z";
            break;
            case "..--":return  "_";
            break;
            case "---.":return  ".";
            break;
            case ".-.-":return  ",";
            break;
            case "----":return  "?";
            break;
        }
        return "";
    }
    

    void Start()
    {
    }

    string procesamientoDePalabra(string palabra){
        var palabraAux = palabra.ToUpper();
        string textoMorse=null;
        string numerosMorse = null;
        string numerosMorseInvertido = null;
        string codigo = null;
        string codigoInvertido = null;
        foreach (char c in palabraAux){
            string aux = obtenerCodigoMorce(""+c);
            numerosMorse = numerosMorse+aux.Length ;
            textoMorse = textoMorse + aux;
        }
        numerosMorseInvertido = invertirNumeros(numerosMorse);
        codigoInvertido = partirCodigoMorce(textoMorse,numerosMorseInvertido);
        return codigoALetra(codigoInvertido);
    }
    string  invertirNumeros(string tmp_s ){
        char[] charArray = tmp_s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    string partirCodigoMorce(string codigoMorce, string numerosInvertidos){
        char[] numeroCharArray = numerosInvertidos.ToCharArray();
        string codigoMorseAux = null;
        int index = 0;
        int indexNumeroCharArray = 0;
        foreach (char c in codigoMorce){
            index+=1;

            if(index==((int)numeroCharArray[indexNumeroCharArray]-48)){
                codigoMorseAux = codigoMorseAux + c+" ";
                if(indexNumeroCharArray<numeroCharArray.Length-1){
                    indexNumeroCharArray+=1;
                }
                index=0;

            }else{
                codigoMorseAux = codigoMorseAux + c;
            }
        }
        return codigoMorseAux;

    }
    string codigoALetra(string codigo){
        string textoCifrado = null;
        foreach (string c in codigo.Split(" ")){
            textoCifrado = textoCifrado + obtenerLetra(c);
        }
        return textoCifrado;
        
    }   
    void crearArchivo(string textoCifrado){
        string savePath = string.Format("{0}/{1}.txt", Application.persistentDataPath, "textoCifradoJonathanAvilesG");    
        print(savePath);
        System.IO.File.WriteAllText(savePath, textoCifrado);
    }
    public void iniciarCifrar(){
        string texto = procesamientoDePalabra(palabraInput.text);
        crearArchivo(texto);


    }
    public  void cargarArchivo(){
        string savePath = string.Format("{0}/{1}.txt", Application.persistentDataPath, "textoCifradoJonathanAvilesG");  
        StreamReader reader = new StreamReader(savePath); 
        var text =  reader.ReadToEnd();
        string texto = procesamientoDePalabra(text);
        reader.Close();
        descifrado.text = texto;
        cargado.text = text;
    }
   
}
