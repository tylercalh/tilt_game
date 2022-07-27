// This script instantiates a random maze within the game map.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{

    public GameObject WallBlock;
    public GameObject wincon;
    public GameObject Parent;
    
    void Start() {
        MazeGenerator mg = new MazeGenerator();
        int[,] walls = mg.getGrid();

        for(int i = 0; i < 11; i ++) {
            for(int j = 0; j < 11; j++) {
                if(walls[i,j] == 1) Instantiate(WallBlock, new Vector3(i -5f, 1f, j - 5f), Quaternion.identity, Parent.transform);
            }
        }
        Instantiate(wincon, new Vector3(9f - 5f, 0.52f, 9f - 5f), Quaternion.identity, Parent.transform);
    }
}

// MazeGenerator creates a 2D array of integers representing where walls should be placed.
public class MazeGenerator {
    private int[,] grid;
    private int size;
    private int startx;
    private int starty;

    private enum Direction {
        N, S, E, W
    }

    public MazeGenerator() {
        this.size = 11;
        this.startx = 1;
        this.starty = 1;


        this.grid = initializeGrid();

        walk(startx, starty, 0);
    }

    private void walk(int cx, int cy, int count) {
        List<Direction> directions = new List<Direction>();
        directions.Add(Direction.N);
        directions.Add(Direction.S);
        directions.Add(Direction.E);
        directions.Add(Direction.W);
        directions = shuffle(directions);



        int nx, ny, start, end;
        foreach (Direction direction in directions) {
            int value = getValue(direction);
            ny = (direction == Direction.N || direction == Direction.S) ? cy + value : cy;
            nx = (direction == Direction.N || direction == Direction.S) ? cx : cx + value;

            if(direction == Direction.N || direction == Direction.S) {
                start = (cy < ny) ? cy : ny;
                end = (ny > cy) ? ny : cy;
            } else {
                start = (cx < nx) ? cx : nx;
                end = (nx > cx) ? nx : cx;
            }

            bool withinBounds = (nx > 0 && nx < size - 1) && (ny > 0 && ny < size - 1);
            if(withinBounds && grid[ny,nx] == 2) {
                if(direction == Direction.N || direction == Direction.S)
                    for(int i = start; i <= end; i++) grid[i,cx] = 0;
                else 
                    for(int i = start; i <= end; i++) grid[cy,i] = 0;
                
                walk(nx, ny, count);
            }

            
        }
    }

    public int[,] getGrid() {
        return this.grid;
    }

    private List<Direction> shuffle(List<Direction> list) {
        System.Random random = new System.Random();
        int n = list.Count;
        while(n > 1) {
            n--;
            int x = random.Next(n + 1);
            Direction value = list[x];
            list[x] = list[n];
            list[n] = value;
        }
        return list;
    }

    private int[,] initializeGrid() {
        int[,] temp = new int[size,size];
        for(int i = 0; i < size; i++) {
            for(int j = 0; j < size; j++) {
                temp[i,j] = (i % 2 == 0 || j % 2 == 0) ? 1 : 2;
            }
        }
        return temp;
    }

    private int getValue(Direction direction) {
        int value = (direction == Direction.N || direction == Direction.E) ? 2 : -2;
        return value;
    }
}