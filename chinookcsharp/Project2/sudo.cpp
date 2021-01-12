#include <stdio.h>
#include <iostream>
#include <utility>
#include <vector>
#include <algorithm>

#define MAX 9

using namespace std;

int arr[MAX + 1][MAX + 1];
int posSize;
vector<pair<int, int> > pos;


void sudoku(int idx) {
    bool map[11] = { 0 };
    if (idx == posSize) {
        for (int i = 0; i < MAX; i++) {
            for (int j = 0; j < MAX; j++) cout << arr[i][j] << " ";
            cout << "\n";
        }
        exit(0);
    }
    int y = pos[idx].first;
    int x = pos[idx].second;
    for (int i = 0; i < MAX; i++) map[arr[y][i]] = true;
    for (int i = 0; i < MAX; i++) map[arr[i][x]] = true;
    for (int i = (y / 3) * 3; i < (y / 3) * 3 + 3; i++)
        for (int j = (x / 3) * 3; j < (x / 3) * 3 + 3; j++)
            map[arr[i][j]] = true;

    for (int i = 1; i < 10; i++) {
        if (!map[i]) {
            arr[y][x] = i;
            sudoku(idx + 1);
            arr[y][x] = 0;
        }
    }
}

int main(int argc, const char* argv[]) {
    for (int i = 0; i < MAX; i++) {
        for (int j = 0; j < MAX; j++) {
            cin >> arr[i][j];
            if (arr[i][j] == 0) pos.push_back(make_pair(i, j));
        }
    }
    posSize = (int)pos.size();
    sudoku(0);
    return 0;
}