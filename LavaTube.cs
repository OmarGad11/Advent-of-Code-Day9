using System.Data;

namespace LavaTube
{
    public class Program
    {
        static void Main(string[] args)
        {
            string file_path = "puzzle input.txt";
            List<List<int>> height_map = ReadHeighMap(file_path);
            PuzzleSolution solution = new PuzzleSolution(height_map);
            int risk_level_sum = solution.GetRiskLevelSum();
            int basin_product = solution.BasinsProduct(3);
            Console.WriteLine("Risk level sum: " + risk_level_sum);
            Console.WriteLine("Largest basins product: " + basin_product);
        }
        static List<List<int>> ReadHeighMap(string file_path)
        {
            List<List<int>> processed_lines = new List<List<int>>();

            using (StreamReader reader = new StreamReader(file_path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    List<int> row = line.Trim().Select(c => int.Parse(c.ToString())).ToList();
                    processed_lines.Add(row);
                }
            }
            return processed_lines;
        }
    }

    public class PuzzleSolution
    {
        private readonly List<List<int>> _height_map;
        private readonly int _rows;
        private readonly int _cols;
        private readonly List<(int,int)> _low_points;
        private readonly Dictionary<(int, int), int> _basins; 

        public PuzzleSolution(List<List<int>> height_map){
            _height_map = height_map;
            _rows = _height_map.Count;
            _cols = _height_map[0].Count;
            _low_points = FindLowPoints();
            _basins = FindBasins();
        }

    	private Dictionary<(int, int), int> FindBasins(){
            Dictionary<(int, int), int> basins = new Dictionary<(int, int), int>();
            int[,] neighbor_offests = { { 0, -1 }, { 0, 1 }, { -1, 0 }, { 1, 0 } };
            
            foreach (var (x,y) in _low_points){
                HashSet<(int, int)> visited = new HashSet<(int, int)>();
                Queue<(int, int)> queue = new Queue<(int, int)>();
                int size = 0;
                queue.Enqueue((x,y));
                
                while (queue.Count > 0){
                    var (current_row,current_col) = queue.Dequeue();
                    if (visited.Contains((current_row,current_col))){
                        continue;
                    }
                    visited.Add((current_row,current_col));
                    size++;

                    for (int i = 0; i < neighbor_offests.GetLength(0); i++)
                    {
                        int new_row = current_row + neighbor_offests[i, 0];
                        int new_col = current_col + neighbor_offests[i, 1];

                        if ( IsValid(new_row,new_col) && _height_map[new_row][new_col] != 9 && _height_map[new_row][new_col] >= _height_map[current_row][current_col] ){
                            queue.Enqueue((new_row, new_col));
                        }
                    
                    }
                }
                // {Basin low point: Basin size}
                basins.Add((x, y), size);
            } 
            return basins;
        }

        public int BasinsProduct(int number_of_basins){
            var largest_basins = _basins.Values.OrderByDescending(value => value).Take(number_of_basins);
            int product = 1;

            foreach (var basin_size in largest_basins)
            {
                product *= basin_size;
            }
            return product;
        }

        private List<(int,int)> FindLowPoints(){
            List<(int,int)> low_points = new  List<(int,int)>();
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    List<int> neighbors = GetNeighbors(row,col);
                    int current_value = _height_map[row][col];
                    if (current_value < neighbors.Min()){
                        low_points.Add((row,col));
                    }
                }
            }
            return low_points;
        }

        public int GetRiskLevelSum(){
            int sum = 0;
            foreach (var (x,y) in _low_points){
                int value = _height_map[x][y];
                sum = sum + value + 1;
            }
            return sum; 
        }
        public List<int> GetNeighbors(int row, int col)
        {
            int[,] direction_offsets = { { 0, -1 }, { 0, 1 }, { -1, 0 }, { 1, 0 } };
            List<int> neighbors = new List<int>();
            for (int i = 0; i < direction_offsets.GetLength(0); i++)
            {
                int neighbor_row = row + direction_offsets[i, 0];
                int neighbor_col = col + direction_offsets[i, 1];

                if (IsValid(neighbor_row,neighbor_col))
                {
                    int neighbor_value = _height_map[neighbor_row][neighbor_col];
                    neighbors.Add(neighbor_value);
                }
            }
            return neighbors;
        }

        public bool IsValid(int row, int col)
        {
            return row >= 0 && row < _rows && col >= 0 && col < _cols;
        }
    }
}

