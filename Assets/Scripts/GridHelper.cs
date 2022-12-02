using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Es una clase de tipo "Helper", un script que nos sirve de apoyo pero no depende de MonoBehaviour
public class GridHelper : MonoBehaviour
{
    //Variables para conocer el ancho y alto de la rejilla
    public static int w = 15; //ancho de la malla       static significa que solo habr� por ejemplo en este caso un ancho y un alto de rejilla en todo el juego
    public static int h = 15; //alto de la malla
    //Un array donde guardar todas las celdas de nuestro juego
    public static Cell[,] cells = new Cell[w, h]; //al ser static tambi�n me permite acceder a esto desde otro script

    //M�todo para destapar todas las minas
    public static void UncoverAllTheMines()
    {
        //Bucle para recorrer el array de celdas y que vaya destapando las minas que haya en esta rejilla
        foreach (Cell c in cells)
        {
            //Si esa celda tiene una mina
            if (c.hasMine)
            {
                //Llamar al m�todo que carga la textura de la mina
                c.LoadTexture(0);
            }
        }
    }

    //M�todo para saber si hay una mina en una posici�n dada
    public static bool HasMineAt(int x, int y)//La posici�n de la celda
    {
        //Si estas condiciones se cumplen estaremos dentro de la rejilla
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            //Vemos que celda hemos seleccionado y guardamos su posici�n en una variable de tipo celda
            Cell cell = cells[x, y];
            //De esa celda nos devolver� su booleano, si es true habr� mina, si es false no
            return cell.hasMine;
        }
        //Si las condiciones de arriba no se cumplen estamos fuera de la rejilla
        else
        {
            //No hay posibilidad de que haya una mina
            return false;
        }
    }

    //M�todo para contar las minas adyacentes a una celda (minas alrededor de una celda dada)
    public static int CountAdjacentMines(int x, int y) //La posici�n de la celda
    {
        //Contador de minas
        int count = 0;

        //8 casos adyacentes en los que contar�amos una mina si la hubiese
        //Usaremos el m�todo para saber si hay una mina en una posici�n dada(celda dada)
        if (HasMineAt(x + 1, y)) count++; //medio-derecha
        if (HasMineAt(x - 1, y)) count++; //medio-izquierda
        if (HasMineAt(x, y + 1)) count++; //medio-arriba
        if (HasMineAt(x, y - 1)) count++; //medio-abajo
        if (HasMineAt(x + 1, y + 1)) count++; //arriba-derecha
        if (HasMineAt(x - 1, y + 1)) count++; //arriba-izquierda
        if (HasMineAt(x + 1, y - 1)) count++; //abajo-derecha
        if (HasMineAt(x - 1, y - 1)) count++; //abajo-izquierda

        //Una vez hechas las comprobaciones devolvemos el n�mero de minas
        return count;
    }
}
