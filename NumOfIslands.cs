// Time Complexity : O(m*n)
// Space Complexity : O(m*n)
// Did this code successfully run on Leetcode : Yes
// Any problem you faced while coding this : No


// Your code here along with comments explaining your approach


int m, n;
    int[][] dirs;
    public int NumIslands(char[][] grid) {
        if(grid == null || grid.Length == 0)
            return 0;
        
        int islandCount = 0;
        int m = grid.Length;
        int n = grid[0].Length;
        Queue<int[]> queue = new Queue<int[]>();
        dirs = new int[][]{new int []{0, 1}, new int[]{1,0}, new int[]{0, -1}, new int[] {-1, 0}};

        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                //if we found land
                if(grid[i][j] == '1')
                {
                    //add to queue and chage to water 0
                    queue.Enqueue(new int[] {i, j});
                    grid[i][j] = '0';
                    while(queue.Count > 0)
                    {
                        var curr = queue.Dequeue();
                        foreach(int[] dir in dirs)
                        {
                            int nr = dir[0] + curr[0];
                            int nc = dir[1] + curr[1];
                            
                            if(nr >= 0 && nc >= 0 && nr < m && nc < n && grid[nr][nc] == '1')
                            {
                                queue.Enqueue(new int[] {nr, nc});
                                grid[nr][nc] = '0';
                            }
                        }
                    }
                    
                    islandCount++;
                }
            }
        }
        
        return islandCount;
    }



    //DFS
    int m, n;
    int[][] dirs;
    public int NumIslandsDFS(char[][] grid)
    {
        if (grid == null || grid.Length == 0)
            return 0;

        int islandCount = 0;
        m = grid.Length;
        n = grid[0].Length;
        dirs = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                //if we found land
                if (grid[i][j] == '1')
                {                        
                    dfs(grid, i, j);
                    islandCount++;
                }
            }
        }

        return islandCount;
    }

    private void dfs(char[][] grid, int r, int c)
    {
        //base condition
        //out of boundary or we hit water or 0
        if (r < 0 || c < 0 || r == m || c == n || grid[r][c] == '0')
            return;

        //logic
        //change land to water
        grid[r][c] = '0';

        //call dfs for all adjacent node if it is land or 1
        foreach (int[] dir in dirs)
        {
            int nr = dir[0] + r;
            int nc = dir[1] + c;
            dfs(grid, nr, nc);
        }
    }